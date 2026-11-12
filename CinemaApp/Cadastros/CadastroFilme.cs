using CinemaApp.Base;
using CinemaApp.Models;
using CinemaDomain;
using CinemaService.Base;
using CinemaService.Validators;
using static System.Net.WebRequestMethods;

namespace CinemaApp.Cadastros
{
    public partial class CadastroFilme : CadastroBase
    {
        private readonly IBaseService<Filme> _filmeService;
        private readonly IBaseService<Genero> _generoService;
        private List<FilmeViewModel> _filmes;
        private List<GeneroViewModel> _generos;

        public CadastroFilme(IBaseService<Filme> filmeService, IBaseService<Genero> generoService)
        {
            _filmeService = filmeService;
            _generoService = generoService;
            InitializeComponent();
            CarregaComboboxGenero();
        }

        private void CarregaComboboxGenero()
        {
            try
            {
                var generos = _generoService.ReadAll<GeneroViewModel>().ToList();
                cboGenero.DataSource = generos;
                cboGenero.DisplayMember = nameof(GeneroViewModel.Nome);
                cboGenero.ValueMember = nameof(GeneroViewModel.Id);
                cboGenero.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar gêneros: " + ex.Message, "Erro",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreencheObjeto(Filme filme)
        {
            filme.Nome = txtNome.Text;
            filme.Classificacao = txtClassificacao.Text;

            int.TryParse(txtDuracao.Text, out int duracao);
            filme.Duracao = duracao;

            if (cboGenero.SelectedValue != null)
            {
                int idGenero = Convert.ToInt32(cboGenero.SelectedValue);
                filme.Genero = _generoService.ReadById<Genero>(idGenero);
            }
        }

        private void PreencheTela(Filme filme)
        {
            txtNome.Text = filme.Nome;
            txtClassificacao.Text = filme.Classificacao;
            txtDuracao.Text = filme.Duracao.ToString();

            if (filme.Genero != null)
            {
                cboGenero.SelectedValue = filme.Genero.Id;
            }
        }

        protected override void Salvar()
        {
            try
            {
                if (IsEditMode)
                {
                    var id = Convert.ToInt32(txtId.Text);
                    var filme = _filmeService.ReadById<Filme>(id);
                    PreencheObjeto(filme);
                    _filmeService.Update<Filme, Filme, FilmeValidator>(filme);
                }
                else
                {
                    var filme = new Filme();
                    PreencheObjeto(filme);
                    _filmeService.Create<Filme, Filme, FilmeValidator>(filme);
                }

                tabControlCadastro.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void CarregaGrid()
        {
            _filmes = _filmeService.ReadAll<FilmeViewModel>().ToList();
            dataGridViewConsulta.DataSource = _filmes;

            dataGridViewConsulta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewConsulta.MultiSelect = false;

            if (dataGridViewConsulta.Columns["GeneroId"] != null)
            {
                dataGridViewConsulta.Columns["GeneroId"].Visible = false;
            }
        }

        protected override void CarregarRegistro(DataGridViewRow row)
        {
            var id = Convert.ToInt32(row.Cells["Id"].Value);
            var filme = _filmeService.ReadById<Filme>(id);

            txtId.Text = filme.Id.ToString();
            PreencheTela(filme);
        }

        protected override void Deletar(int id)
        {
            try
            {
                _filmeService.Delete(id);
                CarregaGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao Excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}