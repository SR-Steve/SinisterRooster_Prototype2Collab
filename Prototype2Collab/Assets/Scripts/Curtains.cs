using UnityEngine;
using System.Collections;

public class Curtains : MonoBehaviour {

	public GameObject drapWall;
	Cloth cloth;

	// Use this for initialization
	void Start () {
		cloth = GetComponentsInChildren<Cloth>()[0];
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(cloth.externalAcceleration.x <= -9f)
			drapWall.SendMessage("MoveDown");
			
	}
}
