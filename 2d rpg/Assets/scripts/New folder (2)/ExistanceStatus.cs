using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Rendering;


#if Unity_Editor
using UnityEditor
#endif

public class ExistanceStatus : MonoBehaviour
{
    [Header("status Page")]
    int maxHealth = 100;
    float currentHealth;

    float maxspeed = 3;
    float accelaration;
    float currentSpeed;

    [CustomEditor(typeof(ExistanceStatus))]
    public class existanceStatusEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            ExistanceStatus es = (ExistanceStatus)target;

            //health
            EditorGUILayout.LabelField("Health", EditorStyles.boldLabel);
            EditorGUILayout.BeginHorizontal();
            es.maxHealth = EditorGUILayout.IntField("Maxhealth", es.maxHealth);
            es.currentHealth = EditorGUILayout.FloatField("Maxhealth", es.currentHealth);
            EditorGUILayout.EndHorizontal();

            EditorGUI.indentLevel++;

            //stats
            EditorGUILayout.LabelField("stats", EditorStyles.boldLabel);

            EditorGUILayout.BeginHorizontal();
            es.maxspeed = EditorGUILayout.FloatField("Maxspeed", es.maxspeed);
            es.maxspeed = EditorGUILayout.FloatField("Maxspeed", es.maxspeed);
            EditorGUILayout.EndHorizontal();

            EditorGUI.indentLevel++;
            es.accelaration = EditorGUILayout.FloatField("Maxspeed", es.maxspeed);
            EditorGUI.indentLevel--;

        }
    }
}