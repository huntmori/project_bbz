using UnityEditor;
using UnityEngine;

[CustomEditor (typeof(StatManager))]
public class StatManagerInspector : Editor
{
    StatManager stats = null;
    
    void OnEnable()
    {
        stats = (StatManager)target;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        serializedObject.Update();

        if (stats != null)
        {
            for (int i = 0; i < stats.BaseStats.Length; i++)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(stats.BaseStats[i]._statName);
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Base:", GUILayout.Width(40));
                EditorGUILayout.FloatField(stats.BaseStats[i]._value, GUILayout.Width(50));
                EditorGUILayout.EndHorizontal();




                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Mod:", GUILayout.Width(40));
                EditorGUILayout.FloatField(stats.ModStats[i]._value, GUILayout.Width(50));
                //EditorGUILayout.EndHorizontal();

                //EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Current:", GUILayout.Width(40));
                EditorGUILayout.FloatField(stats.CurrentStats[i]._value, GUILayout.Width(50));
                EditorGUILayout.EndHorizontal();



                EditorGUILayout.BeginHorizontal();
                if(EditorGUILayout.Toggle("Growable", stats.BaseStats[i]._isGrow, GUILayout.Width(40)))
                {
                    stats.BaseStats[i]._isGrow = !stats.BaseStats[i]._isGrow;
                }
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("GrowValue:", GUILayout.Width(40));
                EditorGUILayout.FloatField(stats.BaseStats[i]._mod, GUILayout.Width(50));
                EditorGUILayout.EndHorizontal();
            }
        }
        serializedObject.ApplyModifiedProperties();
    }
}