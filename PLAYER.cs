using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER : MonoBehaviour
{
    public GameObject groundCheck;
    public float moveSpeed=7f;
    public float acceralation=50f;
    public float jumpSpeed=10f;
    Rigidbody rigidBody;
    float moveX;
    int moveDir;
    bool grounded;
    void Awake(){
        rigidBody= GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        moveDir = (int)Input.GetAxisRaw("Horizontal");
        if(moveDir != 0)
        {
         moveX=Mathf.MoveTowards(moveX,moveDir*moveSpeed,Time.deltaTime*acceralation);}
        else
        {

          moveX=Mathf.MoveTowards(moveX,moveDir*moveSpeed,Time.deltaTime*acceralation*2f);
        }
        grounded=Physics.CheckSphere(groundCheck.transform.position, .2f, LayerMask.GetMask("Ground"));
        if(Input.GetButtonDown("Jump") && grounded){
         Jump();
        }
    }
    void Jump(){
        rigidBody.velocity=new Vector3(rigidBody.velocity.x, jumpSpeed,0);
    }
    void FixedUpdate(){
        if(rigidBody.velocity.y < .75f *jumpSpeed || !Input.GetButton("Jump"))
          rigidBody.velocity += Vector3.up * Physics.gravity.y * Time.fixedDeltaTime *5f;
        rigidBody.velocity=new Vector3(moveX, rigidBody.velocity.y,0);
    }


}
