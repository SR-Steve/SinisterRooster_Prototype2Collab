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
        public bool grab = false; // Lower-cased -Steve
        public bool isTriggered;
        public Rigidbody2D crate; // Lower-cased -Steve

        // For climbing ladders -Steve
        public bool climbingLadder;
        bool startedClimbingThisFrame;
        public LayerMask whatIsLadder;
        bool headGround;
        public Transform headCheck;

        // Initialization -Steve
        void Start()
        {

            //In case Anais prefab is initilized staring left in a level -Steve
            //right = transform.localScale.x < 0f ? false : true;
            if (transform.localScale.x > 0f)
                right = true;

            // Get references for component fields -Steve
            bod = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            boxCollider = GetComponent<BoxCollider2D>();
            circleCollider = GetComponent<CircleCollider2D>();
        }

        // Called once per physics step -Steve
        void FixedUpdate()
        {

            // Check if Anais is on the ground, tell Animator -Steve
            grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
            anim.SetBool("grounded", grounded);
            // Take in lateral input (unless you're on a ladder) -Steve
            if (!climbingLadder)
                xInput = Input.GetAxis("Horizontal");
            /* Push the speed to the Animator's speed parameter so the animation
		       state changes between idle and walking -Steve */
            anim.SetFloat("speed", Mathf.Abs(xInput));
            bod.velocity = new Vector2(xInput * maxSpeed, bod.velocity.y);
            if(grab)
				crate.velocity = new Vector2(xInput * maxSpeed, crate.velocity.y); // Control the crate as well when grabbing -- works but reaquires frictionless floor -Steve
        }


        // Called once per frame -Steve
        void Update()
        {
            // Issues have to do w. these conds. only cheking when going a dir. you're not already
            if (xInput > 0f)
            { // Walking right -Steve
                if (!right)
                { // Walking right but facing left -Steve
                    if (!turning && !grab)
                    { // If not turning right, should be... -Steve
                        turnTime = Time.time;
                        turning = true;
                        maxSpeed = 0.67f; // Slower walk backward -Steve
                    }
                    // Walk backward slowly for 0.9 seconds before turning around -Steve
                    else if (Time.time - turnTime > 0.9f && !grab)
                        Flip();
                }
                else if (!grab)// Walking right and facing right -Steve
                    maxSpeed = 2f;
                else //If the player is Grabbing something, walk slower -Branden
                    maxSpeed = 1f;

            }
            else if (xInput < 0f)
            { // Walking left -Steve
                if (right)
                { // Walking left but facing right -Steve
                    if (!turning && !grab)
                    { // If not turning right, should be... -Steve
                        turnTime = Time.time;
                        turning = true;
                        maxSpeed = 0.67f; // Slower walk backward -Steve
                    }
                    // Walk backward slowly for 0.9 seconds before turning around -Steve
                    else if (Time.time - turnTime > 0.9f && !grab)
                        Flip();
                }
                else if (!grab)// Walking left and facing left -Steve
                    maxSpeed = 2f;
                /*else //If the player is Grabbing something, walk slower -Branden
                    maxSpeed = 1f;*/ // I think we can remove this because it's being done below under if(grab) -Steve
            }

            if (isTriggered)
            {
                if (grounded && Input.GetAxis("Action") != 0f) //Grabs if grounded after pressing x -Branden
                    grab = true;
            }
            Debug.Log("player velocity" + bod.velocity);

            if (grab) //If Grab is true -Branden
            {
                maxSpeed = 1f;
                Debug.Log(crate.velocity);
                Debug.Log("player velocity" + bod.velocity);
                Invoke("justGrabbed", 1); //After a second can let go of box   -Branden
            }

            // Ladder climbing code -Steve
            if (!climbingLadder && grounded && Physics2D.OverlapCircle(headCheck.position, groundRadius, whatIsLadder) && Input.GetAxis("Action") != 0f)
            {
                climbingLadder = true;
                startedClimbingThisFrame = true;
                bod.gravityScale = 0f;
                boxCollider.isTrigger = true;
                circleCollider.isTrigger = true;
            }
            else if (!climbingLadder && grounded && Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsLadder) && Input.GetAxis("Action") != 0f)
            {
                climbingLadder = true;
                startedClimbingThisFrame = true;
                boxCollider.isTrigger = true;
                circleCollider.isTrigger = true;
                bod.gravityScale = 0f;
            }

            if (climbingLadder)
            {
                float yInput = Input.GetAxis("Vertical");
                if (Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsLadder))
                    bod.velocity = new Vector2(0f, yInput * maxSpeed);
                else
                    bod.velocity = new Vector2(0f, 0f);
                if (!startedClimbingThisFrame && grounded && Input.GetAxis("Action") != 0f)
                {
                    climbingLadder = false;
                    boxCollider.isTrigger = false;
                    circleCollider.isTrigger = false;
                    bod.gravityScale = 1f;
                }
                startedClimbingThisFrame = false;
            }
        }

        // Turns the player around logically and visually -Steve
        void Flip()
        {
            right = !right;
            turning = false;
            transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (!grab && other.gameObject.tag == "Crate") //Checks for tag Crate -Branden // Check !grab to avoid crate-swap glitch -Steve
            {
                isTriggered = true;
                crate = other.gameObject.GetComponentInParent<Rigidbody2D>(); //getting Crate rigidbody -Branden
            }

            /*if(other.gameObject.tag == "FloatingCrate")
			{
				Crate = other.gameObject.GetComponentInParent<Rigidbody2D>(); //getting Crate rigidbody -Branden
				Crate.velocity = (new Vector2(0, 1)); //Make it float upwards -Branden
			}*/
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (grab && other.gameObject.tag == "Crate") // Checking grab is more of a formality for consistency here, I guess... maybe it can be removed -Steve
                isTriggered = false;
        }


        void justGrabbed() //function that allows the play to drop the box after being picked up- Branden
        {
            if (Input.GetAxis("Action") != 0) //Should gave frame where it cannot be pressed again -Branden
            {
                grab = false;
                crate.isKinematic = true; //So it can't be pushed again -Branden 
                crate.velocity = (new Vector2(0, 0)); //Stop the box -Branden
            }
        }
    }
}