using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] List<GameObject> items;

    // Start is called before the first frame update
    void Start()
    {
        items.Capacity = 10;


    }

    public GameObject CloneItem()
    {
        return items[Random.Range(0, items.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
