public class Materia
{
    public string Nombre { get; set; }
    public double Nota { get; set; }

    public Materia(string nombre, double nota)
    {
        Nombre = nombre;
        Nota = nota;
    }

    public override string ToString()
    {
        return $"Materia: {Nombre} | Nota: {Nota:F1}";
    }
}