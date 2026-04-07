using System;

ListaEnlazada<Estudiante> estudiantes = new ListaEnlazada<Estudiante>();
int siguienteCodigo = 1;

while (true)
{
    Console.WriteLine();
    Console.WriteLine("===== SISTEMA DE ESTUDIANTES =====");
    Console.WriteLine("1. Agregar estudiante");
    Console.WriteLine("2. Listar estudiantes");
    Console.WriteLine("3. Buscar estudiante");
    Console.WriteLine("4. Eliminar estudiante");
    Console.WriteLine("5. Gestionar materias de un estudiante");
    Console.WriteLine("0. Salir");
    Console.Write("Seleccione una opción: ");

    string opcion = Console.ReadLine() ?? "";

    if (opcion == "1")
    {
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine() ?? "";

        Console.Write("Apellido: ");
        string apellido = Console.ReadLine() ?? "";

        Console.Write("Dirección: ");
        string direccion = Console.ReadLine() ?? "";

        Console.Write("Celular: ");
        string celular = Console.ReadLine() ?? "";

        Console.Write("Email: ");
        string email = Console.ReadLine() ?? "";

        if (nombre.Trim() == "" || apellido.Trim() == "")
        {
            Console.WriteLine("Nombre y apellido son obligatorios.");
        }
        else
        {
            Estudiante nuevo = new Estudiante(siguienteCodigo, nombre, apellido, direccion, celular, email);
            estudiantes.Agregar(nuevo);
            Console.WriteLine("Estudiante agregado correctamente.");
            siguienteCodigo++;
        }
    }
    else if (opcion == "2")
    {
        Console.WriteLine("=== LISTA DE ESTUDIANTES ===");
        estudiantes.Mostrar();
    }
    else if (opcion == "3")
    {
        Console.Write("Ingrese el código del estudiante: ");
        int codigoBuscado = LeerEntero();

        Estudiante? encontrado = estudiantes.Buscar(e => e.Codigo == codigoBuscado);

        if (encontrado == null)
        {
            Console.WriteLine("Estudiante no encontrado.");
        }
        else
        {
            Console.WriteLine("=== ESTUDIANTE ENCONTRADO ===");
            Console.WriteLine(encontrado);
        }
    }
    else if (opcion == "4")
    {
        Console.Write("Ingrese el código del estudiante a eliminar: ");
        int codigoEliminar = LeerEntero();

        Estudiante? encontrado = estudiantes.Buscar(e => e.Codigo == codigoEliminar);

        if (encontrado == null)
        {
            Console.WriteLine("Estudiante no encontrado.");
        }
        else
        {
            Console.Write("¿Seguro que desea eliminarlo? (S/N): ");
            string confirmar = (Console.ReadLine() ?? "").Trim().ToUpper();

            if (confirmar == "S")
            {
                bool eliminado = estudiantes.Eliminar(e => e.Codigo == codigoEliminar);

                if (eliminado)
                {
                    Console.WriteLine("Estudiante eliminado correctamente.");
                }
                else
                {
                    Console.WriteLine("No se pudo eliminar el estudiante.");
                }
            }
            else
            {
                Console.WriteLine("Operación cancelada.");
            }
        }
    }
    else if (opcion == "5")
    {
        Console.Write("Ingrese el código del estudiante: ");
        int codigoMateria = LeerEntero();

        Estudiante? estudiante = estudiantes.Buscar(e => e.Codigo == codigoMateria);

        if (estudiante == null)
        {
            Console.WriteLine("Estudiante no encontrado.");
        }
        else
        {
            GestionarMaterias(estudiante);
        }
    }
    else if (opcion == "0")
    {
        Console.WriteLine("Saliendo del sistema...");
        break;
    }
    else
    {
        Console.WriteLine("Opción no válida.");
    }
}

int LeerEntero()
{
    while (true)
    {
        string texto = Console.ReadLine() ?? "";

        if (int.TryParse(texto, out int numero))
        {
            return numero;
        }

        Console.Write("Ingrese un número válido: ");
    }
}

double LeerNota()
{
    while (true)
    {
        string texto = Console.ReadLine() ?? "";

        if (double.TryParse(texto, out double nota))
        {
            if (nota >= 0.0 && nota <= 5.0)
            {
                return nota;
            }
        }

        Console.Write("Ingrese una nota válida entre 0.0 y 5.0: ");
    }
}

void GestionarMaterias(Estudiante estudiante)
{
    while (true)
    {
        Console.WriteLine();
        Console.WriteLine($"=== MATERIAS DE {estudiante.Nombre} {estudiante.Apellido} ===");
        Console.WriteLine("1. Agregar materia");
        Console.WriteLine("2. Listar materias");
        Console.WriteLine("3. Modificar nota");
        Console.WriteLine("4. Eliminar materia");
        Console.WriteLine("0. Volver");
        Console.Write("Seleccione una opción: ");

        string opcion = Console.ReadLine() ?? "";

        if (opcion == "1")
        {
            Console.Write("Nombre de la materia: ");
            string nombreMateria = Console.ReadLine() ?? "";

            Console.Write("Nota: ");
            double nota = LeerNota();

            if (nombreMateria.Trim() == "")
            {
                Console.WriteLine("El nombre de la materia no puede estar vacío.");
            }
            else
            {
                bool agregada = estudiante.AgregarMateria(nombreMateria, nota);

                if (agregada)
                {
                    Console.WriteLine("Materia agregada correctamente.");
                }
                else
                {
                    Console.WriteLine("Esa materia ya existe para este estudiante.");
                }
            }
        }
        else if (opcion == "2")
        {
            Console.WriteLine("=== LISTA DE MATERIAS ===");
            estudiante.MostrarMaterias();
        }
        else if (opcion == "3")
        {
            Console.Write("Nombre de la materia a modificar: ");
            string nombreMateria = Console.ReadLine() ?? "";

            Console.Write("Nueva nota: ");
            double nuevaNota = LeerNota();

            bool modificada = estudiante.ModificarNotaMateria(nombreMateria, nuevaNota);

            if (modificada)
            {
                Console.WriteLine("Nota modificada correctamente.");
            }
            else
            {
                Console.WriteLine("Materia no encontrada.");
            }
        }
        else if (opcion == "4")
        {
            Console.Write("Nombre de la materia a eliminar: ");
            string nombreMateria = Console.ReadLine() ?? "";

            bool eliminada = estudiante.EliminarMateria(nombreMateria);

            if (eliminada)
            {
                Console.WriteLine("Materia eliminada correctamente.");
            }
            else
            {
                Console.WriteLine("Materia no encontrada.");
            }
        }
        else if (opcion == "0")
        {
            break;
        }
        else
        {
            Console.WriteLine("Opción no válida.");
        }
    }
}