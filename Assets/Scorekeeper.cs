using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scorekeeper : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] float scoreAllow = 10.0f;
    [SerializeField] Text scoreText;
    [SerializeField] Text sceneText;
    [SerializeField] Text livesRemain;
    [SerializeField] int lives = 3;
    int level;
    string playerName;
    //const int DEFAULT_POINTS = 10;

    
    void Awake()
    {
        level = SceneManager.GetActiveScene().buildIndex - 2;
        if(level == 1)
            PersistentData.Instance.SetScore(0);

    }

    // Start is called before the first frame update
    void Start()
    {
        score = PersistentData.Instance.GetScore();
        playerName = PersistentData.Instance.GetName();
        level = SceneManager.GetActiveScene().buildIndex - 2;
        if(level == 1)
            PersistentData.Instance.SetScore(0);
        Debug.Log(playerName);
        sceneText.text = "Welcome " + playerName + " Level: " + level;
        
    }

    // Update is called once per frame
    void Update()
    {
        livesRemain.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
        if(GameObject.FindGameObjectWithTag("Balloon") != null)
        {
            if(scoreAllow > 0)
                scoreAllow -= Time.deltaTime;
            else{
                Destroy(GameObject.FindGameObjectWithTag("Balloon"));
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                scoreAllow = 0.0f;
            }
        }

        if(GameObject.FindGameObjectWithTag("Distractor") == null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void UpdateScore(float addend)
    {
        score += (int)addend;
        PersistentData.Instance.SetScore(score);
        //SceneManager.LoadScene("level2");
        Debug.Log("score " + score);
    }

    public void UpdateScore()
    {
        UpdateScore(scoreAllow);
    }

    public void LoseLives()
    {
        lives --;
    }

    public void WaitNextScene()
    {
        Invoke("NextScene", 0.35f);
    }
    public void NextScene()
    {
        Debug.Log("Should be next scene");
        if(SceneManager.GetActiveScene().buildIndex == 5)
            SceneManager.LoadScene("highscores");
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
