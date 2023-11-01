using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Pelaajan tilatiedot, jotka voidaan tallentaa tietovarastoon

[System.Serializable] // mahdollsitaa tietorakenteen tallennuksen tietovarastoon
public class PlayerData
{
    // pelihahmon sijainti
    public float[] position = new float[3];

    public int level = 0;

    public int playerHealth;

    // Konstruktori eli muodostin
    public PlayerData(Player player)
    { 
        // pelihahmon sijainti
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;


        // Taso
        level = player.Level;
        // Terveys
        playerHealth = player.Health;
    }
}
