using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace KitsuneYuki
{
    [CreateAssetMenu(menuName = "ScriptableObject/DataHealth", fileName = "DataHealth")]
    public class DataHealth : ScriptableObject
    {
        public float HP;
        public float maxHP => HP;
        public bool canDropProp;
        [HideInInspector] public GameObject prop;
        [HideInInspector] public float dropRate;
    }
    [CustomEditor(typeof(DataHealth))]
    public class DataHealthEditor : Editor{
        SerializedProperty canDropProp , prop , dropRate;
        private void OnEnable() {
            canDropProp = serializedObject.FindProperty(nameof(DataHealth.canDropProp));
            prop = serializedObject.FindProperty(nameof(DataHealth.prop));
            dropRate = serializedObject.FindProperty(nameof(DataHealth.dropRate));
        }
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            serializedObject.Update();
            if(canDropProp.boolValue){
                EditorGUILayout.PropertyField(prop);
                EditorGUILayout.PropertyField(dropRate);
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
}
