using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValue;

    public float waitStart;
    public float waitTime;
    public float waveTime;
    public int waveCount;
    public Text scoreText;
    public Text gameOver;
    public GameObject restartButtonObject;
    private int score;

    private bool isGameOver;
    private bool isRestart;

	void Start () 
    {
        score = 0;
        isGameOver = false;
        isRestart = false;
        restartButtonObject.SetActive(false);

        UpdateScore();
        StartCoroutine(SpawnHazard());
	}

    IEnumerator SpawnHazard () 
    {
        while (true)
        {
            for (int i = 0; i < waveCount; i++)
            {
                yield return new WaitForSeconds(waitStart);
                Vector3 position = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                Instantiate(hazard, position, Quaternion.identity);
                yield return new WaitForSeconds(waitTime);
            }
            yield return new WaitForSeconds(waveTime);

            if (isGameOver)
            {
                gameOver.text = "";
                InitRestartButton();
                break;
            }
        }
    }

    public void AddScore(int scoreValue)
    {
        score += scoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "score : " + score;
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOver.text = "Game Over";
    }

    private void InitRestartButton()
    {
        restartButtonObject.SetActive(true);
        Button restartButton = restartButtonObject.GetComponent<Button>();
        restartButton.onClick.RemoveAllListeners();
        restartButton.onClick.AddListener(RegisterRestartButton);
    }

    private void RegisterRestartButton()
    {

        restartButtonObject.SetActive(false);
        SceneManager.LoadScene("main");
    }
}
