using UnityEngine;
using System.Collections;

public class ClearOtherModels : MonoBehaviour {

    private AnimateProtein[] proteins;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (proteins == null)
        {
            proteins = FindObjectsOfType<AnimateProtein>();
            Debug.Log("protein array length is " + proteins.Length);
        }
    }

    public void SetActive (bool isActive)
    {
        foreach (AnimateProtein protein in proteins)
        {
            if (protein.gameObject.tag != "activeProtein" && protein.gameObject.tag != "activeKey")
            {
                protein.gameObject.SetActive(isActive);
            }
        }
    }
}
