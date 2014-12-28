using System;
using UnityEngine;

namespace Application
{
	class FullyChargedState : ChargeGunState
	{
		public ChargeGunState handleInput ()
		{
			if (Input.GetButtonDown("Fire2")) {
				return new FiringState(true);
			}
			return this;
		}

		public void update (ChargedAttackWeapon weapon)
		{
		}
	}


}

