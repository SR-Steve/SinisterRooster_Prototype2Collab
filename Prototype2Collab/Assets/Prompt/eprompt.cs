using UnityEngine;
using System.Collections;

public class eprompt : MonoBehaviour{

	public SpriteRenderer ebutton; //e-button prompt -Adam Thai
	public bool touching;
	
	void Start()
	{
		
		ebutton = GetComponent<SpriteRenderer> ();
		ebutton.enabled=false;
		
	}
	
	void OnTriggerEnter2D(Collider2D col) 
	{
		if (col.gameObject.name == "front") 
			ebutton.enabled = true;	//e-button prompt will appear over player -Adam Thai 
	}
	

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.name == "front")
			ebutton.enabled=false; // if too far from "GameObject" e-button prompt will disappear -Adam Thai
	}
	
	void Update()
	{
		
	}
	
	
}