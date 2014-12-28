using System;
using UnityEngine;
namespace SingleFire
{
	public class ReloadingState : SingleFireWeaponState
	{
		float reloadIntervalElapsed = 0;
		float reloadInterval = 0.3f;

		public ReloadingState ()
		{
		}

		public SingleFireWeaponState handleInput ()
		{
			if (reloadIntervalElapsed < reloadInterval) {
				return this;
			} else if (Input.GetButton ("Fire1")) {
				return new FiringState();
			} else {
				return new IdleState();
			}
		}

		public void update (SingleFireWeapon weapon)
		{
			reloadIntervalElapsed += Time.deltaTime;
		}

	}
}

