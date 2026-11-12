namespace CinemaApp.Cadastros
{
    partial class CadastroSala
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
            txtId = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            nudNumero = new NumericUpDown();
            nudCapacidade = new NumericUpDown();
            nudFileiras = new NumericUpDown();
            nudAssentos = new NumericUpDown();
            lblNumero = new ReaLTaiizor.Controls.MaterialLabel();
            lblCapacidade = new ReaLTaiizor.Controls.MaterialLabel();
            lblFileiras = new ReaLTaiizor.Controls.MaterialLabel();
            lblAssentos = new ReaLTaiizor.Controls.MaterialLabel();
            tabPageCadastro.SuspendLayout();
            tabControlCadastro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudNumero).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCapacidade).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudFileiras).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudAssentos).BeginInit();
            SuspendLayout();
            // 
            // tabPageCadastro
            // 
            tabPageCadastro.Controls.Add(txtId);
            tabPageCadastro.Controls.Add(lblNumero);
            tabPageCadastro.Controls.Add(lblCapacidade);
            tabPageCadastro.Controls.Add(lblFileiras);
            tabPageCadastro.Controls.Add(lblAssentos);
            tabPageCadastro.Controls.Add(nudNumero);
            tabPageCadastro.Controls.Add(nudCapacidade);
            tabPageCadastro.Controls.Add(nudFileiras);
            tabPageCadastro.Controls.Add(nudAssentos);
            // 
            // txtId
            // 
            txtId.AnimateReadOnly = false;
            txtId.AutoCompleteMode = AutoCompleteMode.None;
            txtId.AutoCompleteSource = AutoCompleteSource.None;
            txtId.BackgroundImageLayout = ImageLayout.None;
            txtId.CharacterCasing = CharacterCasing.Normal;
            txtId.Depth = 0;
            txtId.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtId.HideSelection = true;
            txtId.Hint = "Id";
            txtId.LeadingIcon = null;
            txtId.Location = new Point(18, 16);
            txtId.MaxLength = 32767;
            txtId.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtId.Name = "txtId";
            txtId.PasswordChar = '\0';
            txtId.PrefixSuffixText = null;
            txtId.ReadOnly = true;
            txtId.RightToLeft = RightToLeft.No;
            txtId.SelectedText = "";
            txtId.SelectionLength = 0;
            txtId.SelectionStart = 0;
            txtId.ShortcutsEnabled = true;
            txtId.Size = new Size(78, 48);
            txtId.TabIndex = 0;
            txtId.TabStop = false;
            txtId.TextAlign = HorizontalAlignment.Left;
            txtId.TrailingIcon = null;
            txtId.UseSystemPasswordChar = false;
            // 
            // lblNumero
            // 
            lblNumero.AutoSize = true;
            lblNumero.Depth = 0;
            lblNumero.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblNumero.Location = new Point(18, 74);
            lblNumero.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblNumero.Name = "lblNumero";
            lblNumero.Size = new Size(93, 19);
            lblNumero.TabIndex = 5;
            lblNumero.Text = "Número Sala";
            // 
            // lblCapacidade
            // 
            lblCapacidade.AutoSize = true;
            lblCapacidade.Depth = 0;
            lblCapacidade.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblCapacidade.Location = new Point(154, 74);
            lblCapacidade.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblCapacidade.Name = "lblCapacidade";
            lblCapacidade.Size = new Size(85, 19);
            lblCapacidade.TabIndex = 6;
            lblCapacidade.Text = "Capacidade";
            // 
            // lblFileiras
            // 
            lblFileiras.AutoSize = true;
            lblFileiras.Depth = 0;
            lblFileiras.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblFileiras.Location = new Point(18, 137);
            lblFileiras.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblFileiras.Name = "lblFileiras";
            lblFileiras.Size = new Size(52, 19);
            lblFileiras.TabIndex = 7;
            lblFileiras.Text = "Fileiras";
            // 
            // lblAssentos
            // 
            lblAssentos.AutoSize = true;
            lblAssentos.Depth = 0;
            lblAssentos.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblAssentos.Location = new Point(154, 137);
            lblAssentos.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblAssentos.Name = "lblAssentos";
            lblAssentos.Size = new Size(66, 19);
            lblAssentos.TabIndex = 8;
            lblAssentos.Text = "Assentos";
            // 
            // nudNumero
            // 
            nudNumero.Location = new Point(18, 96);
            nudNumero.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudNumero.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudNumero.Name = "nudNumero";
            nudNumero.Size = new Size(120, 23);
            nudNumero.TabIndex = 1;
            nudNumero.TextAlign = HorizontalAlignment.Center;
            nudNumero.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // nudCapacidade
            // 
            nudCapacidade.Location = new Point(154, 96);
            nudCapacidade.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudCapacidade.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCapacidade.Name = "nudCapacidade";
            nudCapacidade.Size = new Size(120, 23);
            nudCapacidade.TabIndex = 2;
            nudCapacidade.TextAlign = HorizontalAlignment.Center;
            nudCapacidade.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // nudFileiras
            // 
            nudFileiras.Location = new Point(18, 159);
            nudFileiras.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudFileiras.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudFileiras.Name = "nudFileiras";
            nudFileiras.Size = new Size(120, 23);
            nudFileiras.TabIndex = 3;
            nudFileiras.TextAlign = HorizontalAlignment.Center;
            nudFileiras.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // nudAssentos
            // 
            nudAssentos.Location = new Point(154, 159);
            nudAssentos.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudAssentos.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudAssentos.Name = "nudAssentos";
            nudAssentos.Size = new Size(120, 23);
            nudAssentos.TabIndex = 4;
            nudAssentos.TextAlign = HorizontalAlignment.Center;
            nudAssentos.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // CadastroSala
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 400);
            Location = new Point(0, 0);
            MinimumSize = new Size(500, 400);
            Name = "CadastroSala";
            Text = "Cadastro de Sala";
            tabPageCadastro.ResumeLayout(false);
            tabPageCadastro.PerformLayout();
            tabControlCadastro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudNumero).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCapacidade).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudFileiras).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudAssentos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.MaterialTextBoxEdit txtId;
        private NumericUpDown nudNumero;
        private NumericUpDown nudCapacidade;
        private NumericUpDown nudFileiras;
        private NumericUpDown nudAssentos;
        private ReaLTaiizor.Controls.MaterialLabel lblNumero;
        private ReaLTaiizor.Controls.MaterialLabel lblCapacidade;
        private ReaLTaiizor.Controls.MaterialLabel lblFileiras;
        private ReaLTaiizor.Controls.MaterialLabel lblAssentos;
    }
}