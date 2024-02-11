using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public CubeSpawner cubeSpawner;
    public LevelManager[] levelManagers = new LevelManager[5];
    public SoundEffectPlayer sfxPlayer;
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    public TMP_Text paused;
    public TMP_Text hardMode;

    public int userScore = 0;
    public int highScore = 0;
    public float hardModeScale = 1.25f;
    public bool isPaused = false;
    public bool isHardMode = false;

    // Start is called before the first frame update
    void Start()
    {
        cubeSpawner = GameObject.Find("CubeSpawner").GetComponent<CubeSpawner>();
        sfxPlayer = this.GetComponent<SoundEffectPlayer>();

        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TogglePause();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            ToggleHardMode();
        }
    }

    public void StartGame()
    {
        userScore = 0;
        ResetBoard();
        SetScoreText();

        //@TODO Add sound effect
    }

    public void SetScoreText()
    {
        scoreText.SetText(userScore.ToString());
    }

    public void ResetBoard()
    {
        cubeSpawner.SpawnCube();
        foreach (LevelManager level in levelManagers)
        {
            level.SetLevel();
        }
    }

    public void Score(int score)
    {
        sfxPlayer.PlayRandomClip();

        userScore += score;
        SetScoreText();
        SetHighScore();

        ResetBoard();
    }

    public void SetHighScore()
    {
        if (userScore > highScore)
        {
            highScore = userScore;
            highScoreText.SetText("High Score: " + highScore.ToString());
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        DestroyCubes();
        sfxPlayer.PlayExplosion();

        StartGame();
    }

    public void DestroyCubes()
    {
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");
        foreach (GameObject cube in cubes)
        {
            Destroy(cube);
        }
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            isPaused = false;
            paused.SetText("");
        } else
        {
            isPaused = true;
            paused.SetText("Paused");
        }

        Time.timeScale = GetTimeScale();
    }

    public void ToggleHardMode()
    {
        if (!isHardMode)
        {
            isHardMode = true;
            hardMode.SetText("Hard Mode");
        } else
        {
            isHardMode = false;
            hardMode.SetText("");
        }

        Time.timeScale = GetTimeScale();
    }

    public float GetTimeScale()
    {
        if (isPaused)
        {
            return 0f;
        } else if (isHardMode)
        {
            return hardModeScale;
        } else
        {
            return 1f;
        }
    }
}
