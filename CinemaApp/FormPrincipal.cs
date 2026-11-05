using CinemaApp.Cadastros;
using CinemaApp.Infra;
using Microsoft.Extensions.DependencyInjection;
using ReaLTaiizor.Forms;

namespace CinemaApp
{
    public partial class FormPrincipal : MaterialForm
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void gêneroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroGenero cadastroGenero = ConfigureDI.ServiceProvider.GetService<CadastroGenero>();
            cadastroGenero.ShowDialog(); // Em vez de cadastroGenero.MdiParent = this; e .Show();
        }

        private void filmeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            CadastroFilme cadastroFilme = ConfigureDI.ServiceProvider.GetService<CadastroFilme>();
            cadastroFilme.ShowDialog();
        }
    }
}
