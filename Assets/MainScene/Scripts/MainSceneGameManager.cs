using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneGameManager : MonoBehaviour
{

	public bool aboutPanelInTheScene = false;
	public bool exitByPressEsc = false;
	public GameObject pressAgainToExit;

	[SerializeField] private GameObject musicPrefab;
	
	private void Awake()
	{
		Screen.sleepTimeout = SleepTimeout.NeverSleep;

		if (GameObject.Find("Music(Clone)") == null)
		{
			Instantiate(musicPrefab);
		}
	}

	private void Update()
	{
		if (Input.GetKeyUp(KeyCode.Escape))
		{
			if (aboutPanelInTheScene)
			{
				Destroy(GameObject.Find("AboutPanel(Clone)"));
				aboutPanelInTheScene = false;
				GameObject.Find("About").GetComponent<SpriteRenderer>().color = Color.white;
			}
			else
			{
				if (exitByPressEsc)
				{
					Application.Quit();
				}
				else
				{
					StartCoroutine(PressAgainCoroutine(2f));
				}
			}
		}
	}

	IEnumerator PressAgainCoroutine(float duration)
	{
		exitByPressEsc = true;
		pressAgainToExit.SetActive(true);
		
		yield return new WaitForSeconds(duration);
		
		exitByPressEsc = false;
		pressAgainToExit.SetActive(false);
	}
	
	
}
