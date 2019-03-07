using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class harmfulEntity : MonoBehaviour
{
    public void KillPlayer(Collision2D col)
    {
        //NOTE(bSalmon): Lower the Player's remaining health and return them to the active checkpoint
		GameObject spawnPoint = col.gameObject.GetComponent<player>().spawnPoint;

		col.gameObject.transform.position = spawnPoint.transform.position;
		col.gameObject.GetComponent<player>().dPlayer = new Vector3(0, 0, 0);
			
		col.gameObject.GetComponent<player>().health--;
    }
}