using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPadHandler : MonoBehaviour
{

	[SerializeField] private GameObject rightPaddle;
	private Vector3 tempVector = new Vector3();
	private bool allowedToMove = false;

	private int tempTouchIndex;
	
	public void Touching()
	{	
		if (!GameObject.Find("GameManager").GetComponent<GameManager>().paused)
		{
			if (allowedToMove)
			{
				tempVector = rightPaddle.transform.position;

				try
				{
					tempVector.y =
						Mathf.Clamp(
							Camera.main.ScreenToWorldPoint(Input.GetTouch(tempTouchIndex).position).y,
							-2.5f, 2.5f);
				}
				catch (ArgumentException e)
				{
					Debug.Log("Recalculating");
					tempTouchIndex = Input.touchCount - 1;
				}
				
				rightPaddle.transform.position = tempVector;
			}
		}
	}

	public void StartTouching()
	{
		tempTouchIndex = Input.touchCount - 1;
		
		if (!GameObject.Find("GameManager").GetComponent<GameManager>().paused)
		{
			tempVector = rightPaddle.transform.position;
			
			tempVector.y =
				Mathf.Clamp(
					Camera.main.ScreenToWorldPoint(Input.GetTouch(tempTouchIndex).position).y,
					-2.5f, 2.5f);
			
			StartCoroutine(GoTranslate(rightPaddle, rightPaddle.transform.position, tempVector, 10f));
		}
		
	}

	public void EndTouching()
	{
		allowedToMove = false;
	}

	IEnumerator GoTranslate(GameObject go, Vector3 from, Vector3 to, float speed)
	{
		float tempValue = 0f;
		while (tempValue < 1f)
		{
			go.transform.position = Vector3.Lerp(from, to, tempValue);
			tempValue += Time.deltaTime * speed;
			yield return new WaitForEndOfFrame();
		}

		allowedToMove = true;
		yield return null;
	}
}
