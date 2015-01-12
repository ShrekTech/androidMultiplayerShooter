using UnityEngine;
using System.Collections;
using AutoAim;

public class EnemyDetectedListener {

	private bool isEnemyDetected = false;
	private Vector3 enemyPosition = new Vector3();

	public EnemyDetectedListener() {
		EnemyDetector.enemyDetected += EnemyDetectedHandler;
	}

	void EnemyDetectedHandler(bool isEnemyDetected, Vector3 enemyPosition) {
		this.isEnemyDetected = isEnemyDetected;
		this.enemyPosition = enemyPosition;
	}

	public bool IsEnemyDetected() {
		return this.isEnemyDetected;
	}

	public Vector3 GetEnemyPosition() {
		return this.enemyPosition;
	}
	
}
