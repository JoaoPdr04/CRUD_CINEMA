using System.ComponentModel;
using CinemaApp.Base;
using CinemaApp.Models;
using CinemaDomain;
using CinemaService.Base;
using CinemaService.Validators;

namespace CinemaApp.Cadastros
{
    public partial class CadastroIngresso : CadastroBase
    {
        private readonly IBaseService<Ingresso> _ingressoService;
        private readonly IBaseService<IngressoItem> _ingressoItemService;
        private readonly IBaseService<Filme> _filmeService;
        private readonly IBaseService<Sessao> _sessaoService;
        private readonly IBaseService<Sala> _salaService;
        private List<FilmeViewModel> _filmes = new();
        private List<SessaoViewModel> _sessoes = new();
        private BindingList<IngressoItem> _itens = new();
        private HashSet<int> _idsItensOriginais = new();
        private int _id;
        private int? _sessaoIdEdicao;

        public CadastroIngresso(
            IBaseService<Ingresso> ingressoService,
            IBaseService<IngressoItem> ingressoItemService,
            IBaseService<Filme> filmeService,
            IBaseService<Sessao> sessaoService,
            IBaseService<Sala> salaService)
        {
            _ingressoService = ingressoService;
            _ingressoItemService = ingressoItemService;
            _filmeService = filmeService;
            _sessaoService = sessaoService;
            _salaService = salaService;
            InitializeComponent();

            this.MinimumSize = Size.Empty;
            this.MaximumSize = Size.Empty;
            this.ClientSize = new Size(660, 620);

            tabControlCadastro.Location = new Point(3, 64);
            tabControlCadastro.Size = new Size(654, 550);
            tabPageCadastro.Size = new Size(646, 522);

            txtDocumento.Location = new Point(18, 12);
            txtDocumento.Size = new Size(358, 48);
            txtDataCompra.Location = new Point(391, 12);
            dataGridViewIngressos.Location = new Point(18, 312);
            dataGridViewIngressos.Size = new Size(610, 105);
            btnSalvar.Location = new Point(552, 425);
            btnCancelar.Location = new Point(448, 425);

            ConfiguraGrid();
            VinculaGrid();

            cboFilme.SelectedIndexChanged += cboFilme_SelectedIndexChanged;
            cboSessao.SelectedIndexChanged += cboSessao_SelectedIndexChanged;
            btnAdicionar.Click += btnAdicionar_Click;
            btnRemover.Click += btnRemover_Click;
            dataGridViewIngressos.CurrentCellDirtyStateChanged += dataGridViewIngressos_CurrentCellDirtyStateChanged;
            dataGridViewIngressos.CellValueChanged += dataGridViewIngressos_CellValueChanged;
            dataGridViewIngressos.CellFormatting += dataGridViewIngressos_CellFormatting;
            dataGridViewIngressos.DataError += dataGridViewIngressos_DataError;

            CarregaFilmes();
        }

