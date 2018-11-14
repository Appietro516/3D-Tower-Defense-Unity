using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the bank tower does not need to update itself, so most  methods are empty.
public class BankTower : AbstractTower {
	public override void Start () {
		base.Start();
	}

	protected override void miscUpdate(){
		return;
	}

	protected override bool fire(){
		return true;
	}

	void OnMouseDown(){
		return;
	}



}
