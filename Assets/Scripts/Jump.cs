using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 direction;
    bool jump = false;
    public float jumpforce = 300f;
     void Awake()
     {
        rb = GetComponent<Rigidbody2D>();
     }
    void Update()
    {
      if(Input.GetButtonDown("Jump"))
      {
         jump = true;
         Debug.Log("Jump true");
      }
        
    }

    void FixedUpdate()
    {  if (jump)
        {
            direction.y = jumpforce * Time.fixedDeltaTime;
            jump = false;
        }
    }
}

      
      
        




