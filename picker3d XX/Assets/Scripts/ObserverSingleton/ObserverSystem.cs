using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverSystem : Observer
{
    public GameObject triggerPointBox;
    public int boxPoint;
    
    
    private void Start()
    {
        ObserverManager.Instance.RegisterObserver(this, SubjectType.MovementPanel);
    }
    public override void OnNotify(NotificationType notificationType)
    {
        switch (notificationType)
        {
            case NotificationType.ForwardButton:
                transform.Translate(Vector3.forward);
                break;
            case NotificationType.BackButton:
                PointBox pointBox = triggerPointBox.GetComponent<PointBox>();
                boxPoint = pointBox.boxRandomPoint;
                GameManagerSc.Instance.PointConroller(boxPoint);
                GameManagerSc.Instance.FinishLevel();
                break;
     
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PointBox")
        {
            triggerPointBox = other.gameObject;
      
        }
    }

}
