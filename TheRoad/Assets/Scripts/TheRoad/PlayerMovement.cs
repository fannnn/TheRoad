using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour {
	//玩家基本資料
	public int health;

	//戰鬥相關
	public GameObject PlayerGO;
//	public GameObject[] EnemyGO;
	public GameObject EnemyCol;
	public GameObject Model;
	public GameObject AttackCol;

	public float attackCD;
	public float defenseCD;

	public bool inBattle;
	public bool attack;
	public bool hurt;
	public bool defense;
	public bool dead;
	public bool stun;
	public bool stopMoving;

	public AudioClip[] audioClip;

	//初始化設置
	void Start (){
		PlayerGO = GameObject.FindGameObjectWithTag ("Player");
//		EnemyGO = GameObject.FindGameObjectsWithTag ("Enemy");
	}
	//暫時用血量ＵＩ
	void OnGUI (){
		GUI.Box (new Rect (10, 10, 200, 20), "HP:" + health);
	}
	//碰撞區設置
	void OnTriggerStay (Collider col){
		if (col.gameObject.tag == ("Enemy")) 
			EnemyCol = col.gameObject;
		//print (EnemyCol);
	}
	//音效設置
	void PlaySound (int clip){
		GetComponent<AudioSource> ().clip = audioClip [clip];
		GetComponent<AudioSource> ().Play ();
	}



	//執行
	void Update () {
		//基本資料狀態
		if (health <= 0) {
			health = 0;
			if (dead == false)
				Dead ();
		}

		//判定是否進入戰鬥狀態
		if (EnemyCol != null) {
			if (Vector3.Distance (PlayerGO.transform.position, EnemyCol.transform.position) < 3)
			if (EnemyCol.GetComponent<EnemyMovement> ().dead == false){
				inBattle = true;
				Model.GetComponent<Animator> ().SetBool ("inBattle", true);
			}
			if (EnemyCol.GetComponent<EnemyMovement> ().dead == true) {
				EnemyCol.GetComponent<BoxCollider>().enabled = !enabled;
				EnemyCol = null;
				inBattle = false;
				Model.GetComponent<Animator> ().SetBool ("inBattle", false);
							}
		}
		//判定無戰鬥狀態 繼續往前移動
		if (inBattle == false)if(stopMoving == false)if(dead == false){
			transform.position += new Vector3 (0.1f, 0, 0);
		}

		//攻擊防禦CD設置
		attackCD -= Time.deltaTime;
		defenseCD -= Time.deltaTime;

		//攻擊判定[F鍵]
		if (Input.GetKeyDown(KeyCode.F)) 
			if(defense == false)if(stun == false)if(hurt == false)if(dead == false)
				if(attackCD < 0){
				Model.GetComponent<Animator>().SetTrigger("attack");
				attackCD = 0.5f;
			}
		//防禦判定[J鍵]
		if (Input.GetKey (KeyCode.J)) 
			if(hurt == false)if(stun == false)if (dead == false)
			if (defenseCD < 0) {
					StartCoroutine(Defense());
					defenseCD = 0.5f;
			}

//update到此結束
	}




//角色動態類

	//攻擊擊中處理
	public IEnumerator Attack1 (){
		//開始攻擊前置
			attack = true;			
		//攻擊碰撞擊出
			//條件
//			if(defense == false)if(stun == false)if(dead == false){
				AttackCol.GetComponent<BoxCollider>().enabled = true;
				PlaySound(0);
//			}
			yield return new WaitForSeconds (0.1f);
		//收回攻擊碰撞
			AttackCol.GetComponent<BoxCollider>().enabled = false;
			attack = false;
		}
	//受傷動態處理
	public IEnumerator Hurt(){
		if (dead == false) {
			if (attack == false){
				hurt = true;
				Model.GetComponent<Animator> ().Play ("hurt");}
			PlaySound(2);
			yield return new WaitForSeconds (0.5f);
			hurt = false;
		}
	}
	//防禦動態處理
	public IEnumerator Defense(){
		if (dead == false) {
			defense = true;
			Model.GetComponent<Animator> ().Play ("defense");
			PlaySound(1);
			yield return new WaitForSeconds (0.5f);
			defense = false;
		}
	}
	//死亡動態處理
	public void Dead(){
		dead = true;
		Model.GetComponent<Animator> ().Play ("dead");
	}//處理死亡
	public IEnumerator Stun(){
		if (dead == false) {
			stun = true;
			Model.GetComponent<Animator> ().Play ("hurt");
			yield return new WaitForSeconds (1);
			stun = false;
		}
	}






//王八羔子
}
