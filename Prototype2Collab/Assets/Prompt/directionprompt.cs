using UnityEngine;
using System.Collections;

public class directionprompt : MonoBehaviour {
	//direction prompt -Adam Thai
	public SpriteRenderer direction;
	public bool touching; 

	void Start () 
	{
		direction = GetComponent<SpriteRenderer> ();
		direction.enabled = false;
	}

	void OnTriggerEnter2D(Collider2D col) 
	{
		if (col.gameObject.name == "GameObject")//|| col.gameObject.name == "side")
			touching = true;//checks for "GameObject" or "side" -Adam Thai

	}

	void OnTriggerExit2D(Collider2D col) 
	{
		if (col.gameObject.name == "GameObject")//|| col.gameObject.name == "side")
			touching = false;//checks for "GameObject" or "side" -Adam Thai
	}

	void Update () 
	{	
		if (touching==true)
			if (Input.GetKeyDown ("x"))//direction prompt appears/disappears, depending if its enabled or not, if x-button is pressed -Adam Thai
				direction.enabled = !direction.enabled;
		if (touching == false)//if not near "GameObject" or "side" direction prompt disappears -Adam Thai
			direction.enabled = false;
	}
}
