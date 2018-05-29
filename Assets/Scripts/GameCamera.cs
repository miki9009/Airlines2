using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour 
{
    public float zoomSpeed = 50;
    public float camSpeed = 50;
    public float minY = 10;
    public float maxY = 40;

    public float axis;
    Vector2 screenSize;
    Vector2 mousePos;

    void Start()
    {
        screenSize.x = Screen.width;
        screenSize.y = Screen.height;
    }

    void Update()
    {
        Zoom();
        CameraPosition();
    }

    void Zoom()
    {
        axis = Input.GetAxis("Mouse ScrollWheel");
        if (axis > 0)
        {
            if(transform.position.y < maxY)
                transform.position += Vector3.up * zoomSpeed * Time.deltaTime;
        }
        else if (axis < 0)
        {
            if(transform.position.y > minY)
                transform.position += Vector3.down * zoomSpeed * Time.deltaTime;
        }
    }

    void CameraPosition()
    {
        mousePos = Input.mousePosition;
        if (mousePos.x < screenSize.x * 0.1f)
        {
            transform.position += Vector3.left * camSpeed * Time.deltaTime;
        }
        if (mousePos.x > screenSize.x * 0.9f)
        {
            transform.position += Vector3.right * camSpeed * Time.deltaTime;
        }
        if (mousePos.y > screenSize.y * 0.9f)
        {
            transform.position += Vector3.forward * camSpeed * Time.deltaTime;
        }
        if (mousePos.y < screenSize.y * 0.1f)
        {
            transform.position += -Vector3.forward * camSpeed * Time.deltaTime;
        }
    }
}
