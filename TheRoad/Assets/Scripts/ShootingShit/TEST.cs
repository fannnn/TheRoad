using UnityEngine;
using System.Collections;

public class TEST : MonoBehaviour {
	public enum fucker{
		fuckyou,
		yomama,
		madafaka
	}
	public fucker faka;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		switch(faka)
		{
			case fucker.fuckyou:
				print ("you are fucked");
			break;
			case fucker.yomama:
				print("so fat");
				print ("very fat");
			break;
			case fucker.madafaka:
				print("fuckyo mada");
				print("very hard");
			break;
		}

	}
}
