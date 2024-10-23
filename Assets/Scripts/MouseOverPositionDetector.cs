using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseOverPositionDetector : MonoBehaviour
{
    public Material targetMaterial;
    public Camera mainCamera;

    void Update()
    {
        // マウス位置を取得 (新しいInput System)
        Vector2 screenPos = Mouse.current.position.ReadValue();

        Ray ray = mainCamera.ScreenPointToRay(screenPos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // スクリーン座標をUV座標に変換（0〜1の範囲）
            Vector2 uvPos = new Vector2(screenPos.x / Screen.width, screenPos.y / Screen.height);

            // シェーダーにUV座標を送信
            targetMaterial.SetVector("_MouseOverPosition", uvPos);
        }
    }
}
