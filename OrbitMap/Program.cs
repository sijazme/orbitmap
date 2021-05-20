using System;
using System.IO;

namespace OrbitMap
{
    class Program
    {
        static void Main(string[] args)
        {
            OMap omap = new OMap();
            
            string data = File.ReadAllText("data.txt");
            
            if (string.IsNullOrEmpty(data) == false)
            {
                int count = omap.GetOrbitCount(data);
                Console.WriteLine("Orbit Count : " + count);
            }

            else
            {
                Console.WriteLine("Orbit data file not found or empty");
            }
            
        }
    }
}
