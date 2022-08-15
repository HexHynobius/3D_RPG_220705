using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hyno
{
    [CreateAssetMenu(menuName ="Hyno/DataEnemy",fileName = "DataEnemy")]
    public class DataEnemy :ScriptableObject
    {
        [Header("��q"), Range(0, 2000)]
        public float hp;
        [Header("�����O"), Range(0, 200)]
        public float attack;
        [Header("�l�ܶZ��"), Range(0, 200)]
        public float rangTrack;
        [Header("�����Z��"), Range(0, 10)]
        public float rangAttack;
        [Header("�����t��"), Range(0, 100)]
        public float seepWalk;
        [Header("�����D����v"), Range(0, 1)]
        public float propbilityProp;
        [Header("�����D��")]
        public GameObject goProp;
        [Header("���ݮɶ��d��")]
        public Vector2 timeIdleRange;
        [Header("�n�l�ܪ��ؼйϼh")]
        public LayerMask layerTarget;
        [Header("�������j"),Range(0,5)]
        public float intervalAttack;
    }
}

