using System;

namespace Task5._1
{
    class Program
    {
        static void Main()
        {
            var matrix = new SparseMatrix(10, 7);
            matrix[1, 1] = 388;
            matrix[1, 2] = 5987;
            matrix[10, 7] = 7456;
            matrix[10, 1] = 4567;
            matrix[1, 7] = 36;
            Console.WriteLine("string");
            Console.WriteLine(matrix.ToString());

            Console.WriteLine("Non zero elements");
            foreach (var element in matrix.GetNonzeroElements())
            {
                Console.WriteLine(element);
            }

            Console.WriteLine($"0: {matrix.GetCount(0)}");

            Console.WriteLine($"36: {matrix.GetCount(36)}");

            var a = matrix.GetEnumerator();

            while(a.MoveNext())
            {
                Console.Write(a.Current);
                Console.Write(", ");
            }
        }
    }
}
