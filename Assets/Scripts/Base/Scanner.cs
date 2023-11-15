using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Scanner : MonoBehaviour
    {
        private List<Resource> _resources = new();

        public int Resources => _resources.Count;

        public List<Resource> ScanPositionResources() =>
            GetResourcesNotFound();

        public void AddResource(Resource resource) =>
            _resources.Add(resource);

        private List<Resource> GetResourcesNotFound()
        {
            List<Resource> resourcesNotFound = new();

            foreach (Resource resource in _resources)
            {
                if (resource.IsFound == false)
                    resourcesNotFound.Add(resource);
            }

            return resourcesNotFound;
        }
    }
}