using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

    Text highscore;
	void Start () {
        highscore = GetComponent<Text>();
        highscore.text = "Puntaje Maximo:" + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
	
	void Update () {
        if (Score.scorevalue > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", Score.scorevalue);
            highscore.text = "Puntaje Maximo:" + PlayerPrefs.GetInt("HighScore", 0).ToString();
        }	
	}

}
