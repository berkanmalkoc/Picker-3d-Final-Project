using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       
    }

    public void PlaformMove()
    {
        transform.DOMoveY(-0.2f, 3).OnComplete(()=>PickerController.Instance.StageComplete());
    }
}
