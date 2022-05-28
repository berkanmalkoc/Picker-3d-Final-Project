using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HelicopterController : MonoBehaviour
{
   
    [SerializeField] private GameObject gameObj = null;
    
    float currentPositionX;
    float currentPoisitonZ;
    float horizontalmove = 3;
    float verticalmove=30;

    public GameObject collectablePrefab;

    // Start is called before the first frame update
    void Start()
    {
        currentPositionX = transform.position.x;
        currentPoisitonZ = transform.position.z;
        HeliTweenright();
        StartCoroutine(SpawnerOfHeli());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnerOfHeli()
    {
        yield return new WaitForSeconds(1f);
        while (true)
        {
           
            yield return new WaitForSeconds(0.15f);
            
            Instantiate(gameObj, transform.position, Quaternion.identity);
        }
    }


    void HeliTweenright()
    {
        if (gameObject != null)
        {
            transform.DOMoveX(currentPositionX + horizontalmove, 1);
            transform.DOMoveZ(currentPoisitonZ + verticalmove, 1).OnComplete(() => HeliTweenleft());
            currentPositionX = 8;
            currentPoisitonZ = transform.position.z;
        }
    }
    void HeliTweenleft()
    {
        if (gameObject != null)
        {
            transform.DOMoveX(currentPositionX - horizontalmove, 1);
            transform.DOMoveZ(currentPoisitonZ + verticalmove, 1).OnComplete(() => HeliTweenright());
            currentPositionX = -8;
            currentPoisitonZ = transform.position.z;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HeliStop")
        {
            Destroy(gameObject);
        }
    }
}
