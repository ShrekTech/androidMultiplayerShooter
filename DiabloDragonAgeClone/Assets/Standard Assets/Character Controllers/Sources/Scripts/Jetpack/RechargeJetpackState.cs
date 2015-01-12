using System;
using UnityEngine;

namespace Jetpack
{
	class RechargeJetpackState : IJetpackState
	{

		private float rechargeCountdown;

		public RechargeJetpackState () {
			initialiseState ();
		}

		public void initialiseState ()
		{
			Debug.Log ("Recharge");
			rechargeCountdown = 1.0f;
		}
		
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

