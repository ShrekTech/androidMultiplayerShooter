using System;
using UnityEngine;

namespace ChargedAttack
{
	class FiringState : ChargeGunState
	{
		bool isFullyCharged;

		public FiringState (Boolean isFullyCharged) {
			this.isFullyCharged = isFullyCharged;
		}

		public ChargeGunState handleInput ()
		{
			return new CooldownState ();
		}

		public void update (ChargedAttackWeapon weapon)
		{
			if (isFullyCharged) {
				for (int i = 0; i < 10; i++ ) {
					Rigidbody projectileClone = (Rigidbody) MonoBehaviour.Instantiate(weapon.projectile, weapon.transform.position, weapon.transform.rotation);
					projectileClone.velocity = weapon.transform.TransformDirection(new Vector3 (0, 0, weapon.speed));
					MonoBehaviour.Destroy (projectileClone.gameObject, 3);
				}
			} else {
				for (int i = 0; i < 3; i++ ) {
					Rigidbody projectileClone = (Rigidbody) MonoBehaviour.Instantiate(weapon.projectile, weapon.transform.position, weapon.transform.rotation);
					projectileClone.velocity = weapon.transform.TransformDirection(new Vector3 (0, 0, weapon.speed));
					MonoBehaviour.Destroy (projectileClone.gameObject, 3);
				}
			}
		}
	}


}

