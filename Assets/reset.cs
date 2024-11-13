using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class reset : MonoBehaviour
{
    //public AudioClip GameOver;
   // AudioSource aud;
    // Start is called before the first frame update
    void Start()
    {
        //this.aud = GetComponent<AudioSource>();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonC()
    {
        SceneManager.LoadScene("GameScene");
    }
}
