using System;
using UnityEngine;
namespace Jetpack
{
	class PowerUpJetpackState : IJetpackState
	{
		private float powerupTimeBeforeJetpackCharged = 2.5f;
		private float powerupTimeElapsed = 0;

		public PowerUpJetpackState () {
			Debug.Log ("Power up");
		}

		public IJetpackState HandleInput ()
		{
			if (powerupTimeElapsed >= powerupTimeBeforeJetpackCharged) {
				return new FullyPoweredJetpackState();
			}
			if(!Input.GetButton("Jump")) {
				return new RechargeJetpackState();
			}
			return this;
		}
		
		public void Update (MonoBehaviour jetpack)
		{
			this.powerupTimeElapsed += Time.deltaTime;
		}
	}

}

