using System;
using UnityEngine;

namespace Jetpack
{
	class FlyJetpackState : IJetpackState
	{
		private Vector3 locationToFlyTo;
		// silly placeholder
		private float countdownToLanding = 1.0f;

		public FlyJetpackState () {
			InitialiseState ();
		}


		public void InitialiseState ()
		{
			this.locationToFlyTo = new Vector3 ();
			this.countdownToLanding = 1.0f;
			Debug.Log ("Fly: " + this.locationToFlyTo);
		}

		public void SetLocationToFlyTo (Vector3 locationToFlyTo) {
			this.locationToFlyTo = locationToFlyTo;
		}

		public IJetpackState HandleInput (JetpackStateFactory jetpackStateFactory)
		{
			// detect landing and return

			if (this.countdownToLanding <= 0) {
				return jetpackStateFactory.getState(JetpackState.RECHARGE);
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

