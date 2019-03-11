using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    private float tileX;
    private float tileY;
    private float lat1 = 41.38885f;
    private float lon1 = 2.195817f;
    private int zoom = 15;
    // Use this for initialization
    IEnumerator Start()
    {
        WorldToTilePos(lon1, lat1, zoom);
        string url =
        "http://a.tile.openstreetmap.org/" + zoom + "/" + Mathf.FloorToInt(tileX) + "/ "+Mathf.FloorToInt(tileY) + ".png";
            WWW www = new WWW(url);
        yield return www;
        Texture2D texture = new Texture2D(2, 2, TextureFormat.ARGB32,
        true);
        www.LoadImageIntoTexture(texture);

        gameObject.GetComponent<Renderer>().material.mainTexture = texture;
        
    }
    public void WorldToTilePos(float lon, float lat, int zoom)
    {
        tileX = (float)((lon + 180.0f) / 360.0f * (1 << zoom));
        tileY = (float)((1.0f - Mathf.Log(Mathf.Tan(lat * Mathf.PI
        / 180.0f) + 1.0f / Mathf.Cos(lat * Mathf.PI / 180.0f)) / Mathf.PI) /
        2.0f * (1 << zoom));
    }
}
