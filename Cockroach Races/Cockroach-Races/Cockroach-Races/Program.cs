class Program
{
    private static int numberOfCockroachs = 14;
    private static object _lock = new object();
    private static ConsoleColor? _winner = null;

    static void Main()
    {
        var threads = CreateThead(numberOfCockroachs);

        Console.CursorVisible = false;

        foreach (Thread thread in threads)
        {
            thread.Start();
        }

        foreach (Thread thread in threads)
        {
            thread.Join();
        }

        Console.ReadKey();
    }

    private static List<Thread> CreateThead(int numberOfThreads)
    {
        var threads = new List<Thread>();

        for (int i = 1; i <= numberOfCockroachs; i++)
        {
            Cockroach cockroach = new Cockroach(GetColor(i), _lock);
            var t = new Thread(cockroach.Run);
            threads.Add(t);
        }

        return threads;
    }

    public static void PrintWinner(ConsoleColor color)
    {
        if (_winner == null)
        {
            lock(_lock)
            {
                _winner = color;
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = color;
                Console.Write($"The cockroach with the color '{color}' won");
            }
        }
    }

    private static ConsoleColor GetColor(int i)
    {
        switch (i % 15)
        {
            case 1: return ConsoleColor.White;
            case 2: return ConsoleColor.DarkBlue;
            case 3: return ConsoleColor.DarkGreen;
            case 4: return ConsoleColor.DarkCyan;
            case 5: return ConsoleColor.DarkRed;
            case 6: return ConsoleColor.DarkMagenta;
            case 7: return ConsoleColor.DarkYellow;
            case 8: return ConsoleColor.Gray;
            case 9: return ConsoleColor.Blue;
            case 10: return ConsoleColor.Green;
            case 11: return ConsoleColor.Cyan;
            case 12: return ConsoleColor.Red;
            case 13: return ConsoleColor.Magenta;
            case 14: return ConsoleColor.Yellow;
            case 15: return ConsoleColor.Black;
            default: return ConsoleColor.White;
        }
    }
}

class Cockroach
{
    private int _position;
    private ConsoleColor _color;
    private readonly Random _random;
    private object _lock;
    private bool _isFinish = false;

    public Cockroach(ConsoleColor color, object ObjectLock)
    {
        _position = 0;
        _color = color;
        _random = new Random();
        _lock = ObjectLock;
    }

    public void Run()
    {
        while (_isFinish != true)
        {
            Move();
            Thread.Sleep(_random.Next(50, 500));
        }
    }

    private void Move()
    {
        int newPosition = _position + _random.Next(1, 6);
        lock (_lock)
        {
            if (newPosition >= Console.WindowWidth)
            {
                Program.PrintWinner(_color);
            }
            else
            {
                Console.SetCursorPosition(newPosition, Thread.CurrentThread.ManagedThreadId);
                Console.ForegroundColor = _color;
                Console.Write("@");
                Console.SetCursorPosition(_position, Thread.CurrentThread.ManagedThreadId);
                Console.Write(" ");
                _position = newPosition;
            }
        }
    }
}