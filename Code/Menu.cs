using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject inputField;
    public static string s_filePath = "";
    public static float s_doorNum = 0;
    public static bool gameDone = false;
    public static bool safe = false;
    public static bool hot = false;
    public static bool noise = false;
    public static bool debug = false;

    [Space]
    public GameObject[] categories;
    public GameObject debugText;
    float timer;
    [Space]

    public GameObject hotText;
    public GameObject noiseText;

    public string[] goodHotEnding;
    public string[] badHotEnding;

    public string[] goodNoisyEnding;
    public string[] badNoisyEnding;

    public string[] goodColdEnding;
    public string[] badColdEnding;

    public string[] goodQuietEnding;
    public string[] badQuietEnding;

    // Start is called before the first frame update
    void Start()
    {
        if (gameDone)
        {
            categories[0].SetActive(false);
            categories[1].SetActive(true);

            if (safe)
            {
                if (hot) hotText.GetComponent<Text>().text = goodHotEnding[Random.Range(0, goodHotEnding.Length - 1)];
                else hotText.GetComponent<Text>().text = goodColdEnding[Random.Range(0, goodColdEnding.Length - 1)];

                if (noise) noiseText.GetComponent<Text>().text = goodNoisyEnding[Random.Range(0, goodNoisyEnding.Length - 1)];
                else noiseText.GetComponent<Text>().text = goodQuietEnding[Random.Range(0, goodQuietEnding.Length - 1)];
            }
            else
            {
                if (hot) hotText.GetComponent<Text>().text = badHotEnding[Random.Range(0, badHotEnding.Length - 1)];
                else hotText.GetComponent<Text>().text = badColdEnding[Random.Range(0, badColdEnding.Length - 1)];

                if (noise) noiseText.GetComponent<Text>().text = badNoisyEnding[Random.Range(0, badNoisyEnding.Length - 1)];
                else noiseText.GetComponent<Text>().text = badQuietEnding[Random.Range(0, badQuietEnding.Length - 1)];
            }
        }
        else
        {
            categories[1].SetActive(false);
            categories[0].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {       
        if (timer <= 0f)
        {
            debugText.SetActive(false);
        }
        timer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Return) && categories[0].activeInHierarchy)
        {
            s_filePath = inputField.GetComponent<InputField>().text;
            SceneManager.LoadScene("Hallway");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                s_doorNum++;
            }
            else
            {
                s_doorNum += 10;
            }
            timer = 3f;
            debugText.SetActive(true);
            debugText.GetComponent<Text>().text = "Number_of_doors_" + (s_doorNum + 20).ToString();
        }
        else if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                s_doorNum--;
            }
            else
            {
                s_doorNum -= 10;
            }
            timer = 3f;
            debugText.SetActive(true);
            debugText.GetComponent<Text>().text = "Number_of_doors_" + (s_doorNum + 20).ToString();
        }
    }

    public void resetGame()
    {
        gameDone = false;
        categories[0].SetActive(true);
        categories[1].SetActive(false);
        inputField.GetComponent<InputField>().text = s_filePath;
    }

    public void toggleDebug()
    {
        debug = !debug;
        timer = 3f;
        debugText.SetActive(true);
        if (debug) debugText.GetComponent<Text>().text = "Debug_Mode_ON"; else debugText.GetComponent<Text>().text = "Debug_Mode_OFF";
    }
}
