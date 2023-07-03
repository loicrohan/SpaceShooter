using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScr : MonoBehaviour
{
    [SerializeField]
    private float speed = 4.0f;
    private float HorizInput;
    private float VertInput;
    private float Xmin = -3.93f;
    private float Ymin = -4.456f;
    private float Xmax = 3.93f;
    private float Ymax = -1.75f;
    
    [SerializeField]
    private GameObject laserPrefab;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    
    [SerializeField]
    private GameObject[] _engines;
    private float _fireRate = 0.5f;
    private float _canFire = 0.0f;
    public float _lives = 9f;
    private float _score = 0f;
    private ScoreManager _scoreManager;
    
    [SerializeField]
    private GameOver _gameOver;
    public bool canTripleShot = false;
    public bool shieldsActive = false;
    [SerializeField]
    private GameObject _shieldGameObject;
    private AudioSource _audioSource;
    private int hitCount = 0;

    void Awake()
    {
        _scoreManager = GameObject.Find("ScoreCanvas").GetComponent<ScoreManager>();
    }


    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _lives = 9f;
        hitCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Boundary();
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0) /*&& Time.time > _canFire*/)
        {
            InstantiateLaser();
        }
    }

    void Movement()
    {
        HorizInput =Input.GetAxisRaw("Horizontal");
        VertInput=Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2 (HorizInput,VertInput);
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void Boundary()
    {
        if(transform.position.x > Xmax)
        {
            transform.position = new Vector2 (Xmin,transform.position.y);
        }
        else if (transform.position.x < Xmin)
        {
             transform.position = new Vector2 (Xmax, transform.position.y);
        }
        else if (transform.position.y > Ymax)
        {
            transform.position = new Vector2 (transform.position.x, Ymax);
        }
        else if (transform.position.y < Ymin)
        {
            transform.position = new Vector2 (transform.position.x, Ymin);
        }
    }

    void InstantiateLaser()
    {
        if (Time.time > _canFire)
        {
            _audioSource.Play();
            if (canTripleShot == true)
            {
                Instantiate(_tripleShotPrefab, new Vector2(transform.position.x, transform.position.y + 0.75f), Quaternion.identity);
            }
            else
            {
                Instantiate(laserPrefab, new Vector2(transform.position.x, transform.position.y + 0.75f), Quaternion.identity);
            }
            _canFire = Time.time + _fireRate;
        }
    }

    public void Damage()
    {
        if (shieldsActive == true)
        {
            shieldsActive = false;
            _shieldGameObject.SetActive(false); 
            return;
        }

        hitCount++;

        if (hitCount == 3)
        {
            _engines[0].SetActive(true);
        }
        else if (hitCount == 6)
        {
            _engines[1].SetActive(true);
        }

        _lives--;
        HealthBar.health -= 1f;
        Debug.Log("No of Lives : " + _lives);
        if (_lives < 1)
        {
            Debug.Log("Game Over");
            _gameOver.SetGameOver();
            Destroy(this.gameObject);
        }
    }

    public void addScore()
    {
        _score += 10;
        //Debug.Log("Score : " + _score);
        _scoreManager.UpdateScore(_score);    
    }

    public void TSPU()
    {
        canTripleShot = true;
        StartCoroutine(TSPD());
    }

    public IEnumerator TSPD()
    {
        yield return new WaitForSeconds(15f);
        canTripleShot = false;
    }

    public void SPU()
    {
        shieldsActive = true;
        _shieldGameObject.SetActive(true);
    }
}