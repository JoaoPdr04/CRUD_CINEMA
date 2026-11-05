using CinemaApp.Base;
using CinemaDomain;
using CinemaService.Base;
using CinemaService.Validators;

namespace CinemaApp.Cadastros
{
    public partial class CadastroFilme : CadastroBase
    {
        private readonly IBaseService<Filme> _filmeService;
        private readonly IBaseService<Genero> _generoService;
        private List<Filme> _filmes;
        private Filme _filme;

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
                var generos = _generoService.ReadAll<Genero>().ToList();
                cboGenero.DataSource = generos;
                cboGenero.DisplayMember = "Nome";
                cboGenero.ValueMember = "Id";
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

            // Converte a duração para número (int)
            int.TryParse(txtDuracao.Text, out int duracao);
            filme.Duracao = duracao;

            // Vincula o objeto Genero selecionado no ComboBox
            if (cboGenero.SelectedItem is Genero generoSelecionado)
            {
                filme.Genero = generoSelecionado;
            }
            else if (cboGenero.SelectedValue != null)
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
                if (IsEditMode && _filme != null)
                {
                    PreencheObjeto(_filme);
                    _filmeService.Update<Filme, Filme, FilmeValidator>(_filme);
                    MessageBox.Show("Filme atualizado com sucesso!", "Sucesso",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var filme = new Filme();
                    PreencheObjeto(filme);
                    _filmeService.Create<Filme, Filme, FilmeValidator>(filme);
                    MessageBox.Show("Filme salvo com sucesso!", "Sucesso",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                IsEditMode = false;
                _filme = null;

                CarregaGrid();
                tabControlCadastro.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message, "Erro no Banco de Dados",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void CarregaGrid()
        {
            _filmes = _filmeService.ReadAll<Filme>().ToList();
            dataGridViewConsulta.DataSource = _filmes;

            dataGridViewConsulta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewConsulta.MultiSelect = false;

            if (dataGridViewConsulta.Columns["Nome"] != null)
            {
                dataGridViewConsulta.Columns["Nome"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        protected override void CarregarRegistro(DataGridViewRow row)
        {
            if (row.DataBoundItem is Filme filmeGrid)
            {
                _filme = _filmeService.ReadById<Filme>(filmeGrid.Id);
            }
            else if (row.Cells["Id"] != null && row.Cells["Id"].Value != null)
            {
                int id = Convert.ToInt32(row.Cells["Id"].Value);
                _filme = _filmeService.ReadById<Filme>(id);
            }

            if (_filme != null)
            {
                txtId.Text = _filme.Id.ToString();
                PreencheTela(_filme);
            }
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