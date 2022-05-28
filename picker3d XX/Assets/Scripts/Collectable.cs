using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using DG.Tweening;

public class Collectable : MonoBehaviour
{
    Vector3 startPosition= new Vector3(0,1,0);
    
    // Start is called before the first frame update
    void Start()
    {
        
        
        DOTween.Init();
    }

    // Update is called once per frame
    void Update()
    {
       
          

        if (transform.position.y <= -5)
            destroythis();
    }

    public void EndOfStage()
    {
        if (this.gameObject.tag == "Picked")
        {
            if(gameObject!= null)
            transform.DOMoveZ(transform.position.z + 10, 1).OnComplete(() => destroythis());
        }
    }
    void destroythis()
    {
        transform.position=startPosition;
        
    }

 


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag== "Player")
        {
            PickerController.Instance.PickedAdd(gameObject);
            this.gameObject.tag = "Picked";
        }
        if (other.gameObject.tag == "Cleaner")
        {
            destroythis();
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PickerController.Instance.PickedRemove(gameObject);
        }
    }


    
    
}
