using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Console : MonoBehaviour
{
    public GameObject console;
    public TMP_InputField input;
    public GameObject inputfield;
    private bool visible = false;
    public Camera mainCamera;
    public GameObject ball;
    public TMP_Text text;
    public GameObject textfield;
    // Start is called before the first frame update
    void Start()
    {
        console.SetActive(visible);
        inputfield.SetActive(visible);
        textfield.SetActive(visible);
    }

    private void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == console.gameObject)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleConsole();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Close();
        }
    }
    void Close()
    {
        visible = false;
        console.SetActive(visible);
        Time.timeScale = 1f;
        inputfield.SetActive(visible);
        textfield.SetActive(visible);
    }
    // Update is called once per frame
    void ToggleConsole()
    {
        visible = true;
        console.SetActive(visible);
        inputfield.SetActive(visible);
        textfield.SetActive(visible);
        Time.timeScale = 0f;
        input.onEndEdit.AddListener(delegate { OnInput(); });
    }

    public void OnInput()
    {
        string checkinput = input.text;
        input.text = "";

        if(checkinput.StartsWith("/background"))
        {
            string colour = checkinput.Substring(12).Trim();
            text.text = "Background Changed to: " + colour;
            BackgroundColor(colour);
        }

        if (checkinput.StartsWith("/ball"))
        {
            string colour = checkinput.Substring(6).Trim();
            text.text = "Ball Changed to: " + colour;
            BallColor(colour);
        }
    }
    void BackgroundColor(string colour)
    {
        Color colourName;
        if(ColorUtility.TryParseHtmlString(colour, out colourName))
        {
            mainCamera.backgroundColor = colourName;
        }
        else
        {
            text.text = "Colour is not valid";
        }
    }

    void BallColor(string colour)
    {
        Color colourName;
        if (ColorUtility.TryParseHtmlString(colour, out colourName))
        {
            ball.GetComponentInChildren<Renderer>().material.color = colourName;
        }
        else
        {
            text.text = "Colour is not valid";
        }
    }
}
