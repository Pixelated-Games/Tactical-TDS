using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

    private Camera cam;

    void Awake() {
        cam = Camera.main;
    }

    void Update() {
        Ray mouseRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(mouseRay, out hit)) {
            Vector3 lookHere = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.LookAt(lookHere);
        }
    }
}
