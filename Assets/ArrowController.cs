using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {   //óéâ∫Ç∑ÇÈÇ«Ç≠ÇÎÇè¡Ç∑
        transform.Translate(0, -0.03f, 0);

        if (transform.position.y < -8.0f)
        {
            Destroy(gameObject);
        }
        
    }
    
}
