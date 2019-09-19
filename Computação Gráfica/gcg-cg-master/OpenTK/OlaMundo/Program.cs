using System;
using OpenTK;

namespace OlaMundo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            GameWindow window = new GameWindow(600, 600);
            window.Run(1.0/60.0);
        }
    }
}
