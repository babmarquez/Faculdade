using OpenTK;
using System;

namespace UnidadeDois
{
    static class Program
    {
        static void Main(string[] args)
        {
            GameWindow window = new Exer4(600, 600);
            window.Run(1.0 / 60.0); ;
        }
    }
}
