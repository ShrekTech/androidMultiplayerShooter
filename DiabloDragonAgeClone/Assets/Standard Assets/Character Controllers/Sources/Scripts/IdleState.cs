using System;
using UnityEngine;
namespace Application
{
	public class IdleState : ChargeGunState
	{
		public IdleState ()
		{
		}

		public ChargeGunState handleInput ()
		{
			if (Input.GetButton ("Fire2")) {
				return new ChargingState();
			}
			return this;
		}

		public void update (ChargedAttackWeapon weapon)
		{

		}

	}
}

