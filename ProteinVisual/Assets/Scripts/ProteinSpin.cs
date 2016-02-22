using UnityEngine;
using System.Collections;

public class ProteinSpin : MonoBehaviour {
	float speedUp = 0;
	float speedLeft = 0;
	bool up = true;
	bool left = false;

	// Use this for initialization
	void Start () {
		speedUp = Random.Range (-20f, 20f);
		speedLeft = Random.Range (-20f, 20f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Random.Range (0, 200) == 42) {
			up = !up;
			left = !left;
			if(up)
				speedUp = Random.Range(-20f, 20f);
			if(left)
				speedLeft = Random.Range(-20f, 20f);
		}
		if(speedLeft > -1 && speedLeft < 1)
			speedLeft = 0;
		if(speedUp > -1 && speedUp < 1)
			speedUp = 0;
		if (speedUp == 0 && speedLeft == 0) {
			speedUp = Random.Range (-20f, 20f);
			speedUp = Random.Range (-20f, 20f);
		}
		if (up && speedLeft != 0) {
			if(speedLeft < -1)
				speedLeft = speedLeft + (float)0.1;
			if(speedLeft > 1)
				speedLeft = speedLeft - (float)0.1;
		}
		if (left && speedUp != 0) {
			if(speedUp < -1)
				speedUp = speedUp + (float)0.1;
			if(speedUp > 1)
				speedUp = speedUp - (float)0.1;
		}
		transform.Rotate (Vector3.up, speedUp * Time.deltaTime);
		transform.Rotate (Vector3.left, speedLeft * Time.deltaTime);
	}
}
