using System;
namespace ChargedAttack
{
	public interface ChargeGunState
	{
		ChargeGunState handleInput ();
		void update(ChargedAttackWeapon weapon);

	}
	
}

