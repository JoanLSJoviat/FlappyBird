using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public GameObject prefabBackground; // El prefab del fondo
    public float speed = 2f; // La velocidad de movimiento del fondo
    private GameObject background1, background2; // Los dos fondos
    public GameObject backgroundParent;
    public GameManager gm;

    void Start()
    {
        // Instanciamos los dos fondos
        background1 = Instantiate(prefabBackground, new Vector3(0, 0, 0), Quaternion.identity, backgroundParent.transform);
        background2 = Instantiate(prefabBackground, new Vector3(prefabBackground.GetComponent<SpriteRenderer>().bounds.size.x, 0, 0), Quaternion.identity, backgroundParent.transform);
    }

    void Update()
    {
        if (gm.startGame)
        {
            background1.transform.position = new Vector3(background1.transform.position.x - speed * Time.deltaTime, 0, 0);
            background2.transform.position = new Vector3(background2.transform.position.x - speed * Time.deltaTime, 0, 0);

            // Si el primer fondo ha salido completamente de la pantalla...
            if (background1.transform.position.x < -prefabBackground.GetComponent<SpriteRenderer>().bounds.size.x)
            {
                // Lo destruimos
                Destroy(background1);

                // Y el segundo fondo pasa a ser el primero
                background1 = background2;

                // Y creamos un nuevo segundo fondo a la derecha del primero
                background2 = Instantiate(prefabBackground, new Vector3(background1.transform.position.x + prefabBackground.GetComponent<SpriteRenderer>().bounds.size.x, 0, 0), Quaternion.identity, backgroundParent.transform);
            }
        }
    }
}