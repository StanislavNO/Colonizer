using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    public class Flag : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Pattern _prefab;
        [SerializeField] private CameraRayPointer _cameraRayPointer;

        private Pattern _pattern;

        public bool IsActivated { get; private set; }

        private void Awake()
        {
            _pattern = Instantiate(_prefab);
            _pattern.Init(this);

            _pattern.GetComponent<ColorChanger>().SetFlag(this);
            _pattern.transform.position = transform.position;

            IsActivated = false;
        }

        private void LateUpdate()
        {
            Debug.Log(_cameraRayPointer.Point);
            if (IsActivated)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    if (_cameraRayPointer.CurrencyPoint == _cameraRayPointer.Point) 
                        _pattern.transform.position = _cameraRayPointer.Point;

                    _pattern.Activate();
                    Deactivate();
                }
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Activate();
        }

        public void Activate() =>
            IsActivated = true;

        public void Deactivate() =>
            IsActivated = false;

        public Pattern GetPattern() =>
            _pattern;
    }
}