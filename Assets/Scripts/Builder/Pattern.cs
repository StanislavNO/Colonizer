using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(ColorChanger))]
    public class Pattern : MonoBehaviour
    {
        [SerializeField] private Flag _flag;
        [SerializeField] private BaseBuilder _baseBuilder;

        public void Init(Flag flag)
        {
            _flag = flag;
            _baseBuilder.Init(_flag.GetComponent<Base>(), _flag.GetComponent<Warehouse>(), _flag.GetComponent<UnitParking>());
        }

        public bool IsActivated { get; private set; }

        public void Activate()
        {
            IsActivated = true;
            //_baseBuilder
        }

        public void DeActivate()
        {
            IsActivated = false;
        }

    }
}