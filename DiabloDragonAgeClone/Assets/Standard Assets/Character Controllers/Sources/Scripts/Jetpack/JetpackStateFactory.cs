using System;
using System.Collections.Generic;
namespace Jetpack
{
	public class JetpackStateFactory
	{
		private Dictionary<JetpackState, IJetpackState> jetpackStateToInstanceMap;

		public JetpackStateFactory () {
			Dictionary<JetpackState, IJetpackState> jetpackStateToInstanceMap = new Dictionary<JetpackState, IJetpackState> ();

			jetpackStateToInstanceMap.Add (JetpackState.IDLE, new IdleJetpackState ());
			jetpackStateToInstanceMap.Add (JetpackState.JUMPING, new CharacterJumpState ());
			jetpackStateToInstanceMap.Add (JetpackState.POWERUP, new PowerUpJetpackState ());
			jetpackStateToInstanceMap.Add (JetpackState.FULL_POWER, new FullyPoweredJetpackState ());
			jetpackStateToInstanceMap.Add (JetpackState.FLY, new FlyJetpackState ());
			jetpackStateToInstanceMap.Add (JetpackState.RECHARGE, new RechargeJetpackState ());


			this.jetpackStateToInstanceMap = jetpackStateToInstanceMap;
		}

		public IJetpackState getState(JetpackState state) {
			IJetpackState jetpackStateInstance;

			if(this.jetpackStateToInstanceMap.TryGetValue (state, out jetpackStateInstance)) {
				jetpackStateInstance.InitialiseState();
				return jetpackStateInstance;
			}

			throw new InvalidOperationException("Jetpack state has not been added to factory: " + state);
		}
	}

	public enum JetpackState {
		IDLE,
		JUMPING,
		POWERUP,
		FULL_POWER,
		FLY,
		RECHARGE
	}
}

