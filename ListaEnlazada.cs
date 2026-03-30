public class ListaEnlazada<T>
{
    private Nodo<T> cabeza;

    // Constructor
    public ListaEnlazada()
    {
        cabeza = null; // inicia vacía
    }

    // Método para agregar un dato
    public void Agregar(T dato)
    {
        Nodo<T> nuevo = new Nodo<T>(dato);

        // si la lista está vacía
        if (cabeza == null)
        {
            cabeza = nuevo;
        }
        else
        {
            Nodo<T> actual = cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevo;
        }
    }
}