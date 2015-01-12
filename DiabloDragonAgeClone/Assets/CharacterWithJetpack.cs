using UnityEngine;
using System.Collections;
using Jetpack;

public class CharacterWithJetpack : MonoBehaviour {

	private IJetpackState jetPackState;
	void Start () {
		this.jetPackState = new IdleJetpackState();
	}
	
	// Update is called once per frame
	void Update () {
		jetPackState = jetPackState.HandleInput ();
		jetPackState.Update (this);
	}
}
