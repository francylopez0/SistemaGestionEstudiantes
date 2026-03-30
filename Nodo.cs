public class Nodo<T>
{
    public T Dato;
    public Nodo<T>? Siguiente;

    public Nodo(T dato)
    {
        Dato = dato;  // se guarda el dato recibido
        Siguiente = null; // inicia sin conexión
    }
}