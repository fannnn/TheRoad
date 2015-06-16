using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	//玩家基本資料
	public int health;
	
	//戰鬥相關
	public GameObject PlayerGO;
	public GameObject EnemyGO;
	public GameObject Model;
	public float attackCD;
	public float defenseCD;
	public bool inBattle;
	public bool attack;
	public bool hurt;
	public bool defense;
	public bool dead;
	public bool stun;
	
	
	private float timer;
	
	
	//初始化設置
	void Start () {
		PlayerGO = GameObject.FindGameObjectWithTag("Player");
		EnemyGO = gameObject;
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
		inBattle = false;
		if (Vector3.Distance (PlayerGO.transform.position, EnemyGO.transform.position) < 3)
			if(PlayerGO.GetComponent<PlayerMovement>().dead == false)
				inBattle = true;
		
		
		//判定無戰鬥狀態 距離玩家夠近 還沒死 繼續往前移動
		if (Vector3.Distance (PlayerGO.transform.position, EnemyGO.transform.position) < 15)
		if (inBattle == false) 
		if (dead == false){
			transform.position += new Vector3 (-0.1f, 0, 0);
		}
		
		//攻擊防禦CD設置
		attackCD -= Time.deltaTime;
		defenseCD -= Time.deltaTime;
		//攻擊判定
		if(inBattle ==true)
			if(stun ==false)
			if(dead == false)
			if(hurt == false)
				if(attackCD < 0){
					StartCoroutine(Attack());

				
				
				
				attackCD = 3f;
			}
		
		
		
		//防禦判定
//		if (Input.GetKey (KeyCode.J)) 
//			if (dead == false)
//			if (defenseCD < 0) {
//				StartCoroutine(Defense());
//				defenseCD = 1;
//			}
		
		
	}
	
	//暫時用血量ＵＩ
//	void OnGUI(){
//		GUI.Box (new Rect (10, 10, 200, 20),"HP:"+health);
//	}
	
	
	
	public IEnumerator Attack (){
		if (dead == false) {
			attack = true;
			Model.GetComponent<Animator> ().Play ("attack");
			yield return new WaitForSeconds (1);
			if(dead == false)if(stun == false)
			AttackEnemy();
			attack = false;
		}
	}
	public IEnumerator Hurt(){
		if (dead == false) {
			hurt = true;
			if (attack == false)
				Model.GetComponent<Animator> ().Play ("hurt");
			yield return new WaitForSeconds (0.3f);
			hurt = false;
		}
	}
	public IEnumerator Defense(){
		if (dead == false) {
			defense = true;
			Model.GetComponent<Animator> ().Play ("defense");
			yield return new WaitForSeconds (0.5f);
			defense = false;
		}
	}
	public void Dead(){
		Model.GetComponent<Animator> ().Play ("dead");
		dead = true;
		//處理死亡
	}
	public IEnumerator Stun(){
		if (dead == false) {
			stun = true;
			Model.GetComponent<Animator> ().Play ("hurt");
			yield return new WaitForSeconds (2);
			stun = false;
		}
	}
	
	
	
	
	//攻擊那些王八羔子
	void AttackEnemy(){
		if (Vector3.Distance (PlayerGO.transform.position, EnemyGO.transform.position) < 5){
			//擊中，執行傷害與演出
			if(PlayerGO.GetComponent<PlayerMovement>().defense == false)
			{PlayerGO.GetComponent<PlayerMovement> ().health -= 10;
				StartCoroutine(PlayerGO.GetComponent<PlayerMovement> ().Hurt());}
			//被防禦，自身受到暈眩
			if(PlayerGO.GetComponent<PlayerMovement>().defense == true)
			{StartCoroutine(Stun());}
		}
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
}
