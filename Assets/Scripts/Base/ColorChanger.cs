using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Renderer))]
    public class ColorChanger : MonoBehaviour
    {
        [SerializeField] private Flag _flag;
        [SerializeField] private Color _activeColor;

        private Renderer _renderer;
        private Color _startColor;

        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
            _startColor = _renderer.material.color;
        }

        //private void OnEnable()
        //{
        //    _renderer = GetComponent<Renderer>();
        //    _startColor = _renderer.material.color;
        //}

        private void Update()
        {
            Debug.Log($"{transform}  {_flag.IsActivated }");

            TryChangeColor();
        }

        //!!!
        public void SetFlag(Flag flag)
        {
            _flag = flag;
        }

        private void TryChangeColor()
        {
            if (_flag.IsActivated && _renderer.material.color == _startColor)
            {
                _renderer.material.color = _activeColor;
            }
            else if (_flag.IsActivated == false && _renderer.material.color == _activeColor)
            {
                _renderer.material.color = _startColor;
            }
        }
    }
}