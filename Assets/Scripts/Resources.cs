using System.Collections.Generic;

namespace Dakard.Card
{
    public static class Resources
    {
        public static void AddResource(Dictionary<string, int> values, string resource)
        {
            if (values.ContainsKey(resource))
            {
                values[resource]++;
            }
            else
            {
                values.Add(resource, 1);
            }
        }
    
        public static void RemoveResource(Dictionary<string, int> values, string resource)
        {
            if (values.ContainsKey(resource))
            {
                values[resource]--;
            }   
        }
    }   
}
