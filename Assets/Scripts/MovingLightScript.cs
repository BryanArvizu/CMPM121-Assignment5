using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLightScript : MonoBehaviour
{
    private Vector3 initPos;

    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(initPos.x, initPos.y, Mathf.Sin(Time.time) * 4 + initPos.z);
    }
}
