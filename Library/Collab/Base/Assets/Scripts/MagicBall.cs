using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBall : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    public GameObject ballYellow;
    public GameObject ballPurple;
    

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "RBall")
        {
            ballPurple.SetActive(false);
            ballYellow.SetActive(false);
            explosion.SetActive(true);
         
        }
    }
}
