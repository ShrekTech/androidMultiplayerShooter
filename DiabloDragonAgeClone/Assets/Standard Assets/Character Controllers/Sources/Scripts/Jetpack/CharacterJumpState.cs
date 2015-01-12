using System;
using UnityEngine;

namespace Jetpack
{
	class CharacterJumpState : IJetpackState
	{
		private float jumpTimeBeforeJetpackStarts;
		private float jumpTimeElapsed;

		public CharacterJumpState () {
			InitialiseState ();
		}

		public void InitialiseState ()
		{
			Debug.Log ("Character Jump");
			this.jumpTimeBeforeJetpackStarts = 0.5f;
			this.jumpTimeElapsed = 0;
		}

		public IJetpackState HandleInput (JetpackStateFactory jetpackStateFactory)
		{
			if (jumpTimeElapsed >= jumpTimeBeforeJetpackStarts) {
				return jetpackStateFactory.getState(JetpackState.POWERUP);
			}
			if(!Input.GetButton("Jump")) {
				return jetpackStateFactory.getState(JetpackState.IDLE);
			}
			return this;
		}

		public void Update (MonoBehaviour jetpack)
		{
			this.jumpTimeElapsed += Time.deltaTime;
		}
	}

}

