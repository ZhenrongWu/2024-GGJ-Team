using System.Collections;
using UnityEngine;

namespace Runtime.Common
{
    public class FadeInImage : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer sprite;
        [SerializeField] private Color          color;

        private Color _currColor;

        public bool IsStart { get; set; }

        private void Update()
        {
            if (IsStart)
            {
                StartCoroutine(SpriteColor());
            }
        }

        private IEnumerator SpriteColor()
        {
            yield return new WaitForSeconds(1.5f);
            sprite.color = Color.Lerp(sprite.color, color, Time.deltaTime);
        }
    }
}