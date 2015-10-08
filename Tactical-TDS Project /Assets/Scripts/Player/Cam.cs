using UnityEngine;
using System.Collections;

public class Cam : MonoBehaviour {

    public float height;
    public float dampening;

    private Transform player;

	void Start(){

		transform.eulerAngles = new Vector3(90,0,0);
		player = GameObject.FindGameObjectWithTag("Local").transform;

	}

    void Update() {

		player = GameObject.FindObjectOfType<PlayerInput>().transform;

        transform.position = Vector3.Lerp(transform.position, player.position + (Vector3.up * height), Time.smoothDeltaTime * dampening);

    }
}
