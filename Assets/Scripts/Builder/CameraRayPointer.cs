using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class CameraRayPointer : MonoBehaviour
    {
        private Ray _ray;
        private RaycastHit _hit;

        public Vector3 point { get; private set; }

        private void Update()
        {
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(_ray.origin, _ray.direction * 100f, Color.gray);

            if (Physics.Raycast(_ray, out _hit))
                point = _hit.point;
        }
    }
}