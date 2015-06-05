using UnityEngine;
using System.Collections;

public class eatWhat_2 : MonoBehaviour {

	public int r1,r2,r3,r4,r5;
	public string d1,d2,d3,d4,d5;
	public string f1,f2,f3,f4,f5,f6,f7,f8;

	// Use this for initialization
	void Start () {
		f1 = "四海游龍";
		f2 = "摩斯漢堡";
		f3 = "麥當勞";
		f4 = "義大利麵1";
		f5 = "義大利麵2";
		f6 = "克拉克自助餐";
		f7 = "小放牛牛肉麵";
		f8 = "八方雲集";
		}
	void OnGUI(){
		if(GUI.Button (new Rect (10, 10, 300, 30), "Monday" + " : " + d1)) {r1 = Random.Range (1, 9);ShowTexts();}
		if(GUI.Button (new Rect (10, 50, 300, 30), "Tuesday" + " : " + d2)){r2 = Random.Range (1, 9);ShowTexts();}
		if(GUI.Button (new Rect (10, 100, 300, 30), "Wensday" + " : " + d3)){r3 = Random.Range (1, 9);ShowTexts();}
		if(GUI.Button (new Rect (10, 150, 300, 30), "Thursday" + " : " + d4)){r4 = Random.Range (1, 9);ShowTexts();}
		if(GUI.Button (new Rect (10, 200, 300, 30), "Friday" + " : " + d5)){r5 = Random.Range (1, 9);ShowTexts();}

		if (GUI.Button (new Rect (500, 20, 100, 100), "吃什麼"))
		{
			Roll();
		}
		if (GUI.Button (new Rect (500, 130, 100, 50), "清空")) 
		{d1 = "";d2 = "";d3 = "";d4 = "";d5 = "";r1=0;r2=0;r3=0;r4=0;r5=0;}

		GUI.Box (new Rect(10,300,600,30),"點'吃什麼'可以全部重骰，結果不會重複。單擊日數可以重骰當日結果");
	}

	void Roll(){
		r1 = Random.Range (1, 9);
		r2 = Random.Range (1, 9);
		r3 = Random.Range (1, 9);
		r4 = Random.Range (1, 9);
		r5 = Random.Range (1, 9);
		if(r1 == r2)Roll();
		if(r1 == r3)Roll();
		if(r1 == r4)Roll();
		if(r1 == r5)Roll();
		if(r2 == r3)Roll();
		if(r2 == r4)Roll();
		if(r2 == r5)Roll();
		if(r3 == r4)Roll();
		if(r3 == r5)Roll();
		if(r4 == r5)Roll();

		ShowTexts();
	}
	void ShowTexts(){
		
		if(r1==1)d1 = f1;if(r1==2)d1 = f2;
		if(r1==3)d1 = f3;if(r1==4)d1 = f4;
		if(r1==5)d1 = f5;if(r1==6)d1 = f6;
		if(r1==7)d1 = f7;if(r1==8)d1 = f8;
		
		if(r2==1)d2 = f1;if(r2==2)d2 = f2;
		if(r2==3)d2 = f3;if(r2==4)d2 = f4;
		if(r2==5)d2 = f5;if(r2==6)d2 = f6;
		if(r2==7)d2 = f7;if(r2==8)d2 = f8;
		
		if(r3==1)d3 = f1;if(r3==2)d3 = f2;
		if(r3==3)d3 = f3;if(r3==4)d3 = f4;
		if(r3==5)d3 = f5;if(r3==6)d3 = f6;
		if(r3==7)d3 = f7;if(r3==8)d3 = f8;
		
		if(r4==1)d4 = f1;if(r4==2)d4 = f2;
		if(r4==3)d4 = f3;if(r4==4)d4 = f4;
		if(r4==5)d4 = f5;if(r4==6)d4 = f6;
		if(r4==7)d4 = f7;if(r4==8)d4 = f8;
		
		if(r5==1)d5 = f1;if(r5==2)d5 = f2;
		if(r5==3)d5 = f3;if(r5==4)d5 = f4;
		if(r5==5)d5 = f5;if(r5==6)d5 = f6;
		if(r5==7)d5 = f7;if(r5==8)d5 = f8;
	}
	// Update is called once per frame
	void Update () {
	}
}
