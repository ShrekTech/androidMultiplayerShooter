using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AutoAim
{
	public class EnemyDetector : MonoBehaviour {

		public delegate void EnemyDetectedHandler(bool isEnemyDetected, Vector3 enemyPosition);
		public static event EnemyDetectedHandler enemyDetected;

		public float autoAimTimeAfterClick = 0.2f;

		private FiringState firingState;
		private float timeSinceLastClick;

		private List<Vector3> pointsToUseForEnemyDetection;

		void Start () {
			firingState = FiringState.IDLE;
			timeSinceLastClick = 0;

			Vector3 topRight = new Vector3 (1, 1);
			topRight.Normalize();
			Vector3 topLeft = new Vector3 (-1, 1);
			topLeft.Normalize();
			Vector3 bottomRight = new Vector3 (1, -1);
			bottomRight.Normalize();
			Vector3 bottomLeft = new Vector3 (-1, -1);
			bottomLeft.Normalize();
				
			pointsToUseForEnemyDetection = new List<Vector3>
			{
				Vector3.up,
				Vector3.down,
				Vector3.left,
				Vector3.right,
				topRight,
				topLeft,
				bottomRight,
				bottomLeft
			};
		}

		void Update () {

			switch (firingState) {
				case FiringState.IDLE:
					if (Input.GetButton ("Fire1")) {
						timeSinceLastClick = 0;
						firingState = FiringState.FIRING;
					} else {
						return;
					}
					break;
				case FiringState.FIRING:
					timeSinceLastClick += Time.deltaTime;
					if(Input.GetButton ("Fire1")) {
						timeSinceLastClick = 0;
					}
					if(timeSinceLastClick > autoAimTimeAfterClick) {
						firingState = FiringState.IDLE;
					enemyDetected(false, new Vector3());
						return;
					}
					DetectEnemies();
					break;
			}
		
		}

		private void DetectEnemies() {
			Transform cameraMainTransform = Camera.main.transform;
			Vector3 forwardFromCamera = cameraMainTransform.TransformDirection (Vector3.forward);
	
			RaycastHit hit;

			List<Vector3> enemyPositionsFound = new List<Vector3>();

			foreach (Vector3 detectionPoint in pointsToUseForEnemyDetection) {
				if (Physics.Raycast (cameraMainTransform.TransformPoint (0.5f * detectionPoint), forwardFromCamera, out hit)) {
					if (hit.collider.gameObject.name.Contains ("Horse")) {
						enemyPositionsFound.Add(hit.collider.bounds.center);
					}
				}
			}

			if (enemyPositionsFound.Count.Equals (0)) {
				enemyDetected (false, new Vector3 ());
				return;
			}

			float shortestDistanceToEnemyPosition = 100000.0f;
			Vector3 closestEnemy = enemyPositionsFound[0];
			foreach (Vector3 enemyPosition in enemyPositionsFound) {
				float distanceToEnemy = (enemyPosition - cameraMainTransform.position).magnitude;
				if (distanceToEnemy < shortestDistanceToEnemyPosition) {
					shortestDistanceToEnemyPosition = distanceToEnemy;
					closestEnemy = enemyPosition;
				}
			}

			if (enemyDetected != null) {
				enemyDetected (true, closestEnemy);
			}
		}
		
		enum FiringState {
			FIRING,
			IDLE
		}
	}
}