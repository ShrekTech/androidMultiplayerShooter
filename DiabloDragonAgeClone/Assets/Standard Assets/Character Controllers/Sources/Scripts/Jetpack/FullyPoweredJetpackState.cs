using System;
using UnityEngine;

namespace Jetpack
{
	class FullyPoweredJetpackState : IJetpackState
	{

		public FullyPoweredJetpackState () {
			initialiseState ();
		}

		public void initialiseState ()
		{
			Debug.Log ("FullyPowered");
		}

		public IJetpackState HandleInput ()
		{
			if (Input.GetButtonDown ("Fire1")) {
				//raycast
				Vector3 positionToFlyTo = new Vector3();
				FlyJetpackState flyJetPack = new FlyJetpackState();
				flyJetPack.SetLocationToFlyTo(positionToFlyTo);
				return flyJetPack;
			}
			return this;
		}

		public void Update (MonoBehaviour jetpack)
		{

		}
	}


}

