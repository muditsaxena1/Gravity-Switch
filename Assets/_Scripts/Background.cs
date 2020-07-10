using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public UnityEngine.UI.RawImage img;

    private Texture2D backgroundTexture;
    [SerializeField] [Range(0f, 1f)] float lerptime;
    [SerializeField] Color[] colorsList;
    Color cTop;
    Color cBottom;
    int index;
    float t;
    int len;

    Color deltaTop;
    Color deltaBottom;

    void Start()
    {
        len = colorsList.Length;
        cTop = colorsList[0];
        cBottom = colorsList[1];
        index = 0;
        t = 0;

        deltaTop = Color.Lerp(colorsList[0], colorsList[1], lerptime) - colorsList[0];
        deltaBottom = Color.Lerp(colorsList[1], colorsList[2], lerptime) - colorsList[1];

        backgroundTexture = new Texture2D(1, 2);
        backgroundTexture.wrapMode = TextureWrapMode.Clamp;
        backgroundTexture.filterMode = FilterMode.Bilinear;
    }


    void FixedUpdate()
    {
        if (t >= 0.9)
        {
            index++;
            cTop = colorsList[(index) % len];
            cBottom = colorsList[(index + 1) % len];
            deltaTop = Color.Lerp(colorsList[(index) % len], colorsList[(index + 1) % len], lerptime) - colorsList[(index) % len];
            deltaBottom = Color.Lerp(colorsList[(index + 1) % len], colorsList[(index + 2) % len], lerptime) - colorsList[(index + 1) % len];
            t = 0;
        }
        else
        {
            cTop = cTop + deltaTop;
            cBottom = cBottom + deltaBottom;
            t += lerptime;
        }

        SetTexture();
    }


    void SetTexture()
    {
        backgroundTexture.SetPixels(new Color[] { cTop, cBottom });
        backgroundTexture.Apply();
        img.texture = backgroundTexture;
    }

}

