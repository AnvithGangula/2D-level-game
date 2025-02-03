using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private float movement;
    public Rigidbody2D rb;
    public float moveSpeed=5f;
    public float jumpHeight=4f;
    public bool facingRight = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        if (movement<0 && facingRight){
            transform.eulerAngles = new Vector3(0f,-180f,0f);
            facingRight=false;
        }
        else if (movement>0 && facingRight == false){
            transform.eulerAngles = new Vector3(0f,0f,0f);
            facingRight=true;
        }
        
    }
    private void FixedUpdate() {
        transform.position += new Vector3(movement,0f,0f)*Time.fixedDeltaTime*moveSpeed;
        if (Input.GetKey(KeyCode.Space)){
            Jump();
         }

    }

    void Jump(){
        rb.AddForce(new Vector2(0f,jumpHeight),ForceMode2D.Impulse);
    }
}

