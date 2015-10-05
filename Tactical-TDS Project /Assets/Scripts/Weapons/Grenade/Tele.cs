using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[RequireComponent(typeof(Rigidbody))]
public class Tele : NetworkBehaviour {

    public Vector3 throwForce;
    public float dampening;

    private Transform player;

    void Start() {

        GetComponent<Rigidbody>().AddRelativeForce(throwForce, ForceMode.Impulse);

    }

	void Update(){

		player = GameObject.FindGameObjectWithTag("Local").transform;

	}

    void OnCollisionEnter() {

        Ray groundRay = new Ray(transform.position, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(groundRay, out hit)) {

			player.position = hit.point + (Vector3.up * dampening);
			NetworkServer.Destroy(gameObject);

        }

    }

}
