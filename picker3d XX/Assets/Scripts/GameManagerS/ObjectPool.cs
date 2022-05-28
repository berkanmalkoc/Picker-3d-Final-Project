using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private BallTypeListSO ballTypeListSO;
    private BallTypeSO ballTypeSO;

    private Queue<Transform> pooledObjects;
    

    [SerializeField] private Transform objectPrefab;
   
    private int poolSize;
    public int randomMaker;
    
    private void Awake()
    {
        
        randomMaker = Random.Range(0, 3);
        if (randomMaker == 0)
            poolSize = 20;
        if (randomMaker == 1)
            poolSize = 30;
        if (randomMaker == 2)
            poolSize = 30;

        ballTypeListSO = Resources.Load<BallTypeListSO>("BallTypeList");
        ballTypeSO = ballTypeListSO.ballTypeList[randomMaker];


        PoolCreator();


    }
    private void PoolCreator()
    {
        pooledObjects = new Queue<Transform>();
        for (int i = 0; i < poolSize; i++)
        {
            Transform obj = Instantiate(ballTypeSO.prefab);
            obj.transform.SetParent(transform);
            
            pooledObjects.Enqueue(obj);
        }

    }

    private void OnEnable()
    {
        
    }

    public Transform GetPooledObject()
    {
        Transform obj = pooledObjects.Dequeue();

       
        pooledObjects.Enqueue(obj);

        return obj;
    }
    


}
