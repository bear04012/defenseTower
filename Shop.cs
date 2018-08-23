using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

	public void SelectStandardTurret() {
		BuildManager.instance.setSelectedTurret(BuildManager.instance.standardTurret);
	}

	public void SelectLaserTurret() {
		BuildManager.instance.setSelectedTurret(BuildManager.instance.laserTurret);
	}

	public void SelectDoubleFireTurret() {
		BuildManager.instance.setSelectedTurret(BuildManager.instance.DoubleFireTurret);
	}
}
