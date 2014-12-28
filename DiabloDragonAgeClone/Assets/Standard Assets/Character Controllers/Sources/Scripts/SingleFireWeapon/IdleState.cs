using System;
using UnityEngine;

namespace SingleFire
{
	public class IdleState : SingleFireWeaponState
	{
		public IdleState ()
		{
		}

		public SingleFireWeaponState handleInput ()
		{
			if (Input.GetButton ("Fire1")) {
				return new FiringState();
			} else {
				return this;
			}
		}

		public void update (SingleFireWeapon weapon)
		{
		}

	}
}

