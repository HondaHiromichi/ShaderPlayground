using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebCamController : MonoBehaviour
{
    int width = 1920;
    int height = 1080;
    int fps = 30;
    WebCamTexture webcamTexture;

    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        webcamTexture = new WebCamTexture(devices[0].name, this.width, this.height, this.fps);
        GetComponent<Renderer> ().material.mainTexture = webcamTexture;
        GetComponent<Renderer> ().material.SetTexture("_Texture", webcamTexture);
        webcamTexture.Play();
    }
}