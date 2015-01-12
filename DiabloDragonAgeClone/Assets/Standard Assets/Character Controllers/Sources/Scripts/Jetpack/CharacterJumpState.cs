using System;
using UnityEngine;

namespace Jetpack
{
	class CharacterJumpState : IJetpackState
	{
		private float jumpTimeBeforeJetpackStarts;
		private float jumpTimeElapsed;

		public CharacterJumpState () {
			initialiseState ();
		}

		public void initialiseState ()
		{
			Debug.Log ("Character Jump");
			this.jumpTimeBeforeJetpackStarts = 0.5f;
			this.jumpTimeElapsed = 0;
		}

		public IJetpackState HandleInput ()
		{
			if (jumpTimeElapsed >= jumpTimeBeforeJetpackStarts) {
				return new PowerUpJetpackState();
			}
			if(!Input.GetButton("Jump")) {
				return new IdleJetpackState();
			}
			return this;
		}

		public void Update (MonoBehaviour jetpack)
		{
			this.jumpTimeElapsed += Time.deltaTime;
		}
	}

}

