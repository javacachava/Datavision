class Program
{
    const int MAX = 100;

    //Arrays (un dataset = misma posicion en todos los arreglos)
    static string[] codigos = new string[MAX];
    static string[] nombres = new string[MAX];
    static string[] areas = new string[MAX];
    static int[] registros = new int[MAX];
    static int[] variables = new int[MAX];
    static int[] tipoAprendizaje = new int[MAX]; // 1=Supervisado, 2=No supervisado, 3=Reforzamiento
    static int[] estado = new int[MAX];          // 0=Sin procesar, 1=En preparacion, 2=Listo para entrenamiento

    static int contador = 0;

    static void Main(string[] args)
    {
        int opcion;
        do
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== Sistema de Gestion de Datasets - DataVision Analytics ===");
                Console.WriteLine("1. Registrar dataset");
                Console.WriteLine("2. Consultar dataset por codigo");
                Console.WriteLine("3. Actualizar estado de dataset");
                Console.WriteLine("4. Listar datasets");
                Console.WriteLine("5. Buscar por area de aplicacion");
                Console.WriteLine("6. Mostrar estadisticas");
                Console.WriteLine("7. Salir");
                opcion = LeerEntero("Ingrese su opcion: ");
                switch (opcion)
                {
                    case 1: RegistrarDataset(); break;
                    case 2: ConsultarDataset(); break;
                    case 3: ActualizarEstadoDataset(); break;
                    case 4: ListarDatasets(); break;
                    case 5: BuscarPorArea(); break;
                    case 6: MostrarEstadisticas(); break;
                    case 7: Console.WriteLine("Saliendo del programa..."); break;
                    default: Console.WriteLine("Opcion invalida. Intente nuevamente."); break;
                }
                if (opcion != 7)
                {
                    Console.WriteLine();
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
        } while (opcion != 7);
    }

    //Utilidades de lectura
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

    static int LeerEnteroPositivo(string mensaje)
    {
        int valor = LeerEntero(mensaje);
        while (valor < 0)
        {
            valor = LeerEntero("El valor no puede ser negativo. Intente de nuevo: ");
        }
        return valor;
    }

    static int LeerOpcionEnRango(string mensaje, int min, int max)
    {
        int valor = LeerEntero(mensaje);
        while (valor < min || valor > max)
        {
            valor = LeerEntero("Opcion fuera de rango. Ingrese un valor entre " + min + " y " + max + ": ");
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

    static bool EsCodigoValido(string texto)
    {
        foreach (char c in texto)
        {
            if (!char.IsLetterOrDigit(c))
            {
                return false;
            }
        }
        return true;
    }

    static string LeerCodigo(string mensaje)
    {
        Console.Write(mensaje);
        string entrada = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(entrada) || !EsCodigoValido(entrada))
        {
            if (string.IsNullOrWhiteSpace(entrada))
            {
                Console.Write("El codigo no puede quedar vacio. Ingreselo de nuevo: ");
            }
            else
            {
                Console.Write("El codigo solo debe contener letras y numeros, sin espacios: ");
            }
            entrada = Console.ReadLine();
        }
        return entrada;
    }

    //Utilidades de dominio
    static int BuscarPorCodigo(string codigo)
    {
        for (int i = 0; i < contador; i++)
        {
            if (codigos[i].ToUpper() == codigo.ToUpper())
            {
                return i;
            }
        }
        return -1;
    }

    static string TextoTipoAprendizaje(int tipo)
    {
        switch (tipo)
        {
            case 1: return "Supervisado";
            case 2: return "No supervisado";
            case 3: return "Reforzamiento";
            default: return "Desconocido";
        }
    }

    static string TextoEstado(int est)
    {
        switch (est)
        {
            case 0: return "Sin procesar";
            case 1: return "En preparacion";
            case 2: return "Listo para entrenamiento";
            default: return "Desconocido";
        }
    }

    static void MostrarDataset(int i)
    {
        Console.WriteLine("Codigo: " + codigos[i]);
        Console.WriteLine("Nombre: " + nombres[i]);
        Console.WriteLine("Area de aplicacion: " + areas[i]);
        Console.WriteLine("Cantidad de registros: " + registros[i]);
        Console.WriteLine("Cantidad de variables: " + variables[i]);
        Console.WriteLine("Tipo de aprendizaje: " + TextoTipoAprendizaje(tipoAprendizaje[i]));
        Console.WriteLine("Estado: " + TextoEstado(estado[i]));
    }

    //Funcionalidades
    static void RegistrarDataset()
    {
        if (contador >= MAX)
        {
            Console.WriteLine("No se pueden registrar mas datasets. Limite alcanzado (" + MAX + ").");
            return;
        }

        Console.WriteLine("--- Registrar nuevo dataset ---");

        string codigo = LeerCodigo("Codigo del dataset: ");
        while (BuscarPorCodigo(codigo) != -1)
        {
            Console.WriteLine("Ya existe un dataset con ese codigo.");
            codigo = LeerCodigo("Ingrese otro codigo: ");
        }

        string nombre = LeerTexto("Nombre del dataset: ");
        string area = LeerTexto("Area de aplicacion (Salud, Finanzas, Educacion, Agricultura, etc.): ");
        int cantRegistros = LeerEnteroPositivo("Cantidad de registros: ");
        int cantVariables = LeerEnteroPositivo("Cantidad de variables (features): ");

        Console.WriteLine("Tipo de aprendizaje:");
        Console.WriteLine("1. Supervisado");
        Console.WriteLine("2. No supervisado");
        Console.WriteLine("3. Reforzamiento");
        int tipo = LeerOpcionEnRango("Seleccione una opcion: ", 1, 3);

        codigos[contador] = codigo;
        nombres[contador] = nombre;
        areas[contador] = area;
        registros[contador] = cantRegistros;
        variables[contador] = cantVariables;
        tipoAprendizaje[contador] = tipo;
        estado[contador] = 0; // Sin procesar por defecto
        contador++;

        Console.WriteLine("Dataset registrado correctamente con estado inicial 'Sin procesar'.");
    }

    static void ConsultarDataset()
    {
        if (contador == 0)
        {
            Console.WriteLine("No hay datasets registrados.");
            return;
        }

        string codigo = LeerCodigo("Ingrese el codigo del dataset a consultar: ");
        int indice = BuscarPorCodigo(codigo);
        if (indice == -1)
        {
            Console.WriteLine("No se encontro ningun dataset con ese codigo.");
            return;
        }

        Console.WriteLine("--- Informacion del dataset ---");
        MostrarDataset(indice);
    }

    static void ActualizarEstadoDataset()
    {
        if (contador == 0)
        {
            Console.WriteLine("No hay datasets registrados.");
            return;
        }

        string codigo = LeerCodigo("Ingrese el codigo del dataset a actualizar: ");
        int indice = BuscarPorCodigo(codigo);
        if (indice == -1)
        {
            Console.WriteLine("No se encontro ningun dataset con ese codigo.");
            return;
        }

        Console.WriteLine("Estado actual: " + TextoEstado(estado[indice]));

        if (estado[indice] == 2)
        {
            Console.WriteLine("El dataset ya se encuentra en el ultimo estado (Listo para entrenamiento).");
            return;
        }

        int siguiente = estado[indice] + 1;
        Console.WriteLine("Siguiente estado disponible: " + TextoEstado(siguiente));
        Console.Write("Desea confirmar el cambio de estado? (S/N): ");
        string respuesta = Console.ReadLine();
        if (respuesta != null && respuesta.Trim().ToUpper() == "S")
        {
            estado[indice] = siguiente;
            Console.WriteLine("Estado actualizado a: " + TextoEstado(estado[indice]));
        }
        else
        {
            Console.WriteLine("Operacion cancelada.");
        }
    }

    static void ListarDatasets()
    {
        if (contador == 0)
        {
            Console.WriteLine("No hay datasets registrados.");
            return;
        }

        Console.WriteLine("--- Listado de datasets registrados (" + contador + ") ---");
        for (int i = 0; i < contador; i++)
        {
            Console.WriteLine();
            Console.WriteLine("[" + (i + 1) + "]");
            MostrarDataset(i);
        }
    }

    static void BuscarPorArea()
    {
        if (contador == 0)
        {
            Console.WriteLine("No hay datasets registrados.");
            return;
        }

        string area = LeerTexto("Ingrese el area de aplicacion a buscar: ");
        bool encontrado = false;

        Console.WriteLine("--- Datasets del area '" + area + "' ---");
        for (int i = 0; i < contador; i++)
        {
            if (areas[i].ToUpper() == area.ToUpper())
            {
                Console.WriteLine();
                MostrarDataset(i);
                encontrado = true;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("No se encontraron datasets para esa area.");
        }
    }

    static void MostrarEstadisticas()
    {
        if (contador == 0)
        {
            Console.WriteLine("No hay datasets registrados.");
            return;
        }

        int totalSupervisado = 0;
        int totalNoSupervisado = 0;
        int totalReforzamiento = 0;
        int totalListos = 0;
        long sumaRegistros = 0;

        int indiceMaxRegistros = 0;
        int indiceMaxVariables = 0;

        for (int i = 0; i < contador; i++)
        {
            switch (tipoAprendizaje[i])
            {
                case 1: totalSupervisado++; break;
                case 2: totalNoSupervisado++; break;
                case 3: totalReforzamiento++; break;
            }

            if (estado[i] == 2)
            {
                totalListos++;
            }

            sumaRegistros += registros[i];

            if (registros[i] > registros[indiceMaxRegistros])
            {
                indiceMaxRegistros = i;
            }

            if (variables[i] > variables[indiceMaxVariables])
            {
                indiceMaxVariables = i;
            }
        }

        double promedioRegistros = (double)sumaRegistros / contador;

        Console.WriteLine("--- Estadisticas generales ---");
        Console.WriteLine("Total de datasets registrados: " + contador);
        Console.WriteLine("Datasets supervisados: " + totalSupervisado);
        Console.WriteLine("Datasets no supervisados: " + totalNoSupervisado);
        Console.WriteLine("Datasets de reforzamiento: " + totalReforzamiento);
        Console.WriteLine("Promedio de registros por dataset: " + promedioRegistros.ToString("F2"));
        Console.WriteLine("Dataset con mayor numero de registros: " + nombres[indiceMaxRegistros] + " (" + codigos[indiceMaxRegistros] + ") con " + registros[indiceMaxRegistros] + " registros");
        Console.WriteLine("Dataset con mayor cantidad de variables: " + nombres[indiceMaxVariables] + " (" + codigos[indiceMaxVariables] + ") con " + variables[indiceMaxVariables] + " variables");
        Console.WriteLine("Datasets listos para entrenamiento: " + totalListos);
    }
}
