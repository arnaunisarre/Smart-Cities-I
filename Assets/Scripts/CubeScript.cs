using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    [SerializeField]
    float lat;
    [SerializeField]
    float lon;

    private float latgps;
    private float longps;

    private GameObject gpsPointer;

    // Start is called before the first frame update
    void Start()
    {
        gpsPointer = GameObject.Find("GpsHandler");
        latgps = gpsPointer.GetComponent<GpsHandler>().latUser;
        longps = gpsPointer.GetComponent<GpsHandler>().lonUser;
        this.gameObject.GetComponent<Renderer>().enabled = false;

        StartCoroutine(HideShow());
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public IEnumerator HideShow()
    {
        yield return new WaitForSeconds(5.0f);
        if (CalcDistance(lat, lon, latgps, longps) <= 20.0f)
        {
            this.gameObject.GetComponent<Renderer>().enabled = true;

        }


    }

    public float CalcDistance(float lat1,float lon1, float lat2, float lon2)
    {
        return 10.0f;
    }

}
