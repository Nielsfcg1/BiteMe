using UnityEngine;
using System.Collections.Generic;

public class BackToMenu : MonoBehaviour {

	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){

		Application.LoadLevel ("Menu");
			
		}
	if (Input.GetKeyDown(KeyCode.Escape))
	{Application.LoadLevel ("Menu");
	}

	}

	

}
