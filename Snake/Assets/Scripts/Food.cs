using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
	public float rotationSpeed = 10f;
	[SerializeField] BoxCollider2D spawArea; //colisor

	private void Start()
    {
		RandomPoitionFood();
	}

	void Update()
	{
        if (Input.GetKey(KeyCode.I))
        {
			transform.Translate(0, 5 * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.Q))
        {
			transform.localScale = new Vector3(5, 5, 5);
        }
		if (Input.GetKey(KeyCode.E))

		{
			transform.localScale = new Vector3(1, 1, 1);
		}
		transform.Rotate(0, 0, 1); //Isso fará com que o objeto gire em torno do eixo Z
	}
	public void RandomPoitionFood()
	{
		Bounds bounds = spawArea.bounds; //Bounds variavel tipo limite. bounds está recebendo o limite da caixa

		Vector2 randomArea = new Vector2(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y)); //criando uma variavel do tipo area, que está pegando os limites min e max da caixa colisora, para que aproxima comida apareca em um local aleatoria da caixa

		/*A redondando a posição da comida*/
		float roundXPos = Mathf.Round(randomArea.x);
		float roundYPos = Mathf.Round(randomArea.y);

		transform.position = new Vector2(roundXPos, roundYPos); //Atualizando a nova posição da comida
	}

	/*Verificando se a colisão do objeto com outro objeto*/
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
        {
			RandomPoitionFood();
		}
	}
}