using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    [SerializeField] private Transform particle;

    static CollectableManager cManager;

    // Start is called before the first frame update
    void Start()
    {
        if (cManager == null)
            cManager = GameObject.Find("Managers").GetComponent<CollectableManager>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            cManager.increase();
            Instantiate(particle, transform.position, Quaternion.Euler(-90,0,0));
            Destroy(gameObject);
        }
    }
}
