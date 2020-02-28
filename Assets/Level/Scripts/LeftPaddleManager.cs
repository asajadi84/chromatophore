using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPaddleManager : MonoBehaviour
{

	[SerializeField] private GameObject ball;
	private Vector3 tempPosition;
	void Update ()
	{
		tempPosition = transform.position;
		tempPosition.y = Mathf.Clamp(ball.transform.position.y, -2.5f, 2.5f);
		transform.position = tempPosition;
	}
}
