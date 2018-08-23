using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour {

	
	private Renderer rend;

	private Material startMaterial;
	public Material hoverMaterial;
	public Material impossibleMaterial;

	private GameObject existedTurret;
	
	public Vector3 offset;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		startMaterial = rend.material;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseEnter() {

		if (PlayStat.isGameOver) {
			return;
		}

		if (EventSystem.current.IsPointerOverGameObject()) 
			return;
		
		if(PlayStat.Money >= 50){
			rend.material = hoverMaterial;
		} else {
			rend.material = impossibleMaterial;
		}
		Debug.Log("OnMouseEnter");
	}

	void OnMouseExit() {
		if (PlayStat.isGameOver) {
			return;
		}

		Debug.Log("OnMouseExit");
		rend.material = startMaterial;
	}

	void OnMouseDown(){
		if (PlayStat.isGameOver) {
			return;
		}
		
		if(EventSystem.current.IsPointerOverGameObject()) 
			return;
		if(existedTurret == null){

			TurretObj turretToBuild = BuildManager.instance.getSelectedTurret();

			if (PlayStat.Money >= turretToBuild.cost) {
				existedTurret = (GameObject) Instantiate(turretToBuild.turretPrefab,transform.position+offset,transform.rotation);
				PlayStat.Money -= turretToBuild.cost;
			}
			
		}
	}
}
