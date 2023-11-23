using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts
{
    public class Scanner : MonoBehaviour
    {
        private List<Resource> _resources = new();

        public int Resources => _resources.Count;

        private void FixedUpdate()
        {
            StartCoroutine(Scanning());
        }

        public List<Resource> ScanPositionResources() =>
            GetResourcesNotFound();

        //public void AddResource(Resource resource) =>
        //    _resources.Add(resource);

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

            //Resource resource = ResourceLocator.TryGetResource();

            //if (resource != null)
            //{
            //    Debug.Log(_resources.Count);
            //    _resources.Add(resource);
            //}
            _resources = ResourceLocator.TryGetResource();
        }
    }
}