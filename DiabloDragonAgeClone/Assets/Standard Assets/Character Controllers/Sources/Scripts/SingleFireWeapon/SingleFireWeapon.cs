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
		private EnemyDetectedListener enemyDetectedListener;

		void Start () {
			gunState = new IdleState ();
			enemyDetectedListener = new EnemyDetectedListener ();
		}
		
		void Update () {
			gunState = gunState.handleInput ();
			gunState.update (this);
		}

		public EnemyDetectedListener GetEnemyDetectedListener() {
			return this.enemyDetectedListener;
		}


	}
}
