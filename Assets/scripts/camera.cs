using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
	public GameObject player;
	void Awake()
	{
		player = GameObject.FindWithTag("Player");
	}
	
	void FixedUpdate()
	{
		if (player != null)
		{
			Vector3 newCamPos = gameObject.transform.position;
			newCamPos.x = player.transform.position.x;
			gameObject.transform.position = newCamPos;
		}
	}
}
