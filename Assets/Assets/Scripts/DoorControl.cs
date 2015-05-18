using UnityEngine;
using System.Collections;

public class DoorControl : MonoBehaviour {
	public float smooth;
	public float DoorOpenAngle;
	public float DoorCloseAngle;
	private bool open;
	private bool enter; 

	//Activate the Main function when player is near the door
	void  OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Player")
		{
			enter = true;
			print("open");
		}
	}
	
	//Deactivate the Main function when player is go away from door
	void  OnTriggerExit (Collider other){
		if (other.gameObject.tag == "Player")
		{
			enter = false;
			print("close");
		}
	}
	// Update is called once per frame
	void Update () {

		if(open == true){ 
			var target = Quaternion.Euler (0, DoorOpenAngle, 0);
			// Dampen towards the target rotation
			transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * smooth);
		}
		
		if(open == false){
			var target1 = Quaternion.Euler (0, DoorCloseAngle, 0);
			// Dampen towards the target rotation
			transform.localRotation = Quaternion.Slerp(transform.localRotation, target1,Time.deltaTime * smooth);
		}
		
		if(enter == true){
			if(Input.GetKeyDown("f")){
				open = !open;
			}
		}

	}


}

