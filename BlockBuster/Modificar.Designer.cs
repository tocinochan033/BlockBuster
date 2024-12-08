namespace BlockBuster
{
    partial class Modificar
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
            this.estatusComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.eliminarButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPeliculas)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPeliculas
            // 
            this.dataGridViewPeliculas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPeliculas.Location = new System.Drawing.Point(31, 22);
            this.dataGridViewPeliculas.Name = "dataGridViewPeliculas";
            this.dataGridViewPeliculas.RowHeadersWidth = 51;
            this.dataGridViewPeliculas.RowTemplate.Height = 24;
            this.dataGridViewPeliculas.Size = new System.Drawing.Size(340, 268);
            this.dataGridViewPeliculas.TabIndex = 0;
            // 
            // estatusComboBox
            // 
            this.estatusComboBox.FormattingEnabled = true;
            this.estatusComboBox.Location = new System.Drawing.Point(284, 347);
            this.estatusComboBox.Name = "estatusComboBox";
            this.estatusComboBox.Size = new System.Drawing.Size(87, 24);
            this.estatusComboBox.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(280, 313);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 22);
            this.label6.TabIndex = 21;
            this.label6.Text = "Estatus";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(258, 393);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 35);
            this.button1.TabIndex = 23;
            this.button1.Text = "modificar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // eliminarButton
            // 
            this.eliminarButton.Location = new System.Drawing.Point(31, 393);
            this.eliminarButton.Name = "eliminarButton";
            this.eliminarButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.eliminarButton.Size = new System.Drawing.Size(112, 35);
            this.eliminarButton.TabIndex = 24;
            this.eliminarButton.Text = "Eliminar\'";
            this.eliminarButton.UseVisualStyleBackColor = true;
            this.eliminarButton.Click += new System.EventHandler(this.eliminarButton_Click);
            // 
            // Modificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 450);
            this.Controls.Add(this.eliminarButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.estatusComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridViewPeliculas);
            this.Name = "Modificar";
            this.Text = "Modificar";
            this.Load += new System.EventHandler(this.Modificar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPeliculas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPeliculas;
        private System.Windows.Forms.ComboBox estatusComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button eliminarButton;
    }
}