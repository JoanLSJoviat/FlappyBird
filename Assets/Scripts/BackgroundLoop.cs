using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public GameObject prefabBackground; 
    public float speed = 2f; 
    private GameObject background1, background2; 
    public GameObject backgroundParent;
    public GameManager gm;

    void Start()
    {
       
        background1 = Instantiate(prefabBackground, new Vector3(0, 0, 0), Quaternion.identity, backgroundParent.transform);
        background2 = Instantiate(prefabBackground, new Vector3(prefabBackground.GetComponent<SpriteRenderer>().bounds.size.x, 0, 0), Quaternion.identity, backgroundParent.transform);
    }

    void Update()
    {
        if (gm.startGame)
        {
            background1.transform.position = new Vector3(background1.transform.position.x - speed * Time.deltaTime, 0, 0);
            background2.transform.position = new Vector3(background2.transform.position.x - speed * Time.deltaTime, 0, 0);

            
            if (background1.transform.position.x < -prefabBackground.GetComponent<SpriteRenderer>().bounds.size.x)
            {
                
                Destroy(background1);
                
                background1 = background2;
                background2 = Instantiate(prefabBackground, new Vector3(background1.transform.position.x + prefabBackground.GetComponent<SpriteRenderer>().bounds.size.x, 0, 0), Quaternion.identity, backgroundParent.transform);
            }
        }
    }
}