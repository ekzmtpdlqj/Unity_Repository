using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tmpManager : MonoBehaviour
{
    public Light spotLight; // Spot Light
    public Camera mainCamera; // 카메라

    void Update()
    {
        // 라이트의 Culling Mask에 해당하는 레이어 설정
        spotLight.cullingMask = 1 << LayerMask.NameToLayer("OtherPlayer");

        // 카메라의 Culling Mask 설정
        mainCamera.cullingMask = ~(1 << LayerMask.NameToLayer("YourLayerName"));
    }
}
