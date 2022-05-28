using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene3Manager : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private float currentTime;
    [SerializeField] private Text timer;
    public GameObject TimesUpPnl;
    public GameObject pushPanel;
    public GameObject claimPanel;

    // Start is called before the first frame update
    void Start()
    {
        _duration = Random.Range(5, 10);
        currentTime = _duration;

        StartCoroutine(UpdateTime());
        
    }
    IEnumerator UpdateTime()
    {
        while (currentTime >= 0)
        {
            if (currentTime == 0)
            {
                pushPanel.SetActive(false);
                TimesUpPnl.SetActive(true);
            
            }

            yield return new WaitForSeconds(1f);
            currentTime--;
        }
        


    }

 
    // Update is called once per frame
    void Update()
    {
        timer.text = currentTime.ToString();
    }

    public void CalimDeactive()
    {
        claimPanel.SetActive(false);
    }
}
