using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Runtime.Common
{
    public class Transition : MonoBehaviour
    {
        [SerializeField] private string sceneName;
        [SerializeField] private Button button;

        private void Start()
        {
            if (button != null) button.onClick.AddListener(ChangeSceneEvent);
        }

        public void ChangeSceneEvent()
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}