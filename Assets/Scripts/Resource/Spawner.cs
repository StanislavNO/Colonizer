using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private UnityEvent<Resource> _resourceCreated;
        [SerializeField] private List<Resource> _resources;

        public void CreatePrefab(Vector3 position)
        {
            Resource resource = Instantiate(
                GetResource(),
                position + Vector3.up,
                Quaternion.identity);

            ResourceLocator.SetResource(resource);
            ResourceWorldCounter.AddResource();
        }

        private Resource GetResource() =>
            _resources[Random.Range(0, _resources.Count)];
    }
}