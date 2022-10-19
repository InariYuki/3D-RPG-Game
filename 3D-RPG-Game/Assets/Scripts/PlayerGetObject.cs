using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace KitsuneYuki
{
    public class PlayerGetObject : MonoBehaviour
    {
        int missionCount = 20;
        int currentCount = 0;
        ObjectPoolChain chainPool;
        TextMeshProUGUI missionDisplay;
        [SerializeField] DataNPC cmplDialogue;
        NPCSystem npc;
        private void Awake()
        {
            chainPool = FindObjectOfType<ObjectPoolChain>();
            missionDisplay = GameObject.Find("MissionCountDisplay").GetComponent<TextMeshProUGUI>();
            npc = GameObject.Find("NPC").GetComponent<NPCSystem>();
        }
        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (hit.gameObject.name.Contains("hall_anchor"))
            {
                chainPool.ReleaseObject(hit.gameObject);
                UpdateMisisonDisplay();
            }
        }
        void UpdateMisisonDisplay()
        {
            currentCount++;
            missionDisplay.text = "ย๊ร์:" + currentCount + "/" + missionCount;
            if (currentCount >= missionCount)
            {
                npc.data_npc = cmplDialogue;
            }
        }
    }
}
