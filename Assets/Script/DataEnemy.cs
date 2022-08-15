using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hyno
{
    [CreateAssetMenu(menuName ="Hyno/DataEnemy",fileName = "DataEnemy")]
    public class DataEnemy :ScriptableObject
    {
        [Header("血量"), Range(0, 2000)]
        public float hp;
        [Header("攻擊力"), Range(0, 200)]
        public float attack;
        [Header("追蹤距離"), Range(0, 200)]
        public float rangTrack;
        [Header("攻擊距離"), Range(0, 10)]
        public float rangAttack;
        [Header("走路速度"), Range(0, 100)]
        public float seepWalk;
        [Header("掉落道具機率"), Range(0, 1)]
        public float propbilityProp;
        [Header("掉落道具")]
        public GameObject goProp;
        [Header("等待時間範圍")]
        public Vector2 timeIdleRange;
        [Header("要追蹤的目標圖層")]
        public LayerMask layerTarget;
        [Header("攻擊間隔"),Range(0,5)]
        public float intervalAttack;
    }
}

