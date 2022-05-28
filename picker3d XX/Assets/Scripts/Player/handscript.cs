using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class handscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.DORotate(transform.localRotation.eulerAngles + new Vector3(0, 360, 0), 1f);
        }
    }
}
