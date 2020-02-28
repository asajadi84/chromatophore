using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightBoundry : MonoBehaviour {
	private void OnCollisionEnter2D(Collision2D other)
	{
		other.gameObject.GetComponent<Rigidbody2D>().velocity=Vector2.zero;
		GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
	}
}
