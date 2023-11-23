using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class TargetMover : MonoBehaviour
    {
        [SerializeField] private UnityEvent _targetAchieved;
        [SerializeField] private float _speed;

        private Transform _targetResource;
        private Vector3 _startPosition;

        public bool IsWorking { get; private set; }
        public bool IsStray { get; private set; }

        public void Init(Vector3 homePosition) =>
            _startPosition = homePosition;

        private void Update()
        {
            if (_targetResource != null)
            {
                Move(_targetResource.position);

                if (transform.position == _targetResource.position)
                {
                    _targetAchieved.Invoke();
                    _targetResource = null;
                }
            }

            if (_targetResource == null && IsWorking == true)
            {
                Move(_startPosition);

                if (transform.position == _startPosition)
                    IsWorking = false;
            }

            if (IsWorking == false && transform.position != _startPosition && _targetResource == null)
            {
                IsStray = true;
                Move(_startPosition);
            }
        }

        public void SetBase()
        {
            IsStray = false;
        }

        //!! basa rigidbady
        //private void OnTriggerEnter(Collider other)
        //{
        //    if (other.TryGetComponent(out Warehouse _))
        //    {
        //        Debug.Log(1);
        //        transform.position = _startPosition;
        //        _isWorking = false;
        //    }
        //}

        public void GoHome(Vector3 homePosition)
        {
            //_isWorking = true;
            _startPosition = homePosition;
        }

        public void SetTarget(Transform resource)
        {
            IsWorking = true;
            _targetResource = resource;
        }

        private void Move(Vector3 targetPosition)
        {
            transform.position = Vector3.MoveTowards(
                    transform.position,
                    targetPosition,
                    _speed * Time.deltaTime);
        }
    }
}