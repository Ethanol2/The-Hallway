using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Conditions;

public class Door_Generating : MonoBehaviour
{
   
    public bool useFile = true;
    public string filePath;
    public List<doorType> types = new List<doorType>();
    [Space]

    public float numberOfDoors = 20;
    public float[] probabilities;
    public Vector3[] doorTypes;
    [Space]

    public Vector3 startPos = new Vector3(0, 0, 0);
    public GameObject door;
    public GameObject doorsParent;

    [Space]
    public GameObject walls;
    public GameObject singleWall;
    public GameObject wallsParent;
    public GameObject carpet;
    public GameObject ceiling;
    public GameObject pictureFrame;

    [Space]
    public Material[] paintings;

    int[] doorTypeList = new int[8];

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generate()
    {
        if (Menu.s_filePath != "")
        {
            filePath = Menu.s_filePath;
        }

        if (!useFile)
        {
            for (int k = 0; k < probabilities.Length; k++)
            {
                doorType temp = new doorType();
                temp.assign(System.Convert.ToBoolean(doorTypes[k].x), System.Convert.ToBoolean(doorTypes[k].y), System.Convert.ToBoolean(doorTypes[k].z), probabilities[k]);
                types.Add(temp);
            }
        }
        else { this.GetComponent<File_Loading>().openFile(filePath); }

        bool side = false;        
        for (int k = 0; k < numberOfDoors + Menu.s_doorNum; k++)
        {
            Vector3 spawnPos = new Vector3(
                startPos.x + (side? -4 : 4),
                startPos.y,
                startPos.z + (4f * k));

            GameObject Temp = Instantiate(door.transform.gameObject,spawnPos , door.transform.rotation, doorsParent.transform);

            int t = 0;
            float typeGen = Random.Range(0f, 1f);
            for (int l = 0; l < 8; l++)
            {
                if (typeGen < types[l].range.y)
                {
                    t = l;
                    doorTypeList[t]++;
                    break;
                }
            }

            Temp.GetComponent<Door>().setDoor(types[t].Hot, types[t].Noisy, types[t].Safe);
            Temp.transform.localRotation = !side ? Quaternion.Euler(0f, 90f, 0f) : Quaternion.Euler(0f, -90f, 0f);

            Temp.GetComponent<Door>().number = t.ToString();

            if (Random.Range(0, 3) == 2)
            {
                GameObject tempPic = Instantiate(pictureFrame, new Vector3(spawnPos.x * 1.1f, 3f, spawnPos.z + 4f),
                    pictureFrame.transform.rotation, wallsParent.transform);
                int paintingIndex = Random.Range(0, 3);
                pictureFrame.transform.GetChild(0).GetComponent<MeshRenderer>().material = paintings[paintingIndex];

                if (paintingIndex < 2)
                {
                    tempPic.transform.rotation = !side ? Quaternion.Euler(90f, 0f, 0f) : Quaternion.Euler(90f, 0f, 180f);
                }
                else
                {
                    tempPic.transform.rotation = !side ? Quaternion.Euler(0f, 0f, 0f) : Quaternion.Euler(0f, 0f, 180f);
                    tempPic.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                }
            }
            side = !side;
        }

        door.SetActive(false);
        startPos.y += -2.71f;
        startPos.z = -4f;
        for (int k = 0; k < (numberOfDoors + Menu.s_doorNum) + 2; k++)
        {
            Instantiate(carpet.transform.gameObject, new Vector3(startPos.x, -2.8f, startPos.z), walls.transform.rotation, wallsParent.transform);
            Instantiate(ceiling.transform.gameObject, new Vector3(startPos.x, 5.7f, startPos.z), ceiling.transform.rotation, wallsParent.transform);
            startPos.z = 4f * k;

        }
        Instantiate(singleWall, new Vector3(startPos.x, -2.387f, startPos.z - 4f), Quaternion.Euler(new Vector3(0f, -90f, 0f)), wallsParent.transform);
        walls.SetActive(false);
        carpet.SetActive(false);

        Debug.Log(
            "1= " + doorTypeList[0] +
            "; 2= " + doorTypeList[1] +
            "; 3= " + doorTypeList[2] +
            "; 4= " + doorTypeList[3] +
            "; 5= " + doorTypeList[4] +
            "; 6= " + doorTypeList[5] +
            "; 7= " + doorTypeList[6] +
            "; 8= " + doorTypeList[7]);
    }
}
