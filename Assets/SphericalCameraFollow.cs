using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphericalCameraFollow : MonoBehaviour {
	// ref variable for world position
	Transform world;
	// ref variable for player position
	Transform player;
	// ref variable for player camera node position
	Transform playerCameraNode;
	// variable for storing intial distance
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		world = GameObject.FindGameObjectWithTag ("World").transform;
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		playerCameraNode = GameObject.FindGameObjectWithTag ("PlayerCameraNode").transform;

		// offset = (world.position - player.position) - transform.position;
		offset = player.position - transform.position;
	}
	
	// after everything else, adjust camera
	void LateUpdate () {
		// move camera to camera node position
		transform.position = playerCameraNode.position;
		// try to get the same "up" as player
		transform.Translate(player.up, Space.Self);

	}
}
