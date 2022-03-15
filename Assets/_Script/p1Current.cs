using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class p1Current : MonoBehaviour
{

    public Animator animator;
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        gm = GameManager.GetInstance();

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("pokeId", gm.p1PokemonId);
    }
}
