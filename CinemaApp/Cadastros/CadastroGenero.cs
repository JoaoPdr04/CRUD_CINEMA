using CinemaApp.Base;
using CinemaApp.Models;
using CinemaDomain;
using CinemaService.Base;
using CinemaService.Validators;

namespace CinemaApp.Cadastros
{
    public partial class CadastroGenero : CadastroBase
    {
        private readonly IBaseService<Genero> _generoService;
        private List<Genero> _generos;
        private Genero _genero;

        public CadastroGenero(IBaseService<Genero> generoService)
        {
            _generoService = generoService;
            InitializeComponent();
        }

        private void PreencheObjeto(Genero genero)
        {
            genero.Nome = txtNome.Text;
        }

        private void PreencheTela(Genero genero)
        {
            txtNome.Text = genero.Nome;
        }

        protected override void Salvar()
        {
            try
            {
                if (IsEditMode && _genero != null)
                {
                    PreencheObjeto(_genero);
                    _generoService.Update<Genero, Genero, GeneroValidator>(_genero);
                    MessageBox.Show("Gênero atualizado com sucesso!", "Sucesso",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var genero = new Genero();
                    PreencheObjeto(genero);
                    _generoService.Create<Genero, Genero, GeneroValidator>(genero);
                    MessageBox.Show("Gênero salvo com sucesso!", "Sucesso",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Reseta o estado para inserções futuras
                IsEditMode = false;
                _genero = null;

                CarregaGrid();
                tabControlCadastro.SelectedIndex = 1; // Alterna para a aba de consulta
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message, "Erro no Banco de Dados",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void CarregaGrid()
        {
            //_generos = _generoService.ReadAll<Genero>().ToList();
            _generos = _generoService.ReadAll<Genero>().OrderBy(g => g.Id).ToList();
            dataGridViewConsulta.DataSource = _generos;

            // Configura o DataGridView para selecionar a linha inteira ao clicar em qualquer célula
            dataGridViewConsulta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewConsulta.MultiSelect = false;

            if (dataGridViewConsulta.Columns["Nome"] != null)
            {
                dataGridViewConsulta.Columns["Nome"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        protected override void CarregarRegistro(DataGridViewRow row)
        {
            // Tenta obter o objeto diretamente do DataBoundItem da linha da tabela
            if (row.DataBoundItem is Genero generoGrid)
            {
                _genero = _generoService.ReadById<Genero>(generoGrid.Id);
            }
            else if (row.Cells["Id"] != null && row.Cells["Id"].Value != null)
            {
                int id = Convert.ToInt32(row.Cells["Id"].Value);
                _genero = _generoService.ReadById<Genero>(id);
            }

            if (_genero != null)
            {
                txtId.Text = _genero.Id.ToString();
                PreencheTela(_genero);
            }
        }

        protected override void Deletar(int id)
        {
            try
            {
                _generoService.Delete(id);
                CarregaGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao Excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}