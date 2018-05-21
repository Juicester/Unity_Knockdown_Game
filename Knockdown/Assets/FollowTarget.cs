using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour {

	public GameObject targetObject;
	private Vector3 initialPosition;

	public GameObject ground;
	private Vector3 groundPosition;

	public float easing = 0.05f;


	// Use this for initialization
	void Start () {

		initialPosition = this.transform.position;
		groundPosition = ground.transform.position;
	}
	
	// Update is called once per frame
	// FixedUpdate is called in sync with physics simulation
	void FixedUpdate () {

		Vector3 targetPosition;

		if (targetObject != null &&
		   targetObject.GetComponent<Rigidbody> ().velocity.magnitude < 0.01) {

			targetObject = null;
		}

		if (targetObject == null) {
			targetPosition = initialPosition;
		} 
		else {
			targetPosition = targetObject.transform.position;
		}

		Vector3 followPosition = Vector3.Lerp (this.transform.position, targetPosition, easing);

		// limit the camera movement
		if (followPosition.x < initialPosition.x) {
			followPosition.x = initialPosition.x;
		}
		if (followPosition.y < initialPosition.y) {
			followPosition.y = initialPosition.y;
		}
		followPosition.z = initialPosition.z;

		this.transform.position = followPosition;

		// zoom camera to include ground
		this.GetComponent<Camera> ().orthographicSize = followPosition.y - groundPosition.y;

	}
}
