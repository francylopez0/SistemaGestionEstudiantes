public class ListaEnlazada<T>
{
    private Nodo<T>? cabeza = null;

    public ListaEnlazada()
    {
    }

    public void Agregar(T dato)
    {
        Nodo<T> nuevo = new Nodo<T>(dato);

        if (cabeza == null)
        {
            cabeza = nuevo;
        }
        else
        {
            Nodo<T>? actual = cabeza;

            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }

            actual.Siguiente = nuevo;
        }
    }

    // 👇 ESTE MÉTODO VA AQUÍ DENTRO
    public void Mostrar()
    {
        Nodo<T>? actual = cabeza;

        if (actual == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        while (actual != null)
        {
            Console.WriteLine(actual.Dato);
            actual = actual.Siguiente;
        }
    }
}
