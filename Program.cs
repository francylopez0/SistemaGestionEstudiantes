// See https://aka.ms/new-console-template for more information
Console.WriteLine("Estructura de Datos - Lista Enlazada");
ListaEnlazada<Estudiante> estudiantes = new ListaEnlazada<Estudiante>();
int siguienteId = 1;

while (true)
{
    Console.WriteLine("===== SISTEMA DE ESTUDIANTES =====");
    Console.WriteLine("1. Agregar estudiante");
    Console.WriteLine("2. Listar estudiantes");
    Console.WriteLine("0. Salir");
    Console.Write("Seleccione una opción: ");

    string opcion = Console.ReadLine();

    if (opcion == "1")
    {
        Console.Write("Ingrese el nombre del estudiante: ");
        string nombre = Console.ReadLine();

        Estudiante nuevo = new Estudiante(siguienteId, nombre);
        estudiantes.Agregar(nuevo);

        Console.WriteLine("Estudiante agregado correctamente.");
        siguienteId++;
    }
    else if (opcion == "2")
    {
        Console.WriteLine("=== LISTA DE ESTUDIANTES ===");
        estudiantes.Mostrar();
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

    Console.WriteLine();
}