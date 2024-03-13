using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{
    #region public
    //Vitesse de Déplacement//
    public float Speed = 10f;
    Rigidbody2D rb;
    bool jump = false;
    public float jumpforce = 300f;
    public int maxjump = 2;
    [SerializeField]
    private float fallMultiplier = 3f;
    [SerializeField]
    private float radiusdetector = 0.5f;

    [Header("Related GameObject")]
    [SerializeField]
    private GameObject graphics;

    [Header("Ground Detection")]
    [SerializeField]
    private LayerMask groundmask;
    [Header("Ground Detector")]
    [SerializeField]
    private Transform groundDetector;
    #endregion

    #region Cycle Unity
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = graphics.GetComponent<Animator>();
    }
  
    // Update is called once per frame
    void Update()
    {
        _direction.x = Input.GetAxisRaw("Horizontal") * Speed;

        if (Input.GetButtonDown("Jump") && nbjump < maxjump)
        {
            jump = true;
            Debug.Log("Jump true");
            animator.SetBool("Jump", true);
           
        }
        animator.SetFloat("Move X", Mathf.Abs(_direction.x));

        GroundDetector();
        
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
    //Quand le player touche le sol l'anim Jump s'arrête//
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Sol"))
        {
            animator.SetBool("Jump", false);
        }
    }
    private void OnDrawGizmos()
    {
        if (isGrounded)
        {
            
            Gizmos.color = Color.green;
        }
        else 
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawWireSphere(groundDetector.position, radiusdetector);
    }
    #endregion

    #region Ground Detector
    private void GroundDetector()
    {
        // si je touche le sol , mon nb de saut repart à zéro //Quand le player touche le sol l'anim Jump s'arrête//
        Collider2D floorcollider = Physics2D.OverlapCircle(groundDetector.position, radiusdetector, groundmask);

        isGrounded = floorcollider != null;

        if (isGrounded)
        {
            nbjump = 0;
        }
    }
    #endregion

    #region Private
    [SerializeField]
    private Vector2 _direction;
    private int nbjump = 0;
    private Animator animator;
    private bool isGrounded = false;
    #endregion
}
            
       

       
            
         
        

    





            
            
            
        
        
            
            

            




    
       



        

      
      
        
           
        


  



        

        




