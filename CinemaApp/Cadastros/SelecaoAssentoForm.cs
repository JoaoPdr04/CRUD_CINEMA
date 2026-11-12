using CinemaDomain;

namespace CinemaApp.Cadastros;

public sealed class SelecaoAssentosForm : Form
{
    private readonly Sala _sala;
    private readonly HashSet<(int Fileira, int Assento)> _ocupados;
    private readonly List<IngressoItem> _selecionados = new();
    private readonly TableLayoutPanel _layoutAssentos;
    private readonly Button _btnConfirmar;

    public IReadOnlyList<IngressoItem> ItensSelecionados => _selecionados;

    public SelecaoAssentosForm(Sala sala, IEnumerable<IngressoItem> itensExistentes)
    {
        _sala = sala;
        _ocupados = itensExistentes
            .Select(item => (item.Fileira, item.Assento))
            .ToHashSet();

        Text = $"Sala {sala.Numero} - Seleção de assentos";
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        ShowInTaskbar = false;
        ClientSize = new Size(800, 600);

        var lblInstrucao = new Label
        {
            AutoSize = true,
            Dock = DockStyle.Top,
            Padding = new Padding(10),
            Text = "Selecione os assentos desejados. Os assentos cinza já estão no ingresso.",
            Font = new Font(Font, FontStyle.Bold)
        };

        _layoutAssentos = new TableLayoutPanel
        {
            AutoScroll = true,
            ColumnCount = Math.Max(1, sala.Assentos + 1),
            RowCount = Math.Max(1, sala.Fileiras + 1),
            Dock = DockStyle.Fill,
            Padding = new Padding(10),
            CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        };

        var painelBotoes = new FlowLayoutPanel
        {
            AutoSize = true,
            Dock = DockStyle.Bottom,
            FlowDirection = FlowDirection.RightToLeft,
            Padding = new Padding(10)
        };

        _btnConfirmar = new Button
        {
            AutoSize = true,
            Text = "Confirmar",
            DialogResult = DialogResult.OK,
            Enabled = false
        };
        _btnConfirmar.Click += btnConfirmar_Click;

        var btnCancelar = new Button
        {
            AutoSize = true,
            Text = "Cancelar",
            DialogResult = DialogResult.Cancel
        };

        painelBotoes.Controls.Add(_btnConfirmar);
        painelBotoes.Controls.Add(btnCancelar);
        AcceptButton = _btnConfirmar;
        CancelButton = btnCancelar;

        Controls.Add(_layoutAssentos);
        Controls.Add(painelBotoes);
        Controls.Add(lblInstrucao);

        DesenhaAssentos();
    }

    private void DesenhaAssentos()
    {
        _layoutAssentos.Controls.Add(new Label
        {
            Text = "",
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleCenter
        }, 0, 0);

        for (var assento = 1; assento <= _sala.Assentos; assento++)
        {
            _layoutAssentos.Controls.Add(new Label
            {
                Text = assento.ToString(),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font(Font, FontStyle.Bold)
            }, assento, 0);

            _layoutAssentos.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 72));
        }

        _layoutAssentos.ColumnStyles[0] = new ColumnStyle(SizeType.Absolute, 55);

        for (var fileira = 1; fileira <= _sala.Fileiras; fileira++)
        {
            _layoutAssentos.Controls.Add(new Label
            {
                Text = $"F{fileira}",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font(Font, FontStyle.Bold)
            }, 0, fileira);
            _layoutAssentos.RowStyles.Add(new RowStyle(SizeType.Absolute, 48));

            for (var assento = 1; assento <= _sala.Assentos; assento++)
            {
                var ocupado = _ocupados.Contains((fileira, assento));
                var botao = new Button
                {
                    AutoSize = false,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(4),
                    Text = assento.ToString(),
                    Tag = (Fileira: fileira, Assento: assento),
                    Enabled = !ocupado,
                    BackColor = ocupado ? Color.LightGray : Color.LightGreen,
                    FlatStyle = FlatStyle.Flat
                };

                if (!ocupado)
                    botao.Click += Assento_Click;

                _layoutAssentos.Controls.Add(botao, assento, fileira);
            }
        }

        _layoutAssentos.RowStyles[0] = new RowStyle(SizeType.Absolute, 32);
    }

    private void Assento_Click(object? sender, EventArgs e)
    {
        if (sender is not Button botao || botao.Tag is not ValueTuple<int, int> assento)
            return;

        var indice = _selecionados.FindIndex(item =>
            item.Fileira == assento.Item1 && item.Assento == assento.Item2);

        if (indice >= 0)
        {
            _selecionados.RemoveAt(indice);
            botao.BackColor = Color.LightGreen;
        }
        else
        {
            _selecionados.Add(new IngressoItem
            {
                Fileira = assento.Item1,
                Assento = assento.Item2
            });
            botao.BackColor = Color.LightBlue;
        }

        _btnConfirmar.Enabled = _selecionados.Count > 0;
    }

    private void btnConfirmar_Click(object? sender, EventArgs e)
    {
        if (_selecionados.Count == 0)
            DialogResult = DialogResult.None;
    }
}
