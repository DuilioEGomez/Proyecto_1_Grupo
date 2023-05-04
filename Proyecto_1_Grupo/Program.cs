using System;
using System.Reflection.Metadata.Ecma335;

namespace Proyecto_1_Grupo
    // Integrantes del Grupo: Catalina German, Juan Manuel Ignacio Galvez, Duilio Enrique Gomez.
{
    internal class Program
    {
        // se crea la estructura Tesla y se le declaran sus parametros y sus tipos.
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
            // Se instancia Tesla con la estructura llamada "teslas" con un limite de 50 teslas.
            Tesla[] teslas = new Tesla[50];

            // se Inicializa un contador llamado "cantidad_autos".
            int cantidad_autos = 0;

            // se inicializa la variable entera "opcion" la cual servira para que funciones el menu de opciones de 1 a 6.
            int opcion;

            Console.WriteLine("Bienvenido al Sistema de Gestion de Autos Tesla\n\r");

            // Se crea el menu y se lo muestra en pantalla.
            do
            {
                Console.WriteLine("");
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

                // se carga la entrada del teclado en la variable "opcion" y se la convierte a entero.
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("");
                        Console.WriteLine("Dar de Alta un Vehiculo Tesla");
                        Console.WriteLine("");
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
                        Console.WriteLine("");
                        
                        // se crea un vehiculo que lleva un numero identificatorio llamado "cantidad_autos",
                        // en la estructura "teslas"
                        // y se le cargan los datos ingresados por el usuario.
                        teslas[cantidad_autos] = new Tesla
                        
                        {
                            modelo = modelo,
                            anio = anio,
                            kmActual = kmActual,
                            kmService = kmService,
                            color = color,
                            duenio = duenio
                        };
                        
                        // se incrementa en uno el contador de teslas.
                        cantidad_autos++;

                        // se imprime los datos cargados por el usuario.
                        Console.WriteLine($"Se ha dado de alta un nuevo vehiculo Tesla: Modelo {modelo}, Año {anio}, " +
                            $"con {kmActual} Kms, el Service es cada {kmService} Kms, de color {color}, y el dueño es {duenio}\n\r");
                        break;

                    case 2:
                        Console.WriteLine("");
                        Console.WriteLine("Ingrese el de Tesla a Eliminar");
                        
                        // se declara la variable "aEliminar" la cual sirve para ingresar por el usuario el modelo
                        // de tesla a eliminar.
                        string aEliminar = Console.ReadLine();

                        // se crea un flag o bandera para la confirmacion si fue borrado con exito el vehiculo a eliminar.
                        bool check = false;
                        
                        // se recorre la estructura teslas para buscar el modelo de vehiculo a eliminar.
                        for (int i = 0; i < cantidad_autos; i++)
                        {
                            // se compara el modelo ingresado por el usuario con el modelo encontrado en la iteracion
                            // y se le coloca .ToUpper para que no hayas problemas por tipeo de mayusculas y o minusculas
                            // en la comparacion.
                            if (teslas[i].modelo.ToUpper() == aEliminar.ToUpper())
                            {
                                // en este for j corre un paso mas que i
                                for (int j = i; j < cantidad_autos - 1; j++)
                                {
                                    //se reordena la estructura, ya que fue eliminado un vehiculo de la estructura "teslas".
                                    teslas[j] = teslas[j + 1];
                                }

                                // se actualiza la cantidad de autos.
                                cantidad_autos--;

                                // se actualiza la bandera o flag a TRUE para confirmar que se elimino un vehiculo.
                                check = true;
                                break;
                            }
                        }
                        // se lee el estado de la bandera o flag para mostra el comentario adecuado.
                        if (check)
                        {
                            Console.WriteLine($"El Tesla {aEliminar} ha sido eliminado exitosamente.");
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.WriteLine($"No se encontró un Tesla con el modelo {aEliminar}.");
                            Console.WriteLine("");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Lista de Vehiculos que ya tuvieron su Service:");
                        // se inicializa un contador llamado "cantService" para registar la cantidad de autos
                        // que ya tuviero su service.
                        
                        int cantService = 0;
                        // se itera la estructura "teslas".
                        
                        for (int i = 0; i < cantidad_autos; i++)
                        {
                            // se calcula la cantidad de services hechos segun el kilometraje actual dividido
                            // el kilometraje establecido para los services.
                            cantService = (teslas[i].kmActual / teslas[i].kmService);

                            // si la cantidad de services es mayor a 0 se imprime el modelo y su cantidad se services.
                            if (cantService > 0)
                            {
                                Console.WriteLine($"El modelo: {teslas[i].modelo} tiene: {cantService}");
                                
                            }
                        }
                        Console.WriteLine("");
                        break;

                    case 4:
                        Console.WriteLine("Lista de Vehiculos Tesla Ordenados por Año:");

                        // se itera la estructura "teslas".
                        for (int i = 0; i < cantidad_autos; i++)
                        {   
                            // se itera la estructura, donde j es i + 1.
                            // se hace esto para poder comparar un vehiculo versus el siguiente comparando el año de los modelos.
                            for (int j = i + 1; j < cantidad_autos; j++)
                            {
                                if (teslas[i].anio > teslas[j].anio)
                                {
                                    // se crea la variable "temp" la cual se usara como tercer contenedor para el intercambio
                                    // de los vehiculos si en la comparacion el primero es mas nuevo que el segundo.
                                    var temp = teslas[i];
                                    teslas[i] = teslas[j];
                                    teslas[j] = temp;
                                }
                            }
                        }
                        // se detalla los modelos por año.
                        for (int i = 0; i < cantidad_autos; i++)
                        {
                            Console.WriteLine($"Modelo: {teslas[i].modelo} / Año: {teslas[i].anio}");
                        }
                        break;

                    case 5:
                        // se crea la variable "masNuevo" donde se guarda el primer vehiculo el cual se usara
                        // para comparar cual es el mas nuevo de la estrutura "teslas".
                        var masNuevo = teslas[0];
                        for (int i = 0; i < cantidad_autos; i++)
                        {   
                            if (teslas[i].anio > masNuevo.anio)
                            {
                                // se carga el vehiculo mas nuevo en la variable "masNuevo"
                                masNuevo = teslas[i];
                            }
                        }
                        // se detalla e imprime el vehiculo mas nuevo.
                        Console.WriteLine($"\nEl Tesla más nuevo es: {masNuevo.modelo} ({masNuevo.anio}) - Dueño: {masNuevo.duenio}");
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