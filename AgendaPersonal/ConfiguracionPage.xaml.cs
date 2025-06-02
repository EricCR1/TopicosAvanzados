namespace AgendaPersonal;

public partial class ConfiguracionPage : ContentPage
{
    public ConfiguracionPage()
    {
        InitializeComponent();
    }
    private void OnThemeToggleClicked(object sender, EventArgs e)
    {
        // Obtén el tema actual
        var currentTheme = Application.Current.UserAppTheme;

        // Cambia al otro tema
        if (currentTheme == AppTheme.Dark)
        {
            Application.Current.UserAppTheme = AppTheme.Light;
            
        }
        else
        {
            Application.Current.UserAppTheme = AppTheme.Dark;
            
        }
    }
}

