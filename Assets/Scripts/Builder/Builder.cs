using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Pattern))]
    public class Builder : MonoBehaviour
    {
        private UnitParking _unitParking;
        private Warehouse _warehouse;
        private Pattern _pattern;

        private Vector3 _startPosition;
        private bool _isActivated;
        private bool _isBay;

        public void Init(UnitParking unitParking, Warehouse warehouse, Pattern pattern)
        {
            _unitParking = unitParking;
            _warehouse = warehouse;
            _pattern = pattern;
            //StartCoroutine(CreateBase1());
        }

        private void Awake() =>
            _isActivated = false;

        private void Start() =>
            _startPosition = transform.position;

        private void LateUpdate()
        {
            if (transform.position != _startPosition)
                _isActivated = true;

            if (_isActivated)
                CreateBase();
            else
                _isBay = false;
        }

        private void OnTrigerEnter(Collider collider)
        {
            if(collider.TryGetComponent<Collector>(out Collector unit))
            {
                if(unit.IsWorking == false)
                {
                    UnitParking newBase =
                        Instantiate(_unitParking, transform.position, Quaternion.identity);

                    newBase.SetUnit(unit);
                }
            }
        }

        public void Work()
        {

        }

        private void Deactivate()
        {
            transform.position = _startPosition;
            _isActivated = false;
        }

        private void CreateBase()
        {
            if (_isBay == false)
            {
                _isBay = true;
                _warehouse.SaveUpForBase();
            }
        }
    }
}