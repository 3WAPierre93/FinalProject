using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    #region public
    //Vitesse de Déplacement//
    public float Speed = 5f;
    #endregion
    void Awake()
    {
        _rgbd = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
        
    {
        _direction.x = Input.GetAxisRaw("Horizontal") * Speed;
        
    }
    void FixedUpdate()
    {
        _rgbd.velocity = _direction;
    }
    #region private
    
    private Rigidbody2D _rgbd;
    private Vector2 _direction;
    #endregion
}



