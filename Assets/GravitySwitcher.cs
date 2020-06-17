using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwitcher : MonoBehaviour
{
    AreaEffector2D areaEffector;
     public bool buttonPressed = false;
    public float startingAngle;

    // Start is called before the first frame update
    void Start()
    {
        areaEffector = GetComponent<AreaEffector2D>();
        areaEffector.forceAngle = startingAngle;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            buttonPressed = true;
        }       
    }

    

    private void FixedUpdate()
    {
        if (buttonPressed)
        {
            buttonPressed = false;
            areaEffector.forceAngle = (areaEffector.forceAngle + 270) % 360;
        }
    }
}
