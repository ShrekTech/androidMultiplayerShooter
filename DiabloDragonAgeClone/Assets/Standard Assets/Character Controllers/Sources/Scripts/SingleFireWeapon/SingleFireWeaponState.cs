using System;
namespace SingleFire
{
	public interface SingleFireWeaponState
	{
		SingleFireWeaponState handleInput ();
		void update(SingleFireWeapon weapon);
	}
}

