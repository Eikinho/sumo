using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColorChange : MonoBehaviour
{
    public Button button;
    public Color wantedcollor;
    // Start is called before the first frame update
    void Start()
    {
        // button.colors = Color.white;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeButtonColor(){
        button.GetComponentInChildren<Text>().color = wantedcollor;
        button.GetComponentInChildren<Text>().text = "READY";
        // ColorBlock cb = button.colors;
        // cb.normalColor = wantedcollor;
        // cb.highlightedColor = wantedcollor;
        // cb.pressedColor = wantedcollor;
        // button.colors = cb;
    }
}
