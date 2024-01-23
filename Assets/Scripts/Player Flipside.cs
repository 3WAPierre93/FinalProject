using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerFlipside : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;


    private float horizontalInput;
    private bool facingRight = true;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        SetUpDirectionByRotation();
    }
    private void SetUpDirectionByScale()
    {
        if (horizontalInput < 0 && facingRight || horizontalInput > 0 && !facingRight)
        {
            facingRight = !facingRight;
            Vector3 playerScale= transform.localScale;
            playerScale.x *= -1;
            transform.localScale = playerScale;

        }
    }

    private void SetUpDirectionByComponent()
    {
        if (horizontalInput < 0)

            _spriteRenderer.flipX = true;

        else if (horizontalInput > 0)

            _spriteRenderer.flipX = false;
    }
    private void SetUpDirectionByRotation()
    {
      if (horizontalInput < 0 && facingRight || horizontalInput > 0 && !facingRight)
      {
        facingRight = !facingRight;

        transform.Rotate(new Vector3(0, 180, 0));
      }

    }
}

            
        




