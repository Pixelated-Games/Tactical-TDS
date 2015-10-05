using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerNetworkSetup : NetworkBehaviour {

	//All of the players input components
	public Component[] inputComponents;

	// Use this for initialization
	void Start () {

		if(!isLocalPlayer){

			foreach(Component comp in inputComponents){

				Destroy(comp);

			}

			gameObject.tag = "Online";

		} else {

			gameObject.tag = "Local";

		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
