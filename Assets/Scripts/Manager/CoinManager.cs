using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] int interval = 2;
    [SerializeField] int createCount = 20;
    [SerializeField] float positionX = 3.5f;

    [SerializeField] GameObject coinPrefab;
    [SerializeField] Transform createPosition;


    void Start()
    {

        NewPosition();
        CreateCoin();

    }

    private void CreateCoin()
    {

        for (int i = 0; i < createCount; i ++)
        {
            GameObject coin = Instantiate(coinPrefab);

            coin.transform.SetParent(createPosition);

            coin.transform.localPosition
                = new Vector3(coin.transform.position.x, coin.transform.position.y, interval * i);


        }
    }

        
   
    public void NewPosition()
    {
        createPosition.gameObject.SetActive(true);

        RoadLine roadLine = (RoadLine)Random.Range(-1,2);

        switch(roadLine)
        {
            case RoadLine.LEFT:
                createPosition.localPosition = new Vector3(-positionX, 0, 0);
                break;
            case RoadLine.MIDDLE:
                createPosition.localPosition = Vector3.zero;
                break;
            case RoadLine.RIGHT:
                createPosition.localPosition = new Vector3(positionX, 0, 0);
                break;
                

        }

    }




}
