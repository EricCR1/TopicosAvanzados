using System;
using System.Windows.Forms;

namespace Contactos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Realizador por: \n \n Eric Cabrera \n 23760307 \n 4SA", "Acerca de", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text.Trim();
            string telefono = textBox2.Text.Trim();
            string correo = textBox3.Text.Trim();


            if (!string.IsNullOrWhiteSpace(nombre) && !string.IsNullOrWhiteSpace(telefono) && !string.IsNullOrWhiteSpace(correo))
            {
                MessageBox.Show("Se ha añadido a la lista!", "Envío Correcto");
                listBox1.Items.Add($"{nombre} - {telefono} - {correo}");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";

            }
            else
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Selecciona un contacto para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}