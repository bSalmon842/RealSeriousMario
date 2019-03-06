using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
	public int health;
	public float playerSpeed;
	public Vector3 dPlayer = new Vector3(0, 0, 0); // Velocity of the player
	public Vector3 oldPos;
	public bool isGrounded;

	void Awake()
	{
		health = 3;
		playerSpeed = 25;
		isGrounded = true;
	}
	
	void FixedUpdate()
	{
		oldPos = gameObject.transform.position;
		
		// Acceleration of the player (derivative of the derivative of position)
		Vector3 ddPlayer = new Vector3(0, 0, 0);
		
		if (Input.GetAxis("Horizontal") < 0)
		{
			ddPlayer.x = -2;
		}
		if (Input.GetAxis("Horizontal") > 0)
		{
			ddPlayer.x = 2;
		}
		if (Input.GetButton("Jump") && isGrounded)
		{
			ddPlayer.y = 90;
			isGrounded = false;
		}

		ddPlayer *= playerSpeed;

		ddPlayer += (dPlayer * -5.0f);

		// Pos = 0.5 * At^2 + Vt + oP
        // Vel = At + oV
        // Accel = ddPlayer

		Vector3 newPos = gameObject.transform.position;
		Vector3 playerDelta = ((ddPlayer * 0.5f) * Mathf.Pow(Time.deltaTime, 2)) + dPlayer * Time.deltaTime;
		newPos += playerDelta;
		dPlayer = (ddPlayer * Time.deltaTime) + dPlayer;

		if (dPlayer.x < 0.1f && dPlayer.x > -0.1f)
		{
			dPlayer.x = 0.0f;
		}
		if (dPlayer.y < 0.1f)
		{
			dPlayer.y = 0.0f;
			isGrounded = true;
		}

		gameObject.transform.position = newPos;
	}
}
