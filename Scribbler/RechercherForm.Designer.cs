namespace Scribbler
{
    partial class RechercherForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.rechercheTextBox = new System.Windows.Forms.TextBox();
            this.suivantButton = new System.Windows.Forms.Button();
            this.annulerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mot à rechercher:";
            // 
            // rechercheTextBox
            // 
            this.rechercheTextBox.Location = new System.Drawing.Point(122, 63);
            this.rechercheTextBox.Name = "rechercheTextBox";
            this.rechercheTextBox.Size = new System.Drawing.Size(149, 20);
            this.rechercheTextBox.TabIndex = 1;
            // 
            // suivantButton
            // 
            this.suivantButton.Location = new System.Drawing.Point(316, 33);
            this.suivantButton.Name = "suivantButton";
            this.suivantButton.Size = new System.Drawing.Size(75, 23);
            this.suivantButton.TabIndex = 2;
            this.suivantButton.Text = "Suivant";
            this.suivantButton.UseVisualStyleBackColor = true;
            this.suivantButton.Click += new System.EventHandler(this.SuivantButton_Click);
            // 
            // annulerButton
            // 
            this.annulerButton.Location = new System.Drawing.Point(316, 81);
            this.annulerButton.Name = "annulerButton";
            this.annulerButton.Size = new System.Drawing.Size(75, 23);
            this.annulerButton.TabIndex = 3;
            this.annulerButton.Text = "Annuler";
            this.annulerButton.UseVisualStyleBackColor = true;
            this.annulerButton.Click += new System.EventHandler(this.AnnulerButton_Click);
            // 
            // RechercherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 184);
            this.Controls.Add(this.annulerButton);
            this.Controls.Add(this.suivantButton);
            this.Controls.Add(this.rechercheTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RechercherForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rechercher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox rechercheTextBox;
        private System.Windows.Forms.Button suivantButton;
        private System.Windows.Forms.Button annulerButton;
    }
}