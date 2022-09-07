using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Hyno
{
    [CreateAssetMenu(menuName = "Hyno/DataHealth", fileName = "DataHealth")]
    public class DataHealth : ScriptableObject
    {
        [Header("血量"), Range(0, 10000)]
        public float hp;
        [HideInInspector]
        public float hpMax => hp;
        [Header("是否掉落寶物")]
        public bool isDropProp;
        [HideInInspector, Header("寶物預製物")]
        public GameObject goProp;
        [HideInInspector, Header("寶物掉落機率"), Range(0f, 1f)]
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
