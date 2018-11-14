using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTower : MonoBehaviour {

	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class AoeTower : AbstractTower {
		public override void Start () {
			base.Start();
		}

		protected override bool fire(){
			foreach(GameObject targetedEnemy in CreatePath.enemies){
				if (inRange(targetedEnemy)){
					Enemy enemy_stats = targetedEnemy.GetComponent<Enemy>();
					enemy_stats.speed-= damage;
				}
			}
			since_fired = 0;
			return true;
		}

		protected override void miscUpdate(){
			//add ice explosion animation
		}


	}

}
