using UnityEngine;
using System.Collections;

namespace AutoAim
{
	public class EnemyDetector : MonoBehaviour {

		public delegate void EnemyDetectedHandler(bool isEnemyDetected, Vector3 enemyPosition);
		public static event EnemyDetectedHandler enemyDetected;
		public float autoAimTimeAfterClick = 0.2f;

		private FiringState firingState;
		private float timeSinceLastClick;

		void Start () {
			firingState = FiringState.IDLE;
			timeSinceLastClick = 0;
		}

		void Update () {

			switch (firingState) {
				case FiringState.IDLE:
					Debug.Log("IDLE");
					if (Input.GetButton ("Fire1")) {
						timeSinceLastClick = 0;
						firingState = FiringState.FIRING;
					} else {
						return;
					}
					break;
				case FiringState.FIRING:
					Debug.Log("FIRING");
					timeSinceLastClick += Time.deltaTime;
					if(Input.GetButton ("Fire1")) {
						timeSinceLastClick = 0;
					}
					if(timeSinceLastClick > autoAimTimeAfterClick) {
						firingState = FiringState.IDLE;
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
			
			if (Physics.Raycast (cameraMainTransform.TransformPoint(0.5f * Vector3.right), forwardFromCamera, out hit)) {
				if(hit.collider.gameObject.name.Contains("Horse")) {
					if(enemyDetected != null)
						enemyDetected(true, hit.collider.bounds.center);
				} else {
					if(enemyDetected != null)
						enemyDetected(false, new Vector3());
				}
			}
		}

		enum FiringState {
			FIRING,
			IDLE
		}
	}
}