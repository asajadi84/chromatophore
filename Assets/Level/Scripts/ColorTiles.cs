using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTiles : MonoBehaviour
{

	[SerializeField] private int tileId;

	private void OnTriggerEnter2D(Collider2D other)
	{
		GameObject.Find("GameManager").GetComponent<GameManager>().ballColorId = tileId;
		other.gameObject.GetComponent<SpriteRenderer>().color = GameObject.Find("GameManager")
			.GetComponent<GameManager>().tileColors[tileId];
		
		other.gameObject.GetComponent<TrailRenderer>().startColor = GameObject.Find("GameManager")
			.GetComponent<GameManager>().tileColors[tileId];
	}
}
