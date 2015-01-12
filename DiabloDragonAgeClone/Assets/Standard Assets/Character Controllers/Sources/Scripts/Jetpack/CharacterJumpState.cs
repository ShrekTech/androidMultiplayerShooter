using System;
using UnityEngine;

namespace Jetpack
{
	class CharacterJumpState : IJetpackState
	{
		private float jumpTimeBeforeJetpackStarts = 0.5f;
		private float jumpTimeElapsed = 0;

		public CharacterJumpState () {
			Debug.Log ("Character Jump");
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

