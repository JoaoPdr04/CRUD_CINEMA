namespace CinemaApp.Cadastros
{
    partial class CadastroSessao
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
            cboFilme = new ReaLTaiizor.Controls.MaterialComboBox();
            cboSala = new ReaLTaiizor.Controls.MaterialComboBox();
            dtpData = new DateTimePicker();
            dtpHora = new DateTimePicker();
            materialLabel1 = new ReaLTaiizor.Controls.MaterialLabel();
            txtPreco = new ReaLTaiizor.Controls.MaterialMaskedTextBox();
            materialLabel2 = new ReaLTaiizor.Controls.MaterialLabel();
            tabPageCadastro.SuspendLayout();
            tabControlCadastro.SuspendLayout();
            SuspendLayout();
            // 
            // tabPageCadastro
            // 
            tabPageCadastro.Controls.Add(txtPreco);
            tabPageCadastro.Controls.Add(materialLabel2);
            tabPageCadastro.Controls.Add(materialLabel1);
            tabPageCadastro.Controls.Add(cboFilme);
            tabPageCadastro.Controls.Add(cboSala);
            tabPageCadastro.Controls.Add(dtpData);
            tabPageCadastro.Controls.Add(dtpHora);
            tabPageCadastro.Controls.SetChildIndex(btnCancelar, 0);
            tabPageCadastro.Controls.SetChildIndex(btnSalvar, 0);
            tabPageCadastro.Controls.SetChildIndex(dtpHora, 0);
            tabPageCadastro.Controls.SetChildIndex(dtpData, 0);
            tabPageCadastro.Controls.SetChildIndex(cboSala, 0);
            tabPageCadastro.Controls.SetChildIndex(cboFilme, 0);
            tabPageCadastro.Controls.SetChildIndex(materialLabel1, 0);
            tabPageCadastro.Controls.SetChildIndex(materialLabel2, 0);
            tabPageCadastro.Controls.SetChildIndex(txtPreco, 0);
            // 
            // cboFilme
            // 
            cboFilme.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboFilme.AutoResize = false;
            cboFilme.BackColor = Color.FromArgb(255, 255, 255);
            cboFilme.Depth = 0;
            cboFilme.DrawMode = DrawMode.OwnerDrawVariable;
            cboFilme.DropDownHeight = 174;
            cboFilme.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFilme.DropDownWidth = 121;
            cboFilme.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cboFilme.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cboFilme.Hint = "Filme";
            cboFilme.IntegralHeight = false;
            cboFilme.ItemHeight = 43;
            cboFilme.Location = new Point(18, 80);
            cboFilme.MaxDropDownItems = 4;
            cboFilme.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            cboFilme.Name = "cboFilme";
            cboFilme.Size = new Size(491, 49);
            cboFilme.StartIndex = 0;
            cboFilme.TabIndex = 4;
            // 
            // cboSala
            // 
            cboSala.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboSala.AutoResize = false;
            cboSala.BackColor = Color.FromArgb(255, 255, 255);
            cboSala.Depth = 0;
            cboSala.DrawMode = DrawMode.OwnerDrawVariable;
            cboSala.DropDownHeight = 174;
            cboSala.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSala.DropDownWidth = 121;
            cboSala.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cboSala.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cboSala.Hint = "Sala";
            cboSala.IntegralHeight = false;
            cboSala.ItemHeight = 43;
            cboSala.Location = new Point(18, 150);
            cboSala.MaxDropDownItems = 4;
            cboSala.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            cboSala.Name = "cboSala";
            cboSala.Size = new Size(491, 49);
            cboSala.StartIndex = 0;
            cboSala.TabIndex = 5;
            // 
            // dtpData
            // 
            dtpData.Font = new Font("Segoe UI", 14F);
            dtpData.Format = DateTimePickerFormat.Short;
            dtpData.Location = new Point(102, 32);
            dtpData.Name = "dtpData";
            dtpData.Size = new Size(122, 32);
            dtpData.TabIndex = 6;
            // 
            // dtpHora
            // 
            dtpHora.CustomFormat = "HH:mm";
            dtpHora.Font = new Font("Segoe UI", 14F);
            dtpHora.Format = DateTimePickerFormat.Custom;
            dtpHora.Location = new Point(266, 32);
            dtpHora.Name = "dtpHora";
            dtpHora.ShowUpDown = true;
            dtpHora.Size = new Size(91, 32);
            dtpHora.TabIndex = 7;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(102, 10);
            materialLabel1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(35, 19);
            materialLabel1.TabIndex = 8;
            materialLabel1.Text = "Data";
            // 
            // txtPreco
            // 
            txtPreco.AllowPromptAsInput = true;
            txtPreco.AnimateReadOnly = false;
            txtPreco.AsciiOnly = false;
            txtPreco.BackgroundImageLayout = ImageLayout.None;
            txtPreco.BeepOnError = false;
            txtPreco.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            txtPreco.Depth = 0;
            txtPreco.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtPreco.HidePromptOnLeave = false;
            txtPreco.HideSelection = true;
            txtPreco.Hint = "Preço";
            txtPreco.InsertKeyMode = InsertKeyMode.Default;
            txtPreco.LeadingIcon = null;
            txtPreco.Location = new Point(18, 220);
            txtPreco.Mask = "$ 09.99";
            txtPreco.MaxLength = 32767;
            txtPreco.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtPreco.Name = "txtPreco";
            txtPreco.PasswordChar = '\0';
            txtPreco.PrefixSuffixText = null;
            txtPreco.PromptChar = ' ';
            txtPreco.ReadOnly = false;
            txtPreco.RejectInputOnFirstFailure = false;
            txtPreco.ResetOnPrompt = true;
            txtPreco.ResetOnSpace = true;
            txtPreco.RightToLeft = RightToLeft.No;
            txtPreco.SelectedText = "";
            txtPreco.SelectionLength = 0;
            txtPreco.SelectionStart = 8;
            txtPreco.ShortcutsEnabled = true;
            txtPreco.Size = new Size(209, 48);
            txtPreco.SkipLiterals = true;
            txtPreco.TabIndex = 9;
            txtPreco.TabStop = false;
            txtPreco.Text = "1000";
            txtPreco.TextAlign = HorizontalAlignment.Right;
            txtPreco.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            txtPreco.TrailingIcon = null;
            txtPreco.UseSystemPasswordChar = false;
            txtPreco.ValidatingType = null;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(266, 10);
            materialLabel2.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(35, 19);
            materialLabel2.TabIndex = 10;
            materialLabel2.Text = "Hora";
            // 
            // CadastroSessao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 450);
            Location = new Point(0, 0);
            MinimumSize = new Size(640, 450);
            Name = "CadastroSessao";
            Text = "Cadastro de Sessão";
            tabPageCadastro.ResumeLayout(false);
            tabPageCadastro.PerformLayout();
            tabControlCadastro.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.MaterialComboBox cboFilme;
        private ReaLTaiizor.Controls.MaterialComboBox cboSala;
        private System.Windows.Forms.DateTimePicker dtpData;
        private System.Windows.Forms.DateTimePicker dtpHora;
        private ReaLTaiizor.Controls.MaterialMaskedTextBox txtPreco;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel1;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel2;
    }
}