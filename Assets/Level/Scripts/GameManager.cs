using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public float ballSpeed = 5f;
	
	public bool canPlay = false;
	public bool paused = false;

	public Color[] tileColors;
	public int activeColorId = 5;
	public int ballColorId = 5;
	
	public GameObject leftPaddle;

	private Vector2 tempVelocity = new Vector2();

	public int tempScore = 0;

	private bool newHighScore;
	[SerializeField] private GameObject newHighScoreGO;

	[SerializeField] private GameObject[] removableGOS;
	[SerializeField] private GameObject[] scorePanelGOS;

	[SerializeField] private Text scoreTextOnTable;
	[SerializeField] private Text highScoreText;

	public void Paused()
	{
		canPlay = false;

		tempVelocity = GameObject.Find("ball").GetComponent<Rigidbody2D>().velocity;
		GameObject.Find("ball").GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
		
		Debug.Log("paused");
	}
	
	public void UnPaused()
	{
		canPlay = true;

		GameObject.Find("ball").GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
		GameObject.Find("ball").GetComponent<Rigidbody2D>().velocity = tempVelocity;
		
		Debug.Log("unpaused");
	}

	public void GameOver()
	{
		canPlay = false;

		GameObject.Find("ball").GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
		GameObject.Find("ball").GetComponent<Animator>().SetBool("Explode", true);
		
		PlayerPrefs.SetInt("lastScore", tempScore);

		if (PlayerPrefs.GetInt("lastScore") > PlayerPrefs.GetInt("bestScore"))
		{
			newHighScore = true;
			PlayerPrefs.SetInt("bestScore", tempScore);
		}

		StartCoroutine(GameOverCoroutine(0.8f, 0.1f));
	}

	IEnumerator GameOverCoroutine(float delay, float tinyDelay)
	{
		yield return new WaitForSeconds(delay);

		for (int i = 0; i < removableGOS.Length; i++)
		{
			removableGOS[i].SetActive(false);
			yield return new WaitForSeconds(tinyDelay);
		}

		scoreTextOnTable.text = PlayerPrefs.GetInt("lastScore").ToString();
		highScoreText.text = PlayerPrefs.GetInt("bestScore").ToString();
		
		for (int i = 0; i < scorePanelGOS.Length; i++)
		{
			scorePanelGOS[i].SetActive(true);
			yield return new WaitForSeconds(tinyDelay);
		}
		
		newHighScoreGO.SetActive(newHighScore);
	}
}
