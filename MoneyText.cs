﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyText : MonoBehaviour {

	public Text moneyText;

	// Use this for initialization	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		moneyText.text = "Money \n$" + PlayStat.Money;
	}
}
