using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;


public class PickerController : MonoBehaviour
{
    public static PickerController Instance;

    #region Movement
    private float _forwardSpeed;
    private float _xSpeed;
    [SerializeField] GameObject hands;
    private Camera _pickerCamera;
    private Vector3 _mousePos;
    private float _distanceToScreen;
    private Vector3 _cameraOffset;
    public bool Moving;
    bool    Final;
    #endregion

    public Transform rightHand;
    public Transform leftHand;
    

    public List<GameObject> pickedones;
    private Collectable[] collectable;
    


    private void Awake()
    {
        Final = false;
        _pickerCamera = _pickerCamera == null ? Camera.main : _pickerCamera;
        _cameraOffset = _pickerCamera.transform.position - transform.position;
        _forwardSpeed = 6f;
        _xSpeed = 5f;
        Moving = true;
        pickedones = new List<GameObject>();
        Instance = this;
        DOTween.Init();
        hands.SetActive(false);
        
    }

   

    private void FixedUpdate()
    {
        
        

        if (Moving)
        {
           rightHand.DORotate(rightHand.localRotation.eulerAngles + new Vector3(0, -180, 0), 2f);
           leftHand.DORotate(leftHand.localRotation.eulerAngles + new Vector3(0, 180, 0), 2f);

            if (Input.GetMouseButton(0))
            {
                var position = Input.mousePosition;

                _distanceToScreen = _pickerCamera.WorldToScreenPoint(gameObject.transform.position).z;
                _mousePos = _pickerCamera.ScreenToWorldPoint(new Vector3(position.x, position.y, _distanceToScreen));
                float direction = _xSpeed;
                direction = _mousePos.x > transform.position.x ? direction : -direction;

                if (Math.Abs(_mousePos.x - transform.position.x) > 0.5f)
                    transform.Translate(Time.deltaTime * direction, 0, 0);
            }
            transform.Translate(0, 0, Time.deltaTime * _forwardSpeed);
        }
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Stop")
        {
            hands.SetActive(false);
            foreach (GameObject gObject in pickedones)
            {
                if (gObject != null)
                {
                    Collectable collectable = gObject.GetComponent<Collectable>();
                    collectable.EndOfStage();
                }
            }
            Moving = false;
            
        }
     

        if (other.gameObject.tag == "Final")
        {
            Final = true;
            Moving = false;
            hands.SetActive(false);
            foreach (GameObject gObject in pickedones)
            {
                if (gObject != null)
                {
                    Collectable collectable = gObject.GetComponent<Collectable>();
                    collectable.EndOfStage();
                    
                }
            }
            StartCoroutine(FinalCo());

        }
        IEnumerator FinalCo()
        {
            yield return new WaitForSeconds(5);
            GameManagerSc.Instance.FinishLevel();
        }
        if (other.gameObject.tag == "Gate")
        {
            Moving = true;
        }
        if (other.gameObject.tag == "HandsActive")
        {
            hands.SetActive(true);
            Destroy(other.gameObject);
        }

      
    }

    public void PickedAdd(GameObject picked)
    {
        picked.tag = "Picked";
        pickedones.Add(picked);
        
    }

    public void PickedRemove(GameObject picked)
    {
        if (Moving)
        {
            picked.tag = "NotPicked";
            pickedones.Remove(picked);
        }
    }

    public void StageComplete()
    {
        if (Final == false)
        {
            transform.DOMoveZ(transform.position.z + 35, 6).OnStepComplete(() => MovingActive());
            transform.DOMoveX(0, 1);
        }
        else if(Final==true)
        {
            GameManagerSc.Instance.FinishLevel();
        }
       

    }

    public void MovingActive()
    {
        GameManagerSc.Instance.StageUp();
        
       
    }
}
