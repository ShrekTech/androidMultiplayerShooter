using System;
using UnityEngine;

namespace Jetpack
{
	class FullyPoweredJetpackState : IJetpackState
	{
		public IJetpackState handleInput ()
		{
			if (Input.GetButtonDown ("Fire1")) {
				//raycast
				Vector3 positionToFlyTo = new Vector3();
				return new FlyJetpackState(positionToFlyTo);
			}
			return this;
		}

		public void Update (MonoBehaviour jetpack)
		{

		}
	}


}

