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
    }

    /* Start button: start animation mode, show
    button interface */
    public void onClickStart()
    {
        //Set animation active
        if (checkActive())
        {
            animateProteinScript.setActive();
        }
    }

    /* Exit button: exit out of animation mode, no 
    button interface */
    public void onClickExit()
    {
        if (checkActive()) {
            //return initial state of protein icons
            activeKey.tag = "Untagged";
            activeProtein.tag = "Untagged";
            animateProteinScript.setActiveFalse();
            enableModelScript.terminateAnimation();
            Debug.Log("Exiting");
        }
    }

    /* check if any groups of proteins are active */
    private bool checkActive() {
        //assign active protein to UI interface
        activeKey = GameObject.FindWithTag("activeKey");
        activeProtein = GameObject.FindWithTag("activeProtein");
        //make sure models exist
        if (activeKey != null && activeProtein != null)
        {
            animateProteinScript = activeProtein.GetComponent<AnimateProtein>();
            enableModelScript = activeKey.GetComponent<EnableModel>();
            return true;
        }
        Debug.LogError("None of the protein models are active.");
        return false;
    }
}
