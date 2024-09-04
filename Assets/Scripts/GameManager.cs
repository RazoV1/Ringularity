using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float difficulty;
    public List<GameObject> Levels;
    public int lives;
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
        lives = maxLives;
        score = 0;
        currentLevelIndex = -1;
        UpdateViewModels();
        StartLevel(0);
    }

    public void StartLevel(int index)
    {
        Instantiate(Levels[index]);
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
	private void UpdateViewModels()
	{
		hpViewModel.fillAmount = lives / (float)maxLives;
        levelIndexViewModel.text = "Level: " + currentLevelIndex.ToString();
        scoreViewModel.text = "Score: " + score.ToString();
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
