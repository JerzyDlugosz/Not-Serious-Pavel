using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDifficulty : MonoBehaviour
{
    public string difficulty;
    public List<GameObject> Enemies;
    public GameObject Player;
    void Start()
    {
        if (difficulty == "extreme")
        {
            foreach (var enemy in Enemies)
            {
                enemy.GetComponent<CharacterStats>().damage = 100;
                enemy.GetComponent<CharacterStats>().maxHealth = 500;
            }

            Player.GetComponent<CharacterStats>().maxHealth = 1;
        }
        if (difficulty == "hard")
        {
            foreach (var enemy in Enemies)
            {
                enemy.GetComponent<CharacterStats>().damage = 50;
                enemy.GetComponent<CharacterStats>().maxHealth = 250;
            }
        }
        if (difficulty == "normal")
        {
            foreach (var enemy in Enemies)
            {
                enemy.GetComponent<CharacterStats>().damage = 30;
                enemy.GetComponent<CharacterStats>().maxHealth = 150;
            }
        }
        if (difficulty == "easy")
        {
            foreach (var enemy in Enemies)
            {
                enemy.GetComponent<CharacterStats>().damage = 10;
                enemy.GetComponent<CharacterStats>().maxHealth = 100;
            }
        }
    }
}
