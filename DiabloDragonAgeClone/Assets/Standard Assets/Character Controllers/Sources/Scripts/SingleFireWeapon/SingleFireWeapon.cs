using UnityEngine;
using System.Collections;
using SingleFire;
using AutoAim;
namespace SingleFire
{
	public class SingleFireWeapon : MonoBehaviour {

		public Rigidbody projectile;
		public float speed;
		public float reloadInterval;
		
		private SingleFireWeaponState gunState;
		private Vector3 enemyPosition;
		private bool isEnemyDetected;

		void Start () {
			gunState = new IdleState ();
		}
		
		void Update () {
			gunState = gunState.handleInput ();
			gunState.update (this);
		}

		void OnEnable ()
		{
			EnemyDetector.enemyDetected += EnemyDetectedHandler;
		}
		
		void OnDisable ()
		{
			EnemyDetector.enemyDetected -= EnemyDetectedHandler;
		}
		
		void EnemyDetectedHandler(bool isEnemyDetected, Vector3 enemyPosition) {
			this.isEnemyDetected = isEnemyDetected;
			this.enemyPosition = enemyPosition;
		}

		public Vector3 GetEnemyPosition() {
			return this.enemyPosition;
		}

		public bool EnemyDetected() {
			return this.isEnemyDetected;
		}


	}
}
