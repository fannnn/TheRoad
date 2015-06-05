using UnityEngine;
using System.Collections;

public class TETforFUN : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate(0,1,0);
		}
	}
}
