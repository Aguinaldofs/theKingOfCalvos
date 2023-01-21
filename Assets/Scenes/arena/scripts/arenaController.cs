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

    public bool activeEnemy = false;

    public List<GameObject> enemy;

    public Image attackImage;

    public int position = 0;

    float startTime = 0;

    float actionTime = 0;

    void Start()
    {
        attackImage.enabled = false;
    }

    void Update()
    {
            setActiveEnemy(position);

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
        GameObject.FindGameObjectWithTag(attack).GetComponent<Animator>().SetTrigger("attack");
        GameObject.FindGameObjectWithTag(die).GetComponent<Animator>().SetTrigger("die");
    }


    void setActiveEnemy(int position)
    {
        if (activeEnemy == false)
        {
            enemy[position].SetActive(true);
            startTime = enemy[position].GetComponent<Enemy>().startTime;
            actionTime = enemy[position].GetComponent<Enemy>().actionTime;
            activeEnemy = true;
        }

    }
    void changeEnemy(int position)
    {
        enemy[position].SetActive(false);
        activeEnemy = false;
        position = position + 1;
        if(position == enemy.Count){
            UnityEngine.SceneManagement.SceneManager.LoadScene("Victory");
        }  
    }
}
