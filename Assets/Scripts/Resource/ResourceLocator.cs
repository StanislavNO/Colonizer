using System.Collections.Generic;

namespace Assets.Scripts
{
    public static class ResourceLocator
    {
        private static List<Resource> _resources = new();

        public static List<Resource> TryGetResource()
        {
            return _resources;
        }

        public static void SetResource(Resource resource) 
        {
            _resources.Add(resource);
        }
    }
}