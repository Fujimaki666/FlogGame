using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject SkullPrefab;
    float span = 1.0f;
    float delta = 0;
    // Start is called before the first frame update
    
    //�ǂ��낪�~���Ă���
    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = Instantiate(SkullPrefab);
            int px = Random.Range(-6, 7);
            go.transform.position = new Vector3(px, 14, 0);
        }

    }
}