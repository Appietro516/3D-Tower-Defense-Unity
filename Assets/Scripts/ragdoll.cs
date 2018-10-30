using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ragdoll : MonoBehaviour {

	public float timer = 0;
	public float existance = 2f;
	public int force;

	private bool impulsed = false;

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime * Time.timeScale;
		if (timer >= existance){
			Destroy(this.gameObject);
		}

	}

	void FixedUpdate(){
		if (!impulsed){
			Vector3 forcevect = new Vector3(Random.Range( -1.0f, 1.0f ) ,force, Random.Range( -1.0f, 1.0f ));
			this.gameObject.GetComponent<Rigidbody>().AddForce(forcevect, ForceMode.Impulse);
			impulsed = true;
		}
   	}
}
