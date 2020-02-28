using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpSceneBallMovement : MonoBehaviour
{
	private float speed = 2f;
	
	// Use this for initialization
	void Start () {
		int tempRandom = Random.Range(1, 5);

		switch (tempRandom)
		{
			case 1:
				GetComponent<Rigidbody2D>().velocity =
					new Vector2(1, 1) * speed;
				break;

			case 2:
				GetComponent<Rigidbody2D>().velocity =
					new Vector2(1, -1) * speed;
				break;

			case 3:
				GetComponent<Rigidbody2D>().velocity =
					new Vector2(-1, 1) * speed;
				break;

			case 4:
				GetComponent<Rigidbody2D>().velocity =
					new Vector2(-1, -1) * speed;
				break;
		}
	}
	
}
