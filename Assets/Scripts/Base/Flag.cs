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
        private bool _isActive;

        public bool IsActive => _isActive;

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
            _isActive = true;
        }

        public void Deactivate()
        {
            _isActive = false;
        }

        public Pattern GetPattern()
        {
            return _pattern;
        }
    }
}