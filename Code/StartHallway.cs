using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartHallway : MonoBehaviour
{
    public GameObject spawner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.G))
        {
            spawner.SetActive(true);
            spawner.GetComponent<Door_Generating>().generate();
            this.gameObject.SetActive(false);
        }
    }
}
