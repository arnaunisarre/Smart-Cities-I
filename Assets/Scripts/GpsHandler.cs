﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GpsHandler : MonoBehaviour
{
    [SerializeField]
    Text latitudeText;

    [SerializeField]
    Text longitudeText;

    public float latUser;
    public float lonUser;

    IEnumerator Start()
    {

        latUser = 0.0f;
        lonUser = 0.0f;

        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
            yield break;

        // Start service before querying location
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            print("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            yield break;
        }
        else
        {
            // Access granted and location value could be retrieved
            print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
        }

        // Stop service if there is no need to query location updates continuously
        //Input.location.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        latitudeText.GetComponent<Text>().text = Input.location.lastData.latitude.ToString();

        latUser = Input.location.lastData.latitude;

        longitudeText.GetComponent<Text>().text = Input.location.lastData.longitude.ToString();

        lonUser = Input.location.lastData.longitude;


    }
}
