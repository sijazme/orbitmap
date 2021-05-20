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
            var ODic = new MapDictionary(input);

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
       
       
    }
}
