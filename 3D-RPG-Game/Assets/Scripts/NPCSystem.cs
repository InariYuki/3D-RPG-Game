using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitsuneYuki
{
    public class NPCSystem : MonoBehaviour
    {
        public DataNPC data_npc;
        [SerializeField] GameObject npc_cam;
        DialogueHint hint;
        ThirdPersonController third_person_ctrl;
        DialogueSystem dialogue_system;
        Animator anim;
        bool player_detected = false;
        private void Awake()
        {
            third_person_ctrl = FindObjectOfType<ThirdPersonController>();
            dialogue_system = FindObjectOfType<DialogueSystem>();
            hint = FindObjectOfType<DialogueHint>();
            anim = GetComponent<Animator>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.name != "Player") return;
            hint.HintOn();
            player_detected = true;
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.name != "Player") return;
            hint.HintOff();
            player_detected = false;
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (player_detected)
                {
                    if (dialogue_system.is_talking) return;
                    third_person_ctrl.enabled = false;
                    npc_cam.SetActive(true);
                    hint.HintOff();
                    dialogue_system.TriggerConversation(ResetControl , data_npc);
                    try
                    {
                        anim.SetBool("bool_talk" , true);
                    }
                    catch
                    {
                        print("There is no Animator");
                    }
                }
            }
        }
        void ResetControl()
        {
            npc_cam.SetActive(false);
            third_person_ctrl.enabled = true;
            hint.HintOn();
            try
            {
                anim.SetBool("bool_talk", false);
            }
            catch
            {
                print("There is no Animator");
            }
        }
    }
}
