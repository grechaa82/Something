class Program
{
    private static int numberOfThreads = 5;

    static void Main()
    {
        var threads = CreateThead(numberOfThreads);

        for (int i = 0; i < threads.Count; i++)
        {
            threads[i].Start();
        }

        while (true) ;
    }

    private static List<Thread> CreateThead(int numberOfThreads)
    {
        var threads = new List<Thread>();

        for (int i = 0; i < numberOfThreads; i++)
        {
            var t = new Thread(printThread);
            threads.Add(t);
        }

        return threads;
    }

    private static void printThread()
    {
        var positionLeft = 0;
        var positionTop = Thread.CurrentThread.ManagedThreadId;

        for (int i = 0; i < 50; i++)
        {
            Console.SetCursorPosition(positionLeft + 1, positionTop);
            Console.Write("@");
            Console.SetCursorPosition(positionLeft, positionTop);
            Console.Write(" ");
            Thread.Sleep(100);
            ++positionLeft;
        }
    }
}