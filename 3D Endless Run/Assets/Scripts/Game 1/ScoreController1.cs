using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController1 : MonoBehaviour {

    private float score = 0f;
    public Text scoreText;
    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 10;
    private int scoreToNextLevel = 200;
    private PlayerController3 PC;
    public DeathMenu1 deathMenu;
    public GameObject scoreImage;

    private void Start()
    {
        // PlayerController2 is in the player2 *if use for children, it will choose the frist order.
        PC = GetComponent<PlayerController3>();
        scoreImage.SetActive(false);
    }

    // Update is called once per frame
    void Update ()
    {
        if (!PC.startScore)
            return;
        else
            scoreImage.SetActive(true);

        if (PC.isDead)
        {
            if(PlayerPrefs.GetFloat("highscore") < score)
                PlayerPrefs.SetFloat("highscore", score);
            deathMenu.ToggleEndMenu(score);
            return;
        }


        if (score > scoreToNextLevel)
            LevelUp();

        score += Time.deltaTime * 10 * difficultyLevel;
        scoreText.text = ((int)score).ToString();
	}

    private void LevelUp()
    {
        if (difficultyLevel >= maxDifficultyLevel)
        {
            return;
        }
        difficultyLevel++;
        scoreToNextLevel *= 2;

        GetComponent<PlayerController3>().Setspeed(difficultyLevel);
    }
}
