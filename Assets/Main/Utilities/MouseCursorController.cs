using UnityEngine;

public class MouseCursorController : MonoBehaviour
{
    public Texture2D mouseDownCursor; // 鼠标按下时显示的自定义图标
    public Texture2D mouseUpCursor; // 鼠标抬起时显示的自定义图标

    void Start()
    {
        Cursor.SetCursor(mouseUpCursor, Vector2.zero, CursorMode.Auto); // 设置初始的鼠标图标为抬起时的图标
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 检测鼠标左键按下
        {
            if (mouseDownCursor != null)
            {
                Cursor.SetCursor(mouseDownCursor, Vector2.zero, CursorMode.Auto); // 切换到按下时的自定义图标
            }
        }

        if (Input.GetMouseButtonUp(0)) // 检测鼠标左键抬起
        {
            if (mouseUpCursor != null)
            {
                Cursor.SetCursor(mouseUpCursor, Vector2.zero, CursorMode.Auto); // 切换回抬起时的自定义图标
            }
        }
    }
}