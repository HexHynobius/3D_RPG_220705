using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Hyno
{
    [CreateAssetMenu(menuName = "Hyno/DataHealth", fileName = "DataHealth")]
    public class DataHealth : ScriptableObject
    {
        [Header("��q"), Range(0, 10000)]
        public float hp;
        [HideInInspector]
        public float hpMax => hp;
        [Header("�O�_�����_��")]
        public bool isDropProp;
        [HideInInspector, Header("�_���w�s��")]
        public GameObject goProp;
        [HideInInspector, Header("�_���������v"), Range(0f, 1f)]
        public float propProbability;
    }

    [CustomEditor(typeof(DataHealth))]
    public class DataHealthEditor : Editor
    {
        SerializedProperty spIsDropProp;
        SerializedProperty spgoProp;
        SerializedProperty sppropProbability;

        private void OnEnable()
        {
            spIsDropProp = serializedObject.FindProperty(nameof(DataHealth.isDropProp));
            spgoProp = serializedObject.FindProperty(nameof(DataHealth.goProp));
            sppropProbability = serializedObject.FindProperty(nameof(DataHealth.propProbability));
        }

        public override void OnInspectorGUI()
        {
            //base.OnInspectorGUI();
            DrawDefaultInspector();
            serializedObject.Update();

            if (spIsDropProp.boolValue)
            {
                EditorGUILayout.PropertyField(spgoProp);
                EditorGUILayout.PropertyField(sppropProbability);
            }

            serializedObject.ApplyModifiedProperties();

        }
    }
}
