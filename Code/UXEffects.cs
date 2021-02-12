using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UXEffects : MonoBehaviour
{
    struct UI_Transform
    {
        public GameObject element;
        public Vector3 target;
        public Color cTarget;
    }

    List<UI_Transform> moveList = new List<UI_Transform>();
    List<UI_Transform> scaleList = new List<UI_Transform>();
    List<UI_Transform> rotList = new List<UI_Transform>();
    List<UI_Transform> colourList = new List<UI_Transform>();
    public int listCount;

    // Use this for initialization
    void Start()
    {
        listCount = moveList.Count + rotList.Count + scaleList.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if (scaleList.Count > 0)
        {
            for (int k = 0; k < scaleList.Count; k++)
            {
                scaleList[k].element.transform.localScale = Vector3.Lerp(scaleList[k].element.transform.localScale, scaleList[k].target, 0.1f);

                if (Mathf.RoundToInt(scaleList[k].element.transform.localScale.magnitude * 1000f) == Mathf.RoundToInt(scaleList[k].target.magnitude * 1000f))
                {
                    scaleList[k].element.transform.localScale = scaleList[k].target;
                    scaleList.RemoveAt(k);
                }
            }
        }

        if (moveList.Count > 0)
        {
            for (int k = 0; k < moveList.Count; k++)
            {
                moveList[k].element.transform.localPosition = Vector3.Lerp(moveList[k].element.transform.localPosition, moveList[k].target, 0.1f);

                if (moveList[k].element.transform.localPosition == moveList[k].target)
                {                                 
                    moveList[k].element.transform.localPosition = moveList[k].target;
                    moveList.RemoveAt(k);
                }
            }
        }

        if (rotList.Count > 0)
        {
            for (int k = 0; k < rotList.Count; k++)
            {
                rotList[k].element.transform.localRotation = Quaternion.Lerp(rotList[k].element.transform.localRotation, Quaternion.Euler(rotList[k].target), 0.1f);

                if (rotList[k].element.transform.localRotation == Quaternion.Euler(rotList[k].target))
                {
                    rotList[k].element.transform.localRotation = Quaternion.Euler(rotList[k].target);
                    rotList.RemoveAt(k);
                }
            }
        }

        if (colourList.Count > 0)
        {
            for (int k = 0; k <  colourList.Count; k++)
            {
                colourList[k].element.GetComponent<MeshRenderer>().material.color = Color.Lerp(colourList[k].element.GetComponent<MeshRenderer>().material.color, 
                   colourList[k].cTarget, 0.1f);

                if (colourList[k].element.GetComponent<MeshRenderer>().material.color == colourList[k].cTarget)
                {
                    colourList[k].element.GetComponent<MeshRenderer>().material.color = colourList[k].cTarget;
                    colourList.RemoveAt(k);
                }
            }
        }

        listCount = moveList.Count + rotList.Count + scaleList.Count + colourList.Count;

    }

    public void scaleElement(GameObject a_element, Vector3 a_scale)
    {
        for (int k = 0; k < scaleList.Count; k++)
        {
            if (scaleList[k].element == a_element)
            {
                UI_Transform replace = new UI_Transform();
                replace.element = a_element;
                replace.target = a_scale;
                scaleList[k] = replace;
                return;
            }
        }

        UI_Transform temp = new UI_Transform();
        temp.element = a_element;
        temp.target = a_scale;
        scaleList.Add(temp);
        return;
    }

    public void moveElement(GameObject a_element, Vector3 a_position)
    {
        if (moveList.Count > 0)
        {
            for (int k = 0; k < moveList.Count; k++)
            {
                if (moveList[k].element == a_element)
                {
                    UI_Transform replace;
                    replace.element = a_element;
                    replace.target = a_position;
                    moveList[k] = replace = new UI_Transform();
                    return;
                }
            }
        }
        UI_Transform temp = new UI_Transform();
        temp.element = a_element;
        temp.target = a_position;
        moveList.Add(temp);
        return;
    }

    public void rotateElement(GameObject a_element, Vector3 a_rot)
    {
        for (int k = 0; k < rotList.Count; k++)
        {
            if (rotList[k].element == a_element)
            {
                UI_Transform replace = new UI_Transform();
                replace.element = a_element;
                replace.target = a_rot;
                rotList[k] = replace;
                return;
            }
        }

        UI_Transform temp = new UI_Transform();
        temp.element = a_element;
        temp.target = a_rot;
        rotList.Add(temp);
        return;
    }

    public void changeColour(GameObject a_element, Color a_Colour)
    {
        for (int k = 0; k < colourList.Count; k++)
        {
            if (colourList[k].element == a_element)
            {
                UI_Transform replace = new UI_Transform();
                replace.element = a_element;
                replace.cTarget = a_Colour;
                rotList[k] = replace;
                return;
            }
        }

        UI_Transform temp = new UI_Transform();
        temp.element = a_element;
        temp.cTarget = a_Colour;
        rotList.Add(temp);
        return;
    }

}
