using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.IO.Directory;
using static System.Console;
using static System.IO.Path;
using static System.Environment;

namespace WorkingWithFileSystems
{
    public partial class Program
    {
        static void SectionTitle(string title)
        {
            ConsoleColor previousColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("*");
            WriteLine($"* {title}");
            WriteLine("*");
            ForegroundColor = previousColor;
        }
    }
}
