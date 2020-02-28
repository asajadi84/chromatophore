using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideTheBall : MonoBehaviour
{

	[SerializeField] private GameObject GO;

	void HideBall()
	{
		GO.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
		GO.SetActive(false);
	}
}
