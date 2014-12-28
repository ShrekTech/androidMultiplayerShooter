using System;
using UnityEngine;

namespace ChargedAttack
{
	class ChargingState : IChargeGunState
	{
		float chargeIntervalElapsed = 0;
		float chargeInterval = 2.0f;

		public IChargeGunState HandleInput ()
		{
			if (chargeIntervalElapsed < chargeInterval) {
				if (Input.GetButtonUp("Fire2")) {
					return new FiringState(false);
				}
				return this;
			} else {
				return new FullyChargedState();
			}
		}

		public void Update (ChargedAttackWeapon weapon)
		{
			chargeIntervalElapsed += Time.deltaTime;
		}
	}

}

