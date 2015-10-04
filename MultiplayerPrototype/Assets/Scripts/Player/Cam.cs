using UnityEngine;
using System.Collections;

public class Cam : MonoBehaviour {

    public float height;
    public float dampening;

    private Transform player;

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update() {
        transform.position = Vector3.Lerp(transform.position, player.position + (Vector3.up * height), Time.smoothDeltaTime * dampening);
    }
}
