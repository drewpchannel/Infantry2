using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;

	// Use this for initialization
	void Start () {
        transform.rotation = Quaternion.Euler(90, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(player.position.x, 15, player.position.z);
	}
}
