using System;
using UnityEngine;

namespace Jetpack
{
	class FlyJetpackState : IJetpackState
	{
		private Vector3 locationToFlyTo;
		// silly placeholder
		private float countdownToLanding = 1.0f;

		public FlyJetpackState (Vector3 locationToFlyTo) {
			this.locationToFlyTo = locationToFlyTo;
			Debug.Log ("Fly: " + this.locationToFlyTo);
		}

		public IJetpackState HandleInput ()
		{
			// detect landing and return

			if (this.countdownToLanding <= 0) {
				return new RechargeJetpackState();
			}
			return this;
		}

		public void Update (MonoBehaviour jetpack)
		{
			// send character flying towards selected point?
			// detect landing and set flag

			countdownToLanding -= Time.deltaTime;
		}
	}



}

