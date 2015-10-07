using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Container : NetworkBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit(Collider other){

		if(other.GetComponent<PlayerNetworkSetup>() != null){

			other.transform.position = other.GetComponent<PlayerNetworkSetup>().startPos;

		} else {

			Destroy(other.gameObject);

		}

	}
}
