using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    private Rigidbody myRigidBody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Camera mainCamera;

	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;

        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundplane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundplane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLookAt = cameraRay.GetPoint(rayLength);
            //Debug.DrawLine(cameraRay.origin, pointToLookAt, Color.green);
            transform.LookAt(new Vector3(pointToLookAt.x, transform.position.y, pointToLookAt.z));
        }
	}

    //something like every 50ms
    void FixedUpdate() {
        myRigidBody.velocity = moveVelocity;
    }
}
