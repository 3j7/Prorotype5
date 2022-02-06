using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{    
    private int score;

    public bool isGameActive;
    public float spawnRate = 1.3f;
    
    public Button restartButton;
    public GameObject titleScreen;
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;


   // Start is called before the first frame update
    void Start()
    {
  
    }
  
    // Update is called once per frame
    void Update()
    {       
    }
    IEnumerator SpawnTarget()
    {
       
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            
        }
    }
   public void ScoreUpdate(int ScoreToAdd)
    {
        score += ScoreToAdd;
        scoreText.text = "Score :" + score;
    }
   public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        score = 0;
        ScoreUpdate(0);
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        titleScreen.gameObject.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
