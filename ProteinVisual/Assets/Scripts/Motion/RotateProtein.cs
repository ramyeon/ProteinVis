using UnityEngine;
using System.Collections;

public class RotateProtein : MonoBehaviour
{

    int speed;
    float friction;
    float lerpSpeed;
    private float xDeg;
    private float yDeg;
    private Quaternion fromRotation;
    private Quaternion toRotation;
    private MeshRenderer[] meshes;

    void Start() {
        speed = 5;
        lerpSpeed = 5f;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            xDeg -= Input.GetAxis("Mouse X") * speed;
            yDeg += Input.GetAxis("Mouse Y") * speed;
            fromRotation = transform.rotation;
            toRotation = Quaternion.Euler(yDeg, xDeg, 0);
            transform.rotation = Quaternion.Lerp(fromRotation, toRotation, Time.deltaTime * lerpSpeed);
        }

        if (Input.GetMouseButtonDown(0)) {
            meshes = gameObject.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer mesh in meshes)
            {
                Color color = mesh.material.color;
                color.a = 0.25f;
                mesh.material.color = color;
            }
        }

        if (Input.GetMouseButtonUp(0)) {
            meshes = gameObject.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer mesh in meshes)
            {
                Color color = mesh.material.color;
                color.a = 1f;
                mesh.material.color = color;
            }
        }
    }
};

