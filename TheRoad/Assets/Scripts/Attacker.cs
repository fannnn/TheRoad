using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {
	public GameObject Owner;
	public int DMG;

	void OnTriggerEnter(Collider col)
	{
		if (col != null)if(col.gameObject.tag!=("Untagged")) {
			//傷害判斷開始
			if (Owner.tag == ("Player"))
			if (col.gameObject.tag == ("Enemy"))
			if (col.GetComponent<UnitState> ().defense == false) {
				col.GetComponent<UnitState> ().health -= DMG;
			}
			if (Owner.tag == ("Enemy"))
			if (col.gameObject.tag == ("Player"))
			if (col.GetComponent<UnitState> ().defense == false) {
				col.GetComponent<UnitState> ().health -= DMG;
			}
			//失敗
			if (col.GetComponent<UnitState> ().defense == true) {
				Owner.GetComponent<UnitState> ().stun = true;
			}
		}
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
