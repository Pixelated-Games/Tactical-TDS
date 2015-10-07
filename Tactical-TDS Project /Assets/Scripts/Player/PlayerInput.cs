using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;

public enum Types { Teleport, Frag, Flash }

[RequireComponent(typeof(Rigidbody))]
public class PlayerInput  : NetworkBehaviour {

	public float speed;

	public List<GameObject> grenades = new List<GameObject>();
	public GameObject currentGrenade;

	public Transform throwPoint;
	public Types types;
	public float upwardMultiplier;

	int cycleIndex;
	Vector3 mousePosThrow;

	void Start() {
		
		throwPoint = transform.GetChild(0);
	
		if(types == Types.Teleport){

			currentGrenade = grenades[0];

		} else if(types == Types.Frag){
			
			currentGrenade = grenades[1];
			
		} else if(types == Types.Flash){
			
			currentGrenade = grenades[2];
			
		}
		
	}

	void Update () {

		Move();
		Rotate();
		Cycle();
		Throw();

	}

	void Move(){

		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3(h,0,v) * speed;
		
		GetComponent<CharacterController>().SimpleMove(movement);

	}

	void Rotate(){

		Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		
		if (Physics.Raycast(mouseRay, out hit)) {
			
			Vector3 lookPos = new Vector3(hit.point.x, transform.position.y, hit.point.z);
			transform.LookAt(lookPos);
		}

	}

	void Cycle(){

		if (Input.GetKeyDown(KeyCode.Alpha1)) {

			cycleIndex = 0;

		} else if (Input.GetKeyDown(KeyCode.Alpha2)) {
			
			cycleIndex = 1;
			
		} else if (Input.GetKeyDown(KeyCode.Alpha3)) {
			
			cycleIndex = 2;
			
		} 

		currentGrenade = grenades[cycleIndex];

	}

	void Throw(){

		if(!isLocalPlayer){
			
			return;
			
		}
		
		if (Input.GetKeyDown(KeyCode.E) && currentGrenade) {
			
			Cmd_ThrowGrenade();
			
		}

	}

	[Command]
	void Cmd_ThrowGrenade(){

		Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		
		if (Physics.Raycast(mouseRay, out hit)) {
			
			mousePosThrow = new Vector3(hit.point.x, transform.position.y, hit.point.z);

		}

		Vector3 forwardForce = transform.forward * Vector3.Distance(transform.position,mousePosThrow) * 10;
		Debug.Log(Vector3.Distance(transform.position,mousePosThrow));

		Vector3 upwardForce = transform.up * upwardMultiplier;

		Vector3 throwForce = forwardForce + upwardForce;

		GameObject g = Instantiate(currentGrenade, throwPoint.position, transform.rotation) as GameObject;
		g.GetComponent<Rigidbody>().AddForce(throwForce, ForceMode.Impulse);

		NetworkServer.Spawn(g);
	
	}

}
