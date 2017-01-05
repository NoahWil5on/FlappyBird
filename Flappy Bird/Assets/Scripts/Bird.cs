using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {

	Vector3 position;
	Vector3 acceleration;
	Vector3 velocity;

	float height;
	float width;

	public float gravity;
	public GameObject gameManager;

	// Use this for initialization
	void Start () {
		width = Mathf.Abs(GetComponent<BoxCollider> ().bounds.min.x);
		height = Mathf.Abs (GetComponent<BoxCollider> ().bounds.min.z);

		velocity = new Vector3(2,0,0);
		acceleration = Vector3.zero;
		position = transform.position;
		gameManager = GameObject.Find("GameManager");
	}
	
	// Update is called once per frame
	void Update () {
		ApplyGravity ();

		if (Input.GetKeyDown ("space") && gameManager.GetComponent<GameManager>().Play) {
			velocity = new Vector3(2,0,0);
			ApplyForce(new Vector3(0,350,0));
		}

		velocity += acceleration;
		velocity = Vector3.ClampMagnitude (velocity, 8);
		position += new Vector3(0,velocity.y,0)*Time.deltaTime;
		if(gameManager.GetComponent<GameManager>().Play)
			ApplyTransform ();
		if (Collide() || position.y < -5f) {
			gameManager.GetComponent<GameManager>().Play = false;
		}
		acceleration = Vector3.zero;
	}
	void ApplyTransform(){
		transform.position = position;
		transform.Rotate (0,-transform.rotation.eulerAngles.y,0);
		transform.Rotate (0,-Mathf.Atan2(velocity.y,velocity.x),0);
	}
	void ApplyForce(Vector3 force){
		acceleration = force*Time.deltaTime;
	}
	void ApplyGravity(){
		acceleration += new Vector3 (0, gravity, 0)*Time.deltaTime;
	}
	bool Collide(){
		foreach (GameObject g in GameObject.FindGameObjectsWithTag("Pipe")) {
			if(GetComponent<BoxCollider>().bounds.Intersects(g.GetComponent<BoxCollider>().bounds))
			{return true;}
		}
		return false;
	}
	bool Within(float aPos, float aBounds, float bPos, float bBounds){
		if((aPos +aBounds > bPos - bBounds
		    && aPos + aBounds < bPos + bBounds) ||
		   (aPos - aBounds < bPos + bBounds
		 && aPos - aBounds > bPos - bBounds)){
			return true;
		}
		return false;
	}


}
