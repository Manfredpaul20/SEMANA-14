using System;

class Nodo
{
    public int Valor;
    public Nodo Izquierdo, Derecho;

    public Nodo(int valor)
    {
        Valor = valor;
        Izquierdo = Derecho = null;
    }
}

class ArbolBST
{
    public Nodo Raiz;

    // Insertar
    public Nodo Insertar(Nodo raiz, int valor)
    {
        if (raiz == null)
            return new Nodo(valor);

        if (valor < raiz.Valor)
            raiz.Izquierdo = Insertar(raiz.Izquierdo, valor);
        else if (valor > raiz.Valor)
            raiz.Derecho = Insertar(raiz.Derecho, valor);

        return raiz;
    }

    // Buscar
    public bool Buscar(Nodo raiz, int valor)
    {
        if (raiz == null) return false;
        if (raiz.Valor == valor) return true;

        if (valor < raiz.Valor)
            return Buscar(raiz.Izquierdo, valor);
        else
            return Buscar(raiz.Derecho, valor);
    }

    // Encontrar mínimo
    public Nodo Minimo(Nodo nodo)
    {
        while (nodo.Izquierdo != null)
            nodo = nodo.Izquierdo;
        return nodo;
    }

    // Eliminar
    public Nodo Eliminar(Nodo raiz, int valor)
    {
        if (raiz == null) return raiz;

        if (valor < raiz.Valor)
            raiz.Izquierdo = Eliminar(raiz.Izquierdo, valor);
        else if (valor > raiz.Valor)
            raiz.Derecho = Eliminar(raiz.Derecho, valor);
        else
        {
            if (raiz.Izquierdo == null)
                return raiz.Derecho;
            else if (raiz.Derecho == null)
                return raiz.Izquierdo;

            Nodo temp = Minimo(raiz.Derecho);
            raiz.Valor = temp.Valor;
            raiz.Derecho = Eliminar(raiz.Derecho, temp.Valor);
        }
        return raiz;
    }

    // Recorridos
    public void Inorden(Nodo raiz)
    {
        if (raiz != null)
        {
            Inorden(raiz.Izquierdo);
            Console.Write(raiz.Valor + " ");
            Inorden(raiz.Derecho);
        }
    }

    public void Preorden(Nodo raiz)
    {
        if (raiz != null)
        {
            Console.Write(raiz.Valor + " ");
            Preorden(raiz.Izquierdo);
            Preorden(raiz.Derecho);
        }
    }

    public void Postorden(Nodo raiz)
    {
        if (raiz != null)
        {
            Postorden(raiz.Izquierdo);
            Postorden(raiz.Derecho);
            Console.Write(raiz.Valor + " ");
        }
    }

    // Altura
    public int Altura(Nodo raiz)
    {
        if (raiz == null) return -1;
        return 1 + Math.Max(Altura(raiz.Izquierdo), Altura(raiz.Derecho));
    }

    // Máximo
    public int Maximo()
    {
        Nodo actual = Raiz;
        while (actual.Derecho != null)
            actual = actual.Derecho;
        return actual.Valor;
    }

    // Mínimo
    public int Min()
    {
        Nodo actual = Raiz;
        while (actual.Izquierdo != null)
            actual = actual.Izquierdo;
        return actual.Valor;
    }

    // Limpiar árbol
    public void Limpiar()
    {
        Raiz = null;
    }
}

class Program
{
    static void Main()
    {
        ArbolBST arbol = new ArbolBST();
        int opcion, valor;

        do
        {
            Console.WriteLine("\n--- MENÚ BST ---");
            Console.WriteLine("1. Insertar");
            Console.WriteLine("2. Buscar");
            Console.WriteLine("3. Eliminar");
            Console.WriteLine("4. Recorrido Inorden");
            Console.WriteLine("5. Recorrido Preorden");
            Console.WriteLine("6. Recorrido Postorden");
            Console.WriteLine("7. Mostrar mínimo");
            Console.WriteLine("8. Mostrar máximo");
            Console.WriteLine("9. Mostrar altura");
            Console.WriteLine("10. Limpiar árbol");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Valor a insertar: ");
                    valor = int.Parse(Console.ReadLine());
                    arbol.Raiz = arbol.Insertar(arbol.Raiz, valor);
                    break;

                case 2:
                    Console.Write("Valor a buscar: ");
                    valor = int.Parse(Console.ReadLine());
                    Console.WriteLine(arbol.Buscar(arbol.Raiz, valor) ? "Encontrado" : "No encontrado");
                    break;

                case 3:
                    Console.Write("Valor a eliminar: ");
                    valor = int.Parse(Console.ReadLine());
                    arbol.Raiz = arbol.Eliminar(arbol.Raiz, valor);
                    break;

                case 4:
                    arbol.Inorden(arbol.Raiz);
                    break;

                case 5:
                    arbol.Preorden(arbol.Raiz);
                    break;

                case 6:
                    arbol.Postorden(arbol.Raiz);
                    break;

                case 7:
                    Console.WriteLine("Mínimo: " + arbol.Min());
                    break;

                case 8:
                    Console.WriteLine("Máximo: " + arbol.Maximo());
                    break;

                case 9:
                    Console.WriteLine("Altura: " + arbol.Altura(arbol.Raiz));
                    break;

                case 10:
                    arbol.Limpiar();
                    Console.WriteLine("Árbol limpiado.");
                    break;
            }

        } while (opcion != 0);
    }
}

