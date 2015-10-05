using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerNetworkSetup : NetworkBehaviour {

	//All of the players input components
	public Component[] inputComponents;
	public GameObject[] necessaryGameobjects;
	public Vector3 startPos;

	// Use this for initialization
	void Start () {

		startPos = transform.position;

		if(!isLocalPlayer){

			foreach(Component comp in inputComponents){

				Destroy(comp);

			}

			gameObject.tag = "Online";

		} else {

			gameObject.tag = "Local";

			foreach(GameObject g in necessaryGameobjects){
				
				Instantiate(g,transform.position,Quaternion.identity);
				
			}

		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
