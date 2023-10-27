using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 75.0f;
    protected GameObject rotatePrefab; 

    protected void Awake()
    {
        rotatePrefab = GameObject.Find("Rotation Prefab");
    }

    protected void OnEnable()
    {
        transform.rotation = Quaternion.Euler
            (
                rotatePrefab.transform.rotation.eulerAngles.x,
                rotatePrefab.transform.rotation.eulerAngles.y,
                rotatePrefab.transform.rotation.eulerAngles.z
            );

    }


    void Update()
    {
        
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }

   


}

