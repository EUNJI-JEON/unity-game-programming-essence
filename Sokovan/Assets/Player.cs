using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public GameManager gameManager;

	public float speed=10f;
	private Rigidbody playerRigidbody;

	// Use this for initialization
	void Start () {
		playerRigidbody = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {

		if(gameManager.isGameOver == true)
		{
			return;
		}
		
		float inputX = Input.GetAxis("Horizontal");

		float inputZ = Input.GetAxis("Vertical");

		float fallSpeed = playerRigidbody.velocity.y;

		Vector3 velocity = new Vector3(inputX,0,inputZ);
		velocity = velocity * speed;
		// (inputX*speed,0*speed,inputZ*speed)

		velocity.y=fallSpeed;
		// (inputX*speed,fallSpeed,inputZ*speed)

		playerRigidbody.velocity = velocity;
	}
}
