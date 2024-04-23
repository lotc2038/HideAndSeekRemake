using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpectator : MonoBehaviour
{

    public Camera playerCamera;

    public float moveSpeed;

    public float sensX;
    public float sensY;
    
    public float minY;
    public float maxY;
    
    private float rotX;
    private float rotY;
    
    
    private Rigidbody rb;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {

        rotX += Input.GetAxis("Mouse X") * sensX;
        rotY += Input.GetAxis("Mouse Y") * sensY;
        
        rotY = Mathf.Clamp(rotY, minY, maxY);
        
        transform.rotation = Quaternion.Euler(-rotY, rotX, 0);
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float y = 0;

        if (Input.GetKey(KeyCode.E))
            y = 1;
        else if (Input.GetKey(KeyCode.Q))
            y = -1;

        Vector3 dir = transform.right * x + transform.up * y + transform.forward * z;

        transform.position += dir * moveSpeed * Time.deltaTime;

    }

    void FixedUpdate()
    {
       
    }
}
    

