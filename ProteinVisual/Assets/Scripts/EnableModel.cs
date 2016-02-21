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
    private Vector3 initKeyPos;
    private Vector3 initHostPos;
    public GameObject parent;

    public void Start(){
        //set state
        isAlive = false;
		model.SetActive(isAlive);
        start.gameObject.SetActive(isAlive);
        exit.gameObject.SetActive(isAlive);
        //assign initial model positions
        initKeyPos = transform.position;
        initHostPos = model.transform.position;
    }

    public void Update(){
		model.SetActive(isAlive);
    }

	private void OnMouseDown(){
        //toggle active
		isAlive = !isAlive;
        start.gameObject.SetActive(isAlive);
        exit.gameObject.SetActive(isAlive);

        if (isAlive)
        {
            //initiate proteins to prep animation
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 4.0f, Screen.height / 2.0f, 300));
            model.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(3.0f * Screen.width / 4.0f, 3.0f * Screen.height / 4.0f, 150));
            gameObject.tag = "activeKey";
            parent.tag = "activeProtein";
            Debug.Log("I am alive");
        }
        else {
            //return initial state of protein icons
            transform.position = initKeyPos;
            //model.transform.position = initHostPos;
            model.SetActive(isAlive);

            //reset tag
            gameObject.tag = "Untagged";
            parent.tag = "Untagged";
        }
    }

    public void terminateAnimation() {
        isAlive = false;

        //reset position
        transform.position = initKeyPos;
        //turn off parent model
        model.SetActive(isAlive);

        //reset tag
        gameObject.tag = "Untagged";
        parent.tag = "Untagged";

        //reset button
        start.gameObject.SetActive(isAlive);
        exit.gameObject.SetActive(isAlive);
        Debug.Log("Exit button: reset everything.");
    }
} 