using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target; // 따라갈 대상 오브젝트의 Transform
    Camera cam;
    Vector3 dis;

    bool nowDiscovering = false;
    int otherPlayerLayer = 8;   // 상대 플레이어 레이어

    void Start()
    {
        cam = GetComponent<Camera>();

        dis = new Vector3(0, 0, -15);
    }

    void Update()
    {
        // 상대 플레이어를 발견
        if(target.GetComponent<Player>().isDiscovering 
            && !nowDiscovering)
        {
            nowDiscovering = true;
            ActiveOtherPlayerLayer();
        }

        // 상대 플레이어 시야에서 벗어남
        if (!target.GetComponent<Player>().isDiscovering
            && nowDiscovering)
        {
            nowDiscovering = false;
            UnactiveOtherPlayerLayer();
        }
    }

    void LateUpdate()
    {
        if (target != null)
        {
            // 카메라 위치 설정
            this.transform.position = target.position + dis;

            // 카메라가 항상 대상 오브젝트를 바라보게끔 회전 설정
            transform.LookAt(target);
        }
    }
    
    void ActiveOtherPlayerLayer()   // 상대 플레이어 보이게 하기
    {
        // 현재 culling mask 가져오기
        int currentCullingMask = cam.cullingMask;

        // 레이어를 활성화하기 위해 해당 레이어의 비트를 OR 연산으로 추가
        currentCullingMask |= 1 << otherPlayerLayer;

        // 업데이트된 culling mask 적용
        cam.cullingMask = currentCullingMask;
    }

    void UnactiveOtherPlayerLayer() // 상대 플레이어 보이지 않게 하기
    {
        // 현재 culling mask 가져오기
        int currentCullingMask = cam.cullingMask;

        // 현재 레이어에서 OtherPlayer 레이어 제거
        currentCullingMask &= ~(1 << otherPlayerLayer);

        cam.cullingMask = currentCullingMask;
    }
}
