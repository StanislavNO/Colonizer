using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public static class EventBus 
    {
        public static UnityEvent PatternActivated = new();

        public static void UseEventPattern() => PatternActivated.Invoke();
    }
}