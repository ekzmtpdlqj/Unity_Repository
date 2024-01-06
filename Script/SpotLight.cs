using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class SpotLight : MonoBehaviour
{
    public string objectTag = "MyObject"; // ���߰��� �ϴ� ������Ʈ �±�
                                          
    void Update()
    {
        // Spot Light�� ���ߴ� �±� ����
        GetComponent<Light>().cullingMask = 1 << LayerMask.NameToLayer(objectTag);
    }
}
