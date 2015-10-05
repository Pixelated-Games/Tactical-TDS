using UnityEngine;
using System.Collections;

public class Throw : MonoBehaviour {

    public GameObject grenade;

    private Transform throwPoint;

    void Awake() {
        throwPoint = GameObject.Find("Throw_Point").transform;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.E) && grenade) {
            Instantiate(grenade, throwPoint.position, transform.rotation);
        }
    }
}
