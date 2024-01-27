using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Runtime.Common
{
    [RequireComponent(typeof(Button))]
    public class Transition : MonoBehaviour
    {
        [SerializeField] private string sceneName;

        private Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();

            _button.onClick.AddListener(ChangeSceneEvent);
        }

        private void ChangeSceneEvent()
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}