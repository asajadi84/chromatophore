using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTileRotation : MonoBehaviour
{

	public float rotationSpeed = 20f;
	[SerializeField] private float increaseSpeed = 1f;

	private void Awake()
	{
		int tempRandom = Random.Range(1, 5);

		switch (tempRandom)
		{
			case 1:
				transform.Rotate(Vector3.forward * 0);
				break;
			
			case 2:
				transform.Rotate(Vector3.forward * 90);
				break;
			
			case 3:
				transform.Rotate(Vector3.forward * 180);
				break;
			
			case 4:
				transform.Rotate(Vector3.forward * 270);
				break;
		}
	}

	// Update is called once per frame
	void Update ()
	{
		if (!GameObject.Find("GameManager").GetComponent<GameManager>().paused)
		{
			transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
			rotationSpeed += Time.deltaTime * increaseSpeed;
		}
	}
}
