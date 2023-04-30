using System;

namespace Proyecto_1_Grupo
{
    internal class Program
    {
        struct Tesla
        {
            public string modelo;
            public int anio;
            public int kmActual;
            public int kmService;
            public string color;
            public string duenio;
        }
        static void Main(string[] args)
        {
            Tesla[] teslas = new Tesla[50];
            int cantidad_autos = 0;
            int opcion;
            do
            {
                Console.WriteLine("Bienvenido al Sistema de Gestion de Autos Tesla");
                Console.WriteLine("Ingrese su Opcion: ");
                Console.WriteLine("");
                Console.WriteLine(" 1 -> Dar de Alta un Tesla.");
                Console.WriteLine(" 2 -> Eliminar un Vehiculo Tesla.");
                Console.WriteLine(" 3 -> Mostrar un Listado de los Vehiculos Tesla que ya Tuvieron su Service.");
                Console.WriteLine(" 4 -> Reordenar el Listado de los Vehiculos Tesla por Año");
                Console.WriteLine(" 5 -> Mostrar el Vehiculo Tesla mas Nuevo.");
                Console.WriteLine("");
                Console.WriteLine(" 6 -> Salir.");
                Console.WriteLine("");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Dar de Alta un Vehiculo Tesla");
                        Console.WriteLine("Ingrese el Modelo del vehiculo Tesla:");
                        string modelo = Console.ReadLine();
                        Console.WriteLine("Ingrese el Año del Modelo:");
                        int anio = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el Kilometraje Actual:");
                        int kmActual = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el Kilometraje de los Service:");
                        int kmService = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el Color del Modelo Tesla:");
                        string color = Console.ReadLine();
                        Console.WriteLine("Ingrese el Dueño del Modelo Tesla");
                        string duenio = Console.ReadLine();
                        teslas[cantidad_autos] = new Tesla
                        {
                            modelo = modelo,
                            anio = anio,
                            kmActual = kmActual,
                            kmService = kmService,
                            color = color,
                            duenio = duenio
                        };
                        cantidad_autos++;
                        Console.WriteLine($"Se ha dado de alta un nuevo vehiculo Tesla: Modelo {modelo}, Año {anio}, " +
                            $"con {kmActual} Kms, el Service es cada {kmService} Kms, de color {color}, y el dueño es {duenio}");
                        break;

                    case 2:
                        Console.WriteLine("Ingrese el de Tesla a Eliminar");
                        string aEliminar = Console.ReadLine();
                        bool check = false;
                        for (int i = 0; i < cantidad_autos; i++)
                        {
                            if (teslas[i].modelo == aEliminar) ;
                            {
                                for (int j = i; j < cantidad_autos - 1; j++)
                                {
                                    teslas[j] = teslas[j + 1];
                                }
                                cantidad_autos--;
                                check = true;
                                break;

                            }
                        }
                        if (check)
                        {
                            Console.WriteLine($"El Tesla {aEliminar} ha sido eliminado exitosamente.");
                        }
                        else
                        {
                            Console.WriteLine($"No se encontró un Tesla con el modelo {aEliminar}.");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Lista de Vehiculos que ya tuvieron su Service:");
                        int cantService = 0;
                        for (int i = 0; i < cantidad_autos; i++)
                        {
                            cantService = (teslas[i].kmActual / teslas[i].kmService);
                            if (cantService > 0)
                            {
                                Console.WriteLine($"El modelo: {teslas[i].modelo} tiene: {cantService}");
                            }
                        }
                        break;

                    case 4:
                        Console.WriteLine("Lista de Vehiculos Tesla Ordenados por Año:");
                        for (int i = 0; i < cantidad_autos; i++)
                        {
                            for (int j = i + 1; j < cantidad_autos; j++)
                            {
                                if (teslas[i].anio > teslas[j].anio)
                                {
                                    var temp = teslas[i];
                                    teslas[i] = teslas[j];
                                    teslas[j] = temp;
                                }
                            }
                        }
                        Console.WriteLine("Lista de Vehiculos Tesla ordenados por Año:");
                        for (int i = 0; i < cantidad_autos; i++)
                        {
                            Console.WriteLine($"Modelo: {teslas[i].modelo} / Año: {teslas[i].anio}");
                        }
                        break;

                    case 5:
                        var masNuevo = teslas[];// REVISAR ESTA PARTE
                        for (int i = 0; i < cantidad_autos; i++)
                        {   
                            if (teslas[i].anio > masNuevo.anio)
                            {
                                masNuevo = teslas[i];
                            }
                        }
                        Console.WriteLine(masNuevo.ToString());
                        break;

                    case 6:
                        Console.WriteLine("Gracias por usar Nuestros Servicios");
                        break;

                    default:
                        Console.WriteLine("Opcion Invalida, Intente de Nuevo.");
                        break;




                }
            }while (opcion != 6);
        }
    }
}