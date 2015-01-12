using System;
using UnityEngine;
namespace Jetpack
{
	class PowerUpJetpackState : IJetpackState
	{
		private float powerupTimeBeforeJetpackCharged;
		private float powerupTimeElapsed;

		public PowerUpJetpackState () {
			initialiseState ();
		}

		public void initialiseState ()
		{
			Debug.Log ("Power up");
			this.powerupTimeBeforeJetpackCharged = 2.5f;
			this.powerupTimeElapsed = 0;
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

