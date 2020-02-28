using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorButtonHandler : MonoBehaviour
{
	public void SelectColorButton(int buttonId)
	{
		if (GameObject.Find("GameManager").GetComponent<GameManager>().canPlay)
		{
			GameObject.Find("GameManager").GetComponent<GameManager>().activeColorId = buttonId;
			GameObject.Find("GameManager").GetComponent<GameManager>().leftPaddle.GetComponent<SpriteRenderer>().color =
				GameObject.Find("GameManager").GetComponent<GameManager>().tileColors[buttonId];
		}
	}
}
