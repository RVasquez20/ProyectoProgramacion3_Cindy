namespace ProyectoProgramacion
{
    partial class Palabras
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
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.label1 = new System.Windows.Forms.Label();
            this.ListaPalabras = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.Filter = "*ListadoPalabras.txt*";
            this.fileSystemWatcher1.NotifyFilter = System.IO.NotifyFilters.LastWrite;
            this.fileSystemWatcher1.SynchronizingObject = this;
            this.fileSystemWatcher1.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Changed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(98, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 96);
            this.label1.TabIndex = 1;
            this.label1.Text = "    Listado \r\n       De\r\n   Palabras\r\nConfirmadas";
            // 
            // ListaPalabras
            // 
            this.ListaPalabras.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListaPalabras.Location = new System.Drawing.Point(13, 122);
            this.ListaPalabras.Multiline = true;
            this.ListaPalabras.Name = "ListaPalabras";
            this.ListaPalabras.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ListaPalabras.Size = new System.Drawing.Size(276, 352);
            this.ListaPalabras.TabIndex = 2;
            // 
            // Palabras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(301, 486);
            this.Controls.Add(this.ListaPalabras);
            this.Controls.Add(this.label1);
            this.Name = "Palabras";
            this.Text = "Palabras";
            this.Load += new System.EventHandler(this.Palabras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ListaPalabras;
    }
}