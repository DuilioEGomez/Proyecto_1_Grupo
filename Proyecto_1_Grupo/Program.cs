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
                        teslas[cantidad_autos] = new Tesla { modelo = modelo, anio = anio, kmActual = kmActual, kmService = kmService, 
                            color = color, duenio = duenio };
                        cantidad_autos++;
                        Console.WriteLine($"Se ha dado de alta un nuevo vehiculo Tesla: Modelo {modelo}, Año {anio}, " +
                            $"con {kmActual} Kms, el Service es cada {kmService} Kms, de color {color}, y el dueño es {duenio}");

                    case 2:
                        Console.WriteLine("Ingrese el de Tesla a Eliminar");
                        string aEliminar = Console.ReadLine();
                        bool check = false;
                        for (int i = 0; i < cantidad_autos; i++) 
                        {
                            if (teslas[i].modelo == aEliminar);
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



                }
            }
        }
    }
}