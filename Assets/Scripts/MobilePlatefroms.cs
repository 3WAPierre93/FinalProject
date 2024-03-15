using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlatefroms : MonoBehaviour
{
    #region Public
    [SerializeField]
    private Transform startPoint;
    [SerializeField]
    private Transform endPoint;

    [SerializeField]
    private float timeToReach = 5f;


    #endregion


    #region Unity Cycle

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lerpPosition = Vector3.Lerp(startPoint.position, endPoint.position, timerMovement / timeToReach );

        transform.position = lerpPosition;
        if (isforward)
        {
          timerMovement += Time.deltaTime; 

            if(timerMovement >= timeToReach)
            {
                isforward = false;
            }
        }
        else
        {
            timerMovement -= Time.deltaTime;

            if(timerMovement <= 0f)
            {
                isforward = true;
            }
        }
    } 

    #endregion

    #region Private
    public float timerMovement = 0f;

    private bool isforward = true;

    #endregion



}
