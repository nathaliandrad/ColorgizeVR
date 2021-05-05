﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClockRotation : MonoBehaviour
{
    const float REAL_SEC_PER_INGAME_DAY = 60;
    public Transform hourClockHandTransform;
    public Transform minuteClockHandTransform;
    public Transform secondClockHandTransform;
    float day;
    GameObject bedLight, mainLight, windowLight,windowLightR,behingClock;
    public List<GameObject> partsOfClock = new List<GameObject>();
    int count;
    public Material currentMaterial;
    public Material blue2, blue3, blue4,blue5,blue6;
    bool isYellow, isGreen, isBlue;
    int countLerpColor;
    bool collided;
    bool keepStill = false;
    public AudioSource speaker;
    public AudioSource startMusicSpeaker;
    public Material defaultLight;
    public Material myWhite;
    public GameObject mainClock;
    public GameObject handClock;
    public Renderer[] piecesOfClock;
    public Material neonBlue;
    public Material lightOrange;
    public GameObject backClock;


    public void Awake()
    {
        hourClockHandTransform = transform.Find("hourHand");
        minuteClockHandTransform = transform.Find("minuteHand");
        secondClockHandTransform = transform.Find("secondHand");

    }

    public void Start()
    {
        hitText.text = "HIT\nME";
        countDownText.text = "";
        GettingLights();
        countLerpColor = 0;
        count = 0;
        StartCoroutine(CheckClock());
        countClockSound = 0;


    }

    public void GettingLights()
    {
        bedLight = GameObject.Find("prop_bed_table_lamp(light)");
        mainLight = GameObject.Find("00_Room_light");
        windowLight = GameObject.Find("01_wall(light)002");
        windowLightR = GameObject.Find("01_wall(light)0022");
        behingClock = GameObject.Find("BehindClock");
    }

    public void StartGame()
    {

        SetUpText.instance.canStartColoring = true;
        // SetUpText.instance.clockCanStart = true;
        SetUpText.instance.gameCanStart = true;
        speaker.Play();
        // SetUpText.instance.defaultWhite.color = Color.white;
        collided = true;
        keepStill = true;
    }

    // -------              CLOCK STUF     -----------
    public IEnumerator CheckClock()
    {
        while (!keepStill)
        {
            yield return new WaitForSeconds(0.2f);
        }

        
        StartCoroutine(StartMyClock());

        yield return null;


    }

    public IEnumerator StartMyClock()
    {
        while (collided)
        {
            RunClock();
            
            StartCoroutine(ChangePieceColor());
            yield return null;
        }
        
        yield return null;
    }

    public void RunClock()
    {
        if (!SetUpText.instance.gameHasEnded)
        {
            day += Time.deltaTime / REAL_SEC_PER_INGAME_DAY;
            float dayNormalized = day % 1;

            float rotationDegree = 360f;
            hourClockHandTransform.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegree);

            float hoursPerDay = 12f;
            minuteClockHandTransform.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegree * hoursPerDay);

            float seconds = 30f;
            secondClockHandTransform.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegree * seconds);

        }

    }

    public IEnumerator ChangePieceColor()
    {

        if (count == 0)
        {
            yield return new WaitForSeconds(5f);

            for (int i = 0; i < partsOfClock.Count; i++)
            {

                partsOfClock[i].GetComponent<Renderer>().material = blue2;
                yield return new WaitForSeconds(6f);

            }
            count = 1;
        }

        if (count == 1)
        {

            for (int i = 0; i < partsOfClock.Count; i++) 
            {
                partsOfClock[i].GetComponent<Renderer>().material = blue3;
                yield return new WaitForSeconds(6f);


            }
            count = 2;
        }

        if (count == 2)
        {

            for (int i = 0; i < partsOfClock.Count; i++)
            {
                partsOfClock[i].GetComponent<Renderer>().material = blue4;
                yield return new WaitForSeconds(6f);


            }
            count = 3;
        }

        if (count == 3)
        {

            for (int i = 0; i < partsOfClock.Count; i++)
            {
                partsOfClock[i].GetComponent<Renderer>().material = blue5;
                yield return new WaitForSeconds(6f);


            }
            count = 4;
        }

        if (count == 4)
        {

            for (int i = 0; i < partsOfClock.Count; i++)
            {
                partsOfClock[i].GetComponent<Renderer>().material = blue6;
                yield return new WaitForSeconds(6f);


            }
            count = 5;
        }
    }

    // --------       CLOCK END    -----------

    // -------- MATERIALS OF LIGHT AND WHITE MATERIAL --------

    public IEnumerator LerpGrayToWhite()
    {
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime / 6;
            SetUpText.instance.defaultWhite.color = Color.Lerp(Color.black, Color.white, t);
            yield return null;
        }
        SetUpText.instance.defaultWhite.color = Color.white;
        MakeLightsWhite();
        
    }



    public void MakeLightsWhite()
    {
        bedLight.GetComponent<Renderer>().material = defaultLight;
        mainLight.GetComponent<Renderer>().material = defaultLight;
        windowLight.GetComponent<Renderer>().material = defaultLight;
        windowLightR.GetComponent<Renderer>().material = defaultLight;
    }



    //  -------- COLLISION ---------
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball") || collision.gameObject.CompareTag("RBall"))
        {
            
            if (countLerpColor == 0)
            {
                MaterialToClock();
                StartCoroutine(LerpGrayToWhite());
                StartCoroutine(CountDown());
                countLerpColor++;
            }
            //StartGame();
        }
    }

    
    public void MaterialToClock()
    {
        mainClock.GetComponent<Renderer>().material = SetUpText.instance.roomMaterial;
        handClock.GetComponent<Renderer>().material = SetUpText.instance.roomMaterial;
        backClock.GetComponent<Renderer>().material = lightOrange;

        foreach (Renderer rendChild in piecesOfClock)
        {
            //sticky.gameObject.GetComponent<Renderer>().material = roomMaterial;
            rendChild.material = neonBlue;
            rendChild.material.EnableKeyword("_EMISSION");
        }

    }

    public AudioClip three, two, one, go, getReady,bellSound;
    public TMP_Text countDownText;
    public TMP_Text hitText;
    public TMP_Text gameNameText;
    int countClockSound;
    public Light clockLight;
    public Animator hitMeAnim;

    public IEnumerator CountDown()
    {
        startMusicSpeaker.Stop();
        hitMeAnim.SetBool("HitMeFade", true);
        //hitText.text = "";

        if (countClockSound < 1) {
             countClockSound++;
            clockLight.enabled = false;
            gameNameText.text = "";
            //hitting sound on the clock - bell sound
            speaker.PlayOneShot(bellSound, 1);
            yield return new WaitForSeconds(1f);
            //get ready sound
            speaker.PlayOneShot(getReady, 1);
            yield return new WaitForSeconds(1.5f);
            //3
            speaker.PlayOneShot(three, 1);
            countDownText.text = "3";
            yield return new WaitForSeconds(0.8f);
            //2
            speaker.PlayOneShot(two, 1);
            countDownText.text = "2";
            yield return new WaitForSeconds(0.8f);
            //1
            speaker.PlayOneShot(one, 1);
            countDownText.text = "1";
            yield return new WaitForSeconds(0.8f);
            //GET READY SOUND
            speaker.PlayOneShot(go, 1);
            countDownText.text = "GO";
            yield return new WaitForSeconds(1.5f);
            //count down text
            countDownText.text = "";
           
            
            StartGame();
        }

     

        
    }




}
