using System;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")] 
    
    [SerializeField]  private float mouseSensitivity;
    [SerializeField]  private float moveSpeed;
    [SerializeField]  private float jumpForce;
    [SerializeField]  private float rotateSpeed;
    [SerializeField]  public LayerMask groundLayer;
    private bool isGrounded = true;

    float verticalLookRotation;
    
    
   private Rigidbody rb;
   private PhotonView pv;
   private Camera cameraHolder;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        pv = GetComponent<PhotonView>();
        cameraHolder = GetComponentInChildren<Camera>();

    }

    private void Start()
    {
        if (!pv.IsMine)
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
        }

    }


    
   private void Update()
    {
      if(!pv.IsMine) return;

        Look();
        Move();
        Jump();
    }

   private void Look()
    {
        transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSensitivity);

        verticalLookRotation += Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);

        cameraHolder.transform.localEulerAngles = Vector3.left * verticalLookRotation;
    }

   private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 cameraForward = Vector3.Scale(cameraHolder.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveDirection = (verticalInput * cameraForward + horizontalInput * cameraHolder.transform.right).normalized;

   
        rb.velocity = moveDirection * moveSpeed;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded ==true )
        {
            isGrounded = false;
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }

   private  void OnCollisionEnter(Collision collision)
    {
        if ((groundLayer & 1 << collision.gameObject.layer) != 0)
        {
            isGrounded = true;
        }
    }
    
}
