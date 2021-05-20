using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OrbitMap
{
    class OMap
    {   
        public int GetOrbitCount(string input)
        {
            return GetMapEnumeration(input).Count();
        }
        
        private IEnumerable<int> GetMapEnumeration(string input)
        {
            var ODic = GetMapDictionary(input);

            foreach (var obj in ODic)
            {
                var nextObj = obj;

                while (nextObj.Value != null)
                {
                    yield return 1;

                    // find the first object around which this object orbits
                    nextObj = ODic.First(map => map.Key.Equals(nextObj.Value));
                }
            }
        }
        
        private MapDictionary GetMapDictionary(string data)
        {
            var orbitDic = new MapDictionary();            

            using (StringReader reader = new StringReader(data))
            {
                string line = string.Empty;
                do
                {
                    line = reader.ReadLine();
                    if (line != null)
                    {
                        string[] orbEntry = line.Split(')');
                        orbitDic.Add(orbEntry[1], orbEntry[0]);
                    }

                } while (line != null);
            }

            return orbitDic;
        }
       
    }
}
