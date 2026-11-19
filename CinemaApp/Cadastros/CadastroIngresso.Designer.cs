namespace CinemaApp.Cadastros
{
    partial class CadastroIngresso
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtDocumento = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            cboFormaPagamento = new ReaLTaiizor.Controls.MaterialComboBox();
            txtValorTotal = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            dataGridViewIngressos = new DataGridView();
            groupBox1 = new GroupBox();
            txtClassificacao = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            txtDataFilme = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            cboSessao = new ReaLTaiizor.Controls.MaterialComboBox();
            txtDataCompra = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            txtQuantidade = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            btnAdicionar = new ReaLTaiizor.Controls.MaterialButton();
            btnRemover = new ReaLTaiizor.Controls.MaterialButton();
            cboFilme = new ReaLTaiizor.Controls.MaterialComboBox();
            tabPageCadastro.SuspendLayout();
            tabControlCadastro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewIngressos).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // tabPageCadastro
            // 
            tabPageCadastro.Controls.Add(btnRemover);
            tabPageCadastro.Controls.Add(btnAdicionar);
            tabPageCadastro.Controls.Add(txtDataCompra);
            tabPageCadastro.Controls.Add(txtQuantidade);
            tabPageCadastro.Controls.Add(groupBox1);
            tabPageCadastro.Controls.Add(dataGridViewIngressos);
            tabPageCadastro.Controls.Add(txtValorTotal);
            tabPageCadastro.Controls.Add(cboFormaPagamento);
            tabPageCadastro.Controls.Add(txtDocumento);
          //  tabPageCadastro.Size = new Size(636, 505);
            tabPageCadastro.Controls.SetChildIndex(txtDocumento, 0);
            tabPageCadastro.Controls.SetChildIndex(cboFormaPagamento, 0);
            tabPageCadastro.Controls.SetChildIndex(txtValorTotal, 0);
            tabPageCadastro.Controls.SetChildIndex(dataGridViewIngressos, 0);
            tabPageCadastro.Controls.SetChildIndex(groupBox1, 0);
            tabPageCadastro.Controls.SetChildIndex(txtDataCompra, 0);
            tabPageCadastro.Controls.SetChildIndex(txtQuantidade, 0);
            tabPageCadastro.Controls.SetChildIndex(btnAdicionar, 0);
            tabPageCadastro.Controls.SetChildIndex(btnRemover, 0);
            // 
            // tabControlCadastro
            // 
           // tabControlCadastro.Size = new Size(644, 533);
            // 
            // txtDocumento
            // 
            txtDocumento.AnimateReadOnly = false;
            txtDocumento.AutoCompleteMode = AutoCompleteMode.None;
            txtDocumento.AutoCompleteSource = AutoCompleteSource.None;
            txtDocumento.BackgroundImageLayout = ImageLayout.None;
            txtDocumento.CharacterCasing = CharacterCasing.Normal;
            txtDocumento.Depth = 0;
            txtDocumento.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtDocumento.HideSelection = true;
            txtDocumento.Hint = "CPF ou RG";
            txtDocumento.LeadingIcon = null;
            txtDocumento.Location = new Point(126, 16);
            txtDocumento.MaxLength = 32767;
            txtDocumento.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtDocumento.Name = "txtDocumento";
            txtDocumento.PasswordChar = '\0';
            txtDocumento.PrefixSuffixText = null;
            txtDocumento.ReadOnly = false;
            txtDocumento.RightToLeft = RightToLeft.No;
            txtDocumento.SelectedText = "";
            txtDocumento.SelectionLength = 0;
            txtDocumento.SelectionStart = 0;
            txtDocumento.ShortcutsEnabled = true;
            txtDocumento.Size = new Size(250, 48);
            txtDocumento.TabIndex = 4;
            txtDocumento.TabStop = false;
            txtDocumento.TextAlign = HorizontalAlignment.Left;
            txtDocumento.TrailingIcon = null;
            txtDocumento.UseSystemPasswordChar = false;
            // 
            // cboFormaPagamento
            // 
            cboFormaPagamento.AutoResize = false;
            cboFormaPagamento.BackColor = Color.FromArgb(255, 255, 255);
            cboFormaPagamento.Depth = 0;
            cboFormaPagamento.DrawMode = DrawMode.OwnerDrawVariable;
            cboFormaPagamento.DropDownHeight = 174;
            cboFormaPagamento.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFormaPagamento.DropDownWidth = 121;
            cboFormaPagamento.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cboFormaPagamento.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cboFormaPagamento.FormattingEnabled = true;
            cboFormaPagamento.Hint = "Forma Pagamento";
            cboFormaPagamento.IntegralHeight = false;
            cboFormaPagamento.ItemHeight = 43;
            cboFormaPagamento.Items.AddRange(new object[] { "Dinheiro", "Pix", "Débito", "Crédito" });
            cboFormaPagamento.Location = new Point(18, 70);
            cboFormaPagamento.MaxDropDownItems = 4;
            cboFormaPagamento.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            cboFormaPagamento.Name = "cboFormaPagamento";
            cboFormaPagamento.Size = new Size(358, 49);
            cboFormaPagamento.StartIndex = 0;
            cboFormaPagamento.TabIndex = 11;
            // 
            // txtValorTotal
            // 
            txtValorTotal.AnimateReadOnly = false;
            txtValorTotal.AutoCompleteMode = AutoCompleteMode.None;
            txtValorTotal.AutoCompleteSource = AutoCompleteSource.None;
            txtValorTotal.BackgroundImageLayout = ImageLayout.None;
            txtValorTotal.CharacterCasing = CharacterCasing.Normal;
            txtValorTotal.Depth = 0;
            txtValorTotal.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtValorTotal.HideSelection = true;
            txtValorTotal.Hint = "ValorTotal";
            txtValorTotal.LeadingIcon = null;
            txtValorTotal.Location = new Point(391, 70);
            txtValorTotal.MaxLength = 32767;
            txtValorTotal.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtValorTotal.Name = "txtValorTotal";
            txtValorTotal.PasswordChar = '\0';
            txtValorTotal.PrefixSuffixText = null;
            txtValorTotal.ReadOnly = true;
            txtValorTotal.RightToLeft = RightToLeft.No;
            txtValorTotal.SelectedText = "";
            txtValorTotal.SelectionLength = 0;
            txtValorTotal.SelectionStart = 0;
            txtValorTotal.ShortcutsEnabled = true;
            txtValorTotal.Size = new Size(227, 48);
            txtValorTotal.TabIndex = 12;
            txtValorTotal.TabStop = false;
            txtValorTotal.TextAlign = HorizontalAlignment.Center;
            txtValorTotal.TrailingIcon = null;
            txtValorTotal.UseSystemPasswordChar = false;
            // 
            // dataGridViewIngressos
            // 
            dataGridViewIngressos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewIngressos.Location = new Point(18, 319);
            dataGridViewIngressos.Name = "dataGridViewIngressos";
            dataGridViewIngressos.Size = new Size(610, 126);
            dataGridViewIngressos.TabIndex = 14;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cboFilme);
            groupBox1.Controls.Add(txtClassificacao);
            groupBox1.Controls.Add(txtDataFilme);
            groupBox1.Controls.Add(cboSessao);
            groupBox1.Font = new Font("Segoe UI", 14F);
            groupBox1.Location = new Point(18, 125);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(617, 137);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "..:: Dados da Sessão ::..";
            // 
            // txtClassificacao
            // 
            txtClassificacao.AnimateReadOnly = false;
            txtClassificacao.AutoCompleteMode = AutoCompleteMode.None;
            txtClassificacao.AutoCompleteSource = AutoCompleteSource.None;
            txtClassificacao.BackgroundImageLayout = ImageLayout.None;
            txtClassificacao.CharacterCasing = CharacterCasing.Normal;
            txtClassificacao.Depth = 0;
            txtClassificacao.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtClassificacao.HideSelection = true;
            txtClassificacao.Hint = "Classificação";
            txtClassificacao.LeadingIcon = null;
            txtClassificacao.Location = new Point(374, 31);
            txtClassificacao.MaxLength = 32767;
            txtClassificacao.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtClassificacao.Name = "txtClassificacao";
            txtClassificacao.PasswordChar = '\0';
            txtClassificacao.PrefixSuffixText = null;
            txtClassificacao.ReadOnly = true;
            txtClassificacao.RightToLeft = RightToLeft.No;
            txtClassificacao.SelectedText = "";
            txtClassificacao.SelectionLength = 0;
            txtClassificacao.SelectionStart = 0;
            txtClassificacao.ShortcutsEnabled = true;
            txtClassificacao.Size = new Size(227, 48);
            txtClassificacao.TabIndex = 17;
            txtClassificacao.TabStop = false;
            txtClassificacao.TextAlign = HorizontalAlignment.Left;
            txtClassificacao.TrailingIcon = null;
            txtClassificacao.UseSystemPasswordChar = false;
            // 
            // txtDataFilme
            // 
            txtDataFilme.AnimateReadOnly = false;
            txtDataFilme.AutoCompleteMode = AutoCompleteMode.None;
            txtDataFilme.AutoCompleteSource = AutoCompleteSource.None;
            txtDataFilme.BackgroundImageLayout = ImageLayout.None;
            txtDataFilme.CharacterCasing = CharacterCasing.Normal;
            txtDataFilme.Depth = 0;
            txtDataFilme.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtDataFilme.HideSelection = true;
            txtDataFilme.Hint = "Data/Hora Sessão";
            txtDataFilme.LeadingIcon = null;
            txtDataFilme.Location = new Point(373, 88);
            txtDataFilme.MaxLength = 32767;
            txtDataFilme.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtDataFilme.Name = "txtDataFilme";
            txtDataFilme.PasswordChar = '\0';
            txtDataFilme.PrefixSuffixText = null;
            txtDataFilme.ReadOnly = true;
            txtDataFilme.RightToLeft = RightToLeft.No;
            txtDataFilme.SelectedText = "";
            txtDataFilme.SelectionLength = 0;
            txtDataFilme.SelectionStart = 0;
            txtDataFilme.ShortcutsEnabled = true;
            txtDataFilme.Size = new Size(227, 48);
            txtDataFilme.TabIndex = 15;
            txtDataFilme.TabStop = false;
            txtDataFilme.TextAlign = HorizontalAlignment.Center;
            txtDataFilme.TrailingIcon = null;
            txtDataFilme.UseSystemPasswordChar = false;
            // 
            // cboSessao
            // 
            cboSessao.AutoResize = false;
            cboSessao.BackColor = Color.FromArgb(255, 255, 255);
            cboSessao.Depth = 0;
            cboSessao.DrawMode = DrawMode.OwnerDrawVariable;
            cboSessao.DropDownHeight = 174;
            cboSessao.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSessao.DropDownWidth = 121;
            cboSessao.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cboSessao.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cboSessao.FormattingEnabled = true;
            cboSessao.Hint = "Sessão";
            cboSessao.IntegralHeight = false;
            cboSessao.ItemHeight = 43;
            cboSessao.Location = new Point(6, 88);
            cboSessao.MaxDropDownItems = 4;
            cboSessao.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            cboSessao.Name = "cboSessao";
            cboSessao.Size = new Size(352, 49);
            cboSessao.StartIndex = 0;
            cboSessao.TabIndex = 14;
            // 
            // txtDataCompra
            // 
            txtDataCompra.AnimateReadOnly = false;
            txtDataCompra.AutoCompleteMode = AutoCompleteMode.None;
            txtDataCompra.AutoCompleteSource = AutoCompleteSource.None;
            txtDataCompra.BackgroundImageLayout = ImageLayout.None;
            txtDataCompra.CharacterCasing = CharacterCasing.Normal;
            txtDataCompra.Depth = 0;
            txtDataCompra.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtDataCompra.HideSelection = true;
            txtDataCompra.Hint = "Data/Hora Compra";
            txtDataCompra.LeadingIcon = null;
            txtDataCompra.Location = new Point(391, 6);
            txtDataCompra.MaxLength = 32767;
            txtDataCompra.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtDataCompra.Name = "txtDataCompra";
            txtDataCompra.PasswordChar = '\0';
            txtDataCompra.PrefixSuffixText = null;
            txtDataCompra.ReadOnly = true;
            txtDataCompra.RightToLeft = RightToLeft.No;
            txtDataCompra.SelectedText = "";
            txtDataCompra.SelectionLength = 0;
            txtDataCompra.SelectionStart = 0;
            txtDataCompra.ShortcutsEnabled = true;
            txtDataCompra.Size = new Size(227, 48);
            txtDataCompra.TabIndex = 16;
            txtDataCompra.TabStop = false;
            txtDataCompra.TextAlign = HorizontalAlignment.Center;
            txtDataCompra.TrailingIcon = null;
            txtDataCompra.UseSystemPasswordChar = false;
            // 
            // txtQuantidade
            // 
            txtQuantidade.AnimateReadOnly = false;
            txtQuantidade.AutoCompleteMode = AutoCompleteMode.None;
            txtQuantidade.AutoCompleteSource = AutoCompleteSource.None;
            txtQuantidade.BackgroundImageLayout = ImageLayout.None;
            txtQuantidade.CharacterCasing = CharacterCasing.Normal;
            txtQuantidade.Depth = 0;
            txtQuantidade.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtQuantidade.HideSelection = true;
            txtQuantidade.Hint = "Quantidade de ingressos";
            txtQuantidade.LeadingIcon = null;
            txtQuantidade.Location = new Point(18, 265);
            txtQuantidade.MaxLength = 32767;
            txtQuantidade.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtQuantidade.Name = "txtQuantidade";
            txtQuantidade.PasswordChar = '\0';
            txtQuantidade.PrefixSuffixText = null;
            txtQuantidade.ReadOnly = true;
            txtQuantidade.RightToLeft = RightToLeft.No;
            txtQuantidade.SelectedText = "";
            txtQuantidade.SelectionLength = 0;
            txtQuantidade.SelectionStart = 0;
            txtQuantidade.ShortcutsEnabled = true;
            txtQuantidade.Size = new Size(227, 48);
            txtQuantidade.TabIndex = 19;
            txtQuantidade.TabStop = false;
            txtQuantidade.Text = "0";
            txtQuantidade.TextAlign = HorizontalAlignment.Center;
            txtQuantidade.TrailingIcon = null;
            txtQuantidade.UseSystemPasswordChar = false;
            // 
            // btnAdicionar
            // 
            btnAdicionar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAdicionar.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnAdicionar.Depth = 0;
            btnAdicionar.HighEmphasis = true;
            btnAdicionar.Icon = null;
            btnAdicionar.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnAdicionar.Location = new Point(441, 272);
            btnAdicionar.Margin = new Padding(4, 6, 4, 6);
            btnAdicionar.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.NoAccentTextColor = Color.Empty;
            btnAdicionar.Size = new Size(188, 36);
            btnAdicionar.TabIndex = 17;
            btnAdicionar.Text = "+  Adicionar Ingresso";
            btnAdicionar.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAdicionar.UseAccentColor = false;
            btnAdicionar.UseVisualStyleBackColor = true;
            // 
            // btnRemover
            // 
            btnRemover.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRemover.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnRemover.Depth = 0;
            btnRemover.HighEmphasis = true;
            btnRemover.Icon = null;
            btnRemover.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnRemover.Location = new Point(259, 272);
            btnRemover.Margin = new Padding(4, 6, 4, 6);
            btnRemover.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnRemover.Name = "btnRemover";
            btnRemover.NoAccentTextColor = Color.Empty;
            btnRemover.Size = new Size(174, 36);
            btnRemover.TabIndex = 18;
            btnRemover.Text = "-  Remover Ingresso";
            btnRemover.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            btnRemover.UseAccentColor = false;
            btnRemover.UseVisualStyleBackColor = true;
            // 
            // cboFilme
            // 
            cboFilme.AutoResize = false;
            cboFilme.BackColor = Color.FromArgb(255, 255, 255);
            cboFilme.Depth = 0;
            cboFilme.DrawMode = DrawMode.OwnerDrawVariable;
            cboFilme.DropDownHeight = 174;
            cboFilme.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFilme.DropDownWidth = 121;
            cboFilme.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cboFilme.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cboFilme.FormattingEnabled = true;
            cboFilme.Hint = "Filme";
            cboFilme.IntegralHeight = false;
            cboFilme.ItemHeight = 43;
            cboFilme.Location = new Point(6, 30);
            cboFilme.MaxDropDownItems = 4;
            cboFilme.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            cboFilme.Name = "cboFilme";
            cboFilme.Size = new Size(352, 49);
            cboFilme.StartIndex = 0;
            cboFilme.TabIndex = 18;
            // 
            // CadastroIngresso
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(650, 600);
            Location = new Point(0, 0);
            MaximumSize = new Size(650, 600);
            MinimumSize = new Size(650, 600);
            Name = "CadastroIngresso";
            Text = "CadastroIngresso";
            tabPageCadastro.ResumeLayout(false);
            tabPageCadastro.PerformLayout();
            tabControlCadastro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewIngressos).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.MaterialTextBoxEdit txtDocumento;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit txtValorTotal;
        private ReaLTaiizor.Controls.MaterialComboBox cboFormaPagamento;
        private GroupBox groupBox1;
        private DataGridView dataGridViewIngressos;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit txtDataCompra;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit txtQuantidade;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit txtClassificacao;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit txtDataFilme;
        private ReaLTaiizor.Controls.MaterialComboBox cboSessao;
        private ReaLTaiizor.Controls.MaterialButton btnRemover;
        private ReaLTaiizor.Controls.MaterialButton btnAdicionar;
        private ReaLTaiizor.Controls.MaterialComboBox cboFilme;
    }
}