using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelotaController : MonoBehaviour
{
	Rigidbody2D rb;
	Vector2 startPosition;
	public float speed;
	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		Invoke("GameStart", 3.5f);
	}
	//TODO: hacer que funcione con el boton que le dara inicio.
	public void GameStart()
	{
		startPosition = transform.position;
		Invoke("Lauch", 2);
	}
	public void Lauch()
	{
		float x = Random.Range(0, 2);
		float y = Random.Range(0, 2);

		x = x == 0 ? -1 : x;
		y = y == 0 ? -1 : y;

		rb.velocity = new Vector2(speed * x, speed * y);
	}
	public void ResetPelota()
	{
		rb.velocity = Vector2.zero;
		transform.position = startPosition;
		Lauch();
		Invoke("Lauch", 0);
	}
	public void StopPelota()
	{
		rb.velocity = Vector2.zero;
		transform.position = startPosition;
	}
}
