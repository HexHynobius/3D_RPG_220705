using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hyno
{
    [CreateAssetMenu(menuName ="Hyno/DataAttack",fileName = "DataAttack")]
    public class DataAttack : ScriptableObject
    {
        [Header("�����O"),Range(0,1000)]
        public float attack;
        [Header("�����ϰ�]�w")]
        public Color attackAreaColor = new Color(1, 0, 0, 0.5f);
        public Vector3 attackAreaSize = Vector3.one;
        public Vector3 attackAreaoffset;
        [Header("�����ؼйϼh")]
        public LayerMask layerTarget;
        [Header("��������ɶ�")]
        public float delayAttack=1.5f;
        [Header("�����ʵe��")]
        public AnimationClip animationAttack;

        public float waitAttackEnd => animationAttack.length - delayAttack;
    }
}
