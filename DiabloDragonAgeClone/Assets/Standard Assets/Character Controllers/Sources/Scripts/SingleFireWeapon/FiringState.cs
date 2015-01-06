using System;
using UnityEngine;
using AutoAim;
namespace SingleFire
{
	public class FiringState : SingleFireWeaponState
	{
		public FiringState ()
		{
		}

		public SingleFireWeaponState handleInput ()
		{
			return new ReloadingState ();
		}

		public void update (SingleFireWeapon weapon)
		{
			Transform mainCameraTransform = Camera.main.transform;

			Vector3 pointToAimAt;
			Debug.Log("lol?");
			if (weapon.EnemyDetected()) {
				pointToAimAt = weapon.GetEnemyPosition();
				Debug.Log("lol");
			} else {
				pointToAimAt = mainCameraTransform.TransformPoint(new Vector3(0,0,100));
			}

			Vector3 velocity = Vector3.Normalize(pointToAimAt - weapon.transform.position)*weapon.speed;

			Rigidbody projectileClone = (Rigidbody) MonoBehaviour.Instantiate(weapon.projectile, weapon.transform.position, new Quaternion());
			projectileClone.velocity = velocity;
			MonoBehaviour.Destroy (projectileClone.gameObject, 3);
		}

	}
}

