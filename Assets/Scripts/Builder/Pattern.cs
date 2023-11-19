using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(ColorChanger))]
    public class Pattern : MonoBehaviour
    {
        [SerializeField] private Flag _flag;
        [SerializeField] private BaseBuilder _baseBuilder;

        public bool IsActivated { get; private set; }

        public void Activate()
        {
            IsActivated = true;
            //_baseBuilder
        }

    }
}