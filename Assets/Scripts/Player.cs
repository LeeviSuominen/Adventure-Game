using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field: SerializeField] public int Level { get; set; } = 1;
    [field: SerializeField] public int Health { get; set; } // = 5;
    //olio muuttuja
    PlayerData playerData;

    void Start()
    {
        SetPlayerData();
    }


    void Update()
    {

    }

    private void SetPlayerData()
    {
        playerData = DataManager.LoadPlayerDataFromJSON();
        Vector3 offset = new(2f, 0, 2f);

        //sijainti
        Vector3 position = new Vector3()
        {
            x = playerData.position[0],
            y = playerData.position[1],
            z = playerData.position[2]

        };
        transform.position = position - offset;

        Health = playerData.playerHealth;

        Level = playerData.level;

        FindObjectOfType<GameManager>().UpdateHeart(Health);
    }
}
