using System;
using UnityEngine;
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

			Vector3 forwardFromCamera = mainCameraTransform.TransformDirection (Vector3.forward);

			RaycastHit hit;

			Vector3 pointToAimAt;

			if (Physics.Raycast (weapon.transform.position, forwardFromCamera, out hit)) {
				pointToAimAt = hit.point;
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

