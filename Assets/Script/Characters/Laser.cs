using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float Speed = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      transform.Translate(Vector2.up * Speed * Time.deltaTime); 
      if (transform.position.y > 5.46f)
      {
            Destroy(this.gameObject);
      }
    }
}
