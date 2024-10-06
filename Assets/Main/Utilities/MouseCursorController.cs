using UnityEngine;

public class MouseCursorController : MonoBehaviour
{
    public Texture2D mouseDownCursor; // ��갴��ʱ��ʾ���Զ���ͼ��
    public Texture2D mouseUpCursor; // ���̧��ʱ��ʾ���Զ���ͼ��

    void Start()
    {
        Cursor.SetCursor(mouseUpCursor, Vector2.zero, CursorMode.Auto); // ���ó�ʼ�����ͼ��Ϊ̧��ʱ��ͼ��
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // �������������
        {
            if (mouseDownCursor != null)
            {
                Cursor.SetCursor(mouseDownCursor, Vector2.zero, CursorMode.Auto); // �л�������ʱ���Զ���ͼ��
            }
        }

        if (Input.GetMouseButtonUp(0)) // ���������̧��
        {
            if (mouseUpCursor != null)
            {
                Cursor.SetCursor(mouseUpCursor, Vector2.zero, CursorMode.Auto); // �л���̧��ʱ���Զ���ͼ��
            }
        }
    }
}