using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeHazard : MonoBehaviour
{
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			// Lower the Player's remaining health and return them to the start of the level
			GameObject spawnPoint = GameObject.FindWithTag("SpawnPoint");

			col.gameObject.transform.position = spawnPoint.transform.position;
			col.gameObject.GetComponent<player>().dPlayer = new Vector3(0, 0, 0);
			
			col.gameObject.GetComponent<player>().health--;
		}
	}
}
