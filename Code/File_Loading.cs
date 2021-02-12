using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Conditions;

public class File_Loading : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openFile(string a_filePath)
    {
        StreamReader reader = new StreamReader(a_filePath);

        bool startAtSecond = false;
        float minRange = 0f;

        for (int k = 0; k < 9; k++)
        {
            string line = reader.ReadLine();           
            if (startAtSecond)
            {
                string[] values = line.Split('\t');

                doorType temp = new doorType();

                bool m_Hot = values[0] == "Y" ? true : false;
                bool m_Noisy = values[1] == "Y" ? true : false;
                bool m_Safe = values[2] == "Y" ? true : false;

                temp.assign(m_Hot, m_Noisy, m_Safe, float.Parse(values[3]));
                temp.range.x = minRange;
                temp.range.y = minRange = minRange + temp.probability;
                this.GetComponent<Door_Generating>().types.Add(temp);
            }
            startAtSecond = true;
        }

        reader.Close();
    }
}
