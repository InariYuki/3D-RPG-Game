using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace KitsuneYuki
{
    [RequireComponent(typeof(AudioSource))]
    public class DialogueSystem : MonoBehaviour
    {
        public DataNPC data_NPC;
        [SerializeField] CanvasGroup canvas_group;
        [SerializeField] TextMeshProUGUI NPC_name;
        [SerializeField] TextMeshProUGUI NPC_dialogue_text;
        [SerializeField] GameObject dialogue_triangle;
        AudioSource audio_source;
        private void Awake()
        {
            audio_source = GetComponent<AudioSource>();
            StartCoroutine(FadeIn());
            StartCoroutine(DisplayText());
        }
        IEnumerator FadeIn()
        {
            NPC_name.text = data_NPC.NPC_name;
            NPC_dialogue_text.text = "";
            while(canvas_group.alpha < 1)
            {
                canvas_group.alpha += 0.02f;
                yield return new WaitForSeconds(1/50);
            }
        }
        IEnumerator DisplayText()
        {
            Dialogue current = data_NPC.NPC_dialogues[0];
            audio_source.PlayOneShot(current.dialogue_sound);
            for(int i = 0; i < current.dialogue_text.Length; i++)
            {
                NPC_dialogue_text.text += current.dialogue_text[i];
                yield return new WaitForSeconds(0.1f);
            }
            dialogue_triangle.SetActive(true);
        }
    }
}
