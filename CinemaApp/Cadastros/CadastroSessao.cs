using CinemaApp.Base;
using CinemaApp.Models;
using CinemaDomain;
using CinemaService.Base;
using CinemaService.Validators;

namespace CinemaApp.Cadastros
{
    public partial class CadastroSessao : CadastroBase
    {
        private readonly IBaseService<Sessao> _sessaoService;
        private readonly IBaseService<Filme> _filmeService;
        private readonly IBaseService<Sala> _salaService;
        private List<SessaoViewModel> _sessoes;
        private List<FilmeViewModel> _filmes;
        private List<SalaViewModel> _salas;
        private int _id;

        public CadastroSessao(
            IBaseService<Sessao> sessaoService,
            IBaseService<Filme> filmeService,
            IBaseService<Sala> salaService)
        {
            _sessaoService = sessaoService;
            _filmeService = filmeService;
            _salaService = salaService;
            InitializeComponent();
            CarregaCombos();
        }

        private void CarregaCombos()
        {
            _filmes = _filmeService.ReadAll<FilmeViewModel>().ToList();
            cboFilme.DisplayMember = nameof(FilmeViewModel.Nome);
            cboFilme.ValueMember = nameof(FilmeViewModel.Id);
            cboFilme.DataSource = _filmes;
            cboFilme.SelectedIndex = -1;

            _salas = _salaService.ReadAll<SalaViewModel>().ToList();
            cboSala.DisplayMember = nameof(SalaViewModel.Numero);
            cboSala.ValueMember = nameof(SalaViewModel.Id);
            cboSala.DataSource = _salas;
            cboSala.SelectedIndex = -1;
        }

        private void PreencheObjeto(Sessao sessao)
        {
            if (cboFilme.SelectedValue == null)
                throw new InvalidOperationException("Filme da sessão deve ser informado");
            if (cboSala.SelectedValue == null)
                throw new InvalidOperationException("Sala da sessão deve ser informada");

            sessao.Filme = _filmeService.ReadById<Filme>(Convert.ToInt32(cboFilme.SelectedValue));
            sessao.Sala = _salaService.ReadById<Sala>(Convert.ToInt32(cboSala.SelectedValue));
            var dataHora = dtpData.Value.Date + dtpHora.Value.TimeOfDay;
            sessao.Data = DateTime.SpecifyKind(dataHora, DateTimeKind.Utc);

            decimal.TryParse(txtPreco.Text, out decimal preco);
            sessao.Preco = preco / 100;
        }

        private void PreencheTela(Sessao sessao)
        {
            cboFilme.SelectedItem = _filmes.FirstOrDefault(f => f.Id == sessao.Filme?.Id);
            cboSala.SelectedItem = _salas.FirstOrDefault(s => s.Id == sessao.Sala?.Id);
            dtpData.Value = sessao.Data;
            dtpHora.Value = DateTime.Today.Add(sessao.Data.TimeOfDay);
            txtPreco.Text = ((int)(sessao.Preco * 100)).ToString("D5");
        }

        protected override void Salvar()
        {
            try
            {
                if (IsEditMode)
                {
                    var sessao = _sessaoService.ReadById<Sessao>(_id);
                    PreencheObjeto(sessao);
                    _sessaoService.Update<Sessao, Sessao, SessaoValidator>(sessao);
                }
                else
                {
                    var sessao = new Sessao();
                    PreencheObjeto(sessao);
                    _sessaoService.Create<Sessao, Sessao, SessaoValidator>(sessao);
                }

                IsEditMode = false;
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
                _sessaoService.Delete(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void CarregaGrid()
        {
            _sessoes = _sessaoService.ReadAll<SessaoViewModel>().ToList();
            dataGridViewConsulta.DataSource = _sessoes;
        }

        protected override void AjustaColunasGrid()
        {
            base.AjustaColunasGrid();

            var colunas = dataGridViewConsulta.Columns;
            colunas["FilmeNome"].HeaderText = "Filme";
            colunas["Classificacao"].HeaderText = "Classificação";
            colunas["SalaNumero"].HeaderText = "Sala";
            colunas["Data"].HeaderText = "Data e hora";
            colunas["Data"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            colunas["Preco"].HeaderText = "Preço";
            colunas["Preco"].DefaultCellStyle.Format = "C2";
        }

        protected override void CarregarRegistro(DataGridViewRow row)
        {
            var id = Convert.ToInt32(row.Cells["Id"].Value);
            var sessao = _sessaoService.ReadById<Sessao>(id);

            _id = sessao.Id;
            PreencheTela(sessao);
        }
    }
}
