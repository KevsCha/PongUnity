using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
	public float speed;
	public float move;
	public bool start = false;
	[SerializeField] int idPlayer;

	Rigidbody2D rb;
	Vector2 startPosition;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	private void Start()
	{
		startPosition = this.transform.position;
	}
	private void Update()
	{
		if (idPlayer == 1)
			move = Input.GetAxisRaw("Vertical1");
		if (idPlayer == 2)
			move = Input.GetAxisRaw("Vertical2");
		rb.velocity = new Vector2(rb.velocity.x, move * speed);
	}
	public void ResetPlayer()
	{
		rb.velocity = Vector2.zero;
		this.gameObject.transform.position = startPosition;
	}
	public void StopPlayer()
	{
		rb.velocity = Vector2.zero;
		this.gameObject.transform.position = startPosition;
	}
}
