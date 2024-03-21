using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MainScript))]
public class PlayerPr : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        MainScript script = (MainScript)target;

        if (GUILayout.Button("�������� PlayerPrefs"))
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("������ PlayerPrefs ���� ������� ��������.");
        }
    }
}
