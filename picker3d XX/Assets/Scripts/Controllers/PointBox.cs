using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointBox : MonoBehaviour
{
    public TextMeshProUGUI pointText;
    public int boxRandomPoint;

    void Start()
    {
        boxRandomPoint = Random.Range(0, 300);
        pointText.text = boxRandomPoint.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
