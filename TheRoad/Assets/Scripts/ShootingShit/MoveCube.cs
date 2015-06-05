using UnityEngine;
using System.Collections;

public class MoveCube : MonoBehaviour {
	public Vector3 positionA;
	public Vector3 positionB;
	public bool Where;

	// Use this for initialization
	void Start () {
		positionA = new Vector3(-100,0,0);
		positionB = new Vector3(100,0,0);

	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x == positionA.x)
			Where = true;
		if (transform.position.x == positionB.x)
			Where = false;
		if (Where == true)
			transform.position += new Vector3 (1, 0, 0);
		if (Where == false)
			transform.position += new Vector3 (-1, 0, 0);

	}


}
