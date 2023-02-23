using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swayScript : MonoBehaviour
{
    public float swayMultiplier;
    public float smoothness;
    public Rigidbody rb;
    public playerMovement gScript;





public bool bobOffset = true;
public bool bobSway = true;

    public float smooth = 10f;
    public float smoothRot = 12f;
    private void Update()
    {

        float mouseX = Input.GetAxisRaw("Mouse X") * swayMultiplier;
        float mouseY = Input.GetAxisRaw("Mouse Y") * swayMultiplier;

        Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);

         Quaternion targetRotation = rotationX * rotationY;
          BobOffet();
          BobRotation();

        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smoothness * Time.deltaTime);

        transform.localPosition = Vector3.Lerp(transform.localPosition, bobPosition, Time.deltaTime * smooth);
        
       
        transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(bobEulerRotation), Time.deltaTime * smoothRot); 

    }

    public float speedCurve;
    float curveSin { get => Mathf.Sin(speedCurve);}
    float curveCos { get => Mathf.Cos(speedCurve);}

    public Vector3 travelLimit = Vector3.one * 0.025f;
    public Vector3 bobLimit = Vector3.one * 0.01f;

    Vector3 bobPosition;

float horizontalInput;
float verticalInput;
    void BobOffet(){

    horizontalInput = Input.GetAxisRaw("Horizontal");
    verticalInput = Input.GetAxisRaw("Vertical");

    speedCurve += Time.deltaTime * (gScript.grounded ? rb.velocity.magnitude : 1f) + 0.01f;

    if (bobOffset == false) {bobPosition = Vector3.zero; return; }

    bobPosition.x = (curveCos * bobLimit.x * (gScript.grounded ? 1 : 0)) - (horizontalInput * travelLimit.x);

    bobPosition.y = (curveSin * bobLimit.y) - (rb.velocity.y * travelLimit.y);

    bobPosition.z = - (verticalInput * travelLimit.z);
    
    }

    public Vector3 multiplier;
    Vector3 bobEulerRotation;
    void BobRotation(){
        if (bobSway == false){ bobEulerRotation = Vector3.zero; return;}

        bobEulerRotation.x = (horizontalInput + verticalInput != 0 ? multiplier.x * (Mathf.Sin(2 * speedCurve)) :
        multiplier.x * (Mathf.Sin(2 * speedCurve) / 2));

        bobEulerRotation.y = (horizontalInput + verticalInput != 0 ? multiplier.y * curveCos : 0);
        bobEulerRotation.z = (horizontalInput + verticalInput != 0 ? multiplier.z * curveCos * horizontalInput : 0);
    }
}
