using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitQuad : MonoBehaviour
{
    [SerializeField]
    public Camera mainCamera;

    void Start()
    {
        Setup();
    }

    void Setup()
    {
        // カメラとQuadの距離
        float distance = Vector3.Distance(mainCamera.transform.position, transform.position);
        // カメラの垂直画角（フィールド・オブ・ビュー）をラジアンに変換
        float verticalFOV = mainCamera.fieldOfView * Mathf.Deg2Rad;
        // 画面の高さを計算
        float quadHeight = 2.0f * distance * Mathf.Tan(verticalFOV / 2.0f);
        // アスペクト比を取得
        float aspectRatio = (float)Screen.width / Screen.height;
        float quadWidth = quadHeight * aspectRatio;

        transform.localScale = new Vector3(quadWidth, quadHeight, 1);
    }
}
