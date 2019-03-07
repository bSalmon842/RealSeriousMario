using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : harmfulEntity
{
	public bool isGoingRight;
	public Vector3 dEnemy;

	void Awake()
	{
		isGoingRight = false;
	}
	
	void FixedUpdate()
	{
		//NOTE(bSalmon): Acceleration of the enemy (derivative of the derivative of position)
		Vector3 ddEnemy = new Vector3(0, 0, 0);
		
		if (isGoingRight)
		{
			ddEnemy.x = 1;
		}
		else
		{
			ddEnemy.x = -1;
		}
		
		ddEnemy *= 25;
		ddEnemy += (dEnemy * -5.0f);

		// Pos = 0.5 * At^2 + Vt + oP
        // Vel = At + oV
        // Accel = ddPlayer

		Vector3 newPos = gameObject.transform.position;
		Vector3 enemyDelta = ((ddEnemy * 0.5f) * Mathf.Pow(Time.deltaTime, 2)) + dEnemy * Time.deltaTime;
		newPos += enemyDelta;
		dEnemy = (ddEnemy * Time.deltaTime) + dEnemy;

		gameObject.transform.position = newPos;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		isGoingRight = !isGoingRight;

		if (col.gameObject.tag == "Player")
		{
			// From HarmfulEntity class
			KillPlayer(col);
		}
	}
}
