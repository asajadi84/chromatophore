using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausedGoCreator : MonoBehaviour {
	[SerializeField] private GameObject pausedPrefab;

	void PausedGoCreate()
	{
		Instantiate(pausedPrefab, new Vector3(-0.576f, 3.963f, 0f), Quaternion.identity);
	}
}
