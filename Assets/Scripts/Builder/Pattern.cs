using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(ColorChanger))]
    public class Pattern : MonoBehaviour
    {
        [SerializeField] private Flag _flag;

        private bool _isActivated;

    }
}