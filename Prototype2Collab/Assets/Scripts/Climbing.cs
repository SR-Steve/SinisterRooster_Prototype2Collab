// Frantz Felix  10/21/15 
/*
Description: This script if for climbing boxs. In a nutshell, I use a  verticle ray cast by expanding the bounds of the torso collider and making the ray's origin at the top-right-most
position, to check if a box infront of the player is the correct size to climb,then I check if she is close enough to climb, If both of these are true then I have a bool thats 
named "canClimb" equal true.  Once this is true and the players position is equal or greater then the postion of the box plus one, It makes the player kinematic, moves their
positon up and over, to the top of the box. 
*******************************************
Some changes I need to make in the future are : Fix this to work with boxes of all sizes, so I can get rid if checking against the box position *plus one*. For this I will probably just 
add half of the boxes size  to the boxs position. I need to flip the ray cast with the player. I need to find a better way to get her to "climb" the box because 
right now the player is basically teleporting on top of the box. This also needs to work for boxs of different sizes. I need to put in certain places where the art team 
can animate her climb. I need to play around with the ray distance(s) and not make them infinate. Lastly I need to make the code a little bit more readable I will probly put somethings in functions of their own.
*/


using UnityEngine;
using System.Collections;
namespace FrantzFelix
{
	public class Climbing : MonoBehaviour 
	{
		public bool touchingBox=false; // var to check if touching a wall or box-Frantz
		public bool canClimb=false;// var to check if box is climable-Frantz
		public Transform boxCheck;//var to give position of wallBoxCheck object-Frantz
		public float detectionRadius = .16f;// radius that you are checking for a wall-Frantz
		public float actualBoxHeight;
		private const float rayDisFromtorso = .5f;//variable to expand the bounds of the torso collider, from which my ray can originate from-Frantz
		public LayerMask whatIsBox,whatIsGround;// defining what a box and ground layers are-Frantz
		private GameObject boxs;// var to reference box game object 
		public RaycastHit2D boxHeightCheck;//var to reference the ray that goes from its origin to the box-Frantz
		public RaycastHit2D groundHeightCheck;//var to reference the ray that goes from its origin to the ground-Frantz
		private Vector2 boxHcheck;// vector to the point where the ray will origin-Frantz
		private BoxCollider2D torsoCollider;
		private Rigidbody2D player;
		private Transform playerPosition;
		private Bounds climbingBounds;//var to reference the bounds from which my ray can originate from-Frantz

		void Start ()
		{
			torsoCollider = GetComponent<BoxCollider2D> ();
			player = GetComponent<Rigidbody2D> ();
			playerPosition = GetComponent<Transform> ();
			boxs = GameObject.Find ("Block (Push/Pull) (Climb)");//sets box to the parent Block (Push/Pull) (Climb), Im asuming to all of its children to.-Frantz
		}
		

		// Update is called once per frame
		void Update () 
		{
			climbingBounds = torsoCollider.bounds;//sets the height detection ray boundaries to the boundry of the torso collider-Frantz
			climbingBounds.Expand (rayDisFromtorso);// expands the boundry to set height detection ray further away from player-Frantz
			// Check if facing right or left and set boxHCheck accordingly -Steve
			if(player.transform.localScale.x > 0f)
				boxHcheck = new Vector2 (climbingBounds.max.x, climbingBounds.max.y);// sets where the height detection ray's orign will be-Frantz
			else
				boxHcheck = new Vector2 (climbingBounds.min.x, climbingBounds.max.y);// sets where the height detection ray's orign will be-Frantz
			touchingBox = Physics2D.OverlapCircle (boxCheck.position, detectionRadius, whatIsBox);// checks if player is touching a box-Frantz
			boxHeightCheck= Physics2D.Raycast( boxHcheck, new Vector2 (0,-1),Mathf.Infinity,whatIsBox);//Makes a ray to detect if there is a box infront of the player and its distance between the rays origin and the top of the box-Frantz
			groundHeightCheck = Physics2D.Raycast (boxHcheck, new Vector2 (0, -1), Mathf.Infinity, whatIsGround);//Makes a ray to detect if there is a ground underneath of the player and its distance between the rays origin and the ground-Frantz
			actualBoxHeight = groundHeightCheck.distance - boxHeightCheck.distance;// finds the actual box height by finding the difference between ( distance of the ray origin to the box) - (distance of the  ray origin to the ground); -Frantz
			Debug.DrawRay(boxHcheck, new Vector2 (0, -2), Color.red, .5f, true);//just draws the ray so we can see it-Frantz

			//if player is touching the box and the box is smaller then 2, the player is able to climb it-Frantz
			// 2 is just for the purposes of the prototype,  I feel like it will change when we scale everything -Frantz
			if ((touchingBox && actualBoxHeight <= 2))
				canClimb = true;
			else
				canClimb = false;
				
				
		}

		void FixedUpdate()
		{
			// This checks the players position, if its larger then the box postion, and if it is a climable box, she climbs-Frantz
			//Side note: need to change to fit all boxs and not just a box of size two -Frantz
			if ((transform.position.y) >= (boxs.transform.position.y + 1) && canClimb==true)
			{
				player.isKinematic=true;
				ClimbInYdir();// moves player in y direction-Frantz
				ClimbInXdir();// moves player in x direction-Frantz
				player.isKinematic=false;
				Debug.Log ("Anasis Climbs");
			}
		}
		//This function adds 1.1 to the current y positon-Frantz
		void ClimbInYdir()
		{
			Vector3 temp;
			temp = new Vector3 (0f, 1.1f,0f);
			playerPosition.position += temp;//adds 1.1 to the y direction-Frantz
		}
		//This function adds 1 to the current x positon-Frantz
		void ClimbInXdir()
		{
			Vector3 temp;
			// Checking if facing right or left and applying climb x force accordingly -Steve
			if(player.transform.localScale.x > 0f)
				temp = new Vector3 (1f, 0f,0f); //adds 1 to the x direction-Frantz
			else
				temp = new Vector3(-1f, 0f, 0f);
			playerPosition.position += temp;
		}
	}
}

