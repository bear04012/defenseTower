using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	private float speed;

	private float baseSpeed;

	private int index;

	public float initHealth = 100;
	private float health;
	private bool isDead = false;
	public Image lifeBar;

	private int value = 30;


	Transform targetPath;

	// Use this for initialization
	void Start () {
		index =Paths.paths.Length-1;
		baseSpeed = 2;
		speed = baseSpeed;
		health = initHealth;
		targetPath = Paths.paths[index];


		// float distance = Vector3.Distance(testPath.position,transform.position);

		
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 direction = targetPath.position - transform.position;
		transform.Translate(direction.normalized * speed * Time.deltaTime);

		float distance = Vector3.Distance(targetPath.position,transform.position);

		if (distance < 0.2f) {
			index--;
			if (index > -1) {
				targetPath = Paths.paths[index];
			} else {
				EndPath();
				return;
			}
			
		}

		speed = baseSpeed;
	}

	void EndPath() {
		PlayStat.Lives--;
		Destroy(gameObject);
	}

	public void TakeDamage(float amount) {
		health -= amount;
		float perc = health/initHealth;
		lifeBar.fillAmount = perc;

		if (perc<0.2){
			lifeBar.color = Color.red;
		} else if (perc<0.5){
			lifeBar.color = Color.yellow;
		}

		if (health <=0 && !isDead) {
			Die();
		}
	}

	void Die() {
		isDead = true;
		PlayStat.Money += value;
		Destroy(gameObject);
	}

	public void SlowDown(float slowSpeed){
		speed = baseSpeed*(1-slowSpeed);
	}
}
