using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScr : MonoBehaviour
{
    private float Xmin = -2.5f;
    private float Xmax = 2.5f;
    [SerializeField]
    private float Speed = 5.5f;
    private PlayerScr _player;
    [SerializeField]
    private GameObject _enemyExplosionPrefab;
    [SerializeField]
    private AudioClip _clip;
    [SerializeField]
    private GameObject _enemyLaserPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawningEnemyLaser());
        _player = GameObject.Find("player_ship").GetComponent<PlayerScr>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Speed * Time.deltaTime);
        if (transform.position.y < -5.6f)
        {
            transform.position = new Vector2 (Random.Range(Xmin,Xmax),5.7f);
            //Destroy(this.gameObject);//optional
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
           PlayerScr _player = other.gameObject.GetComponent<PlayerScr>();
            _player.Damage();
            Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
            Destroy(this.gameObject);
        }
        else if (other.gameObject.tag == "Laser")
        {
            Destroy(other.gameObject);
            Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
            Destroy(this.gameObject);
            _player.addScore();
        }
    }

    IEnumerator StartSpawningEnemyLaser()
    {
        while (true)
        {
            Vector2 pos = new Vector2(transform.position.x, transform.position.y);
            Instantiate(_enemyLaserPrefab, pos , Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
    }
}