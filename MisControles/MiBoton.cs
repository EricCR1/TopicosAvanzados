using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MisControles
{
    public partial class BotonPersonalizado : UserControl
    {
        private Color _colorResaltado = Color.LightCoral;
        private Color _colorBase = SystemColors.ControlDark;

        private int contadorClics = 0;
        private Timer temporizadorClics;

        public BotonPersonalizado()
        {
            InitializeComponent();
            BotonCentral.BackColor = _colorBase;

            BotonCentral.MouseEnter += BotonCentral_MouseEnter;
            BotonCentral.MouseLeave += BotonCentral_MouseLeave;
            BotonCentral.MouseClick += BotonCentral_MouseClick;

            temporizadorClics = new Timer();
            temporizadorClics.Interval = SystemInformation.DoubleClickTime;
            temporizadorClics.Tick += TemporizadorClics_Tick;
        }

        public Button BotonCentral => button1;
        public Color ColorResaltado
        {
            get => _colorResaltado;
            set => _colorResaltado = value;
        }

        public Color ColorBase
        {
            get => _colorBase;
            set
            {
                _colorBase = value;
                BotonCentral.BackColor = _colorBase;
            }
        }

        public event EventHandler ClicSimple;
        public event EventHandler DobleClicConfirmado;

        private void BotonCentral_MouseClick(object sender, MouseEventArgs e)
        {
            contadorClics++;
            temporizadorClics.Start();
        }

        private void TemporizadorClics_Tick(object sender, EventArgs e)
        {
            temporizadorClics.Stop();

            if (contadorClics == 1)
            {
                ClicSimple?.Invoke(this, EventArgs.Empty);
            }
            else if (contadorClics == 2)
            {
                var confirmacion = MessageBox.Show(
                    "¿Deseas proceder con la acción de doble clic?",
                    "Confirmación requerida",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmacion == DialogResult.Yes)
                {
                    DobleClicConfirmado?.Invoke(this, EventArgs.Empty);
                }
            }

            contadorClics = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClicSimple?.Invoke(this, e);
        }

        private void BotonCentral_MouseEnter(object sender, EventArgs e)
        {
            BotonCentral.BackColor = _colorResaltado;
        }

        private void BotonCentral_MouseLeave(object sender, EventArgs e)
        {
            BotonCentral.BackColor = _colorBase;
        }
    }
}
