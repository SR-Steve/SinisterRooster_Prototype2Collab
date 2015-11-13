// Steven Gussman	11/12/15 10:45 AM (THU)		The boxes need to fall off ledges

using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour {

	// For setting the box kinematic or not -Steve
	Rigidbody2D boxBod;
	BoxCollider2D boxCollider;
	
	// For checking if the box is on the ground -Steve
	//public bool grounded;
	public Transform groundCheck;
	float groundRadius = 0.05f;
	public LayerMask whatIsGround;
	Collider2D otherBoxCol;

	// Initialization
	void Start () {
		// Get reference to the box's Rigidbody2D -Steve
		boxBod = GetComponent<Rigidbody2D>();
		boxCollider = GetComponent<BoxCollider2D>();
	}
	
	// Called once per physics step -Steve
	void FixedUpdate () {
		// If the box is on the ground; no physics, if the box is in mid-air, let gravity do what it does -Steve
		if(Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround)){
			boxBod.isKinematic = true;
		}else{
			if(boxBod.IsTouching(otherBoxCol))
				boxBod.isKinematic = true;
			else
				boxBod.isKinematic = false;
		}
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		if(collision.collider.tag == "Box"){
			otherBoxCol = collision.collider;
		}
	}
}
