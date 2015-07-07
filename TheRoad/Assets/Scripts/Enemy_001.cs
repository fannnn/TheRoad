using UnityEngine;
using System.Collections;

public class Enemy_001 : MonoBehaviour {
	
	public UnitState U;
	public AudioClip[] audioClip;
	
	int healthAdjust;
	
	float atkCD;
	float defCD;
	
	
	//初始化設置
	void Start () {
		U = GetComponent<UnitState> ();
		atkCD = U.attackCD;
		defCD = U.defenseCD;
		healthAdjust = U.health;
	}
	
	//碰撞區設置
	void OnTriggerStay (Collider col){
		U.TargetCol = col.gameObject;
		if(col.isTrigger == false)if (col.gameObject.tag == ("Player")) {
			U.inBattle = true;
			GetComponent<Animator> ().SetBool ("moving", false);
		} 
	}
	void OnTriggerExit(Collider col){
		U.inBattle = false;
	}

	//音效設置
	void PlaySound (int clip){
		GetComponent<AudioSource> ().clip = audioClip [clip];
		GetComponent<AudioSource> ().Play ();
	}
	
	
	
	//執行
	void Update () {
		//基本資料狀態
		//死亡檢查
		if (U.health <= 0) {
			U.health = 0;
			if (U.dead == false){
				GetComponent<CapsuleCollider>().enabled = !enabled;
				GetComponent<BoxCollider>().enabled = !enabled;}
			Dead ();
		}
		//受傷檢查
		if (healthAdjust > U.health) {
			healthAdjust = U.health;
			StartCoroutine(Hurt());
		}
		//暈眩檢查
		if (U.knocked == true){
			StartCoroutine (Stun ());
			U.knocked = false;
		}
		

		//前進移動，條件(非戰鬥中，非停止狀態，非死亡狀態，非攻擊中，非受傷中，非防禦中)
		if(Vector3.Distance(gameObject.transform.position,GameObject.FindGameObjectWithTag("Player").transform.position)<15)
			if (U.inBattle == false)if(U.stopMoving == false)if(U.dead == false)if(U.hurt == false)
			if(U.attack == false)if(U.stun == false)if(U.defense == false){
			transform.position -= new Vector3 (0.1f, 0, 0);
			GetComponent<Animator> ().SetBool ("moving", true);
		}
		
		
		
		//攻擊防禦CD設置
		atkCD -= Time.deltaTime;
		defCD -= Time.deltaTime;
		
		//攻擊判定
			if(U.inBattle == true)if(U.defense == false)if(U.stun == false)if(U.hurt == false)if(U.dead == false)if(U.attack == false)
			if(atkCD < 0){
				U.attack = true;
				//StartCoroutine(Move());
				GetComponent<Animator>().SetTrigger("attack");//觸發攻擊動畫
				atkCD = U.attackCD;
			}
		//防禦判定[J鍵]
//			if(U.hurt == false)if(U.stun == false)if (U.dead == false)
//			if (defCD < 0) {
//				StartCoroutine(Defense());
//				defCD = U.defenseCD;
//			}

		
		
	}
	//update到此結束
	
	
	
	
	
	
	//角色動態類
	
	//攻擊擊中處理
	public IEnumerator Attack1 (){
		//攻擊碰撞擊出				
		U.AttackCol.GetComponent<BoxCollider>().enabled = true;
		U.AttackCol.GetComponent<Attacker>().DMG = U.ATKdamage;
		PlaySound(0);
		yield return new WaitForSeconds (0.1f);			
		U.AttackCol.GetComponent<BoxCollider>().enabled = false;	
		U.attack = false;
	}
	
	//受傷動態處理
	public IEnumerator Hurt(){
		if (U.dead == false) {
			U.hurt = true;U.attack = false;
			GetComponent<Animator> ().Play ("hurt");
			PlaySound(2);				
			//擊退
			StartCoroutine(MoveBack());
			yield return new WaitForSeconds (0.5f);
			U.hurt = false;
		}
	}
	//防禦動態處理
	public IEnumerator Defense(){
		if (U.dead == false) {
			U.defense = true;U.attack = false;
			U.stopMoving =true;
			GetComponent<Animator> ().Play ("defense");
			PlaySound(1);
			yield return new WaitForSeconds (0.5f);
			U.defense = false;
			U.stopMoving =false;
		}
	}
	//死亡動態處理
	public void Dead(){
		U.dead = true;
		GetComponent<Animator> ().Play ("dead");
	}
	//暈眩處理
	public IEnumerator Stun(){
		if (U.dead == false) {
			U.stun = true;
			yield return new WaitForSeconds (0.3f);
			StartCoroutine(MoveBack());
			GetComponent<Animator> ().Play ("hurt");
			yield return new WaitForSeconds (1);
			U.stun = false;
		}
	}
	//前進
	public IEnumerator Move(){
		int move = 10;
		while(move > 0){
			transform.position -= new Vector3(0.1f,0,0);
			move -= 1;
			yield return new WaitForSeconds (0.001f);	
			}
	}
	//後退
	public IEnumerator MoveBack(){
		int t = 10;
		while (t>0) {
			transform.position += new Vector3 (0.3f, 0, 0);
			t -= 1;
			yield return new WaitForSeconds (0.001f);
		}
	}
	
}
