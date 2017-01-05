using UnityEngine;
using System.Collections;

public class PipeManager : MonoBehaviour {

	float timer;
	public GameObject pipe;
	GameObject gameManager;
	GameObject temp;
	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find ("GameManager");
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > 1.2f && gameManager.GetComponent<GameManager>().Play) {
			timer = 0;
			temp = Instantiate(pipe, transform.position, Quaternion.identity) as GameObject;
			temp.transform.position = new Vector3(transform.position.x, 
			                                      transform.position.y + Random.Range(-2f,2f), 
			                                      transform.position.z);
		}
	}
}
