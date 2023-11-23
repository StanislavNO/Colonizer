using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Scanner : MonoBehaviour
    {
        private List<Resource> _resources = new();

        public int Resources => _resources.Count;

        private void FixedUpdate() =>
            StartCoroutine(Scanning());

        public List<Resource> ScanPositionResources() =>
            GetResourcesNotFound();

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

        private IEnumerator Scanning()
        {
            WaitForSecondsRealtime delay = new(0.4f);

            yield return delay;

            _resources = ResourceLocator.TryGetResource();
        }
    }
}