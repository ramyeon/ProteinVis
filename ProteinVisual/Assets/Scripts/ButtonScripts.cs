using UnityEngine;
using System.Collections;
using UnityEngine.UI;   //Buttons

public class ButtonScripts : MonoBehaviour {
    private EnableModel enableModelScript;
    private AnimateProtein animateProteinScript;
    private GameObject activeKey;
    private GameObject activeProtein;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        activeKey = GameObject.FindWithTag("activeKey");
        activeProtein = GameObject.FindWithTag("activeProtein");
        if(activeKey != null && activeProtein != null)
        {
            animateProteinScript = activeProtein.GetComponent<AnimateProtein>();
            enableModelScript = activeKey.GetComponent<EnableModel>();
        }
    }

    public void onClickStart()
    {
        if (activeProtein != null) {
            Debug.Log("Active protein is not null.");
        }
        animateProteinScript.setActive();
    }

    public void exitAnimation()
    {
        //return initial state of protein icons
        enableModelScript.transform.position = enableModelScript.initKeyPos;
        enableModelScript.isAlive = false;
        animateProteinScript.setActiveFalse();
        activeKey.gameObject.tag = "Untagged";
        activeProtein.gameObject.tag = "Untagged";
        Debug.Log("Exiting");
    }
}
