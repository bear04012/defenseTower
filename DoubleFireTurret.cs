using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleFireTurret : MonoBehaviour {

	public Transform head;
	private Transform target;


	private string enemyTag = "Enemy";
	private float range = 4f;

	private float turnSpeed = 10f;

	public GameObject Bullet;
	public Transform FirePositionLeft;
	public Transform FirePositionRight;

	private float fireCountDown = 1f;
	private float fireRate = 5f;

	private int leftOrRight = 0;


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
			return;
		}
		LockOn();

		if (fireCountDown <= 0f){
			// leftOrRight%2==0?ShootLeft():ShootRight();
			if(leftOrRight%2==0){
				ShootLeft();
			} else {
				ShootRight();
			}
			leftOrRight++;
			fireCountDown = 1f/fireRate;
			}
			fireCountDown -=Time.deltaTime;
	}

	private void LockOn(){
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(dir);
		Vector3 rotation = Quaternion.Lerp(head.rotation,lookRotation,Time.deltaTime*turnSpeed).eulerAngles;
		head.rotation = Quaternion.Euler(0f,rotation.y,0f);
	}

	void ShootLeft(){
		GameObject bulletGo = (GameObject) Instantiate(Bullet,FirePositionLeft.position,Quaternion.identity);
		
		Bullet bullet = bulletGo.GetComponent<Bullet>();
		if (bullet != null) {
			bullet.Seek(target);
		}
		
	}

	void ShootRight(){
		GameObject bulletGo2 = (GameObject) Instantiate(Bullet,FirePositionRight.position,Quaternion.identity);
		
		Bullet bullet2 = bulletGo2.GetComponent<Bullet>();
		if (bullet2 != null) {
			bullet2.Seek(target);
		}
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(transform.position,range);
	}
}
