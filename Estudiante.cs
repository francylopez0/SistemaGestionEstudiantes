using System;

public class Estudiante
{
    public int Codigo { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Direccion { get; set; }
    public string Celular { get; set; }
    public string Email { get; set; }

    // Cada estudiante tiene su propia lista de materias
    public ListaEnlazada<Materia> Materias { get; set; }

    public Estudiante(int codigo, string nombre, string apellido, string direccion, string celular, string email)
    {
        Codigo = codigo;
        Nombre = nombre;
        Apellido = apellido;
        Direccion = direccion;
        Celular = celular;
        Email = email;
        Materias = new ListaEnlazada<Materia>();
    }

    public bool AgregarMateria(string nombre, double nota)
    {
        Materia? existente = Materias.Buscar(m =>
            m.Nombre.Trim().ToLower() == nombre.Trim().ToLower());

        if (existente != null)
        {
            return false;
        }

        Materias.Agregar(new Materia(nombre, nota));
        return true;
    }

    public bool ModificarNotaMateria(string nombreMateria, double nuevaNota)
    {
        Materia? materia = Materias.Buscar(m =>
            m.Nombre.Trim().ToLower() == nombreMateria.Trim().ToLower());

        if (materia == null)
        {
            return false;
        }

        materia.Nota = nuevaNota;
        return true;
    }

    public bool EliminarMateria(string nombreMateria)
    {
        return Materias.Eliminar(m =>
            m.Nombre.Trim().ToLower() == nombreMateria.Trim().ToLower());
    }

    public void MostrarMaterias()
    {
        Materias.Mostrar();
    }

    public override string ToString()
    {
        return $"Código: {Codigo} | Nombre: {Nombre} {Apellido} | Promedio: {CalcularPromedio():F2}";
    }
    public double CalcularPromedio()
{
    Nodo<Materia>? actual = Materias.Cabeza;

    if (actual == null) return 0;

    double suma = 0;
    int cantidad = 0;

    while (actual != null)
    {
        suma += actual.Dato.Nota;
        cantidad++;
        actual = actual.Siguiente;
    }

    return cantidad > 0 ? suma / cantidad : 0;
}
}
