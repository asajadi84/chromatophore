using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutBtn : MonoBehaviour
{
	[SerializeField] private GameObject aboutPanel;
	
	private void OnMouseUp()
	{
		if (GameObject.Find("GameManager").GetComponent<MainSceneGameManager>().aboutPanelInTheScene == false)
		{
			GameObject.Find("GameManager").GetComponent<MainSceneGameManager>().pressAgainToExit.SetActive(false);
			GameObject.Find("GameManager").GetComponent<MainSceneGameManager>().exitByPressEsc = false;
			
			//1: game manager aboutPanelInTheScene should become true
			GameObject.Find("GameManager").GetComponent<MainSceneGameManager>().aboutPanelInTheScene = true;

			//2: dim the button
			GetComponent<SpriteRenderer>().color = Color.gray;

			//3: insantiate the panel
			Instantiate(aboutPanel);
		}
	}
}
