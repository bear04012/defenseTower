using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paths : MonoBehaviour {

	public static Transform[] paths;

	
	void Awake() {
		int totalTileCount = transform.childCount;
		paths = new Transform[totalTileCount];

		for (int i=paths.Length-1; i>=0; i--){
			paths[i] = transform.GetChild(i);
			Debug.Log(paths[i].position);
		}

		Debug.Log(paths.Length);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
