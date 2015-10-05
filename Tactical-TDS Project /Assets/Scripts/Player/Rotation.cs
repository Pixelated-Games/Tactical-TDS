using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

    void Update() {

		Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(mouseRay, out hit)) {

            Vector3 lookHere = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.LookAt(lookHere);
        }

    }

}
