class Program
{
    const int MAX = 100;

    //Enums
    enum Tipo_Aprendizaje
    { supervisado, no_supervisado, reforzamiento }

    enum Estado_Dataset
    { sin_procesar, en_preparacion, listo_para_entrenar }

    //Arrays
    static string[] codigos = new string[MAX];
    static string[] nombres = new string[MAX];
    static int[] cantidad_registros = new int[MAX];
    static int[] cantidad_variables = new int[MAX];

    static string[] Tipos_Aprendizaje = new string[MAX];
    static string[] Estados_Dataset = new string[MAX];

    static int contador = 0;


    //metodos
    static int LeerEntero(string mensaje)
    {
        int valor;
        Console.Write(mensaje);
        while (!int.TryParse(Console.ReadLine(), out valor))
        {
            Console.Write("Entrada invalida. Debe ingresar un numero entero. Intente de nuevo: ");
        }
        return valor;
    }
    static bool EsTextoValido(string texto)
    {
        foreach (char c in texto)
        {
            if (!char.IsLetterOrDigit(c) && c != ' ')
            {
                return false;
            }
        }
        return true;
    }

    static string LeerTexto(string mensaje)
    {
        Console.Write(mensaje);
        string entrada = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(entrada) || !EsTextoValido(entrada))
        {
            if (string.IsNullOrWhiteSpace(entrada))
            {
                Console.Write("El campo no puede quedar vacio. Ingreselo de nuevo: ");
            }
            else
            {
                Console.Write("No se permiten caracteres especiales. Solo letras, numeros y espacios: ");
            }
            entrada = Console.ReadLine();
        }
        return entrada;
    }


    static void Main(string[] args)
    {
        int opcion;
        do
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== Menú de Gestión de Datasets ===");
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Agregar dataset");
                Console.WriteLine("2. Consultar datasets");
                Console.WriteLine("3. Actualizar estado de dataset");
                Console.WriteLine("4. Salir");
                opcion = LeerEntero("Ingrese su opción: ");
                switch (opcion)
                {
                    case 1:
                        AgregarDataset(); break;
                    case 2:
                        ConsultarDatasets(); break;
                    case 3:
                        ActualizarEstadoDataset(); break;
                    case 4:
                        Console.WriteLine("Saliendo del programa..."); break;
                    default: Console.WriteLine("Opción inválida. Intente nuevamente."); break;
                }
                if (opcion != 4)
                {
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                opcion = 0;
            }
        } while (opcion != 4);
    }

    //Métodos
    static void AgregarDataset()
    {
        Console.WriteLine("valio");
    }

    static void ConsultarDatasets()
    {

    }
    static void ActualizarEstadoDataset()
    {

    }
}