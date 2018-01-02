using UnityEngine;
using System.Collections;

public class Colorize : MonoBehaviour
{
    void Start()
    {
        Texture2D texture = new Texture2D(128, 128);
        GetComponent<Renderer>().material.mainTexture = texture;

        for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                Color color = ((x & y) != 0 ? Color.blue : Color.red);
                texture.SetPixel(x, y, color);
            }
        }
        texture.Apply();
    }
}