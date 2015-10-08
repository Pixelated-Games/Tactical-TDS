using UnityEngine;
using System.Collections;

public class Frag : MonoBehaviour {

    public float radius;
    public float power;
	Vector3 force;

    void OnCollisionEnter() {
			
		Explode();
		Destroy(gameObject);
			
	}

	void Explode(){

		Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
		
		for (int i = 0;i < hitColliders.Length;i++) {
			
			if(hitColliders[i].GetComponent<Rigidbody>() != null){
				
				force = hitColliders[i].transform.position - transform.position;
				
				hitColliders[i].GetComponent<Rigidbody>().AddForce(force * power,ForceMode.Impulse);
				
			}
			
		}

	}
}
