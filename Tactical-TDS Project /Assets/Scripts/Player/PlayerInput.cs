using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;

public enum Types { Teleport, Frag, Flash }

[RequireComponent(typeof(Rigidbody))]
public class PlayerInput : NetworkBehaviour {

	public float speed;

	public List<GameObject> grenades = new List<GameObject>();
	public GameObject currentGrenade;

	private Transform throwPoint;
	public Types types;

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
		
		Vector3 movement = new Vector3(h,0,v) * Time.smoothDeltaTime * speed;
		
		transform.Translate(movement,Space.World);

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

		if (Input.GetKeyDown(KeyCode.Q)) {
			if (types == Types.Flash) {
				types = 0;
			}
			else {
				types += 1;
			}
		}

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
	
		GameObject g = Instantiate(currentGrenade, throwPoint.position, transform.rotation) as GameObject;
	
		NetworkServer.Spawn(g);
	
	}

}
