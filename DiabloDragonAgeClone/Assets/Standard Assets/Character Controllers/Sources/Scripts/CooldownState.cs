using System;
using UnityEngine;

namespace Application
{
	class CooldownState : ChargeGunState
	{
		float cooldownInterval = 1.0f;
		float cooldownIntervalElapsed = 0;

		public ChargeGunState handleInput ()
		{
			if (cooldownIntervalElapsed < cooldownInterval) {
				return this;
			}
			if (Input.GetButton ("Fire2")) {
				return new ChargingState();
			}
			return new IdleState();
		}

		public void update (ChargedAttackWeapon weapon)
		{
			cooldownIntervalElapsed += Time.deltaTime;
		}
	}



}

