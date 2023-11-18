using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    CharacterController cc;
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] float gravity = -15f;
    float yJump = 0.0f;
    float Rrotation;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal_Input = Input.GetAxis("Horizontal");
        float xSpeed = horizontal_Input * movementSpeed * Time.deltaTime;

        if (cc.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                yJump = 10f;
            }
            else
                yJump = -10f;
        }

        yJump += gravity * Time.deltaTime;
        cc.Move(new Vector3(0, yJump * Time.deltaTime , xSpeed));

        if (xSpeed > 0.01f)
        {
            //transform.rotation = Quaternion.Euler(0, 0, 0);
            Rrotation = 0f;
        }
        if (xSpeed < -0.01f)
        {
           // transform.rotation = Quaternion.Euler(0, 180f, 0);
            Rrotation = 180f;
        }
        Vector3 rot = transform.rotation.eulerAngles;
        rot.y = Mathf.Lerp(rot.y,Rrotation,5f * Time.deltaTime);
        transform.rotation = Quaternion.Euler(rot);
        
    }
}
