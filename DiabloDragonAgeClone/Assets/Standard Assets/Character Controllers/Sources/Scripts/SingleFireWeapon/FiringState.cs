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
			Rigidbody projectileClone = (Rigidbody) MonoBehaviour.Instantiate(weapon.projectile, weapon.transform.position, new Quaternion());
			projectileClone.velocity = weapon.transform.TransformDirection(new Vector3 (0, 0, weapon.speed));
			MonoBehaviour.Destroy (projectileClone.gameObject, 3);
		}

	}
}

