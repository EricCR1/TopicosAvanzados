using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MisControles
{
    public partial class MiTextBox : UserControl
    {
        public System.Windows.Forms.TextBox CajaTexto { get; private set; }
        public string TipoValidacion { get; set; }

        public MiTextBox()
        {
            InitializeComponent();
            CajaTexto = textBox1;
        }

        public void ValidarRFC()
        {
            string rfc = CajaTexto.Text.ToUpper(); // Convertir a mayúsculas automáticamente
            string patronRFC = @"^[A-ZÑ&]{4}\d{6}[A-Z\d]{2,3}$";

            if (Regex.IsMatch(rfc, patronRFC))
            {
                CajaTexto.BackColor = Color.LightGreen;
            }
            else
            {
                CajaTexto.BackColor = Color.LightPink;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ValidarRFC();
        }
    }
}
