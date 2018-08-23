using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayStat : MonoBehaviour {

	public static int Money;

	public static int Wave;
	
	public static int Lives;

	public static bool isGameOver;

	public Button restartButton;

	public GameObject GameOverPanel;

	// Use this for initialization
	void Start () {
		init();
		restartButton.onClick.AddListener(restartGame);
	}

	void init() {
		Money = 300;
		Lives = 10;
		Wave = 0;
		isGameOver = false;
	}

	void restartGame(){
		destroyAll();
		init();
		GameOverPanel.SetActive(false);
	}

	void destroyAll() {
		destroyObject("Bullet");
		destroyObject("Turret");
		destroyObject("Enemy");
	}

	void destroyObject(string tag){
		GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
		foreach (GameObject gameObj in gameObjects){
			Destroy(gameObj);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Lives <=0){
			isGameOver = true;
			GameOverPanel.SetActive(true);
		}
	}
}
