using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    /*public GameObject fishOriginal;
    public GameObject fishClone;
    public GameObject currentFish;*/
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        List<Vector2> fishQueueList = new List<Vector2>();
        Vector2 firstPosition = new Vector2(0, 0);
        float positionSize = 8f;
        for (int i = 0; i < 5; i++)
        {
            fishQueueList.Add(firstPosition + new Vector2(-1, 0) * positionSize);
        }
        //SpawnFish(7);
    }

    // Update is called once per frame
   

    /*void SpawnFish(int fishNumber)
    {
        for (i = 0; i <= fishNumber; i++)
        {
            fishClone = Instantiate(fishOriginal, new Vector2(i * 1.5f, fishOriginal.transform.position.y), Quaternion.identity);
        }
    }*/

    void Update()
    {

    }
}
