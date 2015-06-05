using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	public bool FIRE;
	public Transform Motherfucker;
	public Transform MyShit;
	public int score;
	public float time = 1;
	public GameObject MotherfuckerGO;
	// Use this for initialization
	void Start () {
		}
		// Update is called once per frame
	void Update () {
		if (FIRE == true) 
		{
			MyShit.position += new Vector3(0,0,10);
		}
		if (MyShit.position.z > new Vector3 (0, 0, 200).z) 
		{
			FIRE = false;
			MyShit.position = new Vector3 (0, 0, -100);
		}

		float distance = Vector3.Distance (Motherfucker.position, MyShit.position);
		if (time > 0)
			time -= Time.deltaTime;
		else
			/*
		if (Motherfucker.position.x - MyShit.position.x <= new Vector3 (10, 0, 0).x)
		if (Motherfucker.position.x - MyShit.position.x >= new Vector3 (-10, 0, 0).x)
		if (Motherfucker.position.z - MyShit.position.z <= new Vector3 (0, 0, 10).z)
		if (Motherfucker.position.z - MyShit.position.z >= new Vector3 (0, 0, -10).z) 
		*/
			if(distance<10 )


			{
				score += 1;
				MotherfuckerGO.GetComponent<Animator> ().Play ("hurt");
				time=1;
				FIRE = false;
				MyShit.position = new Vector3 (0, 0, -100);
			}
	}
	void OnGUI(){
		if (GUI.Button (new Rect (850, 290, 100, 100), "SHOOT!")) {
			FIRE = true;
			GetComponent<Animator>().Play("fire");
		}	
		GUI.Box (new Rect (380, 10, 200, 30), "你成功了射中 :" + score + "次");
	}
}
