using System;
using UnityEngine;

namespace ChargedAttack
{
	class CooldownState : IChargeGunState
	{
		float cooldownInterval = 1.0f;
		float cooldownIntervalElapsed = 0;

		public IChargeGunState HandleInput ()
		{
			if (cooldownIntervalElapsed < cooldownInterval) {
				return this;
			}
			if (Input.GetButton ("Fire2")) {
				return new ChargingState();
			}
			return new IdleState();
		}

		public void Update (ChargedAttackWeapon weapon)
		{
			cooldownIntervalElapsed += Time.deltaTime;
		}
	}



}

