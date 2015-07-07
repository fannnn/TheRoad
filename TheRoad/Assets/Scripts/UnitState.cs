using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitState : MonoBehaviour {
	//玩家基本資料
	public int health;
	public int ATKdamage;

	//戰鬥相關
	public GameObject AttackCol;
	public GameObject TargetCol;

	public float attackCD;
	public float defenseCD;

	public bool inBattle;
	public bool attack;
	public bool hurt;
	public bool defense;
	public bool dead;
	public bool knocked;
	public bool stun;
	public bool stopMoving;


	void Start (){

	}
	void Update () {

	}

//王八羔子
}
