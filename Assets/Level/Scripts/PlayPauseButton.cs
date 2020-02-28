using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPauseButton : MonoBehaviour
{
	[SerializeField] private Sprite playSprite;
	[SerializeField] private Sprite pauseSprite;

	private void OnMouseUp()
	{
		StartCoroutine(ButtonPressed(0.5f));
	}

	private void Update()
	{
		if (Input.GetKeyUp(KeyCode.Escape))
		{
			StartCoroutine(ButtonPressed(0.5f));
		}
	}

	IEnumerator ButtonPressed(float textAppearDelay)
	{
		if (GameObject.Find("GameManager").GetComponent<GameManager>().paused)
		{	
			//Unpause the game
			GameObject.Find("GameManager").GetComponent<GameManager>().UnPaused();
			
			GameObject.Find("GameManager").GetComponent<GameManager>().paused = false;
			yield return new WaitForSeconds(0.3f);
			GameObject.Find("MainPanel").GetComponent<Animator>().SetBool("DrawerOpen", false);
			GetComponent<SpriteRenderer>().sprite = pauseSprite;
		}
		else
		{
			//Pause the game
			yield return new WaitForSeconds(0.3f);
			GameObject.Find("GameManager").GetComponent<GameManager>().Paused();
			
			GameObject.Find("GameManager").GetComponent<GameManager>().paused = true;
			GameObject.Find("MainPanel").GetComponent<Animator>().SetBool("DrawerOpen", true);
			GetComponent<SpriteRenderer>().sprite = playSprite;

			yield return new WaitForSeconds(textAppearDelay);
		}
	}
}
