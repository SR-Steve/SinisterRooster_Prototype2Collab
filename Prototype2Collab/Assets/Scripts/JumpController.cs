

/*Just a note, I did not add in the Animator yet, need a little help with that. Tested on a test project, requires an empty game object "groundCheck" to be
assigned to the gameobject to work. Let me know if I need to chnage anything, used some of Stevens script to make it compatible and easy to integrate (I think/hope)
*/

using UnityEngine;
using SteveGussman;
using System.Collections;

namespace JakeHohing
{

    public class JumpController : MonoBehaviour
    {
        Rigidbody2D bod;



        public float maxSpeed = 2f;
        public float jumpForce = 400f;
        public LayerMask whatIsGround;
        public Transform groundCheck;
        public bool grounded;
        public bool jump = false;
        float xInput;




        // Use this for initialization
        void Start()
        {

            bod = GetComponent<Rigidbody2D>();


        }

        void FixedUpdate()
        {
            /* 
            //Steven's movment code
            xInput = Input.GetAxis("Horizontal");

            bod.velocity = new Vector2(xInput * maxSpeed, bod.velocity.y);
            
            */ /* We should remove this commented out part altogether because
                  I have walking in another Script.  We should also porbably merge this Script with the AnaisController -Steve */

            // if jump is initiated, jumpforce is applied, jump then becomes false so not to allow double jumping
            if (jump)
            {
                bod.AddForce(new Vector2(0f, jumpForce));
                jump = false;
            }
        }

        // Update is called once per frame
        void Update()
        {
            AnaisController Anais = GetComponent<AnaisController>(); //Importing AnaisController variables  -Branden
            //checking if grounded
            if (!grounded && GetComponent<Rigidbody2D>().velocity.y == 0)
            {
                grounded = true;
            }
            //setting grounded to false if jump is initiated 
            if (Input.GetButtonDown("Jump") && grounded == true && !Anais.grab && !Anais.climbingLadder) //Cannot Jump when Grab or climbing is true -Branden
            {
                bod.AddForce(transform.up * jumpForce);
                grounded = false;


                grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("ground"));

                //jump now becomes true once grounded is true
                if (Input.GetButtonDown("Jump") && grounded) // Changed "jump" to "Jump"; just a typo -Steve
                {
                    jump = true;
                }
            }

        }
    }
}
