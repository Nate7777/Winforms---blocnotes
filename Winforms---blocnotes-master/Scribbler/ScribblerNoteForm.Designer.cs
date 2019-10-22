namespace Scribbler
{
    partial class ScribblerNoteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScribblerNoteForm));
            this.noteRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // noteRichTextBox
            // 
            this.noteRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.noteRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.noteRichTextBox.Name = "noteRichTextBox";
            this.noteRichTextBox.Size = new System.Drawing.Size(371, 279);
            this.noteRichTextBox.TabIndex = 0;
            this.noteRichTextBox.Text = "";
            this.noteRichTextBox.SelectionChanged += new System.EventHandler(this.noteRichTextBox_SelectionChanged);
            // 
            // ScribblerNoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 279);
            this.Controls.Add(this.noteRichTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScribblerNoteForm";
            this.Text = "Note";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScribblerNoteForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.RichTextBox noteRichTextBox;
    }
}