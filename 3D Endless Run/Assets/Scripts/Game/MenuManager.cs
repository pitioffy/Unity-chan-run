using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public Text highscoreText;

	// Use this for initialization
	void Start () {
        highscoreText.text = "Highcore : " + ((int)PlayerPrefs.GetFloat("highscore")).ToString();
    }

    public void ToGame()
    {
        SceneManager.LoadScene("Game");
    }
}
