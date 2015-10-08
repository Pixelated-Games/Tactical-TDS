using UnityEngine;
using System.Collections;

public class GrappleStick : MonoBehaviour {

	public bool canStickAgain = true;
	public float pullStrength;

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

				if(hit.gameObject.GetComponent<Rigidbody>().isKinematic == true){
					
					GameObject.FindGameObjectWithTag("Local").GetComponent<SpringJoint>().spring = pullStrength;
					
				} else {
					
					GameObject.FindGameObjectWithTag("Local").GetComponent<SpringJoint>().spring = 10;
					
				}

				canStickAgain = false;

			}

		} else {
		
			Destroy(gameObject);

		}

	}

}
