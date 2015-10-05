using UnityEngine;
using System.Collections;

public class Cam : MonoBehaviour {

    public float height;
    public float dampening;

    private Transform player;

    void Update() {

		player = GameObject.FindObjectOfType<Movement>().transform;

        transform.position = Vector3.Lerp(transform.position, player.position + (Vector3.up * height), Time.smoothDeltaTime * dampening);

    }
}
