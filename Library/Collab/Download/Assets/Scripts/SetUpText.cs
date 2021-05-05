using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SetUpText : MonoBehaviour
{

    // GM SCRIPT

    public Color goodWhite;
    public Color lowWhite;
    public Color darkColorRoom;
    public static SetUpText instance;
    public Material roomMaterial,darkerMaterial,darkRed,darkYellow,darkOrange,darkGreen,darkBabyGreen,darkBrownGreen,darkLightBrown,darkWindowCurtain,darkGray,darkNitendo,darkPlantPot,darkBlue,darkGrey,darkBrown;
    public bool gameHasEnded;
    public GameObject finalShow;
    public Animator anim;
    public bool gameCanStart;
    public bool canStartColoring;
    public bool clockCanStart;

    public Material defaultWhite;
    public Material defaultLight;
    public Material grayLight;

    public List<GameObject> notYetCollided = new List<GameObject>();
    public List<Renderer> allItemsGameObject = new List<Renderer>();
    public List<Animator> allObjectsAnimator = new List<Animator>();
    public Material arcade, cat, invader, man, robot1, robot2;
    public AudioSource youWinSpeaker;
    public AudioSource shutdownSpeaker;
    public AudioSource speaker;
    public AudioClip tenToGoClip;
    public AudioSource raspberrySource;

    public Animator endingAnim;
    

    private void Awake()
    {
        instance = this;
    }

    public TMP_Text itemsText;

    public int numOfItems;
    // Start is called before the first frame update
    void Start()
    {

        winText.SetActive(false);
        clockCanStart = false;
        canStartColoring = false;
       
        defaultWhite.color = Color.black;
        gameCanStart = false;
        numOfItems = 0;
        gameHasEnded = false;
        darkerMaterial.color = Color.white;
        AllDarkLightsDeactivated();
        StartCoroutine(Tracking());
    }
    void Update()
    {
        SetUpCountText();
    }

    public void AllDarkLightsDeactivated()
    {
        mainLightDark.SetActive(false);
        bedLightDark.SetActive(false);
        outsideLightLeftLightDark.SetActive(false);
        outsideRightLightDark.SetActive(false);
        darkScreenTv.SetActive(false);
        darkScreenArcade.SetActive(false);
    }

    
    public IEnumerator Tracking()
    {
        int count = 0;
        while (numOfItems < 120)
        {
            yield return new WaitForSeconds(0.2f);
            if(numOfItems == 110)
            {
                if (count < 1)
                {
                    speaker.PlayOneShot(tenToGoClip, 1);
                    count++;
                }
                
            }
        }
        AnimationListFalse();
        finalShow.SetActive(true);
       
    }
    //turning all animations false
    public void AnimationListFalse()
    {
        for(int i = 0; i < allObjectsAnimator.Count; i++)
        {
            allObjectsAnimator[i].SetBool("colliding", false);
        }
    }
    //turning all animations true
    public void AnimationListTrue()
    {
        for (int i = 0; i < allObjectsAnimator.Count; i++)
        {
            allObjectsAnimator[i].SetBool("colliding", true);
        }
    }
    public Material myBlackMaterial;
    public GameObject mainLightDark, bedLightDark, outsideLightLeftLightDark, outsideRightLightDark,darkScreenTv,darkScreenArcade;
    public IEnumerator MakeAllMaterialsBlack()
    {
        shutdownSpeaker.Play();
        for (int i = 0; i< allItemsGameObject.Count; i++)
        {
            yield return new WaitForSeconds(RandomSeconds());
            
            allItemsGameObject[i].material = myBlackMaterial;
        }
       
        //final end scene
        StartCoroutine(MakeLightsDarkTrue());
       // MakeLightsDarkTrue();
        StartCoroutine(ManageEndSoundMusic());

    }

    public IEnumerator MakeLightsDarkTrue()
    {
        yield return new WaitForSeconds(1f);
        OnlyLightsAndScreenTrue();
        yield return new WaitForSeconds(11f);
        endingAnim.SetBool("overlayImage", true);
    }
    

    public void OnlyLightsAndScreenTrue()
    {
        mainLightDark.SetActive(true);
        bedLightDark.SetActive(true);
        outsideLightLeftLightDark.SetActive(true);
        outsideRightLightDark.SetActive(true);
        darkScreenTv.SetActive(true);
        darkScreenArcade.SetActive(true);
    }

    public AudioSource bgEndMusicSpeaker;
    public AudioSource fireworkSpeaker;
    
    public GameObject winText;


    public IEnumerator ManageEndSoundMusic()
    {
        //fireworkSpeaker.volume = 0.5f;
        //bgEndMusicSpeaker.volume = 0.5f;
        yield return new WaitForSeconds(12f);
        
        fireworkSpeaker.volume = 0.2f;
        
        bgEndMusicSpeaker.Stop();
        yield return new WaitForSeconds(1f);
        raspberrySource.Stop();
        youWinSpeaker.Play();
        winText.SetActive(true);
    }

    public float RandomSeconds()
    {
        //0.2 starting
        //end 
        float rand = Random.Range(0, 0.05f);
        return rand;
    }

    public void SetUpCountText()
    {
        if (!gameCanStart)
        {
            itemsText.text = "";
        }
        else
        {
            itemsText.text = numOfItems.ToString() + "/120";
        }
        
    }

    public IEnumerator SetScore_Animation()
    {
        anim.SetBool("score", true);
        numOfItems++;
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("score", false);
    }
}
