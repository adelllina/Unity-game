using UnityEngine;
using System.Collections;

public class BatteryCollect : MonoBehaviour
{
    public static int charge = 0;
    public Texture2D charge0tex;
    public Texture2D charge1tex;
    public Texture2D charge2tex;
    public Texture2D charge3tex;
    public Texture2D charge4tex;
	// Use this for initialization
	void Start () {
        GetComponent<GUITexture>().enabled = false;
        charge = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (charge == 1)
        {
            GetComponent<GUITexture>().texture = charge1tex;
            GetComponent<GUITexture>().enabled = true;
        }
        else if (charge == 2)
        {
            GetComponent<GUITexture>().texture = charge2tex;
           // guiTexture.enabled = true;
        }
        else if (charge == 3)
        {
            GetComponent<GUITexture>().texture = charge3tex;
           // guiTexture.enabled = true;
        }
        else if (charge >= 4)
        {
            GetComponent<GUITexture>().texture = charge4tex;
           // guiTexture.enabled = true;
        }
        else
        {
            GetComponent<GUITexture>().texture = charge0tex;
            //guiTexture.enabled = true;
        }
	}
}
