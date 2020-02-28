using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutPanelCloseBtn : MonoBehaviour {
	private void OnMouseUp()
	{
		StartCoroutine(PanelDestruction());
	}
	
	IEnumerator FadeOutGO(GameObject GO, float speed)
	{
		SpriteRenderer tempRenderer = GO.GetComponent<SpriteRenderer>();
		Color tempColor;

		while (tempRenderer.color.a > 0f)
		{
			tempColor = tempRenderer.color;
			tempColor.a += Time.deltaTime * speed * -1;
			GO.GetComponent<SpriteRenderer>().color = tempColor;
			yield return new WaitForEndOfFrame();
		}
		yield return null;
	}

	IEnumerator PanelDestruction()
	{
		Coroutine tempCoroutine = StartCoroutine(FadeOutGO(GameObject.Find("star"), 3f));
		StartCoroutine(FadeOutGO(GameObject.Find("AboutPopup"), 3f));
		yield return tempCoroutine;
		
		//1: destroy the panel
		Destroy(GameObject.Find("AboutPanel(Clone)"));
		
		//2: game manager aboutPanelInTheScene back to false
		GameObject.Find("GameManager").GetComponent<MainSceneGameManager>().aboutPanelInTheScene = false;

		//3: about btn color back to normal
		GameObject.Find("About").GetComponent<SpriteRenderer>().color = Color.white;
	}
}
