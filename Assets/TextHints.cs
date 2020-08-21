using UnityEngine;
using System.Collections;

public class TextHints : MonoBehaviour {
    public static bool textOn = false;
public static string message ;
private float timer  = 0.0f;
	// Use this for initialization
	void Start () {
        timer = 0.0f;
        textOn = false;
        GetComponent<GUIText>().text = "";
	}
	
	// Update is called once per frame
	void Update () {
        if (textOn)
        {
            GetComponent<GUIText>().enabled = true;
            GetComponent<GUIText>().text = message;
            timer += Time.deltaTime;
        }
        if (timer >= 5.0f)
        {
            textOn = false;
            GetComponent<GUIText>().enabled = false;
            timer = 0.0f;
        }
	}
}
