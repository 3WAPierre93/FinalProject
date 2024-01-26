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
    public bool Jump;
    #endregion

    void Awake()
    {
        _rgbd = GetComponent<Rigidbody2D>();
    }
  
    // Update is called once per frame
    void Update()
        
    {
        _direction.x = Input.GetAxisRaw("Horizontal") * Speed;

        // CODE POUR SAUTER// Quand la touche espace est pressé le joueur doit sauter 
        if (Input.GetButtonDown("Jump"))
             Jump = true;
        else
           Jump = false;
    }
        
    void FixedUpdate()
    {
      

        _rgbd.velocity = _direction;

        //un nouveau vecteur pour la nouvelle vitesse
        Vector2 newVelocity = _direction * Speed * Time.fixedDeltaTime;

        //la vitesse actuelle en y ne change pas, on garde la gravité //Shoutout To Maxens//
        newVelocity.y = _rgbd.velocity.y;

        _rgbd.velocity = newVelocity;

    }


    #region 
    [SerializeField]
    private Rigidbody2D _rgbd;
    private Vector2 _direction;
    #endregion

}
        

        




