using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] lifeArray = new GameObject[3];
    private int lifePoint = 3;

    void Update()
    {

        // if (Input.GetMouseButtonDown(1) && lifePoint > 0)
       
    }
    public void DecreaseHp()
    {
        if ( lifePoint > 0)
        {
            lifeArray[lifePoint - 1].SetActive(false);
            lifePoint--;
        }
        if(lifePoint==0)
        {
            SceneManager.LoadScene("Gameover");
        }
    }
}
