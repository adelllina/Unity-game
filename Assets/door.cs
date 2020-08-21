
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]

public class door : MonoBehaviour
{
    private bool doorIsOpen = false;
    private float doorTimer = 0.0f;
    private GameObject currentDoor;
    float doorOpenTime = 3.0f;
    public AudioClip doorOpenSound;
    public AudioClip doorShutSound;
    public AudioClip batteryCollect;
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast (transform.position,transform.forward, out hit,2))
        {
            if (hit.collider.gameObject.tag == "outpostdoor" && doorIsOpen == false)
            {
                if (BatteryCollect.charge >= 4)
                {
                    currentDoor = hit.collider.gameObject;
                    Door(doorOpenSound, true, "dooropen", currentDoor);
                    Component c = GameObject.Find("Battery GUI").GetComponent(typeof(GUITexture));
                    GUITexture g = (GUITexture)c;
                    g.enabled = false;
                }
                else
                {
                    TextHints.message = "Батарейки ищи!";
                    TextHints.textOn = true;
                }
            }

        }
        

        if (doorIsOpen)
        {
            doorTimer += Time.deltaTime;
            if (doorTimer > 3)
            {
                Door(doorShutSound, false, "doorshut", currentDoor);
                doorTimer = 0.0f;
            }
        }
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "outpostdoor" && doorIsOpen == false)
        {
            currentDoor = hit.gameObject;
            Door(doorOpenSound, true, "dooropen", currentDoor);
        }
    }
    void Door(AudioClip aClip, bool openCheck, string animName, GameObject thisDoor)
    {
        GetComponent<AudioSource>().PlayOneShot(aClip);
        doorIsOpen = openCheck;
        thisDoor.transform.parent.GetComponent<Animation>().Play(animName);
    }
}
