using UnityEngine;
using System.Collections;

public class GrappleStick : MonoBehaviour {

	public bool canStickAgain = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	


	}

	void OnCollisionEnter(Collision hit){

		if(canStickAgain){

			if(hit.gameObject.GetComponent<Rigidbody>() != null && hit.gameObject.tag != "Grapple"){

				gameObject.AddComponent<FixedJoint>().connectedBody = hit.gameObject.GetComponent<Rigidbody>();
				canStickAgain = false;

			}

		} else {
		
			Destroy(gameObject);

		}

	}

}
