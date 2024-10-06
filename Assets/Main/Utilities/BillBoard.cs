using UnityEngine;

public class BillBoard : MonoBehaviour
{
    private Camera _cam;
    private void Start()
    {
        _cam = Camera.main;
    }
    private void LateUpdate()
    {
        transform.LookAt(transform.position + _cam.transform.forward);
    }

}
