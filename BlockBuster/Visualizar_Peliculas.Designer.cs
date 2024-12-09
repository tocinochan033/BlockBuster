namespace BlockBuster
{
    partial class Visualizar_Peliculas
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
            this.modificarButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPeliculas)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPeliculas
            // 
            this.dataGridViewPeliculas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPeliculas.Location = new System.Drawing.Point(247, 34);
            this.dataGridViewPeliculas.Name = "dataGridViewPeliculas";
            this.dataGridViewPeliculas.RowHeadersWidth = 51;
            this.dataGridViewPeliculas.RowTemplate.Height = 24;
            this.dataGridViewPeliculas.Size = new System.Drawing.Size(1131, 328);
            this.dataGridViewPeliculas.TabIndex = 0;
            this.dataGridViewPeliculas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // modificarButton
            // 
            this.modificarButton.Location = new System.Drawing.Point(12, 209);
            this.modificarButton.Name = "modificarButton";
            this.modificarButton.Size = new System.Drawing.Size(222, 40);
            this.modificarButton.TabIndex = 21;
            this.modificarButton.Text = "Modificar";
            this.modificarButton.UseVisualStyleBackColor = true;
            this.modificarButton.Click += new System.EventHandler(this.modificarButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 117);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(222, 40);
            this.button1.TabIndex = 22;
            this.button1.Text = "Agregar Pelicula";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 163);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(222, 40);
            this.button2.TabIndex = 23;
            this.button2.Text = "Disponibles";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Visualizar_Peliculas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1390, 433);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.modificarButton);
            this.Controls.Add(this.dataGridViewPeliculas);
            this.Name = "Visualizar_Peliculas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visualizar_Peliculas";
            this.Load += new System.EventHandler(this.Visualizar_Peliculas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPeliculas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPeliculas;
        private System.Windows.Forms.Button modificarButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}