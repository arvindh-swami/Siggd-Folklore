using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour {

	public GameObject player;
	float currentTime;

	// Use this for initialization
	void Start () {
		currentTime = Time.time;
		player = GameObject.FindGameObjectWithTag("player");
		//ransform.position += player.transform.forward;
		transform.rotation = player.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.forward;
		if (Time.time - currentTime >= 5F) {
			Destroy (this.gameObject);
		}
	}
}
