using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodePlayerFollow : MonoBehaviour {

	// TODO add smoothing and lerping
	Transform player;
	Vector3 offset;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		offset = player.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.position + offset;
		transform.rotation = player.rotation;
		transform.LookAt (player.position);
	}
}
