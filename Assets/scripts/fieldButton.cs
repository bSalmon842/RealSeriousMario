using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fieldButton : MonoBehaviour
{
	public GameObject attachedField;

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
			gameObject.GetComponent<SpriteRenderer>().color = Color.red;
			Destroy(attachedField);
		}
	}
}
