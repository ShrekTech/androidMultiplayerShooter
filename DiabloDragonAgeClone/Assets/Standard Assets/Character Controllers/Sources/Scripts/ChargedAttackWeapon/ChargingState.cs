using System;
using UnityEngine;

namespace ChargedAttack
{
	class ChargingState : ChargeGunState
	{
		float chargeIntervalElapsed = 0;
		float chargeInterval = 2.0f;

		public ChargeGunState handleInput ()
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

		public void update (ChargedAttackWeapon weapon)
		{
			chargeIntervalElapsed += Time.deltaTime;
		}
	}

}

