using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    public UnityEngine.UI.RawImage img;

    private Texture2D backgroundTexture;
    [SerializeField] [Range(0f, 1f)] float lerptime;
    [SerializeField] Color[] myColorsFirstArray;
    [SerializeField] Color[] myColorsSecondArray;
    Color color1;
     Color color2;
    int colorIndex = 0;
    
    float t = 0f;
    int len;
    

    void Awake()
    {
        //backgroundTexture = new Texture2D(1, 2);
        //backgroundTexture.wrapMode = TextureWrapMode.Clamp;
        //backgroundTexture.filterMode = FilterMode.Bilinear;
        len = myColorsFirstArray.Length ;
        /**for (int i = 0; i < lenFirstArray && i < lenSecondArray; i++)
        {



            backgroundTexture.SetPixels(new Color[] { myColorsFirstArray[i] , myColorsSecondArray[i] });
            backgroundTexture.Apply();
            img.texture = backgroundTexture;
        }**/

    }

   
   /** public void SetColor(Color c1,Color c2)
    {   


        backgroundTexture.SetPixels(new Color[] { c1 ,c2});
        backgroundTexture.Apply();
        img.texture = backgroundTexture;
    }**/

    void Update()
    {
        backgroundTexture = new Texture2D(1, 2);
        backgroundTexture.wrapMode = TextureWrapMode.Clamp;
        backgroundTexture.filterMode = FilterMode.Bilinear;
        color1 = Color.Lerp(myColorsFirstArray[colorIndex], myColorsFirstArray[colorIndex+1], lerptime * Time.deltaTime);
        color2 = Color.Lerp(myColorsSecondArray[colorIndex], myColorsSecondArray[colorIndex+1], lerptime * Time.deltaTime);
        t = Mathf.Lerp(t, 1f, lerptime * Time.deltaTime);
        if (t > .9f)
        {
            t = 0f;
            colorIndex++;
            colorIndex = (colorIndex >= len-2) ? 0 : colorIndex;
        }


        
        backgroundTexture.SetPixels(new Color[] { color1 ,color2});
        backgroundTexture.Apply();
        img.texture = backgroundTexture;

    }

}

