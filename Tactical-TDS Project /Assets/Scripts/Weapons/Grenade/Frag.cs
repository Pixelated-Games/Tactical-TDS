using UnityEngine;
using System.Collections;

public class Frag : MonoBehaviour {

    public float radius;
    public Vector3 power;

    void OnCollisionEnter() {
        Ray groundRay = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(groundRay, out hit)) {
            foreach (Collider col in Physics.OverlapSphere(hit.point, radius)) {
                col.GetComponent<Rigidbody>().AddForceAtPosition(power,transform.position);
            }
        }
    }
}
