using System;
namespace ChargedAttack
{
	public interface IChargeGunState
	{
		IChargeGunState HandleInput ();
		void Update(ChargedAttackWeapon weapon);

	}
	
}

