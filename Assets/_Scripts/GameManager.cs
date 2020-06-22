using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    AreaEffector2D areaEffector;
    public float startingAngle;
    public bool gameOn = false;
    public static GameManager instance;
    InputManager inputManager;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        areaEffector = GetComponent<AreaEffector2D>();
        areaEffector.forceAngle = startingAngle;
        inputManager = InputManager.instance;
    }

    private void FixedUpdate()
    {
        if (inputManager.IsButtonDown())
        {
            areaEffector.forceAngle = (areaEffector.forceAngle + 270) % 360;
        }
    }

}
