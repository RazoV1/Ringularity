using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float difficulty;
    public List<GameObject> Levels;
    public int lives;
    public int currentLevelIndex = 0;
    [SerializeField] private CarreteController carrete;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private int maxLives;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private Image hpViewModel;

    public void StartLevel(int index)
    {
        Instantiate(Levels[index]);
        CreateBall();
    }
    private void CreateBall()
    {
		var ballInstance = Instantiate(ballPrefab, new Vector2(carrete.transform.position.x,
											carrete.transform.position.y + carrete.transform.localScale.y), Quaternion.identity);
		carrete.SetBallIndtance(ballInstance);
	}
	private void UpdateViewModel()
	{
		hpViewModel.fillAmount = lives / (float)maxLives;
	}
	public void ResetBall()
    {
        carrete.ResetBall();
        if (lives - 1 > 0)
        {
            lives--;
            UpdateViewModel();
            CreateBall();
            return;
        }
        gameOverScreen.SetActive(true);
    }
}
