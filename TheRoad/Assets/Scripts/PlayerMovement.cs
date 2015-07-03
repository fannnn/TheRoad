using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour {
	//玩家基本資料
	public int health;
	public int ATKdamage;

	//戰鬥相關
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

	float atkCD;
	float defCD;

	//初始化設置
	void Start (){
		atkCD = attackCD;
		defCD = defenseCD;

	}

	//碰撞區設置
	void OnTriggerStay (Collider col){
		if (col.gameObject.tag == ("Enemy")) {
			EnemyCol = col.gameObject;
			inBattle = true;
			Model.GetComponent<Animator> ().SetBool ("inBattle", true);
		} 
		else {
			EnemyCol = null;
			inBattle = false;
			Model.GetComponent<Animator> ().SetBool ("inBattle", false);
		}
	
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

		//判定敵人是否死亡，脫離戰鬥狀態
		if (EnemyCol != null) {
			if (EnemyCol.GetComponent<EnemyMovement> ().dead == true) {
				EnemyCol.GetComponent<CapsuleCollider>().enabled = !enabled;
				EnemyCol = null;
				inBattle = false;
				Model.GetComponent<Animator> ().SetBool ("inBattle", false);
							}
		}
		//前進移動，條件(非戰鬥中，非停止狀態，非死亡狀態)
		if (inBattle == false)if(stopMoving == false)if(dead == false){
			transform.position += new Vector3 (0.1f, 0, 0);
		}

		//攻擊防禦CD設置
		atkCD -= Time.deltaTime;
		defCD -= Time.deltaTime;

		//攻擊判定[F鍵]
		if (Input.GetKeyDown(KeyCode.F)) 
			if(defense == false)if(stun == false)if(hurt == false)if(dead == false)if(attack == false)
				if(atkCD < 0){
				attack = true;
				StartCoroutine(Move());
				Model.GetComponent<Animator>().SetTrigger("attack");//觸發攻擊動畫
				atkCD = attackCD;
			}
		//防禦判定[J鍵]
		if (Input.GetKey (KeyCode.J)) 
			if(hurt == false)if(stun == false)if (dead == false)
			if (defCD < 0) {
					StartCoroutine(Defense());
					defCD = defenseCD;
			}

//update到此結束
	}




//角色動態類

	//攻擊擊中處理
	public IEnumerator Attack1 (){
		//攻擊碰撞擊出				
				AttackCol.GetComponent<BoxCollider>().enabled = true;
				PlaySound(0);
		yield return new WaitForSeconds (0.1f);			
		AttackCol.GetComponent<BoxCollider>().enabled = false;	
		attack = false;

		}
	public IEnumerator Attack2 (){
		//攻擊碰撞擊出				
		AttackCol.GetComponent<BoxCollider>().enabled = true;
		PlaySound(0);
		yield return new WaitForSeconds (0.1f);			
		AttackCol.GetComponent<BoxCollider>().enabled = false;	
		attack = false;
	}
	public IEnumerator Attack3 (){
		//攻擊碰撞擊出				
		AttackCol.GetComponent<BoxCollider>().enabled = true;
		PlaySound(0);
		yield return new WaitForSeconds (0.1f);			
		AttackCol.GetComponent<BoxCollider>().enabled = false;	
		attack = false;
	}
	public IEnumerator SAttack1 (){
		//攻擊碰撞擊出				
		AttackCol.GetComponent<BoxCollider>().enabled = true;
		PlaySound(0);
		yield return new WaitForSeconds (0.1f);		
		AttackCol.GetComponent<BoxCollider>().enabled = false;	
		attack = false;
	}

	//受傷動態處理
	public IEnumerator Hurt(){
		if (dead == false) {
				hurt = true;
				Model.GetComponent<Animator> ().Play ("hurt");
				PlaySound(2);				
			//擊退
			int t= 10;
			while(t>0){
				transform.position -= new Vector3(0.3f,0,0);
				t -= 1;
				yield return new WaitForSeconds (0.001f);
			}
			yield return new WaitForSeconds (0.5f);
			hurt = false;
		}
	}
	//防禦動態處理
	public IEnumerator Defense(){
		if (dead == false) {
			defense = true;attack = false;
			stopMoving =true;
			Model.GetComponent<Animator> ().Play ("defense");
			PlaySound(1);
			yield return new WaitForSeconds (0.5f);
			defense = false;
			stopMoving =false;
		}
	}
	//死亡動態處理
	public void Dead(){
		dead = true;
		Model.GetComponent<Animator> ().Play ("dead");
	}
	//暈眩處理
	public IEnumerator Stun(){
		if (dead == false) {
			stun = true;
			Model.GetComponent<Animator> ().Play ("hurt");
			yield return new WaitForSeconds (1);
			stun = false;
		}
	}
	//短移動處理
	public IEnumerator Move(){
		int move = 10;
		while(move > 0){
			transform.position += new Vector3(0.1f,0,0);
			move -= 1;
			yield return new WaitForSeconds (0.001f);	
			print (move);}
	}















//王八羔子
}
