using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextHandler : MonoBehaviour
{

	[SerializeField] private Text bestScoreText;

	private void Awake()
	{
		bestScoreText.text = PlayerPrefs.GetInt("bestScore").ToString();
	}
}
