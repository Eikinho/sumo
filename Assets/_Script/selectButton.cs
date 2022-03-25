using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectButton : MonoBehaviour
{
   public int pokemonId;
    GameManager gm;
    // Start is called before the first frame update
    private void Start()
    {
        gm = GameManager.GetInstance();
        gm.pChoosing = 1;
    }

    public void play(){
        gm.changeState(GameManager.GameState.GAME);
    }

    public void choosed() {
        gm.pChoosing += 1;
    }

    // Update is called once per frame
    public void charmander()
    {
       pokemonId = 1;
       if (gm.pChoosing == 1)
       {
           gm.p1PokemonId =  pokemonId;
       } else {
            gm.p2PokemonId =  pokemonId;
        }
    } 

    public void bulbasaur()
    {

        pokemonId = 2;
        if (gm.pChoosing == 1)
       {
           gm.p1PokemonId =  pokemonId;
       } else {
            gm.p2PokemonId =  pokemonId;
        }
    } 

    public void squirtle()
    {

        pokemonId = 3;
        if (gm.pChoosing == 1)
       {
           gm.p1PokemonId =  pokemonId;
       } else {
            gm.p2PokemonId =  pokemonId;
        }
    } 

    public void pikachu()
    {

        pokemonId = 4;
        if (gm.pChoosing == 1)
       {
           gm.p1PokemonId =  pokemonId;
       } else {
            gm.p2PokemonId =  pokemonId;
        }
    } 

    public void gastly()
    {

        pokemonId = 5;
        if (gm.pChoosing == 1)
        {
            gm.p1PokemonId =  pokemonId;
        } else {
            gm.p2PokemonId =  pokemonId;
        }
    } 
}