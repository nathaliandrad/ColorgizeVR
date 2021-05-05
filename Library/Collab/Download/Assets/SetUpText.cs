using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SetUpText : MonoBehaviour
{
    public Color goodWhite;
    public Color lowWhite;
    public static SetUpText instance;
    public Material roomMaterial;
    private void Awake()
    {
        instance = this;
    }

    public TMP_Text itemsText;
    public int numOfItems;
    // Start is called before the first frame update
    void Start()
    {
        numOfItems = 0;
    }

    // Update is called once per frame
    void Update()
    {
        SetUpCountText();
    }

    public void SetUpCountText()
    {
        itemsText.text = numOfItems.ToString();
    }
}
