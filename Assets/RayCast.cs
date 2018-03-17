using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RayCast : MonoBehaviour {
	private RaycastHit vision;
	public float rayLength;
	public float smooth = 1f;
	private Rigidbody grabbedObject;
	private NavMeshAgent navMeshAgent;
	private Quaternion targetRotation;

	void Start () {
		rayLength = 4.0f;
		navMeshAgent = GetComponent<NavMeshAgent> ();
		navMeshAgent.angularSpeed = 0;
		targetRotation = transform.rotation;
	}
	
	void Update () {
	    Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
	    RaycastHit hit;
	    if (Input.GetButtonDown ("Fire1")) {
	        if (Physics.Raycast(ray, out hit, 100)) {
	            if (hit.collider.CompareTag("plane")) {
					navMeshAgent.destination = hit.point;
					navMeshAgent.Resume();
	            }
	        }
	    }

		if (Input.GetKeyDown (KeyCode.Q)) { 
			targetRotation *= Quaternion.AngleAxis (90, Vector3.up);
		} else if (Input.GetKeyDown (KeyCode.E)) {
			targetRotation *= Quaternion.AngleAxis (-90, Vector3.up);
		}

		transform.rotation= Quaternion.Lerp (transform.rotation, targetRotation , 10 * smooth * Time.deltaTime);
	}
}
