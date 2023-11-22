using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(ColorChanger))]
    public class Pattern : MonoBehaviour
    {
        [SerializeField] private Builder _baseBuilder;

        private Flag _flag;

        public void Init(Flag flag)
        {
            _flag = flag;

            _baseBuilder.Init(_flag.GetComponent<UnitParking>(),
                _flag.GetComponent<Warehouse>(),
                this);
        }

        private void Update()
        {
            Debug.Log(IsActivated);
        }

        public bool IsActivated { get; private set; }

        public void Activate()
        {
            IsActivated = true;
            _baseBuilder.Work();
        }

        public void DeActivate()
        {
            IsActivated = false;
        }

    }
}