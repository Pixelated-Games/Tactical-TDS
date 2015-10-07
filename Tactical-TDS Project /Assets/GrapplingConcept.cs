using UnityEngine;
using System.Collections;

public class GrapplingConcept : MonoBehaviour {
	
	public GameObject grappleObjectPrefab;

	Vector3 mousePos;
	GameObject grappleObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetMouseButtonDown(1)){

			Grapple();

		}

		PullIn();

	}

	void Grapple(){

		Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
	
		if (Physics.Raycast(mouseRay, out hit)) {
			
			mousePos = new Vector3(hit.point.x, transform.position.y, hit.point.z);
			//Debug.Log(mousePos);
		
		}

		Debug.DrawLine(GetComponent<PlayerInput>().throwPoint.position,mousePos,Color.red);

		if(hit.collider.gameObject.GetComponent<Rigidbody>() != null){

			ShootGrapple();

		}

	}



	void ShootGrapple(){

		Ray grappleRay = new Ray(transform.position,(mousePos - transform.position));
		RaycastHit grapplePoint;
		
		if (Physics.Raycast(grappleRay, out grapplePoint)) {

			if(GameObject.FindObjectsOfType<GrappleStick>() != null){

				foreach(GrappleStick g in GameObject.FindObjectsOfType<GrappleStick>()){

					Destroy(g.gameObject);

				}

				Destroy(GetComponent<SpringJoint>());

			}
			
			grappleObject = (GameObject)Instantiate(grappleObjectPrefab,GetComponent<PlayerInput>().throwPoint.position,GetComponent<PlayerInput>().throwPoint.rotation);

			gameObject.AddComponent<SpringJoint>().connectedBody = grappleObject.GetComponent<Rigidbody>();
			grappleObject.GetComponent<Rigidbody>().AddForce((grapplePoint.point - transform.position),ForceMode.Impulse);

		}

	}

	void PullIn(){

		if(Input.GetKey(KeyCode.Alpha4)){

			if(GetComponent<SpringJoint>() != null){

				gameObject.GetComponent<SpringJoint>().spring += Time.deltaTime;
				Debug.Log(gameObject.GetComponent<SpringJoint>().spring);

			}

		}

	}

}