        private void ConfiguraGrid()
        {
            dataGridViewIngressos.AutoGenerateColumns = false;
            dataGridViewIngressos.AllowUserToAddRows = false;
            dataGridViewIngressos.AllowUserToDeleteRows = false;
            dataGridViewIngressos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewIngressos.MultiSelect = false;
            dataGridViewIngressos.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewIngressos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewIngressos.Columns.Clear();

            dataGridViewIngressos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(IngressoItem.Fileira),
                HeaderText = "Fileira",
                Name = nameof(IngressoItem.Fileira),
                ReadOnly = true
            });
            dataGridViewIngressos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(IngressoItem.Assento),
                HeaderText = "Assento",
                Name = nameof(IngressoItem.Assento),
                ReadOnly = true
            });
            dataGridViewIngressos.Columns.Add(new DataGridViewCheckBoxColumn
            {
                DataPropertyName = nameof(IngressoItem.MeiaEntrada),
                HeaderText = "Meia-entrada",
                Name = nameof(IngressoItem.MeiaEntrada)
            });
            dataGridViewIngressos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Valor",
                Name = "Valor",
                ReadOnly = true,
                ValueType = typeof(string),
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });
        }

        private void VinculaGrid()
        {
            dataGridViewIngressos.DataSource = _itens;
            txtQuantidade.Text = _itens.Count.ToString();
            AtualizaValorTotal();
        }

        private void CarregaFilmes()
        {
            _filmes = _filmeService.ReadAll<FilmeViewModel>().ToList();
            cboFilme.DataSource = null;
            cboFilme.DisplayMember = nameof(FilmeViewModel.Nome);
            cboFilme.ValueMember = nameof(FilmeViewModel.Id);
            cboFilme.DataSource = _filmes;
            cboFilme.SelectedIndex = -1;
        }

        private void cboFilme_SelectedIndexChanged(object? sender, EventArgs e)
        {
            LimpaDadosSessao();

            if (cboFilme.SelectedItem is not FilmeViewModel filme)
            {
                CarregaSessoes(Array.Empty<SessaoViewModel>());
                return;
            }

            txtClassificacao.Text = filme.Classificacao;

            CarregaSessoes(_sessaoService.ReadAll<SessaoViewModel>()
                .Where(sessao => sessao.FilmeId == filme.Id &&
                                 (sessao.Data > DateTime.Now || (IsEditMode && sessao.Id == _sessaoIdEdicao)))
                .OrderBy(sessao => sessao.Data));
        }

        private void CarregaSessoes(IEnumerable<SessaoViewModel> sessoes)
        {
            _sessoes = sessoes.ToList();
            cboSessao.DataSource = null;
            cboSessao.DisplayMember = nameof(SessaoViewModel.Descricao);
            cboSessao.ValueMember = nameof(SessaoViewModel.Id);
            cboSessao.DataSource = _sessoes;
            cboSessao.SelectedIndex = -1;

            cboSessao.Hint = cboFilme.SelectedItem != null && _sessoes.Count == 0
                ? "Sessão (este filme não tem sessões futuras)"
                : "Sessão";
        }

        private void LimpaDadosSessao()
        {
            cboSessao.DataSource = null;
            txtClassificacao.Clear();
            txtDataFilme.Clear();
        }

        private void cboSessao_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cboSessao.SelectedItem is not SessaoViewModel sessao)
            {
                txtClassificacao.Clear();
                txtDataFilme.Clear();
                AtualizaValorTotal();
                return;
            }

            txtDataFilme.Text = sessao.Data.ToString("dd/MM/yyyy HH:mm");
            txtClassificacao.Text = sessao.Classificacao;
            AtualizaValorTotal();
            dataGridViewIngressos.Refresh();
        }

        private List<IngressoItem> BuscarItensDoIngresso(int ingressoId)
        {
            // Carrega ingressos e itens no mesmo escopo para o EF Core vincular a navegação Ingresso
            var ingressos = _ingressoService.ReadAll<Ingresso>().ToList();
            var todosItens = _ingressoItemService.ReadAll<IngressoItem>().ToList();

            var ingressoAlvo = ingressos.FirstOrDefault(i => i.Id == ingressoId);
            if (ingressoAlvo?.IngressoItens != null && ingressoAlvo.IngressoItens.Count > 0)
                return ingressoAlvo.IngressoItens.ToList();

            return todosItens
                .Where(item => item.Ingresso != null && item.Ingresso.Id == ingressoId)
                .ToList();
        }

        private void btnAdicionar_Click(object? sender, EventArgs e)
        {
            if (cboSessao.SelectedIndex < 0 || cboSessao.SelectedItem is not SessaoViewModel sessao)
            {
                MessageBox.Show("Selecione uma sessão antes de adicionar um ingresso.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var sala = _salaService.ReadById<Sala>(sessao.SalaId);
                if (sala is null || sala.Fileiras <= 0 || sala.Assentos <= 0)
                {
                    MessageBox.Show("A sala da sessão não possui fileiras ou assentos configurados.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Reúne apenas os assentos ainda presentes na tela + assentos de OUTROS ingressos no banco
                var assentosOcupados = new List<IngressoItem>(_itens);
                var todosIngressos = _ingressoService.ReadAll<Ingresso>().ToList();
                var todosItensBanco = _ingressoItemService.ReadAll<IngressoItem>().ToList();

                foreach (var ing in todosIngressos)
                {
                    if (IsEditMode && ing.Id == _id)
                        continue;

                    if (ing.Sessao?.Id == sessao.Id)
                    {
                        var itensDoIngresso = (ing.IngressoItens != null && ing.IngressoItens.Count > 0)
                            ? ing.IngressoItens
                            : todosItensBanco.Where(it => it.Ingresso != null && it.Ingresso.Id == ing.Id).ToList();

                        assentosOcupados.AddRange(itensDoIngresso);
                    }
                }

                using var formularioAssentos = new SelecaoAssentos(sala, assentosOcupados);
                if (formularioAssentos.ShowDialog(this) != DialogResult.OK)
                    return;

                foreach (var novoItem in formularioAssentos.ItensSelecionados)
                {
                    _itens.Add(novoItem);
                }

                txtQuantidade.Text = _itens.Count.ToString();
                AtualizaValorTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message, "Erro ao carregar a sala",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemover_Click(object? sender, EventArgs e)
        {
            if (dataGridViewIngressos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um ingresso para remover.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int rowIndex = dataGridViewIngressos.SelectedRows[0].Index;
            if (rowIndex < 0 || rowIndex >= _itens.Count)
                return;

            dataGridViewIngressos.EndEdit();
            dataGridViewIngressos.ClearSelection();
            _itens.RemoveAt(rowIndex);

            txtQuantidade.Text = _itens.Count.ToString();
            AtualizaValorTotal();
        }

        private void dataGridViewIngressos_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
        {
            if (dataGridViewIngressos.IsCurrentCellDirty)
            {
                dataGridViewIngressos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridViewIngressos_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _itens.Count)
                return;

            AtualizaValorTotal();

            if (dataGridViewIngressos.Columns["Valor"] != null)
            {
                dataGridViewIngressos.InvalidateCell(dataGridViewIngressos.Columns["Valor"].Index, e.RowIndex);
            }
        }

        private void dataGridViewIngressos_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _itens.Count ||
                e.ColumnIndex < 0 || e.ColumnIndex >= dataGridViewIngressos.Columns.Count)
                return;

            if (dataGridViewIngressos.Columns[e.ColumnIndex].Name != "Valor")
                return;

            var item = _itens[e.RowIndex];
            var valor = item.MeiaEntrada ? PrecoSessao / 2 : PrecoSessao;
            e.Value = valor.ToString("C2");
            e.FormattingApplied = true;
        }

        private void dataGridViewIngressos_DataError(object? sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private decimal PrecoSessao => cboSessao.SelectedItem is SessaoViewModel sessao ? sessao.Preco : 0;

        private void AtualizaValorTotal()
        {
            txtValorTotal.Text = _itens.Sum(item => item.MeiaEntrada ? PrecoSessao / 2 : PrecoSessao)
                .ToString("N2");
        }

        private void PreencheObjeto(Ingresso ingresso)
        {
            if (cboSessao.SelectedValue is null || cboSessao.SelectedIndex < 0)
                throw new InvalidOperationException("Sessão deve ser informada!");

            dataGridViewIngressos.EndEdit();
            ingresso.Documento = txtDocumento.Text.Trim();

            if (!IsEditMode)
                ingresso.DataCompra = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);

            ingresso.FormaPagamento = cboFormaPagamento.Text;
            ingresso.Sessao = _sessaoService.ReadById<Sessao>(Convert.ToInt32(cboSessao.SelectedValue));
            ingresso.IngressoItens = _itens.ToList();
            ingresso.ValorTotal = _itens.Sum(item => item.MeiaEntrada ? ingresso.Sessao.Preco / 2 : ingresso.Sessao.Preco);
        }

        private void PreencheTela(Ingresso ingresso)
        {
            txtDocumento.Text = ingresso.Documento;
            txtDataCompra.Text = ingresso.DataCompra.ToString("dd/MM/yyyy HH:mm");
            cboFormaPagamento.SelectedIndex = cboFormaPagamento.FindStringExact(ingresso.FormaPagamento ?? string.Empty);

            var itensCarregados = BuscarItensDoIngresso(ingresso.Id);
            _idsItensOriginais = itensCarregados.Where(i => i.Id > 0).Select(i => i.Id).ToHashSet();
            _itens = new BindingList<IngressoItem>(itensCarregados);
            VinculaGrid();

            if (ingresso.Sessao != null)
            {
                _sessaoIdEdicao = ingresso.Sessao.Id;

                var sessaoVm = _sessaoService.ReadAll<SessaoViewModel>()
                    .FirstOrDefault(s => s.Id == ingresso.Sessao.Id);

                int filmeId = sessaoVm?.FilmeId ?? ingresso.Sessao.Filme?.Id ?? 0;

                if (filmeId > 0)
                    cboFilme.SelectedValue = filmeId;

                cboSessao.SelectedValue = ingresso.Sessao.Id;

                if (cboSessao.SelectedItem is SessaoViewModel sessaoSelecionada)
                {
                    txtDataFilme.Text = sessaoSelecionada.Data.ToString("dd/MM/yyyy HH:mm");
                    txtClassificacao.Text = sessaoSelecionada.Classificacao;
                }
            }

            AtualizaValorTotal();
            dataGridViewIngressos.Refresh();
        }

        protected override void Novo()
        {
            base.Novo();
            _id = 0;
            _sessaoIdEdicao = null;
            _idsItensOriginais.Clear();
            _itens = new BindingList<IngressoItem>();
            VinculaGrid();

            txtDataCompra.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            cboSessao.SelectedIndex = -1;
            cboFilme.SelectedIndex = -1;
            cboFormaPagamento.SelectedIndex = -1;
            AtualizaValorTotal();
        }

        protected override void Salvar()
        {
            try
            {
                dataGridViewIngressos.EndEdit();

                if (IsEditMode)
                {
                    // Exclui definitivamente no PostgreSQL os assentos que foram removidos na tela
                    var idsAtuais = _itens.Where(i => i.Id > 0).Select(i => i.Id).ToHashSet();
                    foreach (var idRemovido in _idsItensOriginais.Where(id => !idsAtuais.Contains(id)))
                    {
                        _ingressoItemService.Delete(idRemovido);
                    }

                    var ingresso = _ingressoService.ReadById<Ingresso>(_id);
                    PreencheObjeto(ingresso);
                    _ingressoService.Update<Ingresso, Ingresso, IngressoValidator>(ingresso);
                }
                else
                {
                    var ingresso = new Ingresso();
                    PreencheObjeto(ingresso);
                    _ingressoService.Create<Ingresso, Ingresso, IngressoValidator>(ingresso);
                }

                IsEditMode = false;
                _sessaoIdEdicao = null;
                _idsItensOriginais.Clear();
                CarregaGrid();
                tabControlCadastro.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void Deletar(int id)
        {
            try
            {
                _ingressoService.Delete(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void CarregaGrid()
        {
            dataGridViewConsulta.DataSource = _ingressoService.ReadAll<IngressoViewModel>().ToList();
        }

        protected override void CarregarRegistro(DataGridViewRow row)
        {
            var id = Convert.ToInt32(row.Cells[nameof(IngressoViewModel.Id)].Value);
            var ingresso = _ingressoService.ReadById<Ingresso>(id);
            _id = ingresso.Id;
            IsEditMode = true;
            PreencheTela(ingresso);
        }
    }
}