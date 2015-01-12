using System;
using UnityEngine;
namespace Jetpack
{
	class PowerUpJetpackState : IJetpackState
	{
		private float powerupTimeBeforeJetpackCharged;
		private float powerupTimeElapsed;

		public PowerUpJetpackState () {
			InitialiseState ();
		}

		public void InitialiseState ()
		{
			Debug.Log ("Power up");
			this.powerupTimeBeforeJetpackCharged = 2.5f;
			this.powerupTimeElapsed = 0;
		}

		public IJetpackState HandleInput (JetpackStateFactory jetpackStateFactory)
		{
			if (powerupTimeElapsed >= powerupTimeBeforeJetpackCharged) {
				return jetpackStateFactory.getState(JetpackState.FULL_POWER);
			}
			if(!Input.GetButton("Jump")) {
				return jetpackStateFactory.getState(JetpackState.RECHARGE);
			}
			return this;
		}
		
		public void Update (MonoBehaviour jetpack)
		{
			this.powerupTimeElapsed += Time.deltaTime;
		}
	}

}

