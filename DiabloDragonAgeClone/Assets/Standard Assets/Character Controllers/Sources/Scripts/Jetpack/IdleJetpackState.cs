using System;
using UnityEngine;
namespace Jetpack
{
	public class IdleJetpackState : IJetpackState
	{

		public IdleJetpackState ()
		{
		}

		public IJetpackState handleInput ()
		{
			if (Input.GetButton("Jump")) {
				return new CharacterJumpState();
			}
			return this;
		}

		public void Update (UnityEngine.MonoBehaviour jetpack)
		{
			throw new NotImplementedException ();
		}

	}
}

