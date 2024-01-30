using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{
    #region public
    //Vitesse de D�placement//
    public float Speed = 10f;
    Rigidbody2D rb;
    bool jump = false;
    public float jumpforce = 300f;
    public int maxjump = 2;
    [SerializeField]
    private float fallMultiplier = 3f;

    #endregion

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();   
    }
  
    // Update is called once per frame
    void Update()
    {
        _direction.x = Input.GetAxisRaw("Horizontal") * Speed;

        if (Input.GetButtonDown("Jump") && nbjump < maxjump)
        {
            jump = true;
            Debug.Log("Jump true");
        }
    }
    void FixedUpdate()
    {
        _direction.y = rb.velocity.y;
       
        if (jump)
        {
            _direction.y = jumpforce * Time.fixedDeltaTime;
            jump = false;
            nbjump++;
        }
        if(rb.velocity.y <0 )
        {
            rb.gravityScale = fallMultiplier;
        }
        else
        {
            rb.gravityScale = 1f;
        }
        rb.velocity = _direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   // si je touche le sol , mon nb de saut repart � z�ro
        if(collision.collider.CompareTag("Sol"))
        {
            nbjump = 0;
        }
    }

    #region 
    [SerializeField]
    private Vector2 _direction;
    private int nbjump = 0;
    #endregion
}





    
       



        

      
      
        
           
        


  



        

        




