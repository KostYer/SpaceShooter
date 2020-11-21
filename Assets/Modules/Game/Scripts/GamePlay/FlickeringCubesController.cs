using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringCubesController : MonoBehaviour
{
    [SerializeField] Material material;
    Color colorRed;
    Color colorBlack;
    float colorDuration = 1.5f;
    float intensity =  10f;
    void Start()
    {
        colorRed = new Color(191, 0, 0);
        colorBlack  = new Color(0, 0, 0);
        material.EnableKeyword("_EMISSION");
    }

    private void Update()
    {
       
      
        

        float emission = Mathf.PingPong(Time.time * 0.3f, 1.0f);
      

        material.SetColor("_EmissionColor", Color.red * emission);
    }


    [ContextMenu("ChangeColor")]
    private void ChangeColor()
    {
      //  Color colour = material.GetColor("_EmissionColor"); 
      //colour *= 4.0f; //  4X brighter
        material.SetColor("_EmissionColor", colorBlack);
    }

    // Update is called once per frame


    [ContextMenu("ChangeColorCoroutine")]

    void ColorChangeCoroutine()
    {
        StartCoroutine(nameof(ChangeColor1)); 
    }
    IEnumerator ChangeColor1()
    {
        float t = 0;

        while (t < colorDuration)
        {
            t += Time.deltaTime;
            material.color = Color.Lerp(material.GetColor("_EmissionColor"), colorRed, t / colorDuration);
            yield return null;
        }
    }
}
