using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MouseLook : MonoBehaviour
{
    [SerializeField] float mouseSenstivity = 100f;
    [SerializeField] Transform player;
  
    float xRotation;

   
    // Start is called before the first frame update
    void Start()
    {
        xRotation = transform.localRotation.x;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        

        float mouseX = CrossPlatformInputManager.GetAxis("Mouse X") * mouseSenstivity * Time.deltaTime;
        float mouseY = CrossPlatformInputManager.GetAxis("Mouse Y") * mouseSenstivity * Time.deltaTime;

        xRotation += mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        player.Rotate(Vector3.up * mouseX);
    }




}
