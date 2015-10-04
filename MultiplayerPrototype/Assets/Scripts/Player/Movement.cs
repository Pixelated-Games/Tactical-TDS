using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour {

	public int speed;

	void Update () {
        transform.Translate(Input.GetAxis("Horizontal") * Time.smoothDeltaTime * speed, 0, Input.GetAxis("Vertical") * Time.smoothDeltaTime * speed);
	}
}
