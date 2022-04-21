using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{


	public static GameManager instance;
	int score;

	public Text scoreText;
	public Text MYSCORE;
    public Text MyScore;
	public GameObject gameScoreUI;
	public Text highScore;
	public Text MyhighScore;



	private void Awake()
	{
		instance = this;
	}
    // Start is called before the first frame update
    void Start()
    {
    	highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        MyhighScore.text = PlayerPrefs.GetInt("MYHighScore",0).ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
        	if(SceneManager.GetActiveScene().buildIndex == 0)
        	Application.Quit();
        	else
        	SceneManager.LoadScene(0);
        }
    }



    public void GameStart()
    {
    	gameScoreUI.SetActive(false);
    	scoreText.gameObject.SetActive(true);
    	MyScore.gameObject.SetActive(false);
    }





    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void ScoreUp()
    {
    	score++;
    	scoreText.text = score.ToString();
    	if(score > PlayerPrefs.GetInt("MYHighScore",0))
    	{
    		PlayerPrefs.SetInt("MYHighScore", score);
    		MyhighScore.text = score.ToString();
    	}


    	PlayerPrefs.SetInt("HighScore", score);

    	MYSCORE.text = score.ToString();

    }
}
