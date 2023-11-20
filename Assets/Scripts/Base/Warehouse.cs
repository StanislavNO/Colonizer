using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class Warehouse : MonoBehaviour
    {
        [SerializeField] private UnityEvent _unitPriceAchieved;
        [SerializeField] private UnityEvent _basePriceAchieved;
        [SerializeField] private Transform _storageBox;

        readonly private int _unitPrice = 3;
        readonly private int _basePrice = 5;
        private int _currentPrice;

        private Queue<Resource> _resources = new();

        public bool IsAccumulateBase { get; private set; }

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

            TryBayPrice();
        }

        public void SaveUpForBase()
        {
            IsAccumulateBase = true;
        }

        private void TryBayPrice()
        {
            if (IsAccumulateBase)
                _currentPrice = _basePrice;
            else
                _currentPrice = _unitPrice;

            if (_resources.Count >= _currentPrice)
            {
                DeleteResource(_currentPrice);

                if (_currentPrice == _unitPrice)
                    _unitPriceAchieved.Invoke();
                else
                {
                    IsAccumulateBase = false;
                    _basePriceAchieved.Invoke();
                }
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