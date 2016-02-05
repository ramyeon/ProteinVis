using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class EnableModel : MonoBehaviour//, IPointerClickHandler
{
	public GameObject model;
	public bool isAlive = false;
	//RaycastHit hit = new RaycastHit();



	public void Start(){
		print ("Start");
		model.SetActive(isAlive);
	}

	public void Update(){
		/*var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit, 100.0f)) {
			print (hit.collider.tag);
			isAlive = !isAlive;
		}*/
		model.SetActive(isAlive);
	}

	public void OnMouseOver(){
		if (Input.GetMouseButtonDown (0)) {
			isAlive = !isAlive;
		}
	}
	/*public void OnPointerClick(PointerEventData data){
		isAlive = !isAlive;

		model.renderer.enabled = isAlive;
		/*Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
		Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
		
		// Enable rendering:
		foreach (Renderer component in rendererComponents)
		{
			component.enabled = isAlive;
		}
		
		// Enable colliders:
		foreach (Collider component in colliderComponents)
		{
			component.enabled = isAlive;
		}
	}*/
}