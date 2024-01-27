using System.Collections;
using TMPro;
using UnityEngine;

namespace Runtime.Core
{
    public class Dialogue : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI showText;
        [SerializeField] private string[]        sentences;

        private int _sentencesLength;
        private int _loadingTextNum = -1;

        private void Start()
        {
            _sentencesLength = sentences.Length;

            StartCoroutine(LoadingText(sentences[0]));
            _loadingTextNum++;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_loadingTextNum + 1 < _sentencesLength)
                {
                    _loadingTextNum++;
                    StartCoroutine(LoadingText(sentences[_loadingTextNum]));
                }
                else
                {
                    // Debug.Log("超出選擇");
                }
            }
        }
        

        private IEnumerator LoadingText(string text)
        {
            string swapStr   = "";
            int    loopTimes = text.Length;
            for (int i = 0; i < loopTimes; i++)
            {
                swapStr       += text[i];
                showText.text =  swapStr;
                yield return new WaitForSeconds(.1f);
                // Debug.Log(swapStr);
            }

            // Debug.Log("顯示結束");
        }
    }
}