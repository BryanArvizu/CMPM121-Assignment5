using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightScript : MonoBehaviour
{
    private Light light;
    private float intensity;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        intensity = light.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Flashlight"))
        {
            print("Flashlight toggle");
            if(light.intensity == 0)
                light.intensity = intensity;
            else
                light.intensity = 0;
        }
    }
}
