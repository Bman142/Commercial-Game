using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace CubeCastle
{
#if UNITY_EDITOR
    [CustomEditor(typeof(DeleteSave))]
    public class DeleteSaveEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            DeleteSave deleteSave = (DeleteSave)target;
            if (GUILayout.Button("Delete Save"))
            {
                deleteSave.DeleteSaveData();
                Debug.Log("Save Deleted");
            }
        }
    }
#endif
}
