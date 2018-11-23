using UnityEngine;
using System.Collections.Generic;
using System.Linq;

 
public class Bite : MonoBehaviour 
{
	// The prefab with the alpha-transparent bite sprite
	//public GameObject bitePrefab = null;
	public GameObject Bite1 = null;
	public GameObject Bite2 = null;
	public GameObject Bite3 = null;
	public float timer=1.0f;
	public AudioClip Biting;
	public int rnx;
	public int Points;



		
	void Start()
	{//hier wordt het hap-geluidje afgespeeld
		audio.clip = Biting;
	}

	
	void Update () 
	{
		timer -= Time.deltaTime;
		//hier wordt gekeken naar het aantal punten en doorgestuurd naar het winscherm
		if(Points >=850)
		{	
			Application.LoadLevel("WinScreen");
		}
	} 





	public void TakeABite()
	{//hier wordt een van de drie hapjes gekozen en genomen
		GameObject Head = GameObject.Find("Head");
		rnx = Random.Range (1, 4);



		if (rnx==1)
		{	Points +=10;
			Instantiate( Bite1, new Vector3(Head.transform.position.x,Head.transform.position.y, -1.0f), Quaternion.identity );		
			audio.Stop ();
			audio.Play ();
			timer=1.0f;
		}

		if (rnx==2)
		{	Points +=10;
			Instantiate( Bite2, new Vector3(Head.transform.position.x,Head.transform.position.y, -1.0f), Quaternion.identity );		
			audio.Stop ();			audio.Play ();
			timer=1.0f;
		}

		if (rnx==3)
		{	Points +=10;
			Instantiate( Bite3, new Vector3(Head.transform.position.x,Head.transform.position.y, -1.0f), Quaternion.identity );		
			audio.Stop ();
			audio.Play ();
			timer=1.0f;
		}

	}

	void OnGUI() {
		//hier wordt de score op het beeld gezet
		GUIStyle avgFont = new GUIStyle ();
		avgFont.fontSize = 60;
		avgFont.normal.textColor = Color.black;
		//hier wordt de scorer linksboven neergezet, er is gebuik gemaakt van screenWidth en Height omdat het zo op elke telefoon op dezelfde plek staat
		GUI.Label(new Rect(Screen.width / 20  ,Screen.height / 15,150 ,150), "Score "+ Points.ToString(), avgFont);
	}

}
