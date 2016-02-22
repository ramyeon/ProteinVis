using UnityEngine;
using UnityEngine.UI;      //Use button
using UnityEngine.EventSystems;// Required when using Event data.
using System.Collections;

public class AnimateProtein : MonoBehaviour {
    //Protein models
    private Transform key;
    private Transform host;

    //Keep track of animation
    private bool animeActive;
    private bool animationInitialized;
    private Vector3 KEYINITPOS;
    private Vector3 HOSTINITPOS;
    private float[] counter;
	private Vector3[] route;
	private int currPoint;
	private Vector3[] initials;
	private float speedUp;
	private float speedLeft;

	// Use this for initialization
	void Start () {
		animeActive = false;
        animationInitialized = false;
		counter = new float[4]{0.0f,0.0f,0.0f,0.0f};
		initials = new Vector3[4];
		route = new Vector3[4];
		currPoint = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (animeActive) {
            if (!animationInitialized)
                initializeAnimation();
            else
                translateKey();
        }
    }

    private void translateKey() {
		if (counter [currPoint] < 1.0f) {
			key.position = Vector3.Lerp (initials[currPoint], route [currPoint], counter [currPoint]);
			counter [currPoint] += Time.deltaTime * (float).5;
			randRotate();
		} else {
			if(currPoint < 3)
			currPoint++;
		}
    }

	private void randRotate(){
		if (Random.Range (0, 50) == 42) {
			speedUp = Random.Range(-30.0f,30.0f);
			speedLeft = Random.Range(-30.0f,30.0f);
		}
		key.Rotate (Vector3.up, speedUp * Time.deltaTime);
		key.Rotate (Vector3.left, speedLeft * Time.deltaTime);
	}

	private void initializeAnimation () {
        Debug.Log("Animation initialized.");
        key = transform.GetChild(0);
        host = transform.GetChild(1);

        KEYINITPOS = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 4.0f, Screen.height / 2.0f, 500));
		HOSTINITPOS = Camera.main.ScreenToWorldPoint(new Vector3(3.0f * Screen.width / 4.0f, 3.0f * Screen.height / 4.0f, 400));
		key.transform.position = KEYINITPOS;
        host.transform.position = HOSTINITPOS;

		for (int i = 0; i < 4; i++) {
			route[i] = HOSTINITPOS;
		}
		route [0] [0] = route [0] [0] * 1.5f;
		route [1] [1] = route [1] [1] * 1.5f;
		route [2] [0] = route [2] [0] * -0.5f;
		Debug.Log (route[0][0] +" "+ route[0][1] + " " + route[0][2]);
		Debug.Log (route[1][0] +" "+ route[1][1] + " " + route[1][2]);
		Debug.Log (route[2][0] +" "+ route[2][1] + " " + route[2][2]);
		Debug.Log (route[3][0] +" "+ route[3][1] + " " + route[3][2]);
		Debug.Log ("\n");
		initials [0] = KEYINITPOS;
		for (int i = 1; i < 4; i++) {
			initials[i] = route[i-1];
		}

        animationInitialized = true;
	}

    public void setActiveFalse() {
        animeActive = false;
    }
	
	public void setActive () {
		animeActive = true;
        animationInitialized = false;
		for(int i = 0; i < 4; i++){
			counter[i] = 0.0f;
		}
		currPoint = 0;
        if (animeActive)
        {
            Debug.Log("Animation is turned on.");
        }
    }
}
