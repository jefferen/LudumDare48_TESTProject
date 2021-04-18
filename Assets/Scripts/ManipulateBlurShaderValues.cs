using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulateBlurShaderValues : MonoBehaviour
{
    public Material mat;
    [Range(0,0.003f)]
    public float value;
    string ShaderPropertyName = "Vector1_f69a5508fc7b48999e3dc6ee0133da19";
    bool BlurIsRunning = false;
    void Start()
    {
        mat = GetComponent<SpriteRenderer>().material;
    }
    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space) && !BlurIsRunning) LerpBlur();
    }

    public void LerpBlur()
    {
        float BlurVal = mat.GetFloat(ShaderPropertyName);
        float incrementValue = 0.000003f;
        float endValue = 0.003f;

        if (BlurVal >= 0.001f)       
        {
            incrementValue *= -1;
            endValue = 0;
        }
        StartCoroutine(Blur(incrementValue, endValue));
    }

    public IEnumerator Blur(float increment, float endValue)
    {
        BlurIsRunning = true;
        while (mat.GetFloat(ShaderPropertyName) <= 0.003f && mat.GetFloat(ShaderPropertyName) >= 0)
        {
            float v = mat.GetFloat(ShaderPropertyName);
            mat.SetFloat(ShaderPropertyName, v += increment);
            yield return new WaitForEndOfFrame();
        }
        mat.SetFloat(ShaderPropertyName, endValue);
        BlurIsRunning = false;
    }
}
