using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class ToolsForStringsSt
    {
        public static string DoMagic(string input)
        {
            var output = string.Empty;

            foreach(var c in input)
            {
                output += c + " ";
            }

            return output;
        }
    }

    public class Worker
    {
        public string Name { get; set; }
        public Worker(string name)
        {
            Name = name;
        }

        public static string DoMagic(string input)
        {
            var output = " dice que ";

            foreach (var c in input)
            {
                output += c + " ";
            }

            return output;
        }
    }
}
