using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject bulletPrefab;
	public Transform bulletSpawn;
	public Transform bulletSpawn1;
	public Transform bulletSpawn2;
	public Transform bulletSpawn3;

	float time;
	// Use this for initialization
	void Start () {
		time = Time.time;
	}
	int shot = 0;
	int no = 0;
	// Update is called once per frame
	void Update () {
		if (Time.time - time > 5.0f ) {
			no++;
			time = Time.time;
		}
		if (Time.time - time > 2.0f) {
			shot = 0;
			time = Time.time;
		}
		no = no%4;
		Transform[] spawns = {bulletSpawn,bulletSpawn1,bulletSpawn2,bulletSpawn3};
		//Create Bullet from Bullet Prefab
		//var bullet = (GameObject)Instantiate(bulletPrefab, spawns[no].position, bulletSpawn.rotation);
		if (shot == 0) {
			var bullet = Instantiate (bulletPrefab, spawns [no].position, bulletSpawn.rotation);
			shot++;

			//Add velocity to bullet
			bullet.GetComponent<Rigidbody> ().velocity = bullet.transform.forward * 6;

			//Destroy the bullet after 2 seconds
			Destroy (bullet, 0.2f);

			Debug.Log ("Time = " + Time.time + "\nBullet Shot=\n"+shot+"\nno="+no);
		}
		
	}
}
