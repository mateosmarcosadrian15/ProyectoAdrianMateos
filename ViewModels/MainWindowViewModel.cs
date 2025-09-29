    using Avalonia.Controls;
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;

    namespace ProyectoAdrianMateos.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "Welcome to Avalonia!";
    [ObservableProperty]public bool primerformulario = true;
    [RelayCommand]
    public void QuitarPrimerFormulario(object parameter)
    {
        CheckBox parametro = (CheckBox)parameter;
        if (parametro.IsChecked == true)
        {
            primerformulario = false;
        }
        else
        {
            primerformulario = true;
        }
    }
}