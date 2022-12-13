using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShotPowerup : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.5f;
    [SerializeField]
    private AudioClip _clip;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            PlayerScr _player = other.gameObject.GetComponent<PlayerScr>();
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
            _player.TSPU();
        }
    }
}