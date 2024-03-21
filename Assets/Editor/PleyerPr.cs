using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MainScript))]
public class PlayerPr : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        MainScript script = (MainScript)target;

        if (GUILayout.Button("Сбросить PlayerPrefs"))
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("Данные PlayerPrefs были успешно сброшены.");
        }
    }
}
