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

        Estudiante nuevo = new Estudiante(siguienteCodigo, nombre, apellido, direccion, celular, email);
        estudiantes.Agregar(nuevo);

        Console.WriteLine("Estudiante agregado correctamente.");
        siguienteCodigo++;
    }
    else if (opcion == "2")
    {
        Console.WriteLine("=== LISTA DE ESTUDIANTES ===");

        Nodo<Estudiante>? actual = estudiantes.Cabeza;

        if (actual == null)
        {
            Console.WriteLine("No hay estudiantes registrados.");
        }
        else
        {
            while (actual != null)
            {
                Console.WriteLine(actual.Dato);

                Nodo<Materia>? materiaActual = actual.Dato.Materias.Cabeza;

                if (materiaActual == null)
                {
                    Console.WriteLine("   (Sin materias)");
                }
                else
                {
                    while (materiaActual != null)
                    {
                        Console.WriteLine("   - " + materiaActual.Dato);
                        materiaActual = materiaActual.Siguiente;
                    }
                }

                Console.WriteLine();
                actual = actual.Siguiente;
            }
        }
    }
    else if (opcion == "3")
    {
        Console.Write("Ingrese el código del estudiante: ");
        int codigo = LeerEntero();

        Estudiante? encontrado = estudiantes.Buscar(e => e.Codigo == codigo);

        if (encontrado == null)
        {
            Console.WriteLine("Estudiante no encontrado.");
        }
        else
        {
            Console.WriteLine(encontrado);
        }
    }
    else if (opcion == "4")
    {
        Console.Write("Ingrese el código del estudiante a eliminar: ");
        int codigo = LeerEntero();

        bool eliminado = estudiantes.Eliminar(e => e.Codigo == codigo);

        if (eliminado)
        {
            Console.WriteLine("Estudiante eliminado correctamente.");
        }
        else
        {
            Console.WriteLine("Estudiante no encontrado.");
        }
    }
    else if (opcion == "5")
    {
        Console.Write("Ingrese el código del estudiante: ");
        int codigo = LeerEntero();

        Estudiante? estudiante = estudiantes.Buscar(e => e.Codigo == codigo);

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
        Console.WriteLine("Saliendo...");
        break;
    }
    else
    {
        Console.WriteLine("Opción inválida.");
    }
}


// ================= MÉTODOS =================

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
            return nota;
        }

        Console.Write("Ingrese una nota válida: ");
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
            Console.WriteLine("Seleccione una materia:");
            Console.WriteLine("1. Matemáticas");
            Console.WriteLine("2. Inglés");
            Console.WriteLine("3. Física");
            Console.WriteLine("4. Programación");

            string op = Console.ReadLine() ?? "";

            string nombreMateria = "";

            if (op == "1") nombreMateria = "Matemáticas";
            else if (op == "2") nombreMateria = "Inglés";
            else if (op == "3") nombreMateria = "Física";
            else if (op == "4") nombreMateria = "Programación";
            else
            {
                Console.WriteLine("Opción inválida.");
                continue;
            }

            Console.Write("Nota: ");
            double nota = LeerNota();

            estudiante.AgregarMateria(nombreMateria, nota);
            Console.WriteLine("Materia agregada correctamente.");
        }
        else if (opcion == "2")
        {
            estudiante.MostrarMaterias();
        }
        else if (opcion == "3")
        {
            Materia? materia = SeleccionarMateria(estudiante);

            if (materia != null)
            {
                Console.Write("Nueva nota: ");
                double nuevaNota = LeerNota();

                materia.Nota = nuevaNota;
                Console.WriteLine("Nota modificada correctamente.");
            }
        }
        else if (opcion == "4")
        {
            Materia? materia = SeleccionarMateria(estudiante);

            if (materia != null)
            {
                bool eliminada = estudiante.EliminarMateria(materia.Nombre);

                if (eliminada)
                {
                    Console.WriteLine("Materia eliminada correctamente.");
                }
            }
        }
        else if (opcion == "0")
        {
            break;
        }
        else
        {
            Console.WriteLine("Opción inválida.");
        }
    }
}


Materia? SeleccionarMateria(Estudiante estudiante)
{
    Nodo<Materia>? actual = estudiante.Materias.Cabeza;

    if (actual == null)
    {
        Console.WriteLine("No hay materias.");
        return null;
    }

    int contador = 1;

    Console.WriteLine("Seleccione una materia:");

    while (actual != null)
    {
        Console.WriteLine($"{contador}. {actual.Dato.Nombre} | Nota: {actual.Dato.Nota}");
        actual = actual.Siguiente;
        contador++;
    }

    Console.Write("Opción: ");
    int opcion = LeerEntero();

    actual = estudiante.Materias.Cabeza;
    contador = 1;

    while (actual != null)
    {
        if (contador == opcion)
        {
            return actual.Dato;
        }

        actual = actual.Siguiente;
        contador++;
    }

    Console.WriteLine("Opción inválida.");
    return null;
}