using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutPanelInstagramBtn : MonoBehaviour {
	private void OnMouseUp()
	{
		Application.OpenURL("instagram://user?username=ali._.sajjadi");
	}
}
