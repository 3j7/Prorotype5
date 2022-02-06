using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{  
    public int pointValue;
    
    private float xRange = 4;
    private float maxSpeed= 15;
    private float minSpeed = 10;
    private float maxTorgue= 10;
    private float ySpawnPos = -2;
   

    private Rigidbody targetRb;
    private GameManager gameManager;
    public ParticleSystem explosionParticle;
  
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRb = GetComponent<Rigidbody>();       
        ProopsSpawn();
    } 
    void ProopsSpawn()
    {
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorgue(), RandomTorgue(), RandomTorgue(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }
    float RandomTorgue()
    {
        return Random.Range(-maxTorgue, maxTorgue);
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
   
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
        Destroy(gameObject);
        gameManager.ScoreUpdate(pointValue);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }    
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
        

    }
}
