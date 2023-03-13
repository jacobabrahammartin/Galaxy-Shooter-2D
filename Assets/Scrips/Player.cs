using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    [SerializeField]
    private float speed = 3.5f;
    [SerializeField]
    private GameObject lazerPrefab;

    public float horizontalInput;
    public float verticalInput;
    [SerializeField]
    private float fireRate = 0.5f;
   
    public float canFire = -1f;

    [SerializeField]
    private int lives = 3;
    private SpawnManager spawnManager;

    // Start is called before the first frame update
    void Start()
    {
       //take the current position = new position (0, 0, 0)
        transform.position = new Vector3(0 , 0, 0);
        //find the object. Get the compoent
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<Transform>();
        spawnManager.OnPlayerDeath

        if (spawnManager == null)
        {
            Debug.LogError("The Spawn Mnanger is Null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalulateMovement();

        //if i hit the space
        // spawn gameObject
        //Time.time is how long has been runnning nextFire =

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > canFire)
        {
            FireLazer();
        }
    }
    
    
    
    void CalulateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); 
        float verticalInput = Input.GetAxis("Vertical");

                      //new Vector3(1, 0, 0) * 0 * real time
       //transform.Translate(Vector3.left * horizontalInput *speed * Time.deltaTime);
       //transform.Translate(Vector3.up * verticalInput * speed * Time.deltaTime);

       transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * speed * Time.deltaTime); 

       //if player position on the y is greater than 0
       //y posin = 0
       // else if position on the y is less than -3.8f
       //y pos = -3.8f

       if (transform.position.y > 0)
       {
           transform.position = new Vector3(transform.position.x, 0 ,0);
       }
       else if (transform.position.y <= -3.8f)
       {
            transform.position = new Vector3(transform.position.x, -3.8f, 0);

       }

       //if player on the x > 11
       //x pos = -11
       //else if player on the x is less thatn -11
       //x pos = 11

        if (transform.position.x > 11.3f)
       {
           transform.position = new Vector3(-11.3f, transform.position.y, 0 );
       }
       else if (transform.position.x < -11.3f)
       {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
       }    
    }
    void FireLazer()
    {
        canFire = Time.time + fireRate;
            Instantiate(lazerPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
    }

    publi9c void Damage()
    {
        lives--;

        if (lives < 1)
        {
            //Communicate with Spawn Manager
            spawnManager.OnPlayerDeath;
            SpawnMananger spawnMananger = //Find the GameObject then GetComponent
            //Let them know to stop spawning
            Destroy(this.gameObject);
        }
    }
}


