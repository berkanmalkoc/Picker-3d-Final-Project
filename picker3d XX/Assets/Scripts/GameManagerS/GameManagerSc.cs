using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManagerSc : MonoBehaviour
{
    public static GameManagerSc Instance;

    [SerializeField] private int currentLevel;
    public int currentStage;
    private List<GameObject> pickedones;
    private int nextSceneToLoad;
    public bool final;
    

    #region Stages Platform
    public Text _text1;
    public int collected1;
    public Animator gate1Anim;
    public Platform platform1;

    public Text _text2;
    
    public Animator gate2Anim;
    public Platform platform2;

    public Text _text3;
    
    
    public Platform platform3;

    #endregion

    #region UI
    public Text currentLevelTxt;
    public Text nextLevelTxt;
    public List<GameObject> stagesignList= new List<GameObject>();
    public GameObject finishPanel;
    public Text pointText;
    int point;
    public int gamePoint;
    int gameStartPoint;
    public Text gameScoreText;
    public Text TotalScoreText;


    #endregion
    private void Awake()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        point = PlayerPrefs.GetInt("Point", 0);
        pointText.text = point.ToString();
        Instance = this;
       currentLevel= PlayerPrefs.GetInt("level", 1);

        currentLevelTxt.text = currentLevel.ToString();
        nextLevelTxt.text = (currentLevel + 1).ToString();
        currentStage = 1;

        if(_text1!=null)
        _text1.text = (collected1 + "/" + (currentLevel + 1) ).ToString();
        if (_text2 != null)
            _text2.text = (collected1 + "/" + (currentLevel + 2) ).ToString();
        if(_text3!= null)
        _text3.text = (collected1 + "/" + (currentLevel + 3) ).ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        gameStartPoint = point;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(PlayerPrefs.GetInt("level"));
            PlayerPrefs.SetInt("level", 1);
            PlayerPrefs.SetInt("Point", 0);
            
        }

    }

    public void Collected1Increase()
    {
      
        collected1++;
        PointConroller(1);
        if (currentStage == 1) {
            _text1.text = (collected1 + "/" + (currentLevel + currentStage) ).ToString();
            if (collected1 == (currentLevel + 1))
            {
                if (platform1 != null) { 
                platform1.PlaformMove();
                gate1Anim.SetBool("Open", true);
                }

            } 
        }
        else if (currentStage == 2)
        {
            _text2.text = (collected1 + "/" + (currentLevel + currentStage)).ToString();
            if (collected1 == (currentLevel + 2) )
            {
                if (platform2 != null) { 
                platform2.PlaformMove();
                gate2Anim.SetBool("Open", true);
                }

            }
        }
        else if (currentStage == 3)
        {
            _text3.text = (collected1 + "/" + (currentLevel + 3) ).ToString();
            if (collected1 == (currentLevel + 3) )
            {
                if (platform3 != null) { 
                platform3.PlaformMove();
                }

                FinishLevel();
            }
        }

    }

    public void StageUp()
    {
        int n = currentStage - 1;
        stagesignList[n].SetActive(true);
        currentStage++;
        
        SpawnManager.Instance.StageObserver();
        collected1 = 0;
        _text2.text = (collected1 + "/" + (currentLevel + 2) * 2).ToString();
        _text3.text = (collected1 + "/" + (currentLevel + 3) * 2).ToString();


    }

    public void FinishLevel()
    {


        
        gamePoint = point - gameStartPoint;
        gameScoreText.text = gamePoint.ToString();
       
        TotalScoreText.text = point.ToString();
        finishPanel.SetActive(true);
        


    }

    public void nextLevel()
    {
        LevelUP();
        LoadNewScene();
        finishPanel.SetActive(false);
        
    }

  

    public void LoadNewScene()
    {

        if (nextSceneToLoad >= 3)
        {
            nextSceneToLoad -= 3;
            SceneManager.LoadScene(nextSceneToLoad);
        }
        else { 
        SceneManager.LoadScene(nextSceneToLoad);
        }


    }
    

    public void LevelUP()
    {
        PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
        currentLevel = PlayerPrefs.GetInt("level");
    }

    public void PointConroller(int i)
    {
        point = point + i;
        pointText.text = point.ToString();
        PlayerPrefs.SetInt("Point", point);

    }
}
