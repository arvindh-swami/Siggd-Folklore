using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl : MonoBehaviour {

	public GameObject bulletPrefab;
	public Transform bulletSpawn;
	public Transform bulletSpawn1;
	public Transform bulletSpawn2;
	public Transform bulletSpawn3;
	public GameObject head;
	public GameObject top;
	public GameObject mid;
	public GameObject bottom;
	private int health;

	float time;
	// Use this for initialization
	void Start () {
		time = Time.time;
		health = 10;
		no = 0;
		shot = 0;
	}
	int shot;
	int no;
	// Update is called once per frame
	void Update () {
		if (Time.time - time > 5.0f ) {
			no++;
			time = Time.time;
		}
		if (Time.time - time > 0.5f) {
			shot = 0;
			time = Time.time;
		}
		no = no%4;
		Transform[] spawns = {bulletSpawn,bulletSpawn1,bulletSpawn2,bulletSpawn3};
		Vector3[] velocities = { new Vector3 (0, 0, -1), new Vector3 (0,0,1), new Vector3 (-1,0,0), new Vector3 (1,0,0) };
		//Create Bullet from Bullet Prefab
		//var bullet = (GameObject)Instantiate(bulletPrefab, spawns[no].position, bulletSpawn.rotation);
		if (shot == 0) {
			
			int r = Random.Range (0, 4);
			var bullet = Instantiate (bulletPrefab, spawns [r].position, bulletSpawn.rotation);
			shot++;

			//Add velocity to bullet
			if (r == 0 ) {
				bullet.GetComponent<Rigidbody> ().velocity  -= transform.forward;

			}
			else
			{
				bullet.GetComponent<Rigidbody> ().velocity += transform.forward;
			}
			bullet.GetComponent<Rigidbody> ().velocity = velocities [r];

			//Destroy the bullet after 2 seconds
			Destroy (bullet, 2f);


		}
		Debug.Log ("Bullet Shot="+shot+"n_no="+no);

		//Fancy movement...
		head.transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
		top.transform.Rotate (new Vector3 (0, 0, 30) * Time.deltaTime);
		mid.transform.Rotate (new Vector3 (0, 0, -15) * Time.deltaTime);
		bottom.transform.Rotate (new Vector3 (0, 0, 25) * Time.deltaTime);

	}
}
