// Josh Castor 10/13/2015 - Initialized class
/*Description:
 	Handles the basic physics of a moving platform. - Josh
*/

/**Unsolved known errors: 	

*/

/**Solved errors:
   
*/

using UnityEngine;
using System.Collections;

namespace JoshCastor {
	public class MotionPlatform : MonoBehaviour {

		public float moveSpeed;
		private Transform currentPoint;
		public Transform[] points;  // Potential destinations of platforms - Josh
		public int pointSelection;  // Destination of platform - Josh

		// Use this for initialization
		void Start () {
			currentPoint = points[pointSelection];
		}
		
		// Update is called once per frame
		void Update () {

		}

		// Move platform to defined "point" - Josh
		public void MoveToPoint(Transform point){
		    transform.position = Vector3.MoveTowards(transform.position, point.position, Time.deltaTime*moveSpeed);
		}

		public Transform getCurrentPoint() {
			return currentPoint;
		}

		public void setCurrentPoint(Transform newPoint){
			currentPoint = newPoint;
		}

		//Draws path to travel in editor
		public void OnDrawGizmos()
		{
			if (points == null || points.Length < 2)  //Each path needs to have at least two points: a start and an end.
				return;
			
			//Drawing the line
			for (int i = 1; i < points.Length; i++)
				Gizmos.DrawLine(points[i - 1].position, points[i].position);
		}
	}
}
