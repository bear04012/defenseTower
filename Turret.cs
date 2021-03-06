﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	public Transform head;
	private Transform target;

	//laser
	// private Enemy targetEnemy;

	private string enemyTag = "Enemy";
	private float range = 2f;

	private float turnSpeed = 10f;

	public GameObject Bullet;
	public Transform FirePosition;

	private float fireCountDown = 1f;
	private float fireRate = 1f;

	//laser
	// public bool useLaser = false;
	// public LineRenderer lineRenderer;
	// public ParticleSystem laserImpact;

	// Use this for initialization
	void Start () {
		InvokeRepeating("UpdateTarget",0f,0.5f);
	}
	
	void UpdateTarget() {
		GameObject[] Enemies = GameObject.FindGameObjectsWithTag(enemyTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;

		foreach(GameObject Enemy in Enemies) {
			Vector3 myPosition = transform.position;
			float distance = Vector3.Distance(myPosition, Enemy.transform.position);

			if (distance <= shortestDistance) {
				shortestDistance = distance;
				nearestEnemy = Enemy;
			}
			if (nearestEnemy != null && shortestDistance <= range) {
				target = nearestEnemy.transform;
				// targetEnemy = target.gameObject.GetComponent<Enemy>();
			}

		}

	}
	// Update is called once per frame
	void Update () {
		if(target == null){
			// if(useLaser){
			// 	if(lineRenderer.enabled){
			// 		lineRenderer.enabled = false;
			// 		laserImpact.Stop();
			// 	}
			// }
			return;
		}
		LockOn();

		// if(useLaser){
		// 	Laser();
		// } else{
		// 	if (fireCountDown <= 0f){
		// 		Shoot();
		// 		fireCountDown = 1f/fireRate;
		// 	}
		// 	fireCountDown -=Time.deltaTime;
		// }

		if (fireCountDown <= 0f){
				Shoot();
				fireCountDown = 1f/fireRate;
			}
			fireCountDown -=Time.deltaTime;
	}

	// void Laser() {
	// 	if(!lineRenderer.enabled){
	// 		lineRenderer.enabled = true;
	// 		laserImpact.Play();
	// 	}
	// 	lineRenderer.SetPosition(0,FirePosition.position);
	// 	lineRenderer.SetPosition(1, target.position);
	// 	laserImpact.transform.position = target.position;
	// 	targetEnemy.SlowDown(0.5f);
		
	// }

	private void LockOn(){
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(dir);
		Vector3 rotation = Quaternion.Lerp(head.rotation,lookRotation,Time.deltaTime*turnSpeed).eulerAngles;
		head.rotation = Quaternion.Euler(0f,rotation.y,0f);
	}

	void Shoot(){
		GameObject bulletGo = (GameObject) Instantiate(Bullet,FirePosition.position,Quaternion.identity);
		
		Bullet bullet = bulletGo.GetComponent<Bullet>();
		if (bullet != null) {
			bullet.Seek(target);
		}
		
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(transform.position,range);
	}
}
