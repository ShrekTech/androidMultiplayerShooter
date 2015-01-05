using UnityEngine;
using System.Collections;

public class EnemyDetectedListener : MonoBehaviour {


	void OnEnable ()
	{
		EnemyDetector.enemyDetected += EnemyDetectedHandler;
	}

	void OnDisable ()
	{
		EnemyDetector.enemyDetected -= EnemyDetectedHandler;
	}

	public void EnemyDetectedHandler(Vector3 enemyPosition) {
		Debug.Log ("Horse at: " + enemyPosition);
	}
	
}
