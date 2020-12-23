using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour {

    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlock = 1;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool autoPlayEnabled;

    [SerializeField] int currentScore = 0;

    // Use this for initialization

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start ()
    {
        scoreText.text = "Score: " + currentScore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        Time.timeScale = gameSpeed;
		
	}

    public void AddToScore()
    {
        currentScore = currentScore + pointsPerBlock;
        scoreText.text = "Score: " + currentScore.ToString();
    }

    public void resetGame()
    {
        Destroy(gameObject);
    }

    public bool AutoPlayEnabled()
    {
        return autoPlayEnabled;
    }
}
