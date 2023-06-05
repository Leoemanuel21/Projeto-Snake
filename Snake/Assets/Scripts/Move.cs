using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
	[SerializeField] Vector2 direction; // direção da cobra
	[SerializeField] List<Transform> snakeBody; //Criando uma lista
	[SerializeField] Transform body;
	GameManager gM;

	private void Start()
	{
		gM = FindObjectOfType<GameManager>();
		snakeBody = new List<Transform>();
		snakeBody.Add(transform); //Add primeiro elemento

		/*gM.hScore = PlayerPrefs.GetInt("HScore");
		gM.hScoreText.text = "H-score: " + gM.hScore.ToString();*/

	}
	private void Update()
	{
		float xAxis = Input.GetAxisRaw("Horizontal"); //Movimentação do eixo x
		float yAxis = Input.GetAxisRaw("Vertical"); //Movimentação do eixo y

		if (xAxis != 0)
		{
			direction = Vector2.right * xAxis; // variavel direction vai receber 1, -1 e 0
		}

		if (yAxis != 0)
		{
			direction = Vector2.up * yAxis; // variavel direction vai receber 1, -1 e 0
		}
	}

	/*para que a cobra se mova em uma taxa fixa de quadros*/
	private void FixedUpdate()
	{
		for (int i = snakeBody.Count - 1; i > 0; i--)
		{
			snakeBody[i].position = snakeBody[i - 1].position;

		}

		MoveSnake();
	}

	void MoveSnake()
	{
		/*A cobra ira se movimentar em uma em uma unidade*/
		float roundPosX = Mathf.Round(transform.position.x); //Redondando a posição x(atual) para o seu inteiro mais proximo
		float roundPosY = Mathf.Round(transform.position.y); //Redondando a posição y(atual) para o seu inteiro mais proximo

		/*Atualizar a posição*/
		transform.position = new Vector2(roundPosX + direction.x, roundPosY + direction.y); //posição a redondada + direção que a cobra ira no eixo x, mesma coisa no eixo y
	}

	void GrowingSnake() // Método de crescimento da cobra
	{
		Transform SpawnBody = Instantiate(body, snakeBody[snakeBody.Count - 1].position, Quaternion.identity); //Variavel ira receber o método de instanciar objetos
		snakeBody.Add(SpawnBody); //Adicionar o elemento na lista
		//gM.SetScore(10);
	}

	//Restar fase
	public void BtnStartGame()
    {
		gM.gameOverPanel.SetActive(false);
		Time.timeScale = 1;
		transform.position = Vector2.zero;
		direction = Vector2.zero;
		for(int i=1; i < snakeBody.Count; i++)
        {
			Destroy(snakeBody[i].gameObject);
        }
		snakeBody.Clear();
		snakeBody.Add(transform);

		/*gM.score = 0;
		gM.scoreText.text = "Score: 0";

		gM.hScore = PlayerPrefs.GetInt("HScore");
		gM.hScoreText.text = "H-score: " + gM.hScore.ToString();*/
	}

	//verificar a colisão com a comida
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Food"))
		{
			GrowingSnake();
		}
		if (collision.CompareTag("Obstacle"))
        {
			gM.GamerOver();
		}
	}
}