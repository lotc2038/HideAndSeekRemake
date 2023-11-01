using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float mouseSensitivity, moveSpeed, jumpForce, rotateSpeed;

    float verticalLookRotation;
    
    //TODO: Сделать передачу никнейма и команды игрока
   

    public GameObject cameraHolder;

    Rigidbody rb;
    PhotonView pv;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        pv = GetComponent<PhotonView>();

    }

    private void Start()
    {
        if (!pv.IsMine)
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
        }
    }

    //TODO: Вынести управление в отдельный метод?
    void Update()
    {
      if(!pv.IsMine) return;

        Look();
        Move();
       
    }

    void Look()
    {
        transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSensitivity);

        verticalLookRotation += Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);

        cameraHolder.transform.localEulerAngles = Vector3.left * verticalLookRotation;
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 cameraForward = Vector3.Scale(cameraHolder.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveDirection = (verticalInput * cameraForward + horizontalInput * cameraHolder.transform.right).normalized;

        // Перемещаем персонаж
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }


 




}
