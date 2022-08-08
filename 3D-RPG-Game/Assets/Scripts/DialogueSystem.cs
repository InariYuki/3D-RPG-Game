using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace KitsuneYuki
{
    public delegate void ExitDialogue();
    [RequireComponent(typeof(AudioSource))]
    public class DialogueSystem : MonoBehaviour
    {
        DataNPC data_NPC;
        [SerializeField] CanvasGroup canvas_group;
        [SerializeField] TextMeshProUGUI NPC_name;
        [SerializeField] TextMeshProUGUI NPC_dialogue_text;
        [SerializeField] GameObject dialogue_triangle;
        AudioSource audio_source;
        public bool is_talking = false;
        private void Awake()
        {
            audio_source = GetComponent<AudioSource>();
        }
        public void TriggerConversation(ExitDialogue call_back , DataNPC data_npc)
        {
            data_NPC = data_npc;
            NPC_name.text = data_NPC.NPC_name;
            NPC_dialogue_text.text = "";
            StartCoroutine(DisplayText(call_back));
        }
        IEnumerator FadeIn()
        {
            while (canvas_group.alpha < 1f)
            {
                canvas_group.alpha += 0.02f;
                yield return new WaitForSeconds(1 / 50f);
            }
        }
        IEnumerator FadeOut()
        {
            while (canvas_group.alpha > 0)
            {
                canvas_group.alpha -= 0.02f;
                yield return new WaitForSeconds(1 / 50f);
            }
        }
        IEnumerator DisplayText(ExitDialogue call_back)
        {
            is_talking = true;
            yield return StartCoroutine(FadeIn());
            for (int i = 0; i < data_NPC.NPC_dialogues.Length; i++)
            {
                Dialogue current = data_NPC.NPC_dialogues[i];
                audio_source.PlayOneShot(current.dialogue_sound);
                NPC_dialogue_text.text = "";
                for (int j = 0; j < current.dialogue_text.Length; j++)
                {
                    NPC_dialogue_text.text += current.dialogue_text[j];
                    yield return new WaitForSeconds(0.1f);
                }
                dialogue_triangle.SetActive(true);
                while (!Input.GetKeyDown(KeyCode.E))
                {
                    yield return null;
                }
                dialogue_triangle.SetActive(false);
            }
            is_talking = false;
            StartCoroutine(FadeOut());
            call_back();
        }
    }
}
