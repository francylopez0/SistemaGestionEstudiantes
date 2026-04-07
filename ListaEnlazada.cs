using System;

public class ListaEnlazada<T>
{
    private Nodo<T>? cabeza;

    public ListaEnlazada()
    {
        cabeza = null;
    }

    public Nodo<T>? Cabeza
    {
        get { return cabeza; }
    }

    public bool EstaVacia()
    {
        return cabeza == null;
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

            while (actual!.Siguiente != null)
            {
                actual = actual.Siguiente;
            }

            actual.Siguiente = nuevo;
        }
    }

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

    public bool Eliminar(Func<T, bool> condicion)
    {
        if (cabeza == null)
        {
            return false;
        }

        if (condicion(cabeza.Dato))
        {
            cabeza = cabeza.Siguiente;
            return true;
        }

        Nodo<T>? actual = cabeza;

        while (actual.Siguiente != null)
        {
            if (condicion(actual.Siguiente.Dato))
            {
                actual.Siguiente = actual.Siguiente.Siguiente;
                return true;
            }

            actual = actual.Siguiente;
        }

        return false;
    }

    public T? Buscar(Func<T, bool> condicion)
    {
        Nodo<T>? actual = cabeza;

        while (actual != null)
        {
            if (condicion(actual.Dato))
            {
                return actual.Dato;
            }

            actual = actual.Siguiente;
        }

        return default;
    }
}