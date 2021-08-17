using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace CubeCastle
{
#if UNITY_EDITOR
    [CustomEditor(typeof(EnemySpawner))]
    public class EnemySpawnerEditor : Editor
    {
		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();

			EnemySpawner spawner = (EnemySpawner)target;
			if(GUILayout.Button("Spawn Enemies"))
			{
				spawner.Attack();
				Debug.Log("Enemies Spawned");
			}

		}
	}
#endif
}