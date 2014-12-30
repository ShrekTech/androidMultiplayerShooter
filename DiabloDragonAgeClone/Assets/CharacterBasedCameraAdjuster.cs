using UnityEngine;
using System.Collections;

public class CharacterBasedCameraAdjuster : MonoBehaviour {

	public CharacterController playerCharacterController;

	Vector3 previousCharacterToMouseVector;

	void Start () {
		
	}

	void Update () {
		Transform mainCameraTransform = Camera.main.transform;

		Debug.Log ("mainCameraTransformPosition: " + mainCameraTransform.position);
		Debug.Log ("main camera viewport centre: " + Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, Camera.main.nearClipPlane)));

		Vector3 playerCharacterPosition = playerCharacterController.transform.position;

		Vector3 mousePosition = Input.mousePosition;
		Vector3 mousePositionInWorldCoordinates = Camera.main.ScreenToWorldPoint (new Vector3 (mousePosition.x, mousePosition.y, Camera.main.nearClipPlane));

		Vector3 mainCameraPosition = mainCameraTransform.position;

//		Vector3 characterToMouse = playerCharacterPosition - mousePositionInWorldCoordinates;
		Vector3 characterToCamera = playerCharacterPosition - mainCameraPosition;
//		characterToCamera.x = -characterToCamera.x;
//		characterToCamera.y = -characterToCamera.y;
		//Vector3.Angle(characterToCamera, characterToMouse);

		var quaternion = Quaternion.LookRotation (characterToCamera);

		//Vector3 eulerAngles = quaternion.eulerAngles;
		//eulerAngles.x = -eulerAngles.x;
		//eulerAngles.y = -eulerAngles.y;
		//eulerAngles.z = -eulerAngles.z;

//		quaternion.x = -quaternion.x;
//		quaternion.y = -quaternion.y;
//		quaternion.z = -quaternion.z;
//		quaternion.w = -quaternion.w;
		mainCameraTransform.rotation = quaternion;

		mainCameraPosition.x = mousePositionInWorldCoordinates.x;
		mainCameraPosition.y = mousePositionInWorldCoordinates.y;

		mainCameraTransform.position = mainCameraPosition;


	}
}
