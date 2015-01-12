using System;
using UnityEngine;

namespace Jetpack
{
	class RechargeJetpackState : IJetpackState
	{

		public RechargeJetpackState () {
			Debug.Log ("Recharge");
		}

		private float rechargeCountdown = 1.0f;
		
		public IJetpackState HandleInput ()
		{
			// detect landing and return
			
			if (this.rechargeCountdown <= 0) {
				return new IdleJetpackState();
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

