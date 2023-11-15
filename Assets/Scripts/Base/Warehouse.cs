using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class Warehouse : MonoBehaviour
    {
        [SerializeField] private UnityEvent _unitPriceAchieved;
        [SerializeField] private Transform _storageBox;

        private Queue<Resource> _resources = new();

        readonly private int _unitPrice = 3;

        public int Resource => _resources.Count;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Resource resource))
            {
                if (resource.IsAssembled == false)
                {
                    AddResource(resource);
                    CollectResource(resource);
                }
            }

            TryBayUnit();
        }

        private void TryBayUnit()
        {
            if (_resources.Count >= _unitPrice)
            {
                DeleteResource(_unitPrice);

                _unitPriceAchieved.Invoke();
            }
        }

        private void AddResource(Resource resource) =>
            _resources.Enqueue(resource);

        private void DeleteResource(int value)
        {
            int minResource = 0;

            if (value > minResource && value <= _resources.Count)
            {
                for (int i = 0; i < value; i++)
                {
                    Resource resource = _resources.Dequeue();
                    resource.ChangedMaterial();
                }
            }
        }

        private void CollectResource(Resource resource)
        {
            resource.CollectResource();
            resource.StopVelocity();
            resource.transform.position = _storageBox.position;
        }
    }
}