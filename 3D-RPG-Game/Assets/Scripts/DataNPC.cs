using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitsuneYuki
{
    [CreateAssetMenu(menuName = "ScriptableObject/DataNPC" , fileName ="DataNPC")]
    public class DataNPC : ScriptableObject
    {
        public string NPC_name;
        [NonReorderable] public Dialogue[] NPC_dialogues;
    }
    [System.Serializable]
    public class Dialogue
    {
        public string dialogue_text;
        public AudioClip dialogue_sound;
    }
}
