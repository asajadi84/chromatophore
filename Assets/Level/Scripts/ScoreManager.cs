using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

	[SerializeField] private Text scoreText;

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (GameObject.Find("GameManager").GetComponent<GameManager>().activeColorId == GameObject.Find("GameManager").GetComponent<GameManager>().ballColorId)
		{
			GameObject.Find("GameManager").GetComponent<GameManager>().tempScore++;
			scoreText.text = GameObject.Find("GameManager").GetComponent<GameManager>().tempScore.ToString();
		}
		else
		{
			GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
		}
	}
}
