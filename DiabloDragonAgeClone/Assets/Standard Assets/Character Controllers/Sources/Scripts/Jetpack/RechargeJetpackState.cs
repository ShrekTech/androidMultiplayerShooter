using System;
using UnityEngine;

namespace Jetpack
{
	class RechargeJetpackState : IJetpackState
	{

		private float rechargeCountdown;

		public RechargeJetpackState () {
			InitialiseState ();
		}

		public void InitialiseState ()
		{
			Debug.Log ("Recharge");
			rechargeCountdown = 1.0f;
		}
		
		public IJetpackState HandleInput (JetpackStateFactory jetpackStateFactory)
		{
			// detect landing and return
			
			if (this.rechargeCountdown <= 0) {
				return jetpackStateFactory.getState(JetpackState.IDLE);
			}
			return this;
		}
		
		public void Update (MonoBehaviour jetpack)
		{
			// send character flying towards selected point?
			// detect landing and set flag
			
			rechargeCountdown -= Time.deltaTime;
		}
	}


}

