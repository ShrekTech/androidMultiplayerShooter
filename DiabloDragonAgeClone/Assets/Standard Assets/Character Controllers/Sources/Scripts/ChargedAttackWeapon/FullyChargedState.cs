using System;
using UnityEngine;

namespace ChargedAttack
{
	class FullyChargedState : IChargeGunState
	{
		public IChargeGunState HandleInput ()
		{
			if (Input.GetButtonDown("Fire2")) {
				return new FiringState(true);
			}
			return this;
		}

		public void Update (ChargedAttackWeapon weapon)
		{
		}
	}


}

