﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeHazard : harmfulEntity
{
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			// From harmfulEntity class
			KillPlayer(col);
		}
	}
}
