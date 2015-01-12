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

			Vector3 forwardFromCamera = mainCameraTransform.TransformDirection (Vector3.forward);
			RaycastHit hit;

			Vector3 pointToAimAt = mainCameraTransform.TransformPoint(new Vector3(0,0,1000));

			if (Physics.Raycast (mainCameraTransform.position, forwardFromCamera, out hit)) {
				if (hit.collider.name.Contains("Horse")) {
					pointToAimAt = hit.collider.bounds.center;
				}
			}

			Vector3 velocity = Vector3.Normalize(pointToAimAt - weapon.transform.position)*weapon.speed;

			Rigidbody projectileClone = (Rigidbody) MonoBehaviour.Instantiate(weapon.projectile, weapon.transform.position, new Quaternion());
			projectileClone.velocity = velocity;
			MonoBehaviour.Destroy (projectileClone.gameObject, 3);
		}

	}
}

