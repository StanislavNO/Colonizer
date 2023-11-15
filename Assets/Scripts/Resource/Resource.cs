using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody), (typeof(Renderer)))]
    public class Resource : MonoBehaviour
    {
        [SerializeField] private Material _default;

        private Rigidbody _rigidBody;
        private Renderer _renderer;

        private bool _isAssembled = false;
        private bool _isFound = false;

        public bool IsAssembled => _isAssembled;
        public bool IsFound => _isFound;

        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
            _rigidBody = GetComponent<Rigidbody>();
        }

        public void CollectResource() =>
            _isAssembled = true;

        public void ActivateResource() =>
            _isFound = true;

        public void StopVelocity() =>
            _rigidBody.velocity = Vector3.zero;

        public void ChangedMaterial() =>
            _renderer.material = _default;
    }
}