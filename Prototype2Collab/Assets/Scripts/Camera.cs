// Steven Gussman 10/20/15 @11:04 PM

using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	// Game object to look at
	public GameObject target;
	public bool following;
	public float followTime;

	// Init
	void Start () {
	
	}
	
	// Called once per frame
	void Update () {
		if(following){
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x, transform.position.y, transform.position.z), 4 * Time.deltaTime);
			if(Time.time - followTime >= 5f)
				following = false;
		}
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			following = true;
			followTime = Time.time;	
		}
	}
}
