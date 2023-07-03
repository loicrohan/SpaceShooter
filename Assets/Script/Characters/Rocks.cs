using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : MonoBehaviour
{
    private float Xmin = -2.5f;
    private float Xmax = 2.5f;
    [SerializeField]
    private float Speed = 8.5f;
    private PlayerScrRock _player;
    [SerializeField]
    private GameObject _enemyExplosionPrefab;
    [SerializeField]
    private AudioClip _clip;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("player_ship").GetComponent<PlayerScrRock>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Speed * Time.deltaTime);
        if (transform.position.y < -5.6f)
        {
            transform.position = new Vector2(Random.Range(Xmin, Xmax), 5.7f);
            //Destroy(this.gameObject);//optional
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerScrRock _player = other.gameObject.GetComponent<PlayerScrRock>();
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
}