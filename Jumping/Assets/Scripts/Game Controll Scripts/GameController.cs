using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{

    public static GameController instance;
    public PlatformCollecter plat;

    //public GameObject[] platform;
    public GameObject[] firstPlatfomr;
    public GameObject[] clound;
    public GameObject Star;
    [Header("-------------------------")]
    public Vector2 cloundMinXMaxX;
    public float lastPositionYClound;
    public float distanceBtwTwoClound;
    private float DistanceBetweenPlatform = 4.13f;
    private int countPlatform;
    private float lastPlatformPositionY;
    [Header("--------Control UI--------")]
    public GameObject StartGamePanel;
    public GameObject ScorePanel;
    public GameObject jumpButton;
    public GameObject Guild;
    public GameObject GameOverPanel;
    public GameObject ShopPanel;
    public GameObject PausePanel;
    public GameObject ExitPanel;
    public GameObject pauseButton;
    public GameObject Leaderboard;
    public GameObject NewHighscore;
    public GameObject SoundButton;
    [HideInInspector]
    public static bool FirstTimeLoadSreen = true;
    [Header("-------------------------")]
    public Player player;
    public SoundsManager sound;

    [HideInInspector]
    public int ran;
    public HighscoreManager high;
    public bool statusLeaderboard;
    // Use this for initialization
    void Awake()
    {
        if (FirstTimeLoadSreen)
            checkUIStartGame();
        else
        {
            ClickGameOver();
        }
        ran = Random.Range(0, 3);
        RandomPlatform(ran);
        MakeSingleton();
        statusLeaderboard = true;
    }
    public void CreateClound()
    {
        int rd = Random.Range(0, 7);
        float randomPositionX = Random.Range(cloundMinXMaxX.x, cloundMinXMaxX.y);

        switch (rd)
        {
            case 0:
                lastPositionYClound += distanceBtwTwoClound;
                GameObject newClound = Instantiate(clound[0]);
                newClound.transform.position = new Vector3(randomPositionX, lastPositionYClound, 0f);
                break;
            case 1:
                lastPositionYClound += distanceBtwTwoClound;
                GameObject newClound1 = Instantiate(clound[1]);
                newClound1.transform.position = new Vector3(randomPositionX, lastPositionYClound, 0f);
                break;
            case 2:
                lastPositionYClound += distanceBtwTwoClound;
                GameObject newClound2 = Instantiate(clound[2]);
                newClound2.transform.position = new Vector3(randomPositionX, lastPositionYClound, 0f);
                break;
            case 3:
                lastPositionYClound += distanceBtwTwoClound;
                GameObject newClound3 = Instantiate(clound[3]);
                newClound3.transform.position = new Vector3(randomPositionX, lastPositionYClound, 0f);
                break;
            case 4:
                lastPositionYClound += distanceBtwTwoClound;
                GameObject newClound4 = Instantiate(clound[4]);
                newClound4.transform.position = new Vector3(randomPositionX, lastPositionYClound, 0f);
                break;
            case 5:
                lastPositionYClound += distanceBtwTwoClound;
                GameObject newClound5 = Instantiate(clound[5]);
                newClound5.transform.position = new Vector3(randomPositionX, lastPositionYClound, 0f);
                break;
            case 6:
                lastPositionYClound += distanceBtwTwoClound;
                GameObject newClound6 = Instantiate(clound[6]);
                newClound6.transform.position = new Vector3(randomPositionX, lastPositionYClound, 0f);
                break;
        }
        //san tien create star luon 
        int random = Random.Range(0, 100);

        if (random < 20)
        {
            float randomPosition = Random.Range(cloundMinXMaxX.x, cloundMinXMaxX.y);
            GameObject newstar = Instantiate(Star);
            newstar.transform.position = new Vector3(randomPosition, lastPositionYClound, 0f);
        }

    }
    void RandomPlatform(int ran)
    {

        switch (ran)
        {
            case 0:
                GameObject newFirstPlat = Instantiate(firstPlatfomr[0], Vector3.zero, Quaternion.identity);
                break;
            case 1:
                GameObject newFirstPlat1 = Instantiate(firstPlatfomr[1], Vector3.zero, Quaternion.identity);
                break;
            case 2:
                GameObject newFirstPlat2 = Instantiate(firstPlatfomr[2], Vector3.zero, Quaternion.identity);
                break;
        }
    }

    private void Start()
    {
        CreatePlatform();
    }
    #region Xu ly UI
    void checkUIStartGame()
    {
        StartGamePanel.SetActive(true);
        ScorePanel.SetActive(false);
        jumpButton.SetActive(false);
        Guild.SetActive(false);
        GameOverPanel.SetActive(false);
        ShopPanel.SetActive(false);
        ExitPanel.SetActive(false);
        PausePanel.SetActive(false);
    }

    public void ClickPlayGame()
    {
        Player.score = 0;
        player.Bestscore = 0;
        StartGamePanel.SetActive(false);
        ScorePanel.SetActive(true);
        jumpButton.SetActive(true);
        Guild.SetActive(false);
        GameOverPanel.SetActive(false);
        ShopPanel.SetActive(false);
        ExitPanel.SetActive(false);
        PausePanel.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void ClickGuilde()
    {
        StartGamePanel.SetActive(false);
        ScorePanel.SetActive(false);
        jumpButton.SetActive(false);
        Guild.SetActive(true);
        GameOverPanel.SetActive(false);
        ShopPanel.SetActive(false);
        ExitPanel.SetActive(false);
        PausePanel.SetActive(false);
    }
    public void ClickSoundButton()
    {
        SoundButton.SetActive(true);
        StartGamePanel.SetActive(false);
        ScorePanel.SetActive(false);
        jumpButton.SetActive(false);
        Guild.SetActive(false);
        GameOverPanel.SetActive(false);
        ShopPanel.SetActive(false);
        ExitPanel.SetActive(false);
        PausePanel.SetActive(false);
    }
    public void ClickShop()
    {
        clickShopWhenGameover = false;
        StartGamePanel.SetActive(false);
        ScorePanel.SetActive(false);
        jumpButton.SetActive(false);
        Guild.SetActive(false);
        GameOverPanel.SetActive(false);
        ShopPanel.SetActive(true);
        ExitPanel.SetActive(false);
        PausePanel.SetActive(false);
    }
    private bool clickShopWhenGameover;
    public void ClickShopByGameOver()
    {
        clickShopWhenGameover = true;
        StartGamePanel.SetActive(false);
        ScorePanel.SetActive(false);
        jumpButton.SetActive(false);
        Guild.SetActive(false);
        GameOverPanel.SetActive(false);
        ShopPanel.SetActive(true);
        ExitPanel.SetActive(false);
        PausePanel.SetActive(false);
    }

    public void ClickGoHome()
    {
        if (clickShopWhenGameover)
        {
            StartGamePanel.SetActive(false);
            ScorePanel.SetActive(false);
            jumpButton.SetActive(false);
            Guild.SetActive(false);
            GameOverPanel.SetActive(true);
            ShopPanel.SetActive(false);
            ExitPanel.SetActive(false);
            PausePanel.SetActive(false);
            clickShopWhenGameover = false;
        }
        else
        {
            StartGamePanel.SetActive(true);
            ScorePanel.SetActive(false);
            jumpButton.SetActive(false);
            Guild.SetActive(false);
            GameOverPanel.SetActive(false);
            ShopPanel.SetActive(false);
            ExitPanel.SetActive(false);
            PausePanel.SetActive(false);
            SoundButton.SetActive(false);
        }
    }

    public void ClickGameOver()
    {
        //chay 1 dong for
        if (high.detectHighScore())
        {
            Debug.Log("Hi Score");
            sound.Playsound("highscore");
            Leaderboard.SetActive(false);
            NewHighscore.SetActive(true);
            StartGamePanel.SetActive(false);
            ScorePanel.SetActive(false);
            jumpButton.SetActive(false);
            Guild.SetActive(false);
            GameOverPanel.SetActive(false);
            ShopPanel.SetActive(false);
            ExitPanel.SetActive(false);
            PausePanel.SetActive(false);
            pauseButton.SetActive(false);
        }
        else
        {
            Debug.Log("Not Hi Score");
            sound.Playsound("gameover");
            Leaderboard.SetActive(false);
            NewHighscore.SetActive(false);
            StartGamePanel.SetActive(false);
            ScorePanel.SetActive(false);
            jumpButton.SetActive(false);
            Guild.SetActive(false);
            GameOverPanel.SetActive(true);
            ShopPanel.SetActive(false);
            ExitPanel.SetActive(false);
            PausePanel.SetActive(false);
            pauseButton.SetActive(false);
        }
       
    }
    public void ClickViewGameOver()
    {
        if (statusLeaderboard)
        {
            Leaderboard.SetActive(false);
            NewHighscore.SetActive(false);
            StartGamePanel.SetActive(true);
            ScorePanel.SetActive(false);
            jumpButton.SetActive(false);
            Guild.SetActive(false);
            GameOverPanel.SetActive(false);
            ShopPanel.SetActive(false);
            ExitPanel.SetActive(false);
            PausePanel.SetActive(false);
            pauseButton.SetActive(false);
        }
        else
        {
            Leaderboard.SetActive(false);
            NewHighscore.SetActive(false);
            StartGamePanel.SetActive(false);
            ScorePanel.SetActive(false);
            jumpButton.SetActive(false);
            Guild.SetActive(false);
            GameOverPanel.SetActive(true);
            ShopPanel.SetActive(false);
            ExitPanel.SetActive(false);
            PausePanel.SetActive(false);
            pauseButton.SetActive(false);
        }
    }
    public void ClickPlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PauseGame()
    {
        StartGamePanel.SetActive(false);
        ScorePanel.SetActive(false);
        jumpButton.SetActive(false);
        Guild.SetActive(false);
        GameOverPanel.SetActive(false);
        ShopPanel.SetActive(false);
        PausePanel.SetActive(true);
        ExitPanel.SetActive(false);
        Time.timeScale = 0;
    }
    public void EndPauseGame()
    {
        StartGamePanel.SetActive(false);
        ScorePanel.SetActive(true);
        jumpButton.SetActive(true);
        Guild.SetActive(false);
        GameOverPanel.SetActive(false);
        ShopPanel.SetActive(false);
        PausePanel.SetActive(false);
        ExitPanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void ExitGame(string status)
    {
        switch (status)
        {
            case "click":
                StartGamePanel.SetActive(false);
                ScorePanel.SetActive(false);
                jumpButton.SetActive(false);
                Guild.SetActive(false);
                GameOverPanel.SetActive(false);
                ShopPanel.SetActive(false);
                PausePanel.SetActive(false);
                ExitPanel.SetActive(true);
                break;
            case "yes":
                Application.Quit();
                Debug.Log("Quit");
                break;
            case "no":
                StartGamePanel.SetActive(true);
                ScorePanel.SetActive(false);
                jumpButton.SetActive(false);
                Guild.SetActive(false);
                GameOverPanel.SetActive(false);
                ShopPanel.SetActive(false);
                PausePanel.SetActive(false);
                ExitPanel.SetActive(false);
                break;
        }
    }
    public void Submitnewscore()
    {
        statusLeaderboard = false;
        Leaderboard.SetActive(true);
        NewHighscore.SetActive(false);
        StartGamePanel.SetActive(false);
        ScorePanel.SetActive(false);
        jumpButton.SetActive(false);
        Guild.SetActive(false);
        GameOverPanel.SetActive(true);
        ShopPanel.SetActive(false);
        ExitPanel.SetActive(false);
        PausePanel.SetActive(false);
        pauseButton.SetActive(false);
    }
    public void ClickViewLeaderboard()
    {
        statusLeaderboard = true;
        Leaderboard.SetActive(true);
        NewHighscore.SetActive(false);
        StartGamePanel.SetActive(false);
        ScorePanel.SetActive(false);
        jumpButton.SetActive(false);
        Guild.SetActive(false);
        GameOverPanel.SetActive(true);
        ShopPanel.SetActive(false);
        ExitPanel.SetActive(false);
        PausePanel.SetActive(false);
        pauseButton.SetActive(false);
    }
    #endregion

    void Update()
    {

    }
    private void OnDisable()
    {
        instance = null;
    }
    private void MakeSingleton()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void CreatePlatform()
    {
        lastPlatformPositionY += DistanceBetweenPlatform;
        GameObject newPlat = ObjectPooler.Instance.GetFromPool();
        newPlat.transform.position = new Vector3(0, lastPlatformPositionY, 0);
        countPlatform++;
    }

    public void PlayAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    //public void GotoMenu()
    //{
    //    Time.timeScale = 1;
    //    SceneManager.LoadScene("Menu Scene");
    //}

}
