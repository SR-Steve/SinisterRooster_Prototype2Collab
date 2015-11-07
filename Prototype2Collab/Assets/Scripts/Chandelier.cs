// Josh Castor 10/13/15 - Initialized class
// Josh Castor 10/16/15 - Added debug messages for "OnCollisionEnter2D" and "OnCollisionExit2D"
/**Unsolved known errors: 	

*/

/**Solved errors:
    When platform moves down, player temporarily does not collide with platform, causing player to bounce and platform to move down very slowly. -Josh
    - Atmpt'd Sol: Give platform a Rigidbody2D and turn off gravity.
    -- Result: Platform physics become more realistic (which we don't want) when colliding with player.
    - Atmpt'd Sol: Make platform and player out of a frictionless and bounceless material
    -- Result: Absolute bupkis.
	- Sol?: Made player child of platform when player collides with platform.
	-- Result: Creates "Player becomes smaller on platform" error as defined under "AnaisController"

*/

/***Notes:
	This class is meant to be used with only 2 points (platform destinations) - Josh
 */
using UnityEngine;
using System.Collections;

namespace JoshCastor {

	public class Chandelier : MotionPlatform {
	
		public GameObject anais;

        /*
		    Update is called once per physics time step
		    See http://answers.unity3d.com/questions/10993/whats-the-difference-between-update-and-fixedupdat.html for differences between Update() and FixedUpdate()
		    - Josh
		*/
        void FixedUpdate () {
            /*	Pseudocode
			 * If chandelier is currently colliding with player
			 * 	Move to endpoint
			 * 
			 * If chandelier is currently not colliding with player
			 * 	Move to startpoint
			 * 
			 * - Josh
			 */
            MoveToPoint(getCurrentPoint()); // Move platform to destination
        }

		// Detects when two colliders hit off of each other - Josh
		void OnCollisionEnter2D(Collision2D other)
		{
			// Change platform destination to next point (which should be endPoint) - Josh
			if(other.transform.tag == "Player")
			{
				anais.transform.SetParent(transform);
				pointSelection++;
				if (pointSelection < points.Length)
                    setCurrentPoint(points[pointSelection]);
				Debug.Log ("Moving Down");
			}
		}
		
		// Detects when the collision above no longer occurs - Josh
		void OnCollisionExit2D(Collision2D other)   
		{
			// Change platform destination back to startPoint
			if (other.transform.tag == "Player")
			{
				anais.transform.SetParent(null);
				pointSelection = 0;
				setCurrentPoint(points[pointSelection]);
				Debug.Log ("Moving Up");
			}
		}
	}

}
