using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

	[SerializeField] private int sceneIndex;

	[SerializeField] private bool supportEscSceneLoader;
	[SerializeField] private int ecsSceneIndex;

	private void OnMouseUp()
	{
		SceneManager.LoadScene(sceneIndex);
	}

	private void Update()
	{
		if (Input.GetKeyUp(KeyCode.Escape))
		{
			if (supportEscSceneLoader)
			{
				SceneManager.LoadScene(ecsSceneIndex);
			}
		}
	}
}
