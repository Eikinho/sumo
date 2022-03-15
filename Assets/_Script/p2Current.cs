using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class p2Current : MonoBehaviour
{

    Text textComp;
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        textComp = GetComponent<Text>();
        gm = GameManager.GetInstance();

    }

    // Update is called once per frame
    void Update()
    {
        textComp.text = $" You choosed: {gm.p2PokemonId}";
    }
}
