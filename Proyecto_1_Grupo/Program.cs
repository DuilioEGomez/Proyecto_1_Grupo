using System;
using System.Reflection.Metadata.Ecma335;
using System.Linq;

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

            int opcion = 0;

            Console.WriteLine("Bienvenido al Sistema de Gestion de Autos Tesla\n\r");

            // Se crea el menu y se lo muestra en pantalla.
            do
            {
                Console.WriteLine("\nIngrese su opcion:\n");
                Console.WriteLine(" 1 -> Dar de alta un vehiculo Tesla.");
                Console.WriteLine(" 2 -> Eliminar un vehiculo Tesla.");
                Console.WriteLine(" 3 -> Mostrar un listado de los vehiculos Tesla que ya tuvieron su service.");
                Console.WriteLine(" 4 -> Reordenar el listado de los vehiculos Tesla por año.");
                Console.WriteLine(" 5 -> Mostrar el vehiculo Tesla mas nuevo.\n");
                Console.WriteLine(" 6 -> Salir.\n");
                //chequeo opción válida: definición de variables
                var opcInput = Console.ReadLine();

                // se carga la entrada del teclado en la variable "opcion" y se la convierte a entero.
                if (opcInput.All(char.IsDigit) && opcInput !="")
                {
                    opcion = Convert.ToInt32(opcInput);
                }
                else
                {
                    Console.WriteLine("\nSolo se permiten ingresar números.\n");
                    Console.WriteLine("Presione cualquier tecla para volver al menú de inicio.");
                    Console.ReadKey();
                    continue;
                }


                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("\nDar de alta un vehiculo Tesla\n");

                        //-------------------INGRESO MODELO
                        Console.WriteLine("Ingrese el modelo del vehiculo Tesla:");
                        string modelo = Console.ReadLine();


                        //--------------------INGRESO AÑO

                        Console.WriteLine("\nIngrese el año del modelo:");

                        //chequeo año válido: definición de variables
                        var anioinput = Console.ReadLine();
                        int anio;
                        //si el string ingresado es numeral se convierte a int
                        if (anioinput.All(char.IsDigit))
                        {
                            anio = Convert.ToInt32(anioinput);

                            //chequea que el año esté entre el año del primer modelo de tesla (2006)
                            //y el año actual.
                            if (anio < 2005 || anio > DateTime.Now.Year)
                            {
                                Console.WriteLine("\nAño inválido, debe ser desde el 2006 a la actualidad. \n");


                                Console.WriteLine("Presione cualquier tecla para volver al menú de inicio.\n");
                                Console.ReadKey();
                                break;
                            }

                        }
                        else
                        {
                            Console.WriteLine("Solo se permiten ingresar números.\n");
                            Console.WriteLine("Presione cualquier tecla para volver al menú de inicio.\n");
                            Console.ReadKey();
                            break;
                        }


                        //---------------INGRESO KILOMETRAJE

                        Console.WriteLine("\nIngrese el kilometraje actual del vehiculo:");

                        //chequeo kilometraje válido: definición de variables
                        var kmInput = Console.ReadLine();
                        long kmActual;
                        //si el string ingresado es numeral se convierte a int
                        if (kmInput.All(char.IsDigit))
                        {
                            kmActual = Convert.ToInt64(kmInput);
                        }
                        else
                        {
                            Console.WriteLine("Solo se permiten ingresar números.\n");
                            Console.WriteLine("Presione cualquier tecla para volver al menú de inicio.\n");
                            Console.ReadKey();
                            break;
                        }


                        //--------------------INGRESO SERVICE

                        Console.WriteLine("\nIngrese cada cuántos km se debe realizar el Service:");
                        //chequeo kilometraje válido: definición de variables
                        var serviceInput = Console.ReadLine();
                        long kmService;
                        //si el string ingresado es numeral se convierte a int
                        if (serviceInput.All(char.IsDigit))
                        {
                            kmService = Convert.ToInt64(serviceInput);
                        }
                        else
                        {
                            Console.WriteLine("Solo se permiten ingresar números.\n");
                            Console.WriteLine("Presione cualquier tecla para volver al menú de inicio.\n");
                            Console.ReadKey();
                            break;
                        }


                        //---------------INGRESO COLOR

                        Console.WriteLine("\nIngrese el color del vehiculo Tesla:");
                        string color = Console.ReadLine();


                        //---------------INGRESO DUEÑO

                        Console.WriteLine("\nIngrese el nombre del dueño del vehiculo Tesla:\n");
                        string duenio = Console.ReadLine();
                        //se capitaliza el nombre del dueño
                        duenio = char.ToUpper(duenio[0]) + duenio.Substring(1);


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
                        Console.WriteLine($"Se ha dado de alta un nuevo vehiculo Tesla:\nModelo {modelo}, año {anio}, " +
                            $"con {kmActual} Kms, el Service es cada {kmService} Kms, de color {color}, y el dueño es {duenio}.\n\r");
                        Console.WriteLine("\nPresione cualquier tecla para volver al menú de inicio.\n");
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.WriteLine("\nIngrese el Modelo de Tesla a eliminar:");

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
                            Console.WriteLine("\nPresione cualquier tecla para volver al menú de inicio.\n");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine($"No se encontró un Tesla con el modelo {aEliminar}.");
                            Console.WriteLine("\nPresione cualquier tecla para volver al menú de inicio.\n");
                            Console.ReadKey();
                        }
                        break;

                    case 3:

                        //si no hay autos ingresados previamente, sale
                        if (cantidad_autos == 0)
                        {
                            Console.WriteLine("\nNo hay vehiculos que hayan tenido service aún.\n");
                            Console.WriteLine("Presione cualquier tecla para volver al menú de inicio.");
                            Console.ReadKey();
                            break;
                        }


                        // se inicializa un contador llamado "cantService" para registar la cantidad de autos
                        // que ya tuviero su service.

                        long cantService = 0;
                        // se itera la estructura "teslas".

                        for (int i = 0; i < cantidad_autos; i++)
                        {
                            // se calcula la cantidad de services hechos segun el kilometraje actual dividido
                            // el kilometraje establecido para los services.
                            cantService = (teslas[i].kmActual / teslas[i].kmService);

                            // si la cantidad de services es mayor a 0 se imprime el modelo y su cantidad se services.
                            if (cantService > 0)
                            {
                                Console.WriteLine("\nLista de vehiculos que ya tuvieron su Service:\n");
                                Console.WriteLine($"Al modelo {teslas[i].modelo} se le han hecho {cantService} service(s)");

                            }



                            //se crea proxService(inicializada en el primer service a hacer al tesla)
                            long proxService = teslas[i].kmService;
                            //se obtiene el kilometraje necesario para el service proximo, multiplicando la cant de service
                            //hechos por los km de service por defecto

                            proxService = proxService * (cantService + 1);

                            //si la cantidad de km faltantes para el proximo service es menor o igual al 10%, se notifica
                            if (proxService - teslas[i].kmActual <= (proxService * 0.1))
                            {
                                Console.WriteLine("ATENCIÓN! service próximo");
                                Console.WriteLine($"Faltan {(proxService - teslas[i].kmActual)}km para el próximo service del modelo {teslas[i].modelo}");

                            }
                        }
                        Console.WriteLine("\nPresione cualquier tecla para volver al menú de inicio.\n");
                        Console.ReadKey();
                        break;

                    case 4:

                        //si no hay autos ingresados previamente, sale
                        if (cantidad_autos == 0)
                        {
                            Console.WriteLine("\nNo hay vehiculos registrados aún.\n");
                            Console.WriteLine("Presione cualquier tecla para volver al menú de inicio.");
                            Console.ReadKey();
                            break;
                        }

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



                            Console.WriteLine($"Modelo: {teslas[i].modelo} / Año: {teslas[i].anio} / Dueño: {teslas[i].duenio}");

                        }
                        Console.WriteLine("\nPresione cualquier tecla para volver al menú de inicio.\n");
                        Console.ReadKey();
                        break;

                    case 5:

                        //si no hay autos ingresados previamente, sale
                        if (cantidad_autos == 0)
                        {
                            Console.WriteLine("\nNo hay vehiculos registrados aún.\n");
                            Console.WriteLine("Presione cualquier tecla para volver al menú de inicio.");
                            Console.ReadKey();
                            break;
                        }


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
                        Console.WriteLine("\nPresione cualquier tecla para volver al menú de inicio.\n");
                        Console.ReadKey();
                        break;

                    case 6:
                        Console.WriteLine("Gracias por usar nuestros servicios.");
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("Opcion inválida, intente de nuevo.\n");
                        Console.WriteLine("Presione cualquier tecla para volver al menú de inicio.");
                        Console.ReadKey();
                        break;
                }
            } while (opcion != 6);
        }
    }
}
