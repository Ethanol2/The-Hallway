using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public bool Hot = false;
    public bool Noisy = false;
    public bool Safe = false;
    public string number = "1";
    public GameObject numberDisplay;

    public GameObject[] conditions = new GameObject[3];
    public GameObject hotGlow;
    public GameObject doorModel;
    public Material[] doorColors;

    float shakeTimer = 0f;

    public void setDoor(bool a_Hot, bool a_Noisy, bool a_Safe)
    {
        Hot = a_Hot;
        Noisy = a_Noisy;
        Safe = a_Safe;

        //if (!Hot) conditions[0].SetActive(false); else conditions[0].SetActive(true);
        if (Hot){ doorModel.GetComponent<MeshRenderer>().material = doorColors[0]; hotGlow.SetActive(true); } 
        else    { doorModel.GetComponent<MeshRenderer>().material = doorColors[1]; hotGlow.SetActive(false); }
        if (Noisy) this.GetComponent<AudioSource>().Play(); else this.GetComponent<AudioSource>().volume = 0f;
        //if (!Safe) conditions[2].SetActive(false); else conditions[2].SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Menu.debug)
        {
            numberDisplay.SetActive(true);
            numberDisplay.GetComponent<Text>().text = number;
        }
        else
        {
            numberDisplay.SetActive(false);
        }

        if (Noisy)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0f)
            {
                if (doorModel.transform.position == this.transform.position + new Vector3(0f, 0f, 0.1f))
                {
                    doorModel.transform.position = this.transform.position + new Vector3(0f, 0f, -0.1f);
                    shakeTimer = 0.05f;
                }
                else
                {
                    doorModel.transform.position = this.transform.position + new Vector3(0f, 0f, 0.1f);
                    shakeTimer = 0.05f;
                }
            }            
        }
    }

}
