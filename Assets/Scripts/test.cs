using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class test : MonoBehaviour
    {
        private void Awake()
        {
            EventBus.PatternActivated.AddListener(test1);
        }
        // Use this for initialization
        void Start()
        {
            EventBus.UseEventPattern();
        }

        private void test1()
        {
            Debug.Log("test");
        }
    }
}