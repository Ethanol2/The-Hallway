using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FPS_Select : MonoBehaviour
{
    Door selectedDoor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (checkLooking())
            {
                Menu.safe = selectedDoor.Safe;
                Menu.noise = selectedDoor.Noisy;
                Menu.hot = selectedDoor.Hot;
                Menu.gameDone = true;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                SceneManager.LoadScene("Menu");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            SceneManager.LoadScene("Menu");
        }

        if (Input.GetKeyDown(KeyCode.F12))
        {
            Menu.debug = true;
        }
    }

   bool checkLooking()
    {
        RaycastHit info;
        Physics.Raycast(this.transform.position, this.transform.forward, out info, 5f);

        if (info.collider.gameObject.GetComponentInParent<Transform>().gameObject.GetComponentInParent<Door>() != null && info.collider.gameObject.name == "default")
        {
            selectedDoor = info.collider.gameObject.GetComponentInParent<Transform>().gameObject.GetComponentInParent<Door>();
            return true;
        }
        return false;
    }
}
