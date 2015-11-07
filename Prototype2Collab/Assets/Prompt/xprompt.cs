using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class xprompt : MonoBehaviour 
{
	
	public SpriteRenderer xbutton; //x-button prompt -Adam Thai
	public bool touching;

	void Start()
	{

		xbutton = GetComponent<SpriteRenderer> ();
		xbutton.enabled=false;

	}
	
	void OnTriggerEnter2D(Collider2D col) 
	{
		if (col.gameObject.name == "GameObject"|| col.gameObject.name == "side") 
			xbutton.enabled = true;	//x-button prompt will appear over player -Adam Thai 
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.name == "GameObject"|| col.gameObject.name == "side")

			if (Input.GetKeyDown ("x"))//x-buttom prompt will disappear after pressing down "x" -Adam Thai 
				xbutton.enabled = false;

	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.name == "GameObject"|| col.gameObject.name == "side")
			xbutton.enabled=false; // if too far from "GameObject" x-button prompt will disappear -Adam Thai
	}

	void Update()
	{

	}


}

