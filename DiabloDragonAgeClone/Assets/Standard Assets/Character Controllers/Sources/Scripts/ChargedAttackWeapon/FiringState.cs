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
				FireProjectileFromWeaponWithSizeAndVelocity(weapon, 4.0f, velocity);
			} else {
				FireProjectileFromWeaponWithSizeAndVelocity(weapon, 1.5f, velocity);
			}
		}

		private void FireProjectileFromWeaponWithSizeAndVelocity(ChargedAttackWeapon weapon, float projectileSize, Vector3 velocity) {
			Rigidbody projectileClone = (Rigidbody) MonoBehaviour.Instantiate(weapon.projectile, weapon.transform.position, weapon.transform.rotation);
			Vector3 projectileScale = projectileClone.transform.localScale;
			projectileClone.transform.localScale = projectileSize * projectileScale;
			projectileClone.velocity = velocity;
			MonoBehaviour.Destroy (projectileClone.gameObject, 3);
		}

	}


}

