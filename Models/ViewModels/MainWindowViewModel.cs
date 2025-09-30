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
    [ObservableProperty] public bool segundoformulario = false;
    [ObservableProperty] public bool lista = false;
    [ObservableProperty] public bool promocion = false;
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
            Promocion = true;
        }
    }

    [RelayCommand]
    public void SegundaOportunidad()
    {
        if (Primerformulario == false)
        {
            Primerformulario = true;
            Promocion = false;
        }
        else
        {
            Primerformulario = false;
            Promocion = true;
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

    private void CargarEmpresas()
        {
            Empresas emp1 = new Empresas();
            emp1.nombreEmpresa = "Monstruos S.A";
            emp1.direccion = "C/San martin";
            emp1.telefono = "123 456 789";
            emp1.numEmpleados = 200;
            Empresas.Add(emp1);
            Empresas emp2 = new Empresas();
            emp2.nombreEmpresa = "Fundido Org.";
            emp2.direccion = "C/Precilio";
            emp2.telefono = "999 111 222";
            emp2.numEmpleados = 50;
            Empresas.Add(emp2);
            Empresas emp3 = new Empresas();
            emp3.nombreEmpresa = "Pulseras Inc.";
            emp3.direccion = "C/De la vega";
            emp3.telefono = "731 789 123";
            emp3.numEmpleados = 2000;
            Empresas.Add(emp3);
        }
           

        
    public MainWindowViewModel()
    {
        CargarEmpresas();
    }
}
