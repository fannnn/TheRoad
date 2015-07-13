using UnityEngine;
using System.Collections;

public class GameSystem : MonoBehaviour {
	public GameObject player;
	public int playerHealth;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		playerHealth = player.GetComponent<UnitState> ().health;
	}

	void OnGUI(){
		//暫時用血量ＵＩ
		GUI.Box (new Rect (10, 10, 200, 20), "HP:" + playerHealth);

		if(GUI.Button(new Rect (850,10,100,50),"Restart"))		   
		Application.LoadLevel(Application.loadedLevel);

		if (GUI.Button (new Rect (750, 10, 100, 50), "Camera")) {
			GameObject.Find("Main Camera").GetComponent<Animator>().SetTrigger("change");
		}

		if(GameObject.FindGameObjectWithTag("Player").GetComponent<UnitState>().dead == true)
		GUI.Box(new Rect(300,100,300,100),"太大意惹");

		if (GameObject.Find ("BOSS").GetComponent<UnitState> ().dead == true) {
			GameObject.FindGameObjectWithTag("Player").GetComponent<UnitState>().stopMoving = true;
			GUI.Box (new Rect (300, 100, 300, 100), "原來你是來看醫生，我寧願去玩馬力歐醫生");
			GameObject.FindGameObjectWithTag("Player").GetComponent<UnitState>().GetComponent<Animator> ().SetBool ("moving", false);
		}

		GUI.Box (new Rect (10, 350, 400, 30), "說明: [J]攻擊，[F招架]，[D閃躲]");

		}
}
