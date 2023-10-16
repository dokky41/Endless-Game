using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] int interval = 2;
    [SerializeField] int createCount = 15;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] Transform createPosition;

    void Start()
    {
        CreateCoin();

    }

    private void CreateCoin()
    {

        for (int i = 0; i < createCount; i += 2)
        {
            GameObject coin = Instantiate(coinPrefab);

            coin.transform.SetParent(createPosition);

            coin.transform.localPosition
                = new Vector3(coin.transform.position.x, coin.transform.position.y, interval * i);
        }
    }

   


}
