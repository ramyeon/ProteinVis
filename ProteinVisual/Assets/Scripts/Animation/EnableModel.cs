using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;   //Control button

public class EnableModel : MonoBehaviour//, IPointerClickHandler
{
	public GameObject model;
    public Button start;
    public Button exit;
	private bool isAlive;
    private bool translateToInitActive;
    private bool translateResetActive;
    private ClearOtherModels clearOtherModelScript;
    private float count = 0.0f;
    private Vector3 initKeyPos;
    private Vector3 currPos;
    public GameObject parent;

    public void Start(){
        //set state
        isAlive = false;
		model.SetActive(isAlive);
        start.gameObject.SetActive(isAlive);
        exit.gameObject.SetActive(isAlive);
        //assign initial model positions
        initKeyPos = transform.position;
    }

    public void Update(){
        model.SetActive(isAlive);

        if (translateToInitActive)
        {
            translateToInit();
        }
        if (translateResetActive) {
            translateReset();
        }

        if (clearOtherModelScript == null) {
            clearOtherModelScript = FindObjectOfType<ClearOtherModels> ();
        }
    }

	private void OnMouseDown() {
        //toggle active
		isAlive = true;
        start.gameObject.SetActive(isAlive);
        exit.gameObject.SetActive(isAlive);

        //initiate proteins to prep animation
        model.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2.0f, 3.0f * Screen.height / 4.0f, 300));
        gameObject.tag = "activeKey";
        parent.tag = "activeProtein";
        Debug.Log("I am alive");

        count = 0.0f;
        translateToInitActive = true;
        clearOtherModelScript.SetActive(false);
    }

    private void translateToInit() {
        if (count < 1.0f)
        {
            transform.position = Vector3.Lerp(initKeyPos, Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2.0f, Screen.height / 4.0f, 200)), count);
            count += 0.1f;
        }
        else {
            translateToInitActive = false;
        }
    }

    private void translateReset()
    {
        if (count < 1.0f)
        {
            Debug.Log("Resetting translation " + count);
            transform.position = Vector3.Lerp(currPos, initKeyPos, count);
            count += 0.1f;
        }
        else
        {
            translateResetActive = false;
        }
    }

    public void terminateAnimation() {
        isAlive = false;

        //turn off parent model
        model.SetActive(isAlive);

        //reset tag
        gameObject.tag = "Untagged";
        parent.tag = "Untagged";

        //reset button
        start.gameObject.SetActive(isAlive);
        exit.gameObject.SetActive(isAlive);

        //reset animation
        count = 0f;
        currPos = transform.position;
        translateResetActive = true;
        Debug.Log("Exit button: reset everything.");
    }
} 