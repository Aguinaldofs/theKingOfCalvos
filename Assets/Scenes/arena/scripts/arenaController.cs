using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class arenaController : MonoBehaviour
{
    const string PLAYER = "player";
    const string ENEMY = "enemy";
    public bool playerPressedCorrect = false;
    public bool playerPressedWrong = false;

    public Image attackImage;

    public GameObject enemy;

    float startTime = 3;

    float actionTime = 4;

    void Start()
    {
        attackImage.enabled = false;
        startTime = Random.Range(1, 5);
        actionTime = Random.Range(1, 5);

        //change color of the enemy
        enemy.GetComponent<Image>().color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));

    }

    void Update()
    {
        if (startTime > 0)
        {
            startTime -= Time.deltaTime;
            if (Input.GetKey(KeyCode.Space))
            {
                changeAnimationState(ENEMY, PLAYER);
            }
        }
        else
        {
            if (actionTime > 0)
            {
                attackImage.enabled = true;

                actionTime -= Time.deltaTime;

                if (Input.GetKey(KeyCode.Space) && playerPressedCorrect == false)
                {
                    playerPressedCorrect = true;
                    changeAnimationState(PLAYER, ENEMY);
                }
            }
            else
            {
                attackImage.enabled = false;

                if (playerPressedWrong == false)
                {
                    playerPressedWrong = true;
                    changeAnimationState(ENEMY, PLAYER);
                }
            }
        }
    }

    void changeAnimationState(string attack, string die)
    {
            GameObject.FindGameObjectWithTag(attack).GetComponent<Animator>().SetBool("attack", true);
            GameObject.FindGameObjectWithTag(die).GetComponent<Animator>().SetBool("die", true);
    }
}
