using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hyno
{
    [CreateAssetMenu(menuName = "Hyno/DataNPC", fileName = "DataNPC")]
    public class DataNPC : ScriptableObject
    {
        [Header("NPC名稱")]
        public string nameNPC;
        [NonReorderable]//移除排序造成的BUG
        public DataDialogue[] dataDialogue;
    }

    [System.Serializable]
    public class DataDialogue
    {
        [Header("對話內容")]
        public string content;
        [Header("對話音效")]
        public AudioClip sound;
    }
}
