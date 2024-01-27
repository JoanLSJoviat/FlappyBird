using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private int score;
    private int bestScore;
    public bool startGame;
    public GameObject startMessage;
    public GameObject player;
    public PipeSpawner ps;
    public TMP_Text scoreText;
    public TMP_Text finalScoreText;
    public TMP_Text bestScoreText;
    public GameObject scoreLbl;
    public GameObject gameOverMsg;
    public GameObject scorePanel;
    private bool gameOver;

    public AudioClip soundtrack;

    private AudioSource _audioSource;
  
    Coroutine spawnPipesCoroutine;
    void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
        startMessage.SetActive(true);
        scoreLbl.SetActive(false);
        player.SetActive(false);
        gameOverMsg.SetActive(false);
        scorePanel.SetActive(false);
        startGame = false;
        bestScore = PlayerPrefs.GetInt("bestScore");
        gameOver = false;
        _audioSource = GetComponent<AudioSource>();
        _audioSource.PlayOneShot(soundtrack);
    }

    // Update is called once per frame
    void Update()
    {
        if (!startGame &&  !gameOver && (Input.GetMouseButton(0) || Input.GetKeyDown("space")))
        {
            StartGame();
        }
    }

    public void addScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    void StartGame()
    {
        startGame = true;
        startMessage.SetActive(false);
        player.SetActive(true);
        scoreLbl.SetActive(true);
        spawnPipesCoroutine = StartCoroutine(ps.SpawnPipes());
    }

    public void SetUpGameOver()
    {
        startGame = false;
        gameOver = true;

        if (spawnPipesCoroutine != null)
        {
            StopCoroutine(spawnPipesCoroutine);
            spawnPipesCoroutine = null;
        }
        
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Pipe");
       

        foreach (GameObject obstacle in obstacles)
        {
            Destroy(obstacle);
        }

        gameOverMsg.SetActive(true);
        scoreLbl.SetActive(false);
        scorePanel.SetActive(true);
        
        
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("bestScore", bestScore);
        }
        
        finalScoreText.text = score.ToString();
        bestScoreText.text = bestScore.ToString();
        
    }

    public void Replay()
    {
        SceneManager.LoadScene(1);
    }
}
