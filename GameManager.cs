using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


	private float startDelayTime = 1f;
	private float delayTime = 3f;

	public GameObject Enemy;
	public Transform StartingPoint;

	//private int waveCount=0;
	public Text waveText;
	public Button startButton;

	
	// Use this for initialization
	void Start () {
		startButton.onClick.AddListener(forceStart);
	}

	private void forceStart() {
		startDelayTime=0;
	}

	// Update is called once per frame
	void Update () {
		
		if (PlayStat.isGameOver) {
			return;
		}

		// startDelayTime -= Time.deltaTime;

		if(startDelayTime <=0 ){
			PlayStat.Wave++;
			startDelayTime = delayTime;
			Debug.Log("Start Wave");
			StartCoroutine(Spawner());
			
		}
	}

	IEnumerator Spawner(){
		for (int i=0; i<PlayStat.Wave; i++){
			yield return new WaitForSeconds(0.5f);
			SpawnEnemy();
			
		}
	}

	private void SpawnEnemy() {
		Instantiate(Enemy, StartingPoint.position,Quaternion.identity);
		
	}

}
