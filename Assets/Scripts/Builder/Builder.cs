using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(BuildPointer))]
    public class Builder : MonoBehaviour
    {
        private UnitParking _unitParking;
        private Warehouse _warehouse;

        private Vector3 _startPosition;
        private bool _isActivated;
        private bool _isWorking;

        public void Init(UnitParking unitParking, Warehouse warehouse)
        {
            _unitParking = unitParking;
            _warehouse = warehouse;
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
                _isWorking = false;
        }

        private void OnTriggerEnter(Collider collider)
        {
            Vector3 newPosition = new(
                transform.position.x,
                _unitParking.transform.position.y,
                transform.position.z);

            if (collider.TryGetComponent<Collector>(out Collector unit))
            {
                if (unit.IsStray == true && _isActivated)
                {
                    UnitParking newBase =
                        Instantiate(_unitParking, newPosition, Quaternion.identity);

                    newBase.SetUnit(unit);
                    unit.ChangeHomePosition(newBase.transform.position);
                    Deactivate();
                }
            }
        }

        private void Deactivate()
        {
            _isActivated = false;
            transform.position = _startPosition;
        }

        private void CreateBase()
        {
            if (_isWorking == false)
            {
                _isWorking = true;
                _warehouse.SaveUpForBase();
            }
        }
    }
}