using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseStateChecker : MonoBehaviour {

	void PauseChecker()
	{
		if (GameObject.Find("GameManager").GetComponent<GameManager>().paused == false)
		{
			Destroy(gameObject);
		}
	}
}
