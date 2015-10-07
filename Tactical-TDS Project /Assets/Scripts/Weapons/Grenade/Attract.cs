using UnityEngine;
using System.Collections;

public class Attract : MonoBehaviour {

	public float radius;
	public float strength;
	Vector3 force;
	
	// Update is called once per frame
	void Update () {

		PullIn();
	
	}

	void PullIn(){

		Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

		for (int i = 0;i < hitColliders.Length;i++) {

			if(hitColliders[i].GetComponent<Rigidbody>() != null){

				force = transform.position - hitColliders[i].transform.position;

				hitColliders[i].GetComponent<Rigidbody>().AddForce(force * strength * hitColliders[i].GetComponent<Rigidbody>().mass);

			}
		
		}

	}

	void PushAway(){

		Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
		
		for (int i = 0;i < hitColliders.Length;i++) {
			
			if(hitColliders[i].GetComponent<Rigidbody>() != null){

				force = hitColliders[i].transform.position - transform.position;

				hitColliders[i].GetComponent<Rigidbody>().AddForce(force * strength * hitColliders[i].GetComponent<Rigidbody>().mass);
				
			}
			
		}

	}
}
