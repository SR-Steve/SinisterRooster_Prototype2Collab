// Steven Gussman  10/11/15 2:56 PM (SUN)
/*
Description:  This script is for the walking controls and physics of the player
			  but I gave it a generic name for now because it's probably best
			  we merge things like jumping and climbing into one character
			  controller script. -Steve
*/

using UnityEngine;
using System.Collections;

// To avoid naming collisions / stay organized -Steve
namespace SteveGussman{

	public class AnaisController : MonoBehaviour {
	
		// Reference to Rigidbody2D component -Steve
		Rigidbody2D bod;
		BoxCollider2D boxCollider;
		CircleCollider2D circleCollider;
		
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

        //To push/pull blocks - Branden
        public bool Grab = false;
		bool isTriggered;
        public Rigidbody2D Crate;
        
        // For climbing ladders -Steve
        bool climbingLadder;
        bool startedClimbingThisFrame;
        public LayerMask whatIsLadder;
        bool headGround;
        public Transform headCheck;

        // Initialization -Steve
        void Start(){
		
			//In case Anais prefab is initilized staring left in a level -Steve
			//right = transform.localScale.x < 0f ? false : true;
			if(transform.localScale.x > 0f)
				right = true;
			   		
			// Get references for component fields -Steve
			bod = GetComponent<Rigidbody2D>();
			anim = GetComponent<Animator>();
			boxCollider = GetComponent<BoxCollider2D>();
			circleCollider = GetComponent<CircleCollider2D>();
		}
		
		// Called once per physics step -Steve
		void FixedUpdate(){
		
			// Check if Anais is on the ground, tell Animator -Steve
			grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
			anim.SetBool("grounded", grounded);
			// Take in lateral input (unless you're on a ladder) -Steve
			if(!climbingLadder)
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
            
            if(isTriggered){
            	if(grounded && Input.GetAxis("Action" )!= 0f){
            		Grab = true;
            	}
            }           

            if (Grab) //If Grab is true -Branden
            {
                Crate.velocity = (new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0)); //Add the horizontal velocity to Crate -Branden
                Invoke("justGrabbed", 1); //After a second can let go of box -Branden
            }
            
			// Ladder climbing code -Steve
			if(!climbingLadder && grounded && Physics2D.OverlapCircle(headCheck.position, groundRadius, whatIsLadder) && Input.GetAxis("Action") != 0f){
				climbingLadder = true;
				startedClimbingThisFrame = true;
				bod.gravityScale = 0f;
				boxCollider.isTrigger = true;
				circleCollider.isTrigger = true;
			}else if(!climbingLadder && grounded && Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsLadder) && Input.GetAxis("Action") != 0f){
				climbingLadder = true;
				startedClimbingThisFrame = true;
				boxCollider.isTrigger = true;
				circleCollider.isTrigger = true;
				bod.gravityScale = 0f;
			}
			
			if(climbingLadder){
				float yInput = Input.GetAxis("Vertical");
				if(Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsLadder))
					bod.velocity = new Vector2(0f, yInput * maxSpeed);
				else
					bod.velocity = new Vector2(0f, 0f);
				if(!startedClimbingThisFrame && grounded && Input.GetAxis("Action") != 0f){
					climbingLadder = false;
					boxCollider.isTrigger = false;
					circleCollider.isTrigger = false;
					bod.gravityScale = 1f;
				}
				startedClimbingThisFrame = false;
			}
        }
		
		// Turns the player around logically and visually -Steve
		void Flip(){
			right = !right;
			turning = false;
			transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f);
		}

		void OnTriggerEnter2D(Collider2D other)
		{
			if (other.gameObject.tag == "Crate") //Checks for tag Crate -Branden
			{
				isTriggered = true;
				//if (grounded && Input.GetAxis("Action") != 0) //Grabs if grounded after pressing x -Branden
					Crate = other.gameObject.GetComponentInParent<Rigidbody2D>(); //getting Crate rigidbody -Branden
			}
			
			/*if(other.gameObject.tag == "FloatingCrate")
			{
				Crate = other.gameObject.GetComponentInParent<Rigidbody2D>(); //getting Crate rigidbody -Branden
				Crate.velocity = (new Vector2(0, 1)); //Make it float upwards -Branden
			}*/
		}
		
		void OnTriggerExit2D(Collider2D other)
		{
			if (other.gameObject.tag == "Crate")
				isTriggered = false;
		}
		

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
}