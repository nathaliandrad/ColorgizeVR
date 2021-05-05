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
            explosion.SetActive(true);
            collision.gameObject.GetComponentInChildren<GameObject>().SetActive(false);
            collision.gameObject.GetComponent<Collider>().enabled = false;
            //ballPurple.SetActive(false);
            ballYellow.SetActive(false);
            gameObject.GetComponent<Collider>().enabled = false;
            

        }
    }
}
