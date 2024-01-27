using UnityEngine;
using UnityEngine.Events;

namespace Runtime.Common
{
    public class Trigger : MonoBehaviour
    {
        [SerializeField] private UnityEvent unityEvent;

        private void OnTriggerEnter2D(Collider2D other)
        {
            unityEvent?.Invoke();
        }
    }
}