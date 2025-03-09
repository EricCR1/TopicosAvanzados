namespace Componentes_GUI
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.userControl11 = new GUI_Componentes.UserControl1();
            this.label1 = new System.Windows.Forms.Label();
            this.miTextBox1 = new MisControles.MiTextBox();
            this.botonPersonalizado1 = new MisControles.BotonPersonalizado();
            this.SuspendLayout();
            // 
            // userControl11
            // 
            this.userControl11.Location = new System.Drawing.Point(-4, -1);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(410, 348);
            this.userControl11.TabIndex = 0;
            this.userControl11.Load += new System.EventHandler(this.userControl11_Load);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(365, 398);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "SI SIRVIO :)";
            // 
            // miTextBox1
            // 
            this.miTextBox1.Location = new System.Drawing.Point(73, 375);
            this.miTextBox1.Name = "miTextBox1";
            this.miTextBox1.Size = new System.Drawing.Size(98, 21);
            this.miTextBox1.TabIndex = 3;
            this.miTextBox1.TipoValidacion = null;
            // 
            // botonPersonalizado1
            // 
            this.botonPersonalizado1.ColorBase = System.Drawing.SystemColors.ControlDark;
            this.botonPersonalizado1.ColorResaltado = System.Drawing.Color.LightCoral;
            this.botonPersonalizado1.Location = new System.Drawing.Point(194, 375);
            this.botonPersonalizado1.Name = "botonPersonalizado1";
            this.botonPersonalizado1.Size = new System.Drawing.Size(74, 22);
            this.botonPersonalizado1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 444);
            this.Controls.Add(this.botonPersonalizado1);
            this.Controls.Add(this.miTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userControl11);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GUI_Componentes.UserControl1 userControl11;
        private System.Windows.Forms.Label label1;
        private MisControles.MiTextBox miTextBox1;
        private MisControles.BotonPersonalizado botonPersonalizado1;
    }
}

