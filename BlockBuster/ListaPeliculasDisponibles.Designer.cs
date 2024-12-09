namespace BlockBuster
{
    partial class ListaPeliculasDisponibles
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
            this.dataGridViewPeliculas = new System.Windows.Forms.DataGridView();
            this.closeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPeliculas)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPeliculas
            // 
            this.dataGridViewPeliculas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPeliculas.Location = new System.Drawing.Point(11, 12);
            this.dataGridViewPeliculas.Name = "dataGridViewPeliculas";
            this.dataGridViewPeliculas.RowHeadersWidth = 51;
            this.dataGridViewPeliculas.RowTemplate.Height = 24;
            this.dataGridViewPeliculas.Size = new System.Drawing.Size(740, 282);
            this.dataGridViewPeliculas.TabIndex = 0;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(11, 300);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(83, 36);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Salir";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // ListaPeliculasDisponibles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 344);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.dataGridViewPeliculas);
            this.Name = "ListaPeliculasDisponibles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ListaPeliculasDisponibles";
            this.Load += new System.EventHandler(this.ListaPeliculasDisponibles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPeliculas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPeliculas;
        private System.Windows.Forms.Button closeButton;
    }
}