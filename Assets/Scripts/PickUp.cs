using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    #region public
    [SerializeField]
    private IntVariable fruitCollected;

    [SerializeField]
    private int score = 1;


    #endregion
    #region unity cycle

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            fruitCollected.m_value += score;
            Destroy( gameObject );
        }
    }

    #endregion

}
