using UnityEngine;
using System.Collections;

public class Pipe : MonoBehaviour {

	GameObject gameManager;
	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find ("GameManager");
	}
	
	// Update is called once per frame
	void Update () {
		if(gameManager.GetComponent<GameManager>().Play)
			transform.position = new Vector3 (transform.position.x-.07f, transform.position.y, transform.position.z);
		if (transform.position.x < -6) {
			Destroy(gameObject);
		}
	}
}
