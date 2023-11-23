using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public static class ResourceLocator
    {
        private static List<Resource> _resources = new();
        private static int count;

        public static List<Resource> TryGetResource()
        {
            //if (count < _resources.Count)
            //{
            //    Resource result = _resources[count];
            //    count++;

            //    return result;
            //}

            return _resources;
        }

        public static void SetResource(Resource resource) 
        {
            _resources.Add(resource);
        }
    }
}