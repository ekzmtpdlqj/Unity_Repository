using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tmpManager : MonoBehaviour
{
    public Light spotLight; // Spot Light
    public Camera mainCamera; // ī�޶�

    void Update()
    {
        // ����Ʈ�� Culling Mask�� �ش��ϴ� ���̾� ����
        spotLight.cullingMask = 1 << LayerMask.NameToLayer("OtherPlayer");

        // ī�޶��� Culling Mask ����
        mainCamera.cullingMask = ~(1 << LayerMask.NameToLayer("YourLayerName"));
    }
}
