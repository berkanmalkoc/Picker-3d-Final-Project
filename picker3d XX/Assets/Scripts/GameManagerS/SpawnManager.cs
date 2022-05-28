using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpawnManager : MonoBehaviour
{

    private BallTypeListSO ballTypeListSO;
    private BallTypeSO ballTypeSO;

    [SerializeField] private ObjectPool objectPool = null;

    public static SpawnManager Instance;
    
    
    public GameObject helicopter;
    public Transform helitransform;

    private int currentStage=1;
    private int currentLevel;
    Vector3 helicopterCurrentPosition;
    int ballTypeNumber;
    int balanceNumber;


    int length = 20;

    [SerializeField] GameObject hands;
    private int road1min= 30;
    private int road1max= 100;

    private int road2min=180;
    private int road2max=265;

    private int road3min=350;
    private int road3max=440;



    // Start is called before the first frame update
    void Start()
    {
        currentLevel = PlayerPrefs.GetInt("level", 1);

        ballTypeListSO = Resources.Load<BallTypeListSO>("BallTypeList");
    
        ballTypeNumber = objectPool.randomMaker;
        balanceNumber = ballTypeListSO.ballTypeList[ballTypeNumber].typeBalanceNumber;


        Instance = this;
        LevelCreater();
        
        
    }

    public void LevelCreater()
    {
        
        

        if (currentStage == 1)
            RoadCreater( road1min, road1max);

        if (currentStage == 2)
            RoadCreater( road2min, road2max);

        if (currentStage == 3)
            RoadCreater( road3min, road3max);

        Vector3 handsSpawnPosition = new Vector3(0, 0.5f,road1min);
        Instantiate(hands, handsSpawnPosition, Quaternion.identity);

    }

    public void StageObserver()
    {
        currentStage++;
        LevelCreater();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void RoadCreater( float min, float max)
    {
      
     for (int i = 0; i < (length-balanceNumber)+currentStage+currentLevel; i++)
     {
       var obj = objectPool.GetPooledObject();
                
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-8, 8), 0.5f, Random.Range(min, max));
        obj.transform.position = randomSpawnPosition;
                    
     }

      

    }


    


}
