using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPUR : MonoBehaviour
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
            PlayerScrRock _player = other.gameObject.GetComponent<PlayerScrRock>();
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
            _player.SPU();
        }
    }
}
