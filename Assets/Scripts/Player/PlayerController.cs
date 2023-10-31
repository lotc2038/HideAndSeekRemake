using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float mouseSensitivity, moveSpeed, jumpForce, rotateSpeed;

    public Transform cameraTransform;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
       // transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSensitivity);


        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 cameraForward = Vector3.Scale(cameraTransform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveDirection = (verticalInput * cameraForward + horizontalInput * cameraTransform.right).normalized;

        // ѕоворачиваем персонаж в соответствии с направлением движени€
        if (moveDirection != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }

        // ѕеремещаем персонаж
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

    }
}
