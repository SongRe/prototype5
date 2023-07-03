using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private float spawnRate = 1.0f;
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    private int score;
    public bool play = true;
    public Button restartButton;
    public GameObject titleScreen;
    // Start is called before the first frame update
    void Start()
    {
        play = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpawnTarget() {
        while (true) {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
        
    }

    public void UpdateScore(int add) {
        if (play) {
            score += add;
            scoreText.text = "Score: " + score;
        }
        
    }

    public void GameOver() {
        Debug.Log("Game Over");
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        play = false;
        StopCoroutine(SpawnTarget());
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int diff) {
        spawnRate /= diff;
        titleScreen.gameObject.SetActive(false);
        play = true;
        score = 0;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }
}
