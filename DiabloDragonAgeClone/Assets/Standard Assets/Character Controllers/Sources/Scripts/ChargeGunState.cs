using System;
namespace Application
{
	public interface ChargeGunState
	{
		ChargeGunState handleInput ();
		void update(ChargedAttackWeapon weapon);

	}
	
}

