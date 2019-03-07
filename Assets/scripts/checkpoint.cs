using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
	public bool isActiveCheckpoint;
	private GameObject[] checkPoints;

	void Awake()
	{
		isActiveCheckpoint = false;

		//NOTE(bSalmon): Assuming that all checkpoints will be placed in the level already so it's fine to find them on level start
		checkPoints = GameObject.FindGameObjectsWithTag("CheckPoint");
	}
	
	void FixedUpdate()
	{
		if (isActiveCheckpoint)
		{
			gameObject.GetComponent<SpriteRenderer>().color = Color.green;
		}
		else
		{
			gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			foreach (GameObject check in checkPoints)
			{
				if (check.GetComponent<checkpoint>().isActiveCheckpoint == true)
				{
					check.GetComponent<checkpoint>().isActiveCheckpoint = false;
				}
			}

			Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
			isActiveCheckpoint = true;
		}
		else if (col.gameObject.tag == "Enemy")
		{
			Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
		}
	}
}
