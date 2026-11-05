using ReaLTaiizor.Controls;

namespace CinemaApp.Cadastros
{
    partial class CadastroFilme
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
            txtId = new MaterialTextBoxEdit();
            txtNome = new MaterialTextBoxEdit();
            txtClassificacao = new MaterialTextBoxEdit();
            txtDuracao = new MaterialTextBoxEdit();
            cboGenero = new MaterialComboBox();

            tabPageCadastro.SuspendLayout();
            SuspendLayout();

            // 
            // txtId
            // 
            txtId.AnimateReadOnly = false;
            txtId.Depth = 0;
            txtId.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            txtId.Hint = "ID";
            txtId.LeadingIcon = null;
            txtId.Location = new System.Drawing.Point(30, 20);
            txtId.MaxLength = 50;
            txtId.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtId.Name = "txtId";
            txtId.PasswordChar = '\0';
            txtId.PrefixSuffixText = string.Empty;
            txtId.ReadOnly = true;
            txtId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            txtId.SelectedText = "";
            txtId.SelectionLength = 0;
            txtId.SelectionStart = 0;
            txtId.ShortcutsEnabled = true;
            txtId.Size = new System.Drawing.Size(100, 48);
            txtId.TabIndex = 0;
            txtId.TabStop = false;
            txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            txtId.TrailingIcon = null;
            txtId.UseSystemPasswordChar = false;

            // 
            // txtNome
            // 
            txtNome.AnimateReadOnly = false;
            txtNome.Depth = 0;
            txtNome.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            txtNome.Hint = "Nome do Filme";
            txtNome.LeadingIcon = null;
            txtNome.Location = new System.Drawing.Point(30, 80);
            txtNome.MaxLength = 100;
            txtNome.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtNome.Name = "txtNome";
            txtNome.PasswordChar = '\0';
            txtNome.PrefixSuffixText = string.Empty;
            txtNome.ReadOnly = false;
            txtNome.RightToLeft = System.Windows.Forms.RightToLeft.No;
            txtNome.SelectedText = "";
            txtNome.SelectionLength = 0;
            txtNome.SelectionStart = 0;
            txtNome.ShortcutsEnabled = true;
            txtNome.Size = new System.Drawing.Size(400, 48);
            txtNome.TabIndex = 1;
            txtNome.TabStop = false;
            txtNome.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            txtNome.TrailingIcon = null;
            txtNome.UseSystemPasswordChar = false;

            // 
            // txtClassificacao
            // 
            txtClassificacao.AnimateReadOnly = false;
            txtClassificacao.Depth = 0;
            txtClassificacao.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            txtClassificacao.Hint = "Classificação Indicativa (ex: 14 anos)";
            txtClassificacao.LeadingIcon = null;
            txtClassificacao.Location = new System.Drawing.Point(30, 140);
            txtClassificacao.MaxLength = 50;
            txtClassificacao.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtClassificacao.Name = "txtClassificacao";
            txtClassificacao.PasswordChar = '\0';
            txtClassificacao.PrefixSuffixText = string.Empty;
            txtClassificacao.ReadOnly = false;
            txtClassificacao.RightToLeft = System.Windows.Forms.RightToLeft.No;
            txtClassificacao.SelectedText = "";
            txtClassificacao.SelectionLength = 0;
            txtClassificacao.SelectionStart = 0;
            txtClassificacao.ShortcutsEnabled = true;
            txtClassificacao.Size = new System.Drawing.Size(400, 48);
            txtClassificacao.TabIndex = 2;
            txtClassificacao.TabStop = false;
            txtClassificacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            txtClassificacao.TrailingIcon = null;
            txtClassificacao.UseSystemPasswordChar = false;

            // 
            // txtDuracao
            // 
            txtDuracao.AnimateReadOnly = false;
            txtDuracao.Depth = 0;
            txtDuracao.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            txtDuracao.Hint = "Duração (em minutos)";
            txtDuracao.LeadingIcon = null;
            txtDuracao.Location = new System.Drawing.Point(30, 200);
            txtDuracao.MaxLength = 10;
            txtDuracao.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtDuracao.Name = "txtDuracao";
            txtDuracao.PasswordChar = '\0';
            txtDuracao.PrefixSuffixText = string.Empty;
            txtDuracao.ReadOnly = false;
            txtDuracao.RightToLeft = System.Windows.Forms.RightToLeft.No;
            txtDuracao.SelectedText = "";
            txtDuracao.SelectionLength = 0;
            txtDuracao.SelectionStart = 0;
            txtDuracao.ShortcutsEnabled = true;
            txtDuracao.Size = new System.Drawing.Size(400, 48);
            txtDuracao.TabIndex = 3;
            txtDuracao.TabStop = false;
            txtDuracao.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            txtDuracao.TrailingIcon = null;
            txtDuracao.UseSystemPasswordChar = false;

            // 
            // cboGenero
            // 
            cboGenero.AutoResize = false;
            cboGenero.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            cboGenero.Depth = 0;
            cboGenero.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            cboGenero.DropDownHeight = 174;
            cboGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboGenero.DropDownWidth = 121;
            cboGenero.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            cboGenero.ForeColor = System.Drawing.Color.FromArgb(222, 0, 0, 0);
            cboGenero.FormattingEnabled = true;
            cboGenero.Hint = "Selecione o Gênero";
            cboGenero.IntegralHeight = false;
            cboGenero.ItemHeight = 43;
            cboGenero.Location = new System.Drawing.Point(30, 260);
            cboGenero.MaxDropDownItems = 4;
            cboGenero.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            cboGenero.Name = "cboGenero";
            cboGenero.Size = new System.Drawing.Size(400, 49);
            cboGenero.StartIndex = 0;
            cboGenero.TabIndex = 4;

            // 
            // tabPageCadastro
            // 
            tabPageCadastro.Controls.Add(txtId);
            tabPageCadastro.Controls.Add(txtNome);
            tabPageCadastro.Controls.Add(txtClassificacao);
            tabPageCadastro.Controls.Add(txtDuracao);
            tabPageCadastro.Controls.Add(cboGenero);

            // 
            // CadastroFilme
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(694, 520);
            DrawerUsePreProcessIcons = false;
            Name = "CadastroFilme";
            Text = "Cadastro de Filme";

            tabPageCadastro.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private MaterialTextBoxEdit txtId;
        private MaterialTextBoxEdit txtNome;
        private MaterialTextBoxEdit txtClassificacao;
        private MaterialTextBoxEdit txtDuracao;
        private MaterialComboBox cboGenero;
    }
}