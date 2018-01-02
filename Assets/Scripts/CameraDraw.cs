using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDraw : MonoBehaviour {

    public Camera cam;
    

	// Use this for initialization
	void Start () {

        cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        /*
        if (!Input.GetMouseButton(0))
        {
            return;
        }

        RaycastHit hit; 
        if(!Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
        {
            return;
        }

        Renderer rend = hit.transform.GetComponent<Renderer>();
        MeshCollider meshCollider = hit.collider as MeshCollider;

        if(rend == null || rend.sharedMaterial == null || 
            rend.sharedMaterial.mainTexture == null || meshCollider == null)
        {
            return; 
        }

        Texture2D tex = rend.material.mainTexture as Texture2D;

        // hit.texturecoord antaa arvon 0-1:n välillä hiiren sijainnin kuvan päällä
        Vector2 pixelUV = hit.textureCoord;
        // Kerrotaan x ja y komponentti leveydell äja korkeudella niin saadaan aito
        // pixelisijainti float arvona esim. 34,274 ja 57,495 pixeliä
        pixelUV.x *= tex.width;
        pixelUV.y *= tex.height;
        // Muutetaan floatit intiksi, jolloin saadan 34 ja 57 jotka on maalattavat
        // pikselikoordinaatit
        tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, Color.clear);
        tex.Apply();
        */
    } // UPDATE LOPPUU TÄHÄN

    // Tämä metodi palautaa joko true tai false riippuen siitä osutaanko mihin pikselii
    public bool DrawRay(Vector3 rayPosition)
    {
        RaycastHit hit;
        if (!Physics.Raycast(cam.ScreenPointToRay(cam.WorldToScreenPoint(rayPosition)), out hit))
        {
            return false;
        }

        Renderer rend = hit.transform.GetComponent<Renderer>();
        MeshCollider meshCollider = hit.collider as MeshCollider;

        if (rend == null || rend.sharedMaterial == null ||
            rend.sharedMaterial.mainTexture == null || meshCollider == null)
        {
            Debug.Log("jotain on pielessä. Varmasti tulee virheilmoitus");
            return false;
        }

        Texture2D tex = rend.material.mainTexture as Texture2D;

        // hit.texturecoord antaa arvon 0-1:n välillä hiiren sijainnin kuvan päällä
        Vector2 pixelUV = hit.textureCoord;
        // Kerrotaan x ja y komponentti leveydell äja korkeudella niin saadaan aito
        // pixelisijainti float arvona esim. 34,274 ja 57,495 pixeliä
        pixelUV.x *= tex.width;
        pixelUV.y *= tex.height;
        if(tex.GetPixel((int)pixelUV.x, (int)pixelUV.y).a == 1.0)
        {
            return true;

        }else
        {
            return false; 
        }
    }

    public bool PaintRay(Vector3 ammoray, GameObject ammo, int radius)
    {
        RaycastHit hit;
        if (!Physics.Raycast(cam.ScreenPointToRay(cam.WorldToScreenPoint(ammoray)), out hit))
        {
            Destroy(ammo);
            return false;
        }

        Renderer rend = hit.transform.GetComponent<Renderer>();
        MeshCollider meshCollider = hit.collider as MeshCollider;

        if (rend == null || rend.sharedMaterial == null ||
            rend.sharedMaterial.mainTexture == null || meshCollider == null)
        {
            Debug.Log("jotain on pielessä. Varmasti tulee virheilmoitus");
            return false;
        }

        Texture2D tex = rend.material.mainTexture as Texture2D;

        // hit.texturecoord antaa arvon 0-1:n välillä hiiren sijainnin kuvan päällä
        Vector2 pixelUV = hit.textureCoord;
        // Kerrotaan x ja y komponentti leveydell äja korkeudella niin saadaan aito
        // pixelisijainti float arvona esim. 34,274 ja 57,495 pixeliä
        pixelUV.x *= tex.width;
        pixelUV.y *= tex.height;
        if (tex.GetPixel((int)pixelUV.x, (int)pixelUV.y).a == 1.0)
        {

            Circle(tex, (int)pixelUV.x, (int)pixelUV.y, radius, Color.clear);
            tex.Apply();
            return true;

        }
        else
        {
            return false;
        }

    }
    public void Circle(Texture2D tex, int cx, int cy, int r, Color col)
    {
        int x, y, px, nx, py, ny, d;

        for (x = 0; x <= r; x++)
        {
            d = (int)Mathf.Ceil(Mathf.Sqrt(r * r - x * x));
            for (y = 0; y <= d; y++)
            {
                px = cx + x;
                nx = cx - x;
                py = cy + y;
                ny = cy - y;

                tex.SetPixel(px, py, col);
                tex.SetPixel(nx, py, col);

                tex.SetPixel(px, ny, col);
                tex.SetPixel(nx, ny, col);

            }
        }
    }
}
