using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitsuneYuki
{
    public class DialogueHint : MonoBehaviour
    {
        CanvasGroup canvas_group;
        Coroutine fade_routine;
        private void Awake()
        {
            canvas_group = GetComponent<CanvasGroup>();
        }
        public void HintOn()
        {
            fade_routine = StartCoroutine(FadeIn());
        }
        public void HintOff()
        {
            StopCoroutine(fade_routine);
            canvas_group.alpha = 0;
        }
        IEnumerator FadeIn()
        {
            while (canvas_group.alpha <= 1f)
            {
                canvas_group.alpha += 1 / 50f;
                yield return new WaitForSeconds(1/50f);
            }
            StopCoroutine(fade_routine);
        }
    }
}
