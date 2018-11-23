using UnityEngine;
using System.Collections.Generic;

public class Movement : MonoBehaviour {


	//In dit script wordt bepaald waar de rups heen mmoet gaan

	private bool flag = false;
	private Vector3 endPoint;
	public float duration = 50.0f;
	private float zAxis;
	bool alive = true;
	List<float> Xpos = new List<float>();
	List<float> Ypos = new List<float>();
	Vector2 LastBitePosition;



	void Start()
	{	//hier wordt de z-as vastgezet zodat de rups niet in de diepte kan bewegen
		//hier wordt ook gekeken naar de laatste positie van de rups zodat ik kan zorgen dat hij om de zoveel afgelegde afstand een hapje neemt
		zAxis = gameObject.transform.position.z;
		LastBitePosition = new Vector2 (transform.position.x, transform.position.y);
	}

	void Update()
	{ 	//hier wordt de nieuwe en oude positie met elkaar vergeleken, als deze groter is dan 1 wordt er een hapje genomen
		if (Vector2.Distance (LastBitePosition, transform.position) > 1)
			{ 	GameObject Rups = GameObject.Find("Leaf");
				Bite LeafScript = Rups.GetComponent<Bite> ();
				LeafScript.TakeABite();
				LastBitePosition= new Vector2 (transform.position.x, transform.position.y);
			}

		if (alive == false)
		{	GameObject.Destroy(gameObject);
		}

			if (Input.GetMouseButton(0)) 
			{//hier wordt de animatie gestart van de rups
				animation.enabled = true;
			if(animation.enabled = true){
				animation.Play ("Take 001");	
			}

				//hier wordt door middel van een RayCast bepaald waar de muis/vinger is en waar de rups heen moet
				RaycastHit hit;
				Ray ray;
				ray = Camera.main.ScreenPointToRay (Input.mousePosition);

					if (Physics.Raycast (ray, out hit)) 
					{
					flag = true;
					endPoint = hit.point;
					endPoint.z = zAxis;
					} 
							
				if (flag && !Mathf.Approximately (gameObject.transform.position.magnitude, endPoint.magnitude)) 
					{
					gameObject.transform.position = Vector3.Lerp (gameObject.transform.position, endPoint, 1 / (duration * (Vector3.Distance (gameObject.transform.position, endPoint))));
					gameObject.transform.LookAt(endPoint);
					flag = false;
					}

				else if (flag && Mathf.Approximately (gameObject.transform.position.magnitude, endPoint.magnitude)) 
					{
					flag = false;
					//hier wordt gekeken of de rups op de plek is van de muis/vinger zodat hij stil gaat staan
					}

			}
		if(Input.GetMouseButtonUp(0))
		{	animation.enabled = false;
			//hier wordt de animatie gepauseerd als de muis/vinger het scherm niet indrukt
		}
		print (animation.enabled);

	}
		//als laatste wordt er getest of de rups in contact komt met de collisionborder, die het water moet voorstellen		
	void OnTriggerEnter(Collider collider)
	{	
		if (collider.tag == "Water")
		{
			///als de rups het water raakt wordt de speler terug gestuurd naar het menu
			alive = false;
			Application.LoadLevel("Menu");
		}
	}


	void OnTriggerExit( Collider collider)
	{	
		if (collider.tag == "Water") 
		{
					
		}
	}

		 


		
	
	
}
