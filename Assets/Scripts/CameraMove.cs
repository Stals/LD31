using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
    public float Boundary = 50;
    public float speed = 5;

    private float ScreenWidth;
    private float ScreenHeight;

    void Start()
    {
        ScreenWidth = Screen.width;
        ScreenHeight = Screen.height;
    }

    void Update()
    {
        Vector3 newPosition = transform.position;        

        if (Input.mousePosition.x > ScreenWidth - Boundary)
        {
            newPosition.x += speed * Time.deltaTime;
        }

        if (Input.mousePosition.x < 0 + Boundary)
        {
            newPosition.x -= speed * Time.deltaTime;
        }

        if (Input.mousePosition.y > ScreenHeight - Boundary)
        {
            newPosition.y += speed * Time.deltaTime;
        }

        if (Input.mousePosition.y < 0 + Boundary)
        {
            newPosition.y -= speed * Time.deltaTime;
        }

        transform.position = newPosition;
    }
}
