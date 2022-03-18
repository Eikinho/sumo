using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectButton : MonoBehaviour
{
   public int pokemonId;
   public int pChoosing;
    GameManager gm;
    // Start is called before the first frame update
    private void Start()
    {
        gm = GameManager.GetInstance();
        pChoosing = gm.pChoosing;
    }

    public void play(){
        gm.changeState(GameManager.GameState.GAME);
    }

    public void choosed() {
        pChoosing = 2;
    }

    // Update is called once per frame
    public void charmander()
    {
       pokemonId = 1;
       if (pChoosing == 1)
       {
           gm.p1PokemonId =  pokemonId;
       } else {
            gm.p2PokemonId =  pokemonId;
        }
    } 

    public void bulbasaur()
    {

        pokemonId = 2;
        if (pChoosing == 1)
       {
           gm.p1PokemonId =  pokemonId;
       } else {
            gm.p2PokemonId =  pokemonId;
        }
    } 

    public void squirtle()
    {

        pokemonId = 3;
        if (pChoosing == 1)
       {
           gm.p1PokemonId =  pokemonId;
       } else {
            gm.p2PokemonId =  pokemonId;
        }
    } 

    public void pikachu()
    {

        pokemonId = 4;
        if (pChoosing == 1)
       {
           gm.p1PokemonId =  pokemonId;
       } else {
            gm.p2PokemonId =  pokemonId;
        }
    } 

    public void gastly()
    {

        pokemonId = 5;
        if (pChoosing == 1)
        {
            gm.p1PokemonId =  pokemonId;
        } else {
            gm.p2PokemonId =  pokemonId;
        }
    } 
}