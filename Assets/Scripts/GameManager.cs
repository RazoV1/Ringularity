using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float difficulty;
    public List<GameObject> Levels;
    private GameObject currentLevelInstance;
    public int lives = 0;
    public int currentLevelIndex = 0;
    public int score;
    [SerializeField] private CarreteController carrete;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private int maxLives;

    [Header("UI/UX")]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private Image hpViewModel;
    [SerializeField] private TextMeshProUGUI scoreViewModel;
    [SerializeField] private TextMeshProUGUI levelIndexViewModel;
    [SerializeField] private GameObject mainMenu;

    public void NewGame()
    {
        score = 0;
        currentLevelIndex = 0;
        if (currentLevelInstance != null)
        {
            Destroy(currentLevelInstance);
        }
        StartLevel(0);
		UpdateViewModels();
	}

    private void CalculateBricks()
    {
        var bricks = currentLevelInstance.GetComponentsInChildren<BrickBehaviour>();
        Debug.Log("Length = "+bricks.Length);
        if (bricks != null && bricks.Length-1 > 0)
        {
            return;
        }
        carrete.ResetBall();
        StartLevel(currentLevelIndex);
    }

    public void StartLevel(int index)
    {
        currentLevelInstance = Instantiate(Levels[index]);
        lives += 3;
        maxLives = lives;
        CreateBall();
        currentLevelIndex++;
    }
    private void CreateBall()
    {
		var ballInstance = Instantiate(ballPrefab, new Vector2(carrete.transform.position.x,
											carrete.transform.position.y + carrete.transform.localScale.y), Quaternion.identity);
		carrete.SetBallIndtance(ballInstance);
        var ballBehaviour = ballInstance.GetComponent<BallBehavior>();
        ballBehaviour.SetCarrete(carrete);
	}
	public void UpdateViewModels()
	{
		hpViewModel.fillAmount = lives / (float)maxLives;
        levelIndexViewModel.text = "Level: " + currentLevelIndex.ToString();
        scoreViewModel.text = "Score: " + score.ToString();
        CalculateBricks();
	}
    public void CheckHpUpdate()
    {
        if (score % 300 == 0)
        {
            lives++;
        }
    }
	public void ResetBall()
    {
        carrete.ResetBall();
        if (lives - 1 > 0)
        {
            lives--;
            UpdateViewModels();
            CreateBall();
            return;
        }
        gameOverScreen.SetActive(true);
    }
}
