using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	bool play;

	public bool Play{ get { return play; } set { play = value; } }

	// Use this for initialization
	void Start () {
		play = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
