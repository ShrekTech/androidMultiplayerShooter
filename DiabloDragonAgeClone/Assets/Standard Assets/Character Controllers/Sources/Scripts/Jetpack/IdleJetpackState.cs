using System;
using UnityEngine;
namespace Jetpack
{
	public class IdleJetpackState : IJetpackState
	{

		public IdleJetpackState ()
		{
			InitialiseState ();
		}

		public void InitialiseState ()
		{
			Debug.Log ("Idle");
		}

		public IJetpackState HandleInput (JetpackStateFactory jetpackStateFactory)
		{
			if (Input.GetButton("Jump")) {
				return jetpackStateFactory.getState(JetpackState.JUMPING);
			}
			return this;
		}

		public void Update (UnityEngine.MonoBehaviour jetpack)
		{

		}

	}
}

