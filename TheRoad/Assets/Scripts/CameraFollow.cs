using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	GameObject playerGO;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		playerGO = GameObject.FindGameObjectWithTag ("Player");
//		var tmp = transform.position;
//		tmp.x = playerGO.transform.position.x;
//		transform.position = tmp;
		if(playerGO.GetComponent<UnitState>().inBattle == false)
			if(playerGO.GetComponent<UnitState>().stopMoving == false)
				if(playerGO.GetComponent<UnitState>().dead == false)
					transform.position += new Vector3 (0.1f, 0, 0);
	}
}
