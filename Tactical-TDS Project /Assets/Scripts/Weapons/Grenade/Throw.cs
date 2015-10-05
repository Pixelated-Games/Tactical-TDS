using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Throw : NetworkBehaviour {

    public GameObject grenade;

    private Transform throwPoint;

    void Start() {

        throwPoint = transform.GetChild(0);

    }

    void Update() {

		if(!isLocalPlayer){

			return;

		}

		if (Input.GetKeyDown(KeyCode.E) && grenade) {

     		Cmd_ThrowGrenade();

		}

    }

	[Command]
	void Cmd_ThrowGrenade(){
			

		GameObject g = Instantiate(grenade, throwPoint.position, transform.rotation) as GameObject;
			
		NetworkServer.Spawn(g);

	}

}
