using UnityEngine;
using System.Collections;
using AutoAim;

public class EnemyDetectedListener : MonoBehaviour {


	void OnEnable ()
	{
		EnemyDetector.enemyDetected += EnemyDetectedHandler;
	}

	void OnDisable ()
	{
		EnemyDetector.enemyDetected -= EnemyDetectedHandler;
	}

	public void EnemyDetectedHandler(bool isEnemyDetected, Vector3 enemyPosition) {
		Debug.Log ("Horse at: " + enemyPosition);
	}
	
}
