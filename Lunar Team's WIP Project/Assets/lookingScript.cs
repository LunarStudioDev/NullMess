
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookingScript : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;
    public Texture2D cursor;

    float xRotation;
    float yRotation;

    public bool lookEnabled;

    
    void Start()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.ForceSoftware);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        lookEnabled = true;
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if(hasFocus){
            Cursor.SetCursor(cursor, Vector2.zero, CursorMode.ForceSoftware);
            if (Cursor.lockState == CursorLockMode.Locked){
             Cursor.visible = false;
            }
        } else{
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto); 
        }
    }
    private void Update()
    {

        if (lookEnabled){
        float mouseX = Input.GetAxisRaw("Mouse X") * sensX * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensY * Time.deltaTime;
        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0,  yRotation, 0);
        }
        

    }
}
