using UnityEngine;

public class CustomGizmosDrawer : MonoBehaviour
{
    public Vector2 centerPosition;
    public Vector2 size;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        // ������ε��ĸ�����
        Vector3 topLeft = new Vector3(centerPosition.x - size.x / 2, centerPosition.y + size.y / 2, 0);
        Vector3 topRight = new Vector3(centerPosition.x + size.x / 2, centerPosition.y + size.y / 2, 0);
        Vector3 bottomLeft = new Vector3(centerPosition.x - size.x / 2, centerPosition.y - size.y / 2, 0);
        Vector3 bottomRight = new Vector3(centerPosition.x + size.x / 2, centerPosition.y - size.y / 2, 0);

        // ���ƾ���
        Gizmos.DrawLine(topLeft, topRight);
        Gizmos.DrawLine(topRight, bottomRight);
        Gizmos.DrawLine(bottomRight, bottomLeft);
        Gizmos.DrawLine(bottomLeft, topLeft);
    }

    void OnDrawGizmosSelected()
    {
        // ��Scene��ͼ�л��Ƹ����ߣ��Ա�������ؿ������ε�����λ��
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(centerPosition, 0.1f);
    }
}