using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallVelocityHandler : MonoBehaviour
{

	[SerializeField] private Vector2 velocityVector;
	
	private void OnCollisionEnter2D(Collision2D other)
	{
		other.gameObject.GetComponent<Rigidbody2D>().velocity =
			velocityVector.normalized * GameObject.Find("GameManager").GetComponent<GameManager>().ballSpeed;
	}
}
