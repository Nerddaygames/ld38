using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour {

	private Transform parent;

	void Start(){
	}

	void Update () {
		// transform.LookAt(Camera.main.transform);
		transform.rotation = transform.parent.rotation;
	}
}
