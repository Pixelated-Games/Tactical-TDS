using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour {

	public float speed;

	void Update () {

		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(h,0,v) * Time.smoothDeltaTime * speed;

        transform.Translate(movement,Space.World);

	}

}
