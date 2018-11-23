using UnityEngine;
using System.Collections.Generic;

public class ChangeScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void NextScene(string BiteMeScene2){
		
		Application.LoadLevel("BiteMeScene2");
		
	}
	public void NextScene2(string Instuctions){
		
		Application.LoadLevel("Instructions");
		
	}
	public void NextScene3 (string Menu){

		Application.LoadLevel ("Menu");

	}


}
