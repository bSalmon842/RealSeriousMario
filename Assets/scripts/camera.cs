using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
	public GameObject player;
	public GameObject offscreenMarker;

	void Awake()
	{
		player = GameObject.FindWithTag("Player");
		offscreenMarker = GameObject.FindWithTag("OffscreenMarker");
		offscreenMarker.SetActive(false);
	}
	
	void FixedUpdate()
	{
		if (player != null)
		{
			Vector3 newCamPos = gameObject.transform.position;
			newCamPos.x = player.transform.position.x;
			gameObject.transform.position = newCamPos;

			Vector3 newMarkerPos = newCamPos;
			newMarkerPos.y = 4.75f;
			newMarkerPos.z = 0;
			offscreenMarker.transform.position = newMarkerPos;

			if (gameObject.GetComponent<Camera>().WorldToViewportPoint(player.transform.position).y > 1.0f)
			{
				offscreenMarker.SetActive(true);
			}
			else
			{
				offscreenMarker.SetActive(false);
			}
		}
	}
}
