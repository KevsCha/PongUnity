using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using JetBrains.Annotations;

public class InicioController : MonoBehaviour
{
	public int inGame = 0;
	public RectTransform menuBtn_solo;
	public RectTransform menuBtn_mult;
	public GameObject btnPrincipal;
	public GameObject btnOption;
	public float posX;
	public float posY;
	public float btn2_pos;
	public Vector3 posInit;
	public bool active = false;
	public float time = 0.5f;
	private void Awake()
	{
		btnPrincipal = GameObject.Find("Inicio");
		btnOption = GameObject.Find("Option");
		menuBtn_solo = GameObject.Find("Solo").GetComponent<RectTransform>();
		menuBtn_mult = GameObject.Find("Multiplayer").GetComponent<RectTransform>();
		posX = btnPrincipal.transform.position.x;
	}
	public void MoverMenu(float time, Vector3 posInitSingle, Vector3 posInitMult, Vector3 posFin, Vector3 posFinMult)
	{
		StartCoroutine(Mov(time, posInitSingle, posInitMult, posFin, posFinMult));
	}
	public void OcultarMenu(float time, Vector3 posFInSingle, Vector3 posFinMult, Vector3 posFin, Vector3 pos)
	{
		StartCoroutine(Mov(time, posFInSingle, posFinMult, posFin, posFin));
	}
	IEnumerator Mov(float time, Vector3 posInitSingle, Vector3 posInitMult, Vector3 posFin, Vector3 posFinMult)
	{
		float elTime = 0;

		while (elTime < time)
		{
			menuBtn_solo.position = Vector3.Lerp(posInitSingle, posFin, (elTime / time));
			menuBtn_mult.position = Vector3.Lerp(posInitMult, posFinMult, (elTime / time)); ;
			elTime += Time.deltaTime;
			yield return null;
		}
		menuBtn_solo.position = posFin;
		menuBtn_mult.position = posFinMult;
		active = !active;
	}
	public void SinglePlayer()
	{
		inGame = 1;
		CambiarLevel();
	}
	//TODO: Añadir la opcion para poder jugar contra la IA
	public void MultiPlayer()
	{
		inGame = 2;
		PlayerPrefs.SetInt("Player2", 2);
		CambiarLevel();
	}

	private void CambiarLevel()
	{
		SceneManager.LoadScene(1);
	}
	//TODO: hacer un menu desplegable
	public void Menu()
	{

		posInit = btnPrincipal.transform.position;
		posY = btnOption.transform.position.y;
		if (active == false)
			MoverMenu(time, posInit, posInit, new((posX / 2), menuBtn_solo.position.y, 0), new((posX / 2), posY, 0));
		if (active)
			OcultarMenu(time, menuBtn_solo.position, menuBtn_mult.position, posInit, posInit);
	}
	public void Salir()
	{
		Application.Quit();
	}
}
