using System;
using UnityEngine;
namespace ChargedAttack
{
	public class IdleState : IChargeGunState
	{
		public IdleState ()
		{
		}

		public IChargeGunState HandleInput ()
		{
			if (Input.GetButton ("Fire2")) {
				return new ChargingState();
			}
			return this;
		}

		public void Update (ChargedAttackWeapon weapon)
		{

		}

	}
}

