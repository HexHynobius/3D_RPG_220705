using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hyno
{
    [CreateAssetMenu(menuName = "Hyno/DataNPC", fileName = "DataNPC")]
    public class DataNPC : ScriptableObject
    {
        [Header("NPC�W��")]
        public string nameNPC;
        [NonReorderable]//�����Ƨǳy����BUG
        public DataDialogue[] dataDialogue;
    }

    [System.Serializable]
    public class DataDialogue
    {
        [Header("��ܤ��e")]
        public string content;
        [Header("��ܭ���")]
        public AudioClip sound;
    }
}
