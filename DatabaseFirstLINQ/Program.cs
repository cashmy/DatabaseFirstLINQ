using System;

namespace DatabaseFirstLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Problems problems = new Problems();
            problems.RunLINQQueries();
            Console.WriteLine("\n\n********** End of List **********\n\n");
        }
    }
}
