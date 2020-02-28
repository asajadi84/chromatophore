using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpSceneTiles : MonoBehaviour
{

	[SerializeField] private int tileIndex;

	private void OnTriggerEnter2D(Collider2D other)
	{
		other.gameObject.GetComponent<SpriteRenderer>().color =
			GameObject.Find("HGameManager").GetComponent<HelpScene2GameManager>().HTileColors[tileIndex];
	}
}
