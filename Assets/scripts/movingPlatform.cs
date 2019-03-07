using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
	public Vector3 startPoint;
	public float moveDistance;
	public bool isGoingRight;
	public float platformSpeed;

	public Vector3 dPlatform;

	void Awake()
	{
		startPoint = gameObject.transform.position;
		isGoingRight = true;
	}
	
	void FixedUpdate()
	{
		//NOTE(bSalmon): Acceleration of the platform (derivative of the derivative of position)
		Vector3 ddPlatform = new Vector3(0, 0, 0);
		
		if (isGoingRight)
		{
			ddPlatform.x = 1;
		}
		else
		{
			ddPlatform.x = -1;
		}
		
		ddPlatform *= platformSpeed;
		ddPlatform += (dPlatform * -5.0f);

		// Pos = 0.5 * At^2 + Vt + oP
        // Vel = At + oV
        // Accel = ddPlayer

		Vector3 newPos = gameObject.transform.position;
		Vector3 platformDelta = ((ddPlatform * 0.5f) * Mathf.Pow(Time.deltaTime, 2)) + dPlatform * Time.deltaTime;
		newPos += platformDelta;
		dPlatform = (ddPlatform * Time.deltaTime) + dPlatform;

		if (newPos.x > (startPoint.x + moveDistance))
		{
			isGoingRight = false;
		}		
		if (newPos.x < startPoint.x)
		{
			isGoingRight = true;
		}

		gameObject.transform.position = newPos;

	}
}
