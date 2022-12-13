using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleLaser : MonoBehaviour
{
    [SerializeField]
    private float speed = 7.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        if (transform.position.y > 5.46f)
        {
            Destroy(this.gameObject);
        }
    }
}
