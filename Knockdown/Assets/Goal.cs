using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Goal : MonoBehaviour {

	public Text winText;
	public GameObject prefabEffect;

	// Use this for initialization
	void Start () {
		winText.enabled = false;
	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.tag == "Ball") {
			winText.enabled = true;
			GameObject effect = Instantiate (prefabEffect) as GameObject;
			effect.transform.position = this.transform.position;

			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
		this.transform.localRotation = Quaternion.Euler (0, 1, 0) * this.transform.localRotation;
	}
}
