using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTextActivator : MonoBehaviour
{
	[SerializeField] private GameObject GO;

	void ScoreTextActivation()
	{
		GO.SetActive(true);
	}
}
