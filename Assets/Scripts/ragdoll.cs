using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ragdoll : MonoBehaviour {

	public float timer = 0;
	public float existance = 2f;
	public int force;
	public int mag = 1;

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
			Vector3 forcevect = new Vector3(Random.Range( -1.0f*mag, 1.0f*mag ) ,force, Random.Range( -1.0f*mag, 1.0f*mag ));
			this.gameObject.GetComponent<Rigidbody>().AddForce(forcevect, ForceMode.Impulse);
			impulsed = true;
		}
   	}
}
