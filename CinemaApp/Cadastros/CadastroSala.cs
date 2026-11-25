using CinemaApp.Base;
using CinemaApp.Models;
using CinemaDomain;
using CinemaService.Base;
using CinemaService.Validators;


namespace CinemaApp.Cadastros
{
    public partial class CadastroSala : CadastroBase
    {
        private readonly IBaseService<Sala> _salaService;
        private List<SalaViewModel> _salas;

        public CadastroSala(IBaseService<Sala> salaService)
        {
            _salaService = salaService;
            InitializeComponent();

            nudFileiras.Maximum = 10;
            nudAssentos.Maximum = 100;

            nudCapacidade.Enabled = false;
            nudFileiras.ValueChanged += (s, e) => AtualizaCapacidade();
            nudAssentos.ValueChanged += (s, e) => AtualizaCapacidade();
            AtualizaCapacidade();

            this.MinimumSize = Size.Empty;
            this.MaximumSize = Size.Empty;
            this.ClientSize = new Size(560, 385);

            tabControlCadastro.Location = new Point(3, 64);
            tabControlCadastro.Size = new Size(554, 318);
            tabPageCadastro.Size = new Size(546, 290);

            btnCancelar.Location = new Point(358, 242);
            btnSalvar.Location = new Point(462, 242);

            nudFileiras.Maximum = 10;
            nudAssentos.Maximum = 10;

            nudCapacidade.Enabled = false;
            nudFileiras.ValueChanged += (s, e) => AtualizaCapacidade();
            nudAssentos.ValueChanged += (s, e) => AtualizaCapacidade();
            AtualizaCapacidade();
        }

        private void AtualizaCapacidade()
        {
            nudCapacidade.Value = nudFileiras.Value * nudAssentos.Value;
        }

        private void PreencheObjeto(Sala sala)
        {
            sala.Numero = (int)nudNumero.Value;
            sala.Capacidade = (int)(nudFileiras.Value * nudAssentos.Value);
            sala.Fileiras = (int)nudFileiras.Value;
            sala.Assentos = (int)nudAssentos.Value;
        }

        private void PreencheTela(Sala sala)
        {
            nudNumero.Value = sala.Numero;
            nudCapacidade.Value = sala.Capacidade;
            nudFileiras.Value = sala.Fileiras;
            nudAssentos.Value = sala.Assentos;
        }

        protected override void Salvar()
        {
            try
            {
                if (IsEditMode)
                {
                    var id = Convert.ToInt32(txtId.Text);
                    var sala = _salaService.ReadById<Sala>(id);
                    PreencheObjeto(sala);

                    if (NumeroSalaJaExiste(sala.Numero, id))
                    {
                        MessageBox.Show($"Já existe uma sala cadastrada com o número {sala.Numero}.", "Atenção",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    _salaService.Update<Sala, Sala, SalaValidator>(sala);
                }
                else
                {
                    var sala = new Sala();
                    PreencheObjeto(sala);

                    if (NumeroSalaJaExiste(sala.Numero, 0))
                    {
                        MessageBox.Show($"Já existe uma sala cadastrada com o número {sala.Numero}.", "Atenção",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    _salaService.Create<Sala, Sala, SalaValidator>(sala);
                }

                tabControlCadastro.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool NumeroSalaJaExiste(int numero, int idAtual)
        {
            return _salaService.ReadAll<Sala>()
                .Any(s => s.Numero == numero && s.Id != idAtual);
        }

        protected override void Deletar(int id)
        {
            try
            {
                _salaService.Delete(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void CarregaGrid()
        {
            _salas = _salaService.ReadAll<SalaViewModel>().ToList();
            dataGridViewConsulta.DataSource = _salas;

        }

        protected override void CarregarRegistro(DataGridViewRow row)
        {
            var id = Convert.ToInt32(row.Cells["Id"].Value);
            var sala = _salaService.ReadById<Sala>(id);

            txtId.Text = sala.Id.ToString();
            PreencheTela(sala);
        }
    }
}
