using UnityEngine;
using System.Collections;
using Jetpack;

public class CharacterWithJetpack : MonoBehaviour {

	private IJetpackState jetPackState;
	private JetpackStateFactory jetpackStateFactory;
	void Start () {
		jetpackStateFactory = new JetpackStateFactory ();
		this.jetPackState = jetpackStateFactory.getState(JetpackState.IDLE);
	}
	
	// Update is called once per frame
	void Update () {
		jetPackState = jetPackState.HandleInput (this.jetpackStateFactory);
		jetPackState.Update (this);
	}
}
