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
        //assign active protein to UI interface
        activeKey = GameObject.FindWithTag("activeKey");
        activeProtein = GameObject.FindWithTag("activeProtein");
        //make sure models exist
        if (activeKey != null && activeProtein != null)
        {
            animateProteinScript = activeProtein.GetComponent<AnimateProtein>();
            enableModelScript = activeKey.GetComponent<EnableModel>();
        }
        else
        {
            Debug.LogError("None of the protein models are active.");
        }

        //Set animation active
        if (animateProteinScript)
        {
            animateProteinScript.setActive();
        }
    }

    /* Exit button: exit out of animation mode, no 
    button interface */
    public void onClickExit()
    {
        //return initial state of protein icons
        enableModelScript.terminateAnimation();
        animateProteinScript.setActiveFalse();
        activeKey.gameObject.tag = "Untagged";
        activeProtein.gameObject.tag = "Untagged";
        Debug.Log("Exiting");
    }
}
