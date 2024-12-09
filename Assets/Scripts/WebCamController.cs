using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebCamController : MonoBehaviour
{
    public Slider slider;
    // 色相が1周する時間 (秒)
    public float cycleDuration = 1f;
    // HDRカラーの強度
    public float intensity = 1f;
    int width = 1920;
    int height = 1080;
    int fps = 30;
    WebCamTexture webcamTexture;

    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        webcamTexture = new WebCamTexture(devices[0].name, this.width, this.height, this.fps);
        GetComponent<Renderer>().material.mainTexture = webcamTexture;
        GetComponent<Renderer>().material.SetTexture("_Texture", webcamTexture);
        webcamTexture.Play();

        GetComponent<Renderer>().material.SetFloat("_Threshold ", slider.value);
    }

    void Update()
    {
        if (GetComponent<Renderer>().material == null) return;

        // 時間に基づいて色相を計算
        // 0.0～1.0の範囲でループ
        float hue = (Time.time % cycleDuration) / cycleDuration;
        // 彩度を固定
        float saturation = 1f;
        // 明度を固定
        float value = 1f;

        // HSVからRGBに変換
        Color rgbColor = Color.HSVToRGB(hue, saturation, value);
        // HDR強度を適用
        rgbColor *= intensity;

        // マテリアルに色を設定
        GetComponent<Renderer>().material.SetColor("_Color", rgbColor);
    }

    public void SliderValueChanged()
    {
        Debug.Log($"slider.value : {slider.value}");
        GetComponent<Renderer>().material.SetFloat("_Threshold", slider.value);
    }
}