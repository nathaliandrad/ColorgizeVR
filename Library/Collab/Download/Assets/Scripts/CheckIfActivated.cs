using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfActivated : MonoBehaviour
{
    int count;
    public Renderer[] rend;
    public Color c;
    public bool changeBallColor;
    Renderer myRend;

    public bool useSpecialWhite;
    public Color specialWhite;

    bool activated;

    public bool canPlaySound;


    public Material specialMaterial;

    // Start is called before the first frame update
    void Start()
    {
  
        activated = false;
        canPlaySound = true;
        count = 0;
        StartCoroutine(StartEndGame());
        SetUpText.instance.notYetCollided.Add(gameObject);
        //SetUpText.instance.allItemsGameObject.Add(rend[]);



        if (gameObject.GetComponent<Animator>())
        {
            SetUpText.instance.allObjectsAnimator.Add(gameObject.GetComponent<Animator>());
        }
        if (gameObject.GetComponentInParent<Animator>())
        {
            SetUpText.instance.allObjectsAnimator.Add(gameObject.GetComponentInParent<Animator>());
        }

        //RandomPaints();

        //SetUpText.instance.allObjects = SetUpText.instance.notYetCollided;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (SetUpText.instance.gameCanStart)
        {
            if (collision.gameObject.CompareTag("Ball") || (collision.gameObject.CompareTag("RBall")))
            {
                if (count == 0)
                {

                    //changing ball color
                    if (changeBallColor)
                    {
                        collision.gameObject.SendMessage("ChangeColor", c);
                    }
                   
                    Activate();

                }
                else
                {
                    StartCoroutine(Flash());
                }
                count++;
            }
        }

    }
   
    void Activate()
    {
        if (SetUpText.instance.canStartColoring == true)
        {
            SetUpText.instance.notYetCollided.Remove(gameObject);
            //score
            //SetUpText.instance.numOfItems++;
            if (!SetUpText.instance.gameHasEnded)
            {
                StartCoroutine(SetUpText.instance.SetScore_Animation());
            }


            if (specialMaterial != null)
            {
                // FOR DIFFERENT MATERIALS WITH CHILDREN
                if (rend.Length > 0)
                {
                    foreach (Renderer rendChild in rend)
                    {
                        //sticky.gameObject.GetComponent<Renderer>().material = roomMaterial;
                        rendChild.material = specialMaterial;
                        rendChild.material.EnableKeyword("_EMISSION");
                        SetUpText.instance.allItemsGameObject.Add(rendChild);
                    }
                }
                else // DIFFERENT MATERIALS FOR INDIVIDUALS
                {
                    myRend = GetComponent<Renderer>();
                    myRend.material = specialMaterial;
                    myRend.material.EnableKeyword("_EMISSION");
                    SetUpText.instance.allItemsGameObject.Add(myRend);
                }
            }

            // ORIGINAL TEXTURE ROOM MATERIAL WITH CHILDREN
            else if (rend.Length > 0)
            {
                foreach (Renderer rendChild in rend)
                {
                    //sticky.gameObject.GetComponent<Renderer>().material = roomMaterial;
                    rendChild.material = SetUpText.instance.roomMaterial;
                    rendChild.material.EnableKeyword("_EMISSION");
                    SetUpText.instance.allItemsGameObject.Add(rendChild);
                }
            }
            else // INDIVIDUAL OBJECTS
            {
                myRend = GetComponent<Renderer>();
                myRend.material = SetUpText.instance.roomMaterial;
                myRend.material.EnableKeyword("_EMISSION");
                SetUpText.instance.allItemsGameObject.Add(myRend);
            }
            activated = true;
            StartCoroutine(Flash());
        }
      
    }

    //public IEnumerator AssingBlackMaterial()
    //{
    //       // ORIGINAL TEXTURE ROOM MATERIAL WITH CHILDREN
    //    if (rend.Length > 0)
    //    {
    //        foreach (Renderer rendChild in rend)
    //        {
    //            //sticky.gameObject.GetComponent<Renderer>().material = roomMaterial;
    //            yield return new WaitForSeconds();
    //            rendChild.material = SetUpText.instance.myBlackMaterial;
             
    //        }
    //    }
    //    else // INDIVIDUAL OBJECTS
    //    {
    //        yield return new WaitForSeconds();
    //        myRend = GetComponent<Renderer>();
    //        myRend.material = SetUpText.instance.myBlackMaterial;
           
    //    }
    //}

    public IEnumerator Flash()
    {        
        float t = 0f;
        Color myWhite = count >=1 ? SetUpText.instance.lowWhite : SetUpText.instance.goodWhite;
        //SPECIAL LOWER WHITE
        if (count >= 1 && useSpecialWhite) myWhite = specialWhite;

        while (t < 1)
        {
            t += Time.deltaTime;
            Color tempColor = Color.Lerp(myWhite, Color.black, t);
            yield return null;


            if (rend.Length > 0)
            {
                foreach (Renderer r in rend)
                {
                    r.material.SetColor("_EmissionColor", tempColor);

                }

            }
            else
            {
                myRend.material.SetColor("_EmissionColor", tempColor);
            }
         
        }
    }



    public IEnumerator StartEndGame()
    {
       
        while (!SetUpText.instance.gameHasEnded)
        {
            yield return new WaitForSeconds(0.2f);
        }
        StartCoroutine(LerpColor());
       // PlayAnimationOneMoreTime();
    }



    // FOR ENDING SCENE
    public IEnumerator LerpColor()
    {

        if (specialMaterial != null)
        {
            // FOR DIFFERENT MATERIALS WITH CHILDREN
            if (rend.Length > 0)
            {
                foreach (Renderer rendChild in rend)
                {
                   // rendChild.material = SetUpText.instance.darkerMaterial;
                    if (gameObject.CompareTag("Walls"))
                    {
                        float t = 0f;
                        while (t < 1)
                        {
                            t += Time.deltaTime;
                            rendChild.material.color = Color.Lerp(rendChild.material.color, SetUpText.instance.darkOrange.color, t);
                            yield return null;
                        }
                        rendChild.material = SetUpText.instance.darkOrange;
                    }
                    //else if (gameObject.CompareTag("Fan"))
                    //{
                    //    rendChild.material = SetUpText.instance.darkBabyGreen;
                    //}
                    //else if (gameObject.CompareTag("Wardrobe"))
                    //{
                    //    myRend.material = SetUpText.instance.darkWindowCurtain;
                    //}


                }
            }// DIFFERENT MATERIALS FOR INDIVIDUALS
            else if (gameObject.CompareTag("Walls"))
            {
                float t = 0f;
                while (t < 1)
                {
                    t += Time.deltaTime;
                    myRend.material.color = Color.Lerp(myRend.material.color, SetUpText.instance.darkOrange.color, t);
                    yield return null;
                }
               
                myRend.material = SetUpText.instance.darkOrange;
            }else if (gameObject.CompareTag("Ceiling"))
            {
                float t = 0f;
                while (t < 1)
                {
                    t += Time.deltaTime;
                    myRend.material.color = Color.Lerp(myRend.material.color, SetUpText.instance.darkYellow.color, t);
                    yield return null;
                }
                myRend.material = SetUpText.instance.darkYellow;
            }else if (gameObject.CompareTag("Floor"))
            {
                float t = 0f;
                while (t < 1)
                {
                    t += Time.deltaTime;
                    myRend.material.color = Color.Lerp(myRend.material.color, SetUpText.instance.darkYellow.color, t);
                    yield return null;
                }
                myRend.material = SetUpText.instance.darkYellow;
            }

        }

    }

    public IEnumerator SoundsCD()
    {
        canPlaySound = false;
        yield return new WaitForSeconds(1f);
        canPlaySound = true;
    }



}
