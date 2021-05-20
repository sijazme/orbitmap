using System.Collections.Generic;
using System.IO;

namespace OrbitMap
{
    class MapDictionary : Dictionary<string,string>
    {
        public MapDictionary(string data)
        {
            this.Add("COM", null);
            this.LoadData(data);
        }

        public void LoadData(string data)
        {            
            using (StringReader reader = new StringReader(data))
            {
                string line = string.Empty;
                do
                {
                    line = reader.ReadLine();
                    if (line != null)
                    {
                        string[] orbEntry = line.Split(')');
                        this.Add(orbEntry[1], orbEntry[0]);
                    }

                } while (line != null);
            }            
        }
    }
}
