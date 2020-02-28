using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class BallMovement : MonoBehaviour {
	
	void BallHeadStart()
	{
		GameObject.Find("GameManager").GetComponent<GameManager>().canPlay = true;
		
		GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
		GetComponent<Rigidbody2D>().gravityScale = 0f;
		GetComponent<Rigidbody2D>().angularDrag = 0f;

		int tempRandom = Random.Range(1, 3);
		
		switch(tempRandom)
		{
			case 1:
				GetComponent<Rigidbody2D>().velocity =
					new Vector2(1, 1) * GameObject.Find("GameManager").GetComponent<GameManager>().ballSpeed;
				break;
			
			case 2:
				GetComponent<Rigidbody2D>().velocity =
					new Vector2(1, -1) * GameObject.Find("GameManager").GetComponent<GameManager>().ballSpeed;
				break;
				
		}
	}
}
