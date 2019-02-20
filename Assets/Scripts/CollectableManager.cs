using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectableManager : MonoBehaviour
{

    private static int collected;

    [SerializeField] private GameObject[] door;
    [SerializeField] private int[] requirement;

    // Start is called before the first frame update
    void Start()
    {
        collected = 0;
    }

    // Update is called once per frame
    public void increase()
    {
        collected++;
        for(int i=0; i<door.Length; i++)
        {
            if(collected == requirement[i])
            {
                print("Door opening");
                door[i].GetComponent<Animation>().Play("DoorLift");
            }
        }

        if(collected == 15)
            SceneManager.LoadScene("Game");
    }
}
