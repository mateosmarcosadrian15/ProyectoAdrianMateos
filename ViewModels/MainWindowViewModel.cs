    using System;
    using System.Collections.ObjectModel;
    using Avalonia.Controls;
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using ProyectoAdrianMateos.Models;

    namespace ProyectoAdrianMateos.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "Welcome to Avalonia!";
    [ObservableProperty]public bool primerformulario = true;
    [ObservableProperty] public bool segundoformulario = true;
    [ObservableProperty] public bool lista = false;
    [ObservableProperty]public Empresas empresa = new();
    [ObservableProperty] private ObservableCollection<Empresas> empresas = new();
    
    [RelayCommand]
    public void QuitarPrimerFormulario(object parameter)
    {
        CheckBox parametro = (CheckBox)parameter;
        if (Primerformulario)
        {
            Primerformulario = false;
            lista = true;
        }
        else
        {
            Primerformulario = true;
            lista = false;
        }

        if (parametro.IsChecked == true)
        {
            Segundoformulario = true;
        }
        else
        {
            Segundoformulario = false;
        }
    }

    [RelayCommand]
    public void QuitarSegundoformulario()
    {
        if (Segundoformulario)
        {
            Segundoformulario = true;
        }
        else
        {
            Segundoformulario = false;
        }
    }
    [RelayCommand]
    public void MostrarEmpresas()
    {
        if (string.IsNullOrWhiteSpace(Empresa.nombreEmpresa))
        {
            Console.Write("Ingrese el nombre de la empresa");
        }
        
        else if (string.IsNullOrWhiteSpace(Empresa.direccion))
        {
            Console.Write("Ingrese la direccion de la empresa");
        }
        
        else if (string.IsNullOrWhiteSpace(Empresa.telefono))
        {
            Console.Write("Ingrese telefono de la empresa");
        }
        
        else if (Empresa.numEmpleados == 0)
        {
            Console.Write("Ingrese minimo 5 empleados");
        }
        else
        {
            Empresas.Add(empresa);
            Empresa = new Empresas();
            
        }
       
    }
}