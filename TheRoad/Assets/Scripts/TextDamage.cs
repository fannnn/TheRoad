using UnityEngine;
using System.Collections;

public class TextDamage : MonoBehaviour {
	public GameObject Text;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void SelfDestruction(){
		GameObject.Destroy (gameObject);
		}
}
