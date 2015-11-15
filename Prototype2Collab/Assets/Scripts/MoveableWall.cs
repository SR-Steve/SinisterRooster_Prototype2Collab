// Frantz Felix 11/13/15 

/* This Script moves the drop wall down, as the chandelier hits the endpoint
 * */
using UnityEngine;
using System.Collections;

namespace JoshCastor {



	public class MoveableWall :MonoBehaviour
	{
		
		public bool endPoint=false;

		void Update()
		{
			if (endPoint == true)//if chaddy daddy is at the endpoint - Frantz
			{
				transform.position-= new Vector3(0f,10*Time.deltaTime,0f); //makes a new velcoity vector for the drop wall-Frantz

			}

		}

		void MoveDown()//when called( by send message on chaddy daddy) sets end point to true-Frantz
		{
			endPoint = true;
		}
		


	}
	
}
