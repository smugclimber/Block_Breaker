using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
		 
	private Paddle paddle;
	private Vector3 paddleToBallVector;
	private bool hasStarted = false;
	
	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		//Provides the distance between the start position paddle and ball
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(!hasStarted){
			//Locking the ball to the paddle
			this.transform.position = paddleToBallVector + paddle.transform.position;
			
			//Waiting for the mouse press to launch ball
			if(Input.GetMouseButtonDown(0)){
				// Mouse click, launch ball 
				hasStarted = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2 (2f,10f);
				// f in coordinates is stating it is a float.
			}
		}	
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		//ball does not trigger sound when brick is destroyed.
		//Not 100% sure why, possibly because brick isnt there.
		
		Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
		//Added tweak to add random velocity to ball and avoid boring gameplay loops
		//New Vector tweak needs a min and max of the tweak to x and y
		
		if(hasStarted == true){
			GetComponent<AudioSource>().Play();
			GetComponent<Rigidbody2D>().velocity += tweak;
		}
	}
}
