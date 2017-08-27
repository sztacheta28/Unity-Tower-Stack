using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
	public Text scoreText;

	private void Start(){
		scoreText.text = PlayerPrefs.GetInt ("score").ToString();
        MusicPlayer.instance.UnPauseMusic();
	}

	public void ToGame(){
        print("Load level Game");
		SceneManager.LoadScene ("1_Game");
	}
}
