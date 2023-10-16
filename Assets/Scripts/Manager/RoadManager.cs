using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] float offset = 40f;
    [SerializeField] List<GameObject> roads;
    public static Action roadCallback;

    public void Start()
    {
        roadCallback = NewPosition; // 함수 주소를 넣는다
    }


    void Update()
    {
        for (int i = 0; i < roads.Count; i++)
        {
            roads[i].transform.Translate(Vector3.back * speed * Time.deltaTime);

        }       
    }


    public void NewPosition()
    {
        GameObject firstRoad = roads[0];

        roads.Remove(roads[0]);

        float newZ = roads[roads.Count-1].transform.position.z + offset;

        firstRoad.transform.position = new Vector3(0,0, newZ);

        roads.Add(firstRoad);

    }




}



