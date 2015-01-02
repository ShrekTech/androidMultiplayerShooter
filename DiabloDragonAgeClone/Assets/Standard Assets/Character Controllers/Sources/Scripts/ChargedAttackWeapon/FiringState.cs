using System;
using UnityEngine;

namespace ChargedAttack
{
	class FiringState : IChargeGunState
	{
		bool isFullyCharged;

		public FiringState (Boolean isFullyCharged) {
			this.isFullyCharged = isFullyCharged;
		}

		public IChargeGunState HandleInput ()
		{
			return new CooldownState ();
		}

		public void Update (ChargedAttackWeapon weapon)
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

			if (isFullyCharged) {
				for (int i = 0; i < 10; i++ ) {
					Rigidbody projectileClone = (Rigidbody) MonoBehaviour.Instantiate(weapon.projectile, weapon.transform.position, weapon.transform.rotation);
					projectileClone.velocity = velocity;
					MonoBehaviour.Destroy (projectileClone.gameObject, 3);
				}
			} else {
				for (int i = 0; i < 3; i++ ) {
					Rigidbody projectileClone = (Rigidbody) MonoBehaviour.Instantiate(weapon.projectile, weapon.transform.position, weapon.transform.rotation);
					projectileClone.velocity = velocity;
					MonoBehaviour.Destroy (projectileClone.gameObject, 3);
				}
			}
		}
	}


}

