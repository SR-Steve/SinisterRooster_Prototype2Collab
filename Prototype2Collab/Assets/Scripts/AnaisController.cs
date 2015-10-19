/* Steven Gussman  10/11/15 2:56 PM (SUN)
   Josh Castor 10/13/2015 - added temporary jump controls (with Space key)
							made Player child of Chandelier when player lands on it
   Josh Castor 10/16/2015 - 
*/
/*
Description:  This script is for the walking controls and physics of the player
			  but I gave it a generic name for now because it's probably best
			  we merge things like jumping and climbing into one character
			  controller script. -Steve
*/

/**Unsolved known errors

*/
/**Solved errors: 
	Player becomes smaller on platform -Josh
	- Source: When player turns, player's size is dependent on platform she's on. -Josh
    -- Reason: Player becomes child of moving platform, thereby affecting player scaling. -Josh
    Attempted Sol: Rescale to a predetermined default before and after collision.
    - Result: Could work with default of (0.5, 2, 1), but this would not be versatile enough and would potentially make a maintenance nightmare.
	Sol: In Flip method(), make player's localScale change to: 
		-transform.localScale.x, transform.localScale.y, transform.localScale.z
		instead of:
		-transform.localScale.x, 1f, 1f
	
 */

using UnityEngine;
using System.Collections;

// To avoid naming collisions / stay organized -Steve
namespace SteveGussman{

	public class AnaisController : MonoBehaviour {
	
		// Reference to Rigidbody2D component -Steve
		Rigidbody2D bod;
		
		public float maxSpeed = 2f;
		float xInput;
		
		/* turnTime records the time when the player changes direction
	       so that there can be a delay in the visual flip - Steve */
		public float turnTime;
		public bool turning;
		public bool right;
		
		// For checking whether you're on the ground (able to jump) -Steve
		public bool grounded;
		public Transform groundCheck;
		float groundRadius = 0.05f;
		public LayerMask whatIsGround;
		public float jumpForce = 400f;
		
		// Reference to Animator component -Steve
		Animator anim;
<<<<<<< HEAD
	
		// (Temporary) controls how high player can jump - Josh
		public float tempJumpForce = 12f;

		// Initialization -Steve
		void Start(){
=======

        //To push/pull blocks - Branden
        public bool Grab = false;
        public Rigidbody2D Crate;

        // Initialization -Steve
        void Start(){
>>>>>>> origin/master
		
			//In case Anais prefab is initilized staring left in a level -Steve
			//right = transform.localScale.x < 0f ? false : true;
			if(transform.localScale.x > 0f)
				right = true;
			   		
			// Get references for component fields -Steve
			bod = GetComponent<Rigidbody2D>();
			anim = GetComponent<Animator>();
		}
		
		// Called once per physics step -Steve
		void FixedUpdate(){
		
			// Check if Anais is on the ground, tell Animator -Steve
			grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
			anim.SetBool("grounded", grounded);
			// Take in lateral input -Steve
			xInput = Input.GetAxis("Horizontal");
			/* Push the speed to the Animator's speed parameter so the animation
		       state changes between idle and walking -Steve */
			anim.SetFloat("speed", Mathf.Abs(xInput));
			bod.velocity = new Vector2(xInput * maxSpeed, bod.velocity.y);
		}
		
		// Called once per frame -Steve
		void Update(){
			// Issues have to do w. these conds. only cheking when going a dir. you're not already
			if(xInput > 0f){ // Walking right -Steve
				if(!right){ // Walking right but facing left -Steve
					if(!turning){ // If not turning right, should be... -Steve
						turnTime = Time.time;
						turning = true;
						maxSpeed = 0.67f; // Slower walk backward -Steve
					}
					// Walk backward slowly for 0.9 seconds before turning around -Steve
					else if(Time.time - turnTime > 0.9f)
						Flip();
				}else // Walking right & facing right -Steve
					maxSpeed = 2f;
				
			}else if(xInput < 0f){ // Walking left -Steve
				if(right){ // Walking left but facing right -Steve
					if(!turning){ // If not turning right, should be... -Steve
						turnTime = Time.time;
						turning = true;
						maxSpeed = 0.67f; // Slower walk backward -Steve
					} 
					// Walk backward slowly for 0.9 seconds before turning around -Steve
					else if(Time.time - turnTime > 0.9f)
						Flip();
				}else // Walking left and facing left -Steve
					maxSpeed = 2f;
            }
<<<<<<< HEAD
			if (Grab)
			{
				Crate.velocity = (new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0));
				if (Input.GetAxis("Action")!=0 && !justGrabbed) //Should gave frame where it cannot be pressed again -Branden
				{
					Grab = false;
					Crate.isKinematic = true; //So it can't be pushed again -Branden Hey times 2
					Crate.velocity = (new Vector2(0, 0));
				}
				else
					justGrabbed = false;
			}

		}
=======

            if (Grab) //If Grab is true -Branden
            {
                Crate.velocity = (new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0)); //Add the horizontal velocity to Crate -Branden
                Invoke("justGrabbed", 1); //After a second can let go of box -Branden
            }
        }
>>>>>>> refs/remotes/SR-Steve/master
		
		// Turns the player around logically and visually -Steve
		void Flip(){
			right = !right;
			turning = false;
			transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		}

<<<<<<< HEAD
		// Detects when two colliders hit off of each other - Josh
		void OnCollisionEnter2D(Collision2D other)
		{
			// Lets player move with moving platform while on moving platform - Josh
			if(other.transform.tag == "MotionPlatform")
			{
                transform.parent = other.transform;
			}
		}

		// Detects when the collision above no longer occurs - Josh
		void OnCollisionExit2D(Collision2D other)   
		{
			// Stops player from moving in relation to moving platform - Josh
			if (other.transform.tag == "MotionPlatform")
			{
				transform.parent = null;
			}
		}

	}
=======
        void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.tag == "Crate") //Checks for tag Crate -Branden
                if (grounded && Input.GetAxis("Action") != 0) //Grabs if grounded after pressing x -Branden
                {
                    Grab = true; //For grabbing and letting go -Branden
                    Crate = other.gameObject.GetComponentInParent<Rigidbody2D>(); //getting Crate rigidbody -Branden
                    Crate.isKinematic = false; //Crate is Kinematic naturally -Branden
                }
        }

        //Fun little side thing I made. Once the player touches the box they will begin to float up, nothing serious -Branden
        /*void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.tag == "FloatingCrate")
            {
                Crate = other.gameObject.GetComponentInParent<Rigidbody2D>(); //getting Crate rigidbody -Branden
                Crate.velocity = (new Vector2(0, 1)); //Make it float upwards -Branden
            }
        }*/

        void justGrabbed() //function that allows the play to drop the box after being picked up- Branden
        {
            if (Input.GetAxis("Action") != 0) //Should gave frame where it cannot be pressed again -Branden
            {
                Grab = false;
                Crate.isKinematic = true; //So it can't be pushed again -Branden 
                Crate.velocity = (new Vector2(0, 0)); //Stop the box -Branden
            }
        }
    }
>>>>>>> origin/master
}