using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveLight : MonoBehaviour
{
    // Light intensity
    public float maxIntensity;
    public float minIntensity;
    public float blinkingSpeed = 2f;
    private Light _light;
    private void Start()
    {
        _light = GetComponent<Light>();
    }

    private void Update()
    {
        _light.intensity = Mathf.PingPong(Time.time * blinkingSpeed, maxIntensity);
    }
}
