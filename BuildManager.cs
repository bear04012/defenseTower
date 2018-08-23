using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {


	public static BuildManager instance;

	public TurretObj standardTurret;
	public TurretObj laserTurret;
	public TurretObj DoubleFireTurret;

	public TurretObj selectedTurret;

	public TurretObj getSelectedTurret(){
		return selectedTurret;
	}
	public void setSelectedTurret(TurretObj turret){
		selectedTurret = turret;
	}
	void Awake(){

		if (instance != null){
			return;
		}
		instance = this;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
