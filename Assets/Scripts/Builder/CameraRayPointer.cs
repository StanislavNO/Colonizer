using UnityEngine;

namespace Assets.Scripts
{
    public class CameraRayPointer : MonoBehaviour
    {
        private Ray _ray;
        private RaycastHit _hit;

        public Vector3 Point { get; private set; }
        public Vector3 CurrencyPoint { get; private set; }

        private void Update()
        {
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(_ray.origin, _ray.direction * 100f, Color.gray);

            if (Physics.Raycast(_ray, out _hit))
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    CurrencyPoint = _hit.point;

                    if (_hit.collider.TryGetComponent<Base>(out Base _) == false)
                        Point = _hit.point;
                }
            }
        }
    }
}