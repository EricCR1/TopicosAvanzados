using AgendaPersonal.Modelos;
using AgendaPersonal.Datos;
//using AgendaPersonal.Utils;
using System.Collections.ObjectModel;

namespace AgendaPersonal;

public partial class ContactosPage : ContentPage
{

    private ContactoDatabase db = new ContactoDatabase();
    public ObservableCollection<Contacto> Contactos { get; set; }

    public ContactosPage()
    {
        InitializeComponent();
        Contactos = new ObservableCollection<Contacto>
        {
            new Contacto { Nombre = "Ana", Telefono = "1234567890", Correo = "ana@mail.com" },
            new Contacto { Nombre = "Luis", Telefono = "0987654321", Correo = "luis@mail.com" }
        };
        BindingContext = this;
    }

    private async void OnContactoSeleccionado(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Contacto contactoSeleccionado)
        {
            await Shell.Current.GoToAsync(nameof(DetalleContactoPage), true, new Dictionary<string, object>
            {
                { "Contacto", contactoSeleccionado }
            });
        }
        ((CollectionView)sender).SelectedItem = null;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        ContactosCollectionView.ItemsSource = await db.ObtenerContactosAsync();
    }

    private async void OnEliminarContacto(object sender, EventArgs e)
    {
        if (((SwipeItem)sender).BindingContext is Contacto contacto)
        {
            bool confirm = await DisplayAlert("Confirmar", $"¿Eliminar a {contacto.Nombre}?", "Sí", "No");
            if (confirm)
            {

                await db.EliminarContactoAsync(contacto);
                ContactosCollectionView.ItemsSource = await db.ObtenerContactosAsync();
            }
        }
    }
}



/*public class Contacto
{
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public string Correo { get; set; }
    public string Direccion { get; set; } // Para DetalleContactoPage
}*/