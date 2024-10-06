using UnityEngine;

public class CustomGizmosDrawer : MonoBehaviour
{
    public Vector2 centerPosition;
    public Vector2 size;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        // 计算矩形的四个顶点
        Vector3 topLeft = new Vector3(centerPosition.x - size.x / 2, centerPosition.y + size.y / 2, 0);
        Vector3 topRight = new Vector3(centerPosition.x + size.x / 2, centerPosition.y + size.y / 2, 0);
        Vector3 bottomLeft = new Vector3(centerPosition.x - size.x / 2, centerPosition.y - size.y / 2, 0);
        Vector3 bottomRight = new Vector3(centerPosition.x + size.x / 2, centerPosition.y - size.y / 2, 0);

        // 绘制矩形
        Gizmos.DrawLine(topLeft, topRight);
        Gizmos.DrawLine(topRight, bottomRight);
        Gizmos.DrawLine(bottomRight, bottomLeft);
        Gizmos.DrawLine(bottomLeft, topLeft);
    }

    void OnDrawGizmosSelected()
    {
        // 在Scene视图中绘制辅助线，以便更清晰地看到矩形的中心位置
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(centerPosition, 0.1f);
    }
}