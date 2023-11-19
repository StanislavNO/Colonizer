using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    public class Flag : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Builder _builder;
        [SerializeField] private Pattern _prefab;

        private Pattern _pattern;

        public bool IsActivated { get; private set; }

        private void Awake()
        {
            _pattern = Instantiate(_prefab);

            _pattern.GetComponent<ColorChanger>().SetFlag(this);
            _pattern.transform.position = transform.position;

            IsActivated = false;
        }

        public void OnPointerClick(PointerEventData eventData)
            => _builder.ChangeTargetBase(this);

        public void Activate() =>
            IsActivated = true;

        public void Deactivate() =>
            IsActivated = false;

        public Pattern GetPattern() =>
            _pattern;
    }
}