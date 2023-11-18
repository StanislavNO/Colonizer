using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    public class Flag : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Builder _builder;
        [SerializeField] private Pattern _prefab;

        private Pattern _pattern;
        private bool _isActivated;

        public bool IsActivated => _isActivated;

        private void Start()
        {
            _pattern = Instantiate(_prefab);

            _pattern.GetComponent<ColorChanger>().SetFlag(this);
            _pattern.transform.position = transform.position;
        }

        public void OnPointerClick(PointerEventData evntData)
        {
            _builder.ChangeTargetBase(this);
        }

        public void Activate()
        {
            _isActivated = true;
        }

        public void Deactivate()
        {
            _isActivated = false;
        }

        public Pattern GetPattern()
        {
            return _pattern;
        }
    }
}