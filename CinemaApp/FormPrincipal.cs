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
            using var scope = ConfigureDI.ServiceProvider.CreateScope();
            var cadastroGenero = scope.ServiceProvider.GetRequiredService<CadastroGenero>();
            cadastroGenero.ShowDialog();
        }

        private void filmeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            using var scope = ConfigureDI.ServiceProvider.CreateScope();
            var cadastroFilme = scope.ServiceProvider.GetRequiredService<CadastroFilme>();
            cadastroFilme.ShowDialog();
        }

        private void salaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var scope = ConfigureDI.ServiceProvider.CreateScope();
            var cadastroSala = scope.ServiceProvider.GetRequiredService<CadastroSala>();
            cadastroSala.ShowDialog();
        }

        private void sessãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var scope = ConfigureDI.ServiceProvider.CreateScope();
            var cadastroSessao = scope.ServiceProvider.GetRequiredService<CadastroSessao>();
            cadastroSessao.ShowDialog();
        }
    }
}
