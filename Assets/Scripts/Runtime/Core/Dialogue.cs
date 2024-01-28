using System.Collections;
using Runtime.Common;
using TMPro;
using UnityEngine;

namespace Runtime.Core
{
    public class Dialogue : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI showText;
        [SerializeField] private string[]        sentences;

        [Space(10)] [SerializeField] private bool       isNeedTransition;
        [SerializeField]             private Transition transition;
        [SerializeField]             private float      delayTime;

        private int  _sentencesLength;
        private int  _sentenceNum;
        private int  _loadingTextNum = -1;
        private bool _isTextEnding;

        private void Start()
        {
            _sentencesLength = sentences.Length;

            StartCoroutine(LoadingText(sentences[0]));
            _loadingTextNum++;
            _sentenceNum++;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && _isTextEnding)
            {
                _sentenceNum++;

                if (_loadingTextNum + 1 < _sentencesLength)
                {
                    _loadingTextNum++;
                    StartCoroutine(LoadingText(sentences[_loadingTextNum]));
                }
                else
                {
                    // Debug.Log("超出選擇");
                }

                _isTextEnding = false;
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

            _isTextEnding = true;
            // Debug.Log("顯示結束");
            if (isNeedTransition && _sentenceNum == sentences.Length)
            {
                yield return new WaitForSeconds(delayTime);
                transition.ChangeSceneEvent();
            }
        }
    }
}