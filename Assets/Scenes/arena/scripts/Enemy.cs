using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    const string PLAYER = "player";
    const string ENEMY = "enemy";
    public float startTime;
    public float actionTime;
    public bool playerPressedCorrect = false;
    public bool playerPressedWrong = false;

    public Image attackImage;

    void Start()
    {
        attackImage.enabled = false;
    }

    void Update()
    {
        if (startTime > 0)
        {
            startTime -= Time.deltaTime;
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
        GameObject.FindGameObjectWithTag(attack).GetComponent<Animator>().SetTrigger("attack");
        GameObject.FindGameObjectWithTag(die).GetComponent<Animator>().SetTrigger("die");
    }
}
