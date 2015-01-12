using System;
using UnityEngine;

namespace Jetpack
{
	class CharacterJumpState : IJetpackState
	{
		private float jumpTimeBeforeJetpackStarts = 0.5f;
		private float jumpTimeElapsed = 0;

		public IJetpackState handleInput ()
		{
			if (jumpTimeElapsed >= jumpTimeBeforeJetpackStarts) {
				return new PowerUpJetpackState();
			}
			if(!Input.GetButtonDown("Jump")) {
				return new IdleJetpack();
			}
			return this;
		}

		public void Update (MonoBehaviour jetpack)
		{
			this.jumpTimeElapsed += Time.deltaTime;
		}
	}

}

