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
    private float counter;

	// Use this for initialization
	void Start () {
		animeActive = false;
        animationInitialized = false;
        counter = 0.0f;
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
        if (counter < 1.0f) {
            key.position = Vector3.Lerp(KEYINITPOS, HOSTINITPOS, counter);
            counter += Time.deltaTime;
        }
    }
	
	private void initializeAnimation () {
        Debug.Log("Animation initialized.");
        key = transform.GetChild(0);
        host = transform.GetChild(1);

        KEYINITPOS = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 4.0f, Screen.height / 2.0f, 300));
        HOSTINITPOS = Camera.main.ScreenToWorldPoint(new Vector3(3.0f * Screen.width / 4.0f, 3.0f * Screen.height / 4.0f, 150));
        key.transform.position = KEYINITPOS;
        host.transform.position = HOSTINITPOS;
        animationInitialized = true;
	}

    public void setActiveFalse() {
        animeActive = false;
    }
	
	public void setActive () {
		animeActive = true;
        animationInitialized = false;
        counter = 0.0f;

        if (animeActive)
        {
            Debug.Log("Animation is turned on.");
        }
    }
}
