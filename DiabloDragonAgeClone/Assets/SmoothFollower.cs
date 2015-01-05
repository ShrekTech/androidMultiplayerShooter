using UnityEngine;
using System.Collections;

public class SmoothFollower : MonoBehaviour {

	public Transform target;
	// The distance in the x-z plane to the target
	public float distance = 5.0f;
	public float rotationDamping = 3.0f;

	void LateUpdate () {
		// Early out if we don't have a target
		if (target == null)
			return;

		transform.position = target.position;
		
		Vector3 forwardFromCamera = transform.TransformDirection (Vector3.forward);
		
		RaycastHit hit;
		
		if (Physics.Raycast (transform.TransformPoint(0.5f * Vector3.right), forwardFromCamera, out hit)) {
			if(hit.collider.gameObject.name.Contains("Horse")) {
				transform.LookAt(hit.collider.bounds.center);
			}
		} else {	
			// Always look at the target
			transform.LookAt (target);
		}
		
		// Calculate the current rotation angles
		float wantedRotationAngle = target.eulerAngles.y;
		
		
		float currentRotationAngleY = transform.eulerAngles.y;
		float currentRotationAngleX = transform.eulerAngles.x;
		
		// Damp the rotation around the y-axis
		currentRotationAngleY = Mathf.LerpAngle (currentRotationAngleY, wantedRotationAngle, rotationDamping * Time.deltaTime);
		
		// Damp the height
		//currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);
		
		// Convert the angle into a rotation
		Quaternion currentRotation = Quaternion.Euler (currentRotationAngleX, currentRotationAngleY, 0);
		
		Vector3 offsetBehindCharacter = new Vector3(0, 0, distance);
		transform.position -= currentRotation * offsetBehindCharacter;
	}
}
