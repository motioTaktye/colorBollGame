using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
	[SerializeField]
	private float fadeSecond;
	[SerializeField]
	private Image fadeImage;

	private bool fade;
	private bool fadeIn;
	private float fadeSpeed;
	private int beforScene;
	private int nowScene;

	private void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
		fade = true;
		fadeIn = true;
	}

	private void Start()
	{
		fadeSpeed = 1.0f / (fadeSecond * 60.0f);
	}

	private void Update()
	{

		// fade
		if (fade != true)
		{
			return;
		}

		Color color = fadeImage.color;

		if (fadeIn)
		{
			color.a -= fadeSpeed;

			if (color.a <= 0.0f)
			{
				color.a = 0.0f;
				fade = false;
				fadeIn = false;
			}

		}
		else
		{
			color.a += fadeSpeed;

			if (color.a >= 1.0f)
			{
				color.a = 1.0f;
				fadeIn = true;
				SceneManager.LoadScene(nowScene);
			}
		}

		fadeImage.color = new Color(color.r, color.g, color.b, color.a);

	}

	public void SceneChange(int sceneNumber)
	{
		beforScene = nowScene;
		nowScene = sceneNumber;
		fade = true;
		fadeIn = false;
	}

	public bool isFade()
	{
		return fade;
	}

	public bool isFadeIn()
	{
		return fadeIn;
	}
}
