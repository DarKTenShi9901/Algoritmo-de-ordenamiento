using System;

// Define una clase llamada SortingAlgorithms que contendrá nuestros métodos de ordenación.
class SortingAlgorithms
{
    // Método estático ShellSort para ordenar un array utilizando el algoritmo de Shell.
    static void ShellSort(int[] arr)
    {
        // Obtiene la longitud del array.
        int n = arr.Length;
        // Calcula el valor inicial del gap (distancia entre elementos a comparar).
        int gap = n / 2;
        // Inicializa contadores para las pasadas y los intercambios realizados.
        int pasadas = 0, intercambios = 0;

        // Continúa mientras el valor del gap sea mayor que 0.
        while (gap > 0)
        {
            // Itera sobre los elementos del array comenzando desde el primer elemento después del gap.
            for (int i = gap; i < n; i++)
            {
                // Almacena el valor actual del elemento en una variable temporal.
                int temp = arr[i];
                int j;
                // Realiza una ordenación por inserción para el subarray definido por el gap.
                for (j = i; j >= gap && arr[j - gap] > temp; j -= gap)
                {
                    // Desplaza el elemento a la posición actual.
                    arr[j] = arr[j - gap];
                    // Incrementa el contador de intercambios.
                    intercambios++;
                }
                // Coloca el elemento temporal en su posición correcta.
                arr[j] = temp;
            }
            // Incrementa el contador de pasadas después de completar una pasada completa.
            pasadas++;
            // Reduce el gap para la próxima iteración, acercándose progresivamente a 1.
            gap /= 2;
        }

        // Imprime el número de pasadas e intercambios realizados durante el Shell Sort.
        Console.WriteLine($"Shell Sort -> Pasadas: {pasadas}, Intercambios: {intercambios}");
    }

    // Método Partition utilizado por QuickSort para dividir el array.
    static int Division(int[] arr, int low, int high)
    {
        // Elige el último elemento como pivote.
        int pivot = arr[high];
        // Índice del elemento menor.
        int i = (low - 1);

        // Itera sobre el array desde 'low' hasta 'high - 1'.
        for (int j = low; j < high; j++)
        {
            // Si el elemento actual es menor que el pivote, intercambia con el elemento en 'i'.
            if (arr[j] < pivot)
            {
                i++;
                // Realiza el intercambio.
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }
        // Coloca el pivote en su posición correcta.
        int temp1 = arr[i + 1];
        arr[i + 1] = arr[high];
        arr[high] = temp1;
        // Retorna la posición del pivote.
        return i + 1;
    }

    // Método QuickSort que ordena el array de manera recursiva.
    static void QuickSort(int[] arr, int low, int high)
    {
        // Verifica si hay al menos dos elementos para ordenar.
        if (low < high)
        {
            // Particiona el array y obtiene la posición del pivote.
            int pi = Division(arr, low, high);
            // Ordena recursivamente los elementos antes y después de la partición.
            QuickSort(arr, low, pi - 1);
            QuickSort(arr, pi + 1, high);
        }
    }

    // Método Main, punto de entrada del programa.
    static void Main()
    {
        // Define y inicializa el array a ordenar.
        int[] arr = { 8, 43, 17, 6, 40, 16, 18, 97, 11, 7 };

        // Realiza una copia del array para usar con Shell Sort.
        int[] shellSortArray = (int[])arr.Clone();
        Console.WriteLine("Ordenando con Shell Sort:");
        // Ordena el array con Shell Sort y muestra los resultados.
        ShellSort(shellSortArray);
        Console.WriteLine("Array ordenado con Shell Sort:");
        foreach (var item in shellSortArray)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine("\n");

        // Realiza otra copia del array original para usar con QuickSort.
        int[] quickSortArray = (int[])arr.Clone();
        Console.WriteLine("Ordenando con Quicksort:");
        // Ordena el array con QuickSort y muestra los resultados.
        QuickSort(quickSortArray, 0, quickSortArray.Length - 1);
        Console.WriteLine("Array ordenado con Quicksort:");
        foreach (var item in quickSortArray)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}