﻿using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI(){
		if(GUI.Button(new Rect (850,10,100,50),"Restart"))		   
		Application.LoadLevel(Application.loadedLevel);
		

		if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().dead == true)
		GUI.Box(new Rect(300,100,300,100),"太大意惹");

		if (GameObject.Find ("EvilFucker 5").GetComponent<EnemyMovement> ().dead == true) {
			GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().stopMoving = true;
			GUI.Box (new Rect (300, 100, 300, 100), "原來你是來看醫生，我寧願去玩馬力歐醫生");
			GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().Model.GetComponent<Animator> ().SetBool ("inBattle", true);
		}

		GUI.Box (new Rect (10, 350, 400, 30), "說明: [F]攻擊，[J防禦]，抓時機防禦然後扁回去");

		}
}
