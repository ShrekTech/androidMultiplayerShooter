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
			if (isFullyCharged) {
				for (int i = 0; i < 10; i++ ) {
					Rigidbody projectileClone = (Rigidbody) MonoBehaviour.Instantiate(weapon.projectile, weapon.transform.position, weapon.transform.rotation);
					projectileClone.velocity = mainCameraTransform.TransformDirection(new Vector3 (0, 0, weapon.speed));
					MonoBehaviour.Destroy (projectileClone.gameObject, 3);
				}
			} else {
				for (int i = 0; i < 3; i++ ) {
					Rigidbody projectileClone = (Rigidbody) MonoBehaviour.Instantiate(weapon.projectile, weapon.transform.position, weapon.transform.rotation);
					projectileClone.velocity = mainCameraTransform.TransformDirection(new Vector3 (0, 0, weapon.speed));
					MonoBehaviour.Destroy (projectileClone.gameObject, 3);
				}
			}
		}
	}


}

