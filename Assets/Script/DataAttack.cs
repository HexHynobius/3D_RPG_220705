using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hyno
{
    [CreateAssetMenu(menuName ="Hyno/DataAttack",fileName = "DataAttack")]
    public class DataAttack : ScriptableObject
    {
        [Header("攻擊力"),Range(0,1000)]
        public float attack;
        [Header("攻擊區域設定")]
        public Color attackAreaColor = new Color(1, 0, 0, 0.5f);
        public Vector3 attackAreaSize = Vector3.one;
        public Vector3 attackAreaoffset;
        [Header("攻擊目標圖層")]
        public LayerMask layerTarget;
        [Header("攻擊延遲時間")]
        public float delayAttack=1.5f;
        [Header("攻擊動畫檔")]
        public AnimationClip animationAttack;

        public float waitAttackEnd => animationAttack.length - delayAttack;
    }
}
