public class Estudiante
{
    public int Id { get; set; }
    public string Nombre { get; set; }

    public ListaEnlazada<Materia> Materias { get; set; }

    // Constructor
    public Estudiante(int id, string nombre)
    {
        Id = id;
        Nombre = nombre;
        Materias = new ListaEnlazada<Materia>();
    }

    public void AgregarMateria(string nombre, double nota)
    {
        Materia nueva = new Materia(nombre, nota);
        Materias.Agregar(nueva);
    }

    // Mostrar materias del estudiante
    public void MostrarMaterias()
    {
        Materias.Mostrar();
    }
    public override string ToString()
    {
        return $"ID: {Id} | Nombre: {Nombre}";
    }
}