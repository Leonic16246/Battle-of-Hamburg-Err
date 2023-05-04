using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public float panSpeed = 32;
    public float panBorderThickness = 16;
    public float scrollSpeed = 5;
    public float minY = 10;
    public float maxY = 200;

    public float minX = -50;
    public float maxX = 50;

    public float minZ = -50;
    public float maxZ = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            if (transform.position.z < maxZ)
            {
                transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
            }
            
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            if (transform.position.x > minX)
            {
                transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
            }
            
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            if (transform.position.z > minZ)
            {
                transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
            }
            
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            if (transform.position.x < maxX)
            {
                transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
            }
            
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
        

    }
}
