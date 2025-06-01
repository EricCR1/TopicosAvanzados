using AgendaPersonal.Modelos;
using AgendaPersonal.Datos;

namespace AgendaPersonal;

public partial class CrearContactoPage : ContentPage
{

    private ContactoDatabase db = new ContactoDatabase();
    private Contacto contacto;

    public CrearContactoPage()
    {
        InitializeComponent();

        contacto = new Contacto();

    }
    public CrearContactoPage(Contacto c)
    {
        InitializeComponent();

        contacto = c;

        nombreEntry.Text = contacto.Nombre;
        telefonoEntry.Text = contacto.Telefono;
        correoEntry.Text = contacto.Correo;
    }

    private async void OnGuardarClicked(object sender, EventArgs e)
    {

        if (string.IsNullOrWhiteSpace(nombreEntry.Text) ||
            string.IsNullOrWhiteSpace(telefonoEntry.Text) ||
            string.IsNullOrWhiteSpace(correoEntry.Text))
        {
            await DisplayAlert("Campos requeridos", "Todos los campos son obligatorios.", "OK");
            return;
        }

        contacto.Nombre = nombreEntry.Text;
        contacto.Telefono = telefonoEntry.Text;
        contacto.Correo = correoEntry.Text;

        await db.GuardarContactoAsync(contacto);
        await Navigation.PopAsync();
    }
}