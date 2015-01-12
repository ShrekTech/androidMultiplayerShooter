using System;
using UnityEngine;
namespace Jetpack
{
	public class IdleJetpackState : IJetpackState
	{

		public IdleJetpackState ()
		{
			initialiseState ();
		}

		public void initialiseState ()
		{
			Debug.Log ("Idle");
		}

		public IJetpackState HandleInput ()
		{
			if (Input.GetButton("Jump")) {
				return new CharacterJumpState();
			}
			return this;
		}

		public void Update (UnityEngine.MonoBehaviour jetpack)
		{

		}

	}
}

