using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody), (typeof(Renderer)))]
    public class Resource : MonoBehaviour
    {
        [SerializeField] private Material _default;

        private Rigidbody _rigidBody;
        private Renderer _renderer;

        public bool IsAssembled { get; private set; }
        public bool IsFound { get; private set; }

        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
            _rigidBody = GetComponent<Rigidbody>();
        }

        public void CollectResource() =>
            IsAssembled = true;

        public void ActivateResource() =>
            IsFound = true;

        public void StopVelocity() =>
            _rigidBody.velocity = Vector3.zero;

        public void ChangedMaterial() =>
            _renderer.material = _default;
    }
}