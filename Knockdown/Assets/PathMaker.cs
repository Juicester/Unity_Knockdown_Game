using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathMaker : MonoBehaviour {


	private LineRenderer path;
	private GameObject targetObject;

	private float minDistance = 0.1f;
	private List<Vector3> pointList;

	public GameObject follower;

	// Use this for initialization
	void Start () {
	
		path = this.GetComponent<LineRenderer> ();
		path.enabled = false;
		pointList = new List<Vector3> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		this.targetObject = follower.GetComponent<FollowTarget>().targetObject;

		if (this.targetObject == null) {
			return;
		}

		Vector3 currentPoint = targetObject.transform.position;

		if (pointList.Count > 0) {
			Vector3 previousPoint = pointList [pointList.Count - 1];

			if ((currentPoint - previousPoint).magnitude < minDistance) {
				return;
			}
		}

		pointList.Add (currentPoint);
		path.enabled = true;
		path.SetVertexCount (pointList.Count);
		path.SetPosition (pointList.Count - 1, currentPoint);
	}

	public void Clear() {

		targetObject = null;
		path.enabled = false;
		pointList.Clear ();
	}
}
