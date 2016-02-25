using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform Hero;
	public Vector3 offset;

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (Hero.position.x + offset.x, Hero.position.y + offset.y, offset.z);
	}
}
