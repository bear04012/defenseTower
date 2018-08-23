using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	// Use this for initialization

	private Transform target;

	public float speed;

	public GameObject particle;

	public void Seek(Transform _target){
		target = _target;
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (target == null){
			Destroy(gameObject);
			return;
		}

		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed*Time.deltaTime;

		if (dir.magnitude<= distanceThisFrame) {
			HitTarget();
			return;
		}

		transform.Translate(dir.normalized * distanceThisFrame, Space.World);
		transform.LookAt(target);

	}

	private void HitTarget(){
		GameObject particleObj = (GameObject)Instantiate(particle,target.position,Quaternion.identity);
		Destroy(particleObj,0.5f);
		Damage(target);
		Destroy(gameObject);
		
	}

	void Damage(Transform target){
		target.gameObject.GetComponent<Enemy>().TakeDamage(30);
	}
}
