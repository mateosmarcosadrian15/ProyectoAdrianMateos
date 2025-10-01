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
    [ObservableProperty] public bool perfil = false;
    [ObservableProperty]public Empresas empresa = new();
    [ObservableProperty] private ObservableCollection<Empresas> empresas = new();
    [ObservableProperty] private ObservableCollection<Persona> personas = new();
    [ObservableProperty] public string mensaje = string.Empty;
    [ObservableProperty] public Persona persona = new();
    [RelayCommand]
    public void QuitarPrimerFormulario(object parameter)
    {
        CheckBox parametro = (CheckBox)parameter;
        if (string.IsNullOrEmpty(Persona.nombre))
        {
            Mensaje = "El nombre no puede estar vacio";
            Console.WriteLine("El nombre no puede estar vacio");
           

        }else if (string.IsNullOrEmpty(Persona.apellido))
        {
            Mensaje = "El apellido no puede estar vacio";
            Console.WriteLine("El nombre no puede estar vacio");
        }else if (string.IsNullOrEmpty(Persona.telefono))
        {
            Mensaje = "El telefono no puede estar vacio";
            Console.WriteLine("El telefono no puede estar vacio");
        }else if (string.IsNullOrEmpty(Persona.email))
        {
            Mensaje = "El email no puede estar vacio";
            Console.WriteLine("El email no puede estar vacio");
        }
        else
        {
            Mensaje = "";
            Persona persona = new Persona();
            persona.nombre = Persona.nombre;
            persona.apellido = Persona.apellido;
            persona.telefono = Persona.telefono;
            persona.email = Persona.email;
            Personas.Add(persona);
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
                Perfil = true;
            }
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
    public void VolverAlPrincipio()
    {
        Primerformulario = true;
        Segundoformulario = false;
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
            Mensaje = "El nombre de la empresa no puede estar vacio";
            Console.Write("Ingrese el nombre de la empresa");
        }

        else if (string.IsNullOrWhiteSpace(Empresa.direccion))
        {
            Mensaje = "La direccion de la empresa no puede estar vacio";
            Console.Write("Ingrese la direccion de la empresa");
        }

        else if (string.IsNullOrWhiteSpace(Empresa.telefono))
        {
            Mensaje = "La telefono de empresa no puede estar vacio";
            Console.Write("Ingrese telefono de la empresa");
        }

        else if (Empresa.numEmpleados == 0)
        {
            Mensaje = "Debes añadir minimo 5 empleados a tu empresa";
            Console.Write("Ingrese minimo 5 empleados");
        }
        else
        {
            Mensaje = "";
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
