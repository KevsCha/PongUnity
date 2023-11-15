using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
	[SerializeField] GameObject bola;
	[SerializeField] GameObject player1;
	[SerializeField] GameObject player2;
	[SerializeField] GameObject iaController;
	[SerializeField] GameObject gloa1;
	[SerializeField] GameObject gloa2;
	[SerializeField] TextMeshProUGUI cont;
	[SerializeField] TextMeshProUGUI t_puntos_play1;
	[SerializeField] TextMeshProUGUI t_puntos_play2;
	[SerializeField] ExitGame gameOption;
	public GameObject exitGame;
	public int puntos1;
	public int puntos2;
	public float i;
	public bool start = true;

	private void Awake()
	{
		if (PlayerPrefs.HasKey("Player2"))
			player2.GetComponent<IaController>().enabled = false;
		else
			player2.GetComponent<Player1Controller>().enabled = false;
	}
	public void Player1Scored()
	{
		puntos1++;
		t_puntos_play1.text = puntos1.ToString();
		ResetAll();
	}
	public void Player2Scored()
	{
		puntos2++;
		t_puntos_play2.text = puntos2.ToString();
		ResetAll();
	}
	private void ResetAll()
	{
		bola.GetComponent<PelotaController>().ResetPelota();
		player1.GetComponent<Player1Controller>().ResetPlayer();
		player2.GetComponent<Player1Controller>().ResetPlayer();
		iaController.GetComponent<IaController>().ResetIa();

	}
	public void Win()
	{
		if (puntos1 == 7 || puntos2 == 7)
			Stop();
	}

	public void Stop()
	{
		exitGame.SetActive(true);
		bola.GetComponent<PelotaController>().StopPelota();
		player1.GetComponent<Player1Controller>().StopPlayer();
		if (cont.GetComponent<TextMeshProUGUI>().IsActive() == false)
		{
			cont.GetComponent<TextMeshProUGUI>().enableAutoSizing = true;
			cont.GetComponent<TextMeshProUGUI>().enabled = true;
			if (puntos1 > puntos2)
				cont.text = "Gana Jugador 1";
			if (puntos2 > puntos1)
				cont.text = "Gana Jugador 2";
			if (puntos2 == puntos1)
				cont.text = "Empate";
		}
	}
	void Update()
	{
		if (start == true)
		{
			if (i <= 0 && cont.GetComponent<TextMeshProUGUI>().IsActive() == true)
			{
				start = false;
				cont.GetComponent<TextMeshProUGUI>().enabled = false;
			}
			i -= Time.deltaTime;
			cont.text = i.ToString($"F{0}");
		}
		Win();
		if (Input.GetKeyDown(KeyCode.P))
			Stop();
	}
	public void ResetPlay()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	public void Salir()
	{
		SceneManager.LoadScene(0);
	}
}
