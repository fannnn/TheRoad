using UnityEngine;
using System.Collections;

public class UselessShit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
		// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3(1,1,1) * 99*Time.deltaTime);
		//transform.Rotate(Vector3.up * 99*Time.deltaTime, Space.World);
	}
}
