using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

    public Text scoreText;
    public Image bgImage;
    private float transition;
    private bool isShowed;

	// Use this for initialization
	void Start () {
        //bgImage = GetComponent<Image>();
        gameObject.SetActive(false);
	}

    private void Update()
    {
        if (!isShowed)
        {
            return;
        }
        transition += Time.deltaTime * 2;
        bgImage.color = Color.Lerp(new Color(0, 0, 0, 0), new Color(0.8f, 0.8f, 0.8f, 1), transition);
    }

    public void ToggleEndMenu(float score)
    {
        gameObject.SetActive(true);
        scoreText.text = ((int)score).ToString();
        isShowed = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu 1");
    }
}
