using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    bool buttonDown = false;
    public static InputManager instance;

    public void ButtonPressed()
    {
        buttonDown = true;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            buttonDown = true;
        }
    }

    public bool IsButtonDown()
    {
        bool temp = buttonDown;
        buttonDown = false;
        return temp;
    }

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

}
