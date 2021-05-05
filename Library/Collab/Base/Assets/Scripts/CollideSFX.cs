using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideSFX : MonoBehaviour
{
    public AudioClip collided;
    public AudioClip ukulele;
    public AudioClip rocket;
    public AudioClip fan;
    public AudioClip vinyl;
    public AudioClip car;
    public AudioClip radio;
    public AudioClip laptop;
    public AudioClip tv;
    public AudioClip basketball;
    public AudioClip bag;
    public AudioClip luggage;
    public AudioClip hanger;
    public AudioClip umbrella;
    public AudioClip lamp;
    public AudioClip alarm;
    public AudioClip darts;
    public AudioClip speaker;
    public AudioClip microwave;
    public AudioClip fridge;
    public AudioClip arcade;
    public AudioClip nintendo;
    public AudioClip clock;
    public AudioClip door;

    private void OnCollisionEnter(Collision collision)
    {
        if (!SetUpText.instance.gameHasEnded)
        {
            AudioSource.PlayClipAtPoint(collided, transform.position);
        }
        
        if(collision.collider.tag == "Ukulele")
        {
            AudioSource.PlayClipAtPoint(ukulele, transform.position);
        }

        if (collision.collider.tag == "Rocket")
        {
            AudioSource.PlayClipAtPoint(rocket, Camera.main.transform.position);
        }
        if (collision.collider.tag == "Fan")
        {
            AudioSource.PlayClipAtPoint(fan, Camera.main.transform.position);
        }
        if (collision.collider.tag == "Vinyl")
        {
            AudioSource.PlayClipAtPoint(vinyl, Camera.main.transform.position);
        }
        if (collision.collider.tag == "Car")
        {
            AudioSource.PlayClipAtPoint(car, Camera.main.transform.position);
        }
        if (collision.collider.tag == "Radio")
        {
            AudioSource.PlayClipAtPoint(radio, Camera.main.transform.position);
        }
        if (collision.collider.tag == "Laptop")
        {
            AudioSource.PlayClipAtPoint(laptop, Camera.main.transform.position);
        }
        if (collision.collider.tag == "TV")
        {
            AudioSource.PlayClipAtPoint(tv, Camera.main.transform.position);
        }
        if (collision.collider.tag == "Basketball")
        {
            AudioSource.PlayClipAtPoint(basketball, Camera.main.transform.position);
        }
        if (collision.collider.tag == "Bag")
        {
            AudioSource.PlayClipAtPoint(bag, Camera.main.transform.position);
        }
        if (collision.collider.tag == "Luggage")
        {
            AudioSource.PlayClipAtPoint(luggage, Camera.main.transform.position);
        }
        if (collision.collider.tag == "Hanger")
        {
            AudioSource.PlayClipAtPoint(hanger, Camera.main.transform.position);
        }
        if (collision.collider.tag == "Umbrella")
        {
            AudioSource.PlayClipAtPoint(umbrella, Camera.main.transform.position);
        }
        if (collision.collider.tag == "Lamp")
        {
            AudioSource.PlayClipAtPoint(lamp, Camera.main.transform.position);
        }
        if (collision.collider.tag == "Alarm")
        {
            AudioSource.PlayClipAtPoint(alarm, Camera.main.transform.position);
        }
        if (collision.collider.tag == "Darts")
        {
            AudioSource.PlayClipAtPoint(darts, Camera.main.transform.position);
        }
        if (collision.collider.tag == "Speaker")
        {
            AudioSource.PlayClipAtPoint(speaker, Camera.main.transform.position);
        }
        if (collision.collider.tag == "Microwave")
        {
            AudioSource.PlayClipAtPoint(microwave, Camera.main.transform.position);
        }
        if (collision.collider.tag == "Fridge")
        {
            AudioSource.PlayClipAtPoint(fridge, Camera.main.transform.position);
        }
        if (collision.collider.tag == "Arcade")
        {
            AudioSource.PlayClipAtPoint(arcade, Camera.main.transform.position);
        }
        if (collision.collider.tag == "Nintendo")
        {
            AudioSource.PlayClipAtPoint(nintendo, Camera.main.transform.position);
        }
        if (collision.collider.tag == "Clock")
        {
            AudioSource.PlayClipAtPoint(clock, transform.position);
        }
        if (collision.collider.tag == "Door")
        {
            AudioSource.PlayClipAtPoint(door, Camera.main.transform.position);
        }
    }
}
