using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisorDeImagenes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Mostrar el diálogo para seleccionar una carpeta
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                // Limpiar el panel antes de cargar nuevas imágenes
                panel1.Controls.Clear();

                // Obtener la ruta de la carpeta seleccionada
                string carpetaSeleccionada = folderBrowserDialog1.SelectedPath;

                // Obtener la lista de archivos de imagen en la carpeta (solo archivos .jpg)
                string[] archivos = Directory.GetFiles(carpetaSeleccionada, "*.jpg");

                // Variables para controlar la posición de las imágenes en el Panel
                int posX = 10, posY = 10; // Posición inicial (márgenes)
                int anchoThumbnail = 100; // Ancho fijo para las miniaturas
                int altoThumbnail = 100; // Alto fijo para las miniaturas

                // Recorrer cada archivo de imagen en la carpeta
                foreach (string archivo in archivos)
                {
                    // Cargar la imagen original
                    Image imagenOriginal = Image.FromFile(archivo);

                    // Redimensionar la imagen al tamaño deseado (100x100)
                    Image imagenRedimensionada = RedimensionarImagen(imagenOriginal, anchoThumbnail, altoThumbnail);

                    // Crear un PictureBox para mostrar la imagen redimensionada
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = imagenRedimensionada; // Asignar la imagen redimensionada
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom; // Ajustar la imagen al tamaño del PictureBox
                    pictureBox.Width = anchoThumbnail; // Ancho fijo
                    pictureBox.Height = altoThumbnail; // Alto fijo
                    pictureBox.Location = new Point(posX, posY); // Establecer la posición en el Panel

                    // Asignar un evento Click a la imagen para abrirla en tamaño completo
                    pictureBox.Click += (s, ev) => MostrarImagenCompleta(archivo);

                    // Agregar el PictureBox al Panel
                    panel1.Controls.Add(pictureBox);

                    // Ajustar la posición para la siguiente imagen
                    posX += anchoThumbnail + 10; // Espacio horizontal entre imágenes
                    if (posX + anchoThumbnail > panel1.Width) // Si no cabe en la misma fila, pasar a la siguiente
                    {
                        posX = 10; // Reiniciar la posición X
                        posY += altoThumbnail + 10; // Mover la posición Y hacia abajo
                    }
                }
            }
        }

        // Método para redimensionar una imagen
        private Image RedimensionarImagen(Image imagenOriginal, int ancho, int alto)
        {
            // Crear un nuevo bitmap con el tamaño deseado
            Bitmap bitmapRedimensionado = new Bitmap(ancho, alto);

            // Crear un objeto Graphics para dibujar la imagen redimensionada
            using (Graphics g = Graphics.FromImage(bitmapRedimensionado))
            {
                // Dibujar la imagen original redimensionada en el bitmap
                g.DrawImage(imagenOriginal, 0, 0, ancho, alto);
            }

            // Devolver la imagen redimensionada
            return bitmapRedimensionado;
        }

        private void MostrarImagenCompleta(string rutaImagen)
        {
            // Crear un nuevo formulario para mostrar la imagen en tamaño completo
            Form formImagenCompleta = new Form();
            formImagenCompleta.Text = Path.GetFileName(rutaImagen); // Establecer el título del formulario con el nombre de la imagen

            // Crear un PictureBox para mostrar la imagen en tamaño completo
            PictureBox pictureBoxCompleto = new PictureBox();
            pictureBoxCompleto.Image = Image.FromFile(rutaImagen); // Cargar la imagen desde el archivo
            pictureBoxCompleto.SizeMode = PictureBoxSizeMode.Zoom; // Ajustar la imagen al tamaño del PictureBox
            pictureBoxCompleto.Dock = DockStyle.Fill; // Hacer que el PictureBox ocupe todo el espacio del formulario

            // Agregar el PictureBox al formulario
            formImagenCompleta.Controls.Add(pictureBoxCompleto);

            // Mostrar el formulario como un diálogo modal
            formImagenCompleta.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}