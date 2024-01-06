using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target; // ���� ��� ������Ʈ�� Transform
    Camera cam;
    Vector3 dis;

    bool nowDiscovering = false;
    int otherPlayerLayer = 8;   // ��� �÷��̾� ���̾�

    void Start()
    {
        cam = GetComponent<Camera>();

        dis = new Vector3(0, 0, -15);
    }

    void Update()
    {
        // ��� �÷��̾ �߰�
        if(target.GetComponent<Player>().isDiscovering 
            && !nowDiscovering)
        {
            nowDiscovering = true;
            ActiveOtherPlayerLayer();
        }

        // ��� �÷��̾� �þ߿��� ���
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
            // ī�޶� ��ġ ����
            this.transform.position = target.position + dis;

            // ī�޶� �׻� ��� ������Ʈ�� �ٶ󺸰Բ� ȸ�� ����
            transform.LookAt(target);
        }
    }
    
    void ActiveOtherPlayerLayer()   // ��� �÷��̾� ���̰� �ϱ�
    {
        // ���� culling mask ��������
        int currentCullingMask = cam.cullingMask;

        // ���̾ Ȱ��ȭ�ϱ� ���� �ش� ���̾��� ��Ʈ�� OR �������� �߰�
        currentCullingMask |= 1 << otherPlayerLayer;

        // ������Ʈ�� culling mask ����
        cam.cullingMask = currentCullingMask;
    }

    void UnactiveOtherPlayerLayer() // ��� �÷��̾� ������ �ʰ� �ϱ�
    {
        // ���� culling mask ��������
        int currentCullingMask = cam.cullingMask;

        // ���� ���̾�� OtherPlayer ���̾� ����
        currentCullingMask &= ~(1 << otherPlayerLayer);

        cam.cullingMask = currentCullingMask;
    }
}
