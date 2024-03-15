using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateText : MonoBehaviour
{
    #region public
    [SerializeField]
    private IntVariable FruitsCollected;

    #endregion
    #region unity cycle
    private void Awake()
    {
        Label = GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Label.text = FruitsCollected.m_value.ToString();
    }
    #endregion

    #region private
    private TextMeshProUGUI Label;
    #endregion
}
