using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Tele : MonoBehaviour {

    public Vector3 throwForce;
    public float dampening;

    private Transform player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        GetComponent<Rigidbody>().AddRelativeForce(throwForce, ForceMode.Impulse);

    }

    void OnCollisionEnter() {
        Ray groundRay = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(groundRay, out hit)) {
            player.position = hit.point + (Vector3.up * dampening);
            Destroy(gameObject);
        }
    }
}
