using UnityEngine;
using System.Collections;

public class eatWhatShuffle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		string[] fuck = {"到八仙","玩水囉","躺著完","坐著完","趴著完"};
		reshuffle(fuck);
			}
	
	// Update is called once per frame
	void Update () {
	
	}
	void reshuffle(string[] texts)
	{
		// Knuth shuffle algorithm :: courtesy of Wikipedia :)
		for (int t = 0; t < texts.Length; t++ )
		{
			string tmp = texts[t];
			int r = Random.Range(t, texts.Length);
			texts[t] = texts[r];
			texts[r] = tmp;
			print (texts[t]);
			print (texts [r]);
			print ("123");
		}

	}
}
