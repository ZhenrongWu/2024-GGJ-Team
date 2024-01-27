using UnityEngine;

namespace Runtime.Common
{
    public class Animation : MonoBehaviour
    {
        [SerializeField] private GameObject obj;

        public void OpenObj()
        {
            obj.SetActive(true);
        }
    }
}