using UnityEngine;
using System.Collections;

public class ShortMoving : MonoBehaviour {
	public float MoveDis;
	public float MoveTime;

	// Use this for initialization
	void Start () {
		MoveDis = 0.1f;
		MoveTime = 10;
	}	
	// Update is called once per frame
	void Update () {
	}

	//往左
	public IEnumerator MoveLeft(){
		while(MoveTime >= 0){
			transform.position -= new Vector3(MoveDis,0,0);
			MoveTime -= 1;
			yield return new WaitForSeconds (0.001f);			
		}
	}
	//往右
	public IEnumerator MoveRight(){
		while(MoveTime >= 0){
			transform.position += new Vector3(MoveDis,0,0);
			MoveTime -= 1;
			yield return new WaitForSeconds (0.001f);			
		}
	}
	
}

