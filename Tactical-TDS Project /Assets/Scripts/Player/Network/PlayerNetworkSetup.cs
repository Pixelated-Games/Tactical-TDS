using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerNetworkSetup : NetworkBehaviour {

	//All of the players input components
	public PlayerInput inputScript;
	public GameObject[] necessaryGameobjects;
	public Vector3 startPos;

	// Use this for initialization
	void Start () {

		startPos = transform.position;

		if(!isLocalPlayer){

			inputScript.enabled = false;
			gameObject.tag = "Online";

		} else {

			gameObject.tag = "Local";

			foreach(GameObject g in necessaryGameobjects){
				
				Instantiate(g,transform.position,Quaternion.identity);
				
			}

		}
	
	}

}
