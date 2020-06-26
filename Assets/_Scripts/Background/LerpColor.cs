using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpColor : MonoBehaviour
{
    MeshRenderer cubeMeshRenderer;
    [SerializeField] [Range(0f, 1f)] float lerptime;
    [SerializeField] Color[] myColors;
    int colorIndex = 0;
    float t = 0f;
    int len;
    
    void Start()
    {
        cubeMeshRenderer = GetComponent<MeshRenderer>();
        len = myColors.Length;
    }

    
    void Update()
    {
        while (true)
        {
            cubeMeshRenderer.material.color = Color.Lerp(cubeMeshRenderer.material.color, myColors[colorIndex], lerptime * Time.deltaTime);
        }
        //cubeMeshRenderer.material.color = Color.Lerp(cubeMeshRenderer.material.color, myColors[colorIndex], lerptime * Time.deltaTime);
        /**t = Mathf.Lerp(t, 1f, lerptime * Time.deltaTime);
        if (t>.9f)
        {
            t = 0f;
            colorIndex++;
            colorIndex = (colorIndex >= len) ? 0 : colorIndex;
        }**/
    }
}
