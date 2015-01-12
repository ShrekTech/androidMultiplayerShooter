using System;
using UnityEngine;

namespace Jetpack
{
	class FullyPoweredJetpackState : IJetpackState
	{

		public FullyPoweredJetpackState () {
			InitialiseState ();
		}

		public void InitialiseState ()
		{
			Debug.Log ("FullyPowered");
		}

		public IJetpackState HandleInput (JetpackStateFactory jetpackStateFactory)
		{
			if (Input.GetButtonDown ("Fire1")) {
				//raycast
				Vector3 positionToFlyTo = new Vector3();
				FlyJetpackState flyJetPack = (FlyJetpackState)jetpackStateFactory.getState(JetpackState.FLY);
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

