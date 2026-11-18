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
        private readonly IBaseService<Filme> _filmeService;
        private readonly IBaseService<Sessao> _sessaoService;
        private readonly IBaseService<Sala> _salaService;
        private List<FilmeViewModel> _filmes = new();
        private List<SessaoViewModel> _sessoes = new();
        private List<IngressoItem> _itens = new();

        public CadastroIngresso(
            IBaseService<Ingresso> ingressoService,
            IBaseService<Filme> filmeService,
            IBaseService<Sessao> sessaoService,
            IBaseService<Sala> salaService)
        {
            _ingressoService = ingressoService;
            _filmeService = filmeService;
            _sessaoService = sessaoService;
            _salaService = salaService;
            InitializeComponent();

            ConfiguraGrid();
            cboFilme.SelectedIndexChanged += cboFilme_SelectedIndexChanged;
            cboSessao.SelectedIndexChanged += cboSessao_SelectedIndexChanged;
            cboSessao.Format += cboSessao_Format;
            btnAdicionar.Click += btnAdicionar_Click;
            btnRemover.Click += btnRemover_Click;
            dataGridViewIngressos.CellValueChanged += dataGridViewIngressos_CellValueChanged;
            dataGridViewIngressos.CellFormatting += dataGridViewIngressos_CellFormatting;
            dataGridViewIngressos.DataError += dataGridViewIngressos_DataError;
            dataGridViewIngressos.RowsRemoved += dataGridViewIngressos_RowsRemoved;
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
                Name = nameof(IngressoItem.Fileira)
            });
            dataGridViewIngressos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(IngressoItem.Assento),
                HeaderText = "Assento",
                Name = nameof(IngressoItem.Assento)
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

        private void CarregaFilmes()
        {
            _filmes = _filmeService.ReadAll<FilmeViewModel>().ToList();
            cboFilme.DisplayMember = nameof(FilmeViewModel.Nome);
            cboFilme.ValueMember = nameof(FilmeViewModel.Id);
            cboFilme.DataSource = null;
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
                .Where(sessao => sessao.FilmeId == filme.Id && sessao.Data > DateTime.Now)
                .OrderBy(sessao => sessao.Data));
        }

        private void CarregaSessoes(IEnumerable<SessaoViewModel> sessoes)
        {
            _sessoes = sessoes.ToList();
            cboSessao.DisplayMember = nameof(SessaoViewModel.Id);
            cboSessao.ValueMember = nameof(SessaoViewModel.Id);
            cboSessao.DataSource = null;
            cboSessao.DataSource = _sessoes;
            cboSessao.SelectedIndex = -1;
        }

        private void LimpaDadosSessao()
        {
            cboSessao.DataSource = null;
            txtClassificacao.Clear();
            txtDataFilme.Clear();
        }

        private void cboSessao_Format(object? sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is SessaoViewModel sessao)
                e.Value = $"#{sessao.Id} - {sessao.Data:dd/MM/yyyy HH:mm} - R$ {sessao.Preco:N2}";
        }

        private void cboSessao_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cboSessao.SelectedItem is not SessaoViewModel sessao)
            {
                txtClassificacao.Clear();
                txtDataFilme.Clear();
                return;
            }

            txtDataFilme.Text = sessao.Data.ToString("dd/MM/yyyy HH:mm");
            txtClassificacao.Text = sessao.Classificacao;
            AtualizaValorTotal();
        }

        private void btnAdicionar_Click(object? sender, EventArgs e)
        {
            if (cboSessao.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione uma sessão antes de adicionar um ingresso.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cboSessao.SelectedItem is not SessaoViewModel sessao)
                return;

            try
            {
                var sala = _salaService.ReadById<Sala>(sessao.SalaId);
                if (sala is null || sala.Fileiras <= 0 || sala.Assentos <= 0)
                {
                    MessageBox.Show("A sala da sessão não possui fileiras ou assentos configurados.", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using var formularioAssentos = new SelecaoAssentosForm(sala, _itens);
                if (formularioAssentos.ShowDialog(this) != DialogResult.OK)
                    return;

                _itens.AddRange(formularioAssentos.ItensSelecionados);
                AtualizaGrid();
                AtualizaValorTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao carregar a sala", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            var item = dataGridViewIngressos.SelectedRows[0].DataBoundItem as IngressoItem;
            if (item is not null)
                _itens.Remove(item);

            AtualizaGrid();
            AtualizaValorTotal();
        }

        private void dataGridViewIngressos_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                AtualizaValorTotal();
        }

        private void dataGridViewIngressos_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || dataGridViewIngressos.Columns[e.ColumnIndex].Name != "Valor")
                return;

            if (dataGridViewIngressos.Rows[e.RowIndex].DataBoundItem is IngressoItem item)
            {
                var valor = item.MeiaEntrada ? PrecoSessao / 2 : PrecoSessao;
                e.Value = valor.ToString("C2");
                e.FormattingApplied = true;
            }
        }

        private void dataGridViewIngressos_DataError(object? sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void dataGridViewIngressos_RowsRemoved(object? sender, DataGridViewRowsRemovedEventArgs e)
        {
            AtualizaValorTotal();
        }

        private void AtualizaGrid()
        {
            dataGridViewIngressos.DataSource = null;
            dataGridViewIngressos.DataSource = _itens;
            txtQuantidade.Text = _itens.Count.ToString();
        }

        private decimal PrecoSessao
        {
            get
            {
                return cboSessao.SelectedItem is SessaoViewModel sessao ? sessao.Preco : 0;
            }
        }

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
            ingresso.DataCompra = DateTime.Now;
            ingresso.FormaPagamento = cboFormaPagamento.Text;
            ingresso.Sessao = _sessaoService.ReadById<Sessao>(Convert.ToInt32(cboSessao.SelectedValue));
            ingresso.IngressoItens = _itens;
            ingresso.ValorTotal = _itens.Sum(item => item.MeiaEntrada ? ingresso.Sessao.Preco / 2 : ingresso.Sessao.Preco);
        }

        private void PreencheTela(Ingresso ingresso)
        {
            txtDocumento.Text = ingresso.Documento;
            txtDataCompra.Text = ingresso.DataCompra.ToString("dd/MM/yyyy HH:mm");
            cboFormaPagamento.SelectedItem = ingresso.FormaPagamento;
            cboSessao.SelectedValue = ingresso.Sessao?.Id;
            _itens = ingresso.IngressoItens ?? new List<IngressoItem>();
            AtualizaGrid();
            AtualizaValorTotal();
        }

        protected override void Novo()
        {
            base.Novo();
            _itens = new List<IngressoItem>();
            AtualizaGrid();
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
                if (IsEditMode)
                {
                    var ingresso = _ingressoService.ReadById<Ingresso>(Convert.ToInt32(txtId.Text));
                    PreencheObjeto(ingresso);
                    _ingressoService.Update<Ingresso, Ingresso, IngressoValidator>(ingresso);
                }
                else
                {
                    var ingresso = new Ingresso();
                    PreencheObjeto(ingresso);
                    _ingressoService.Create<Ingresso, Ingresso, IngressoValidator>(ingresso);
                }

                tabControlCadastro.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtId.Text = ingresso.Id.ToString();
            PreencheTela(ingresso);
        }
    }
}
