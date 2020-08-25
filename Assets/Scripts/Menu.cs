using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Animator anim;
    public void Play()
    {
        StartCoroutine("play");
    }

    public void Quit()
    {
        StartCoroutine("quit");
    }

    IEnumerator play()
    {
        anim.SetTrigger("End");
        yield return new WaitForSeconds(.75f);
        SceneManager.LoadScene("Game");
    }

    IEnumerator quit()
    {
        anim.SetTrigger("End");
        yield return new WaitForSeconds(.75f);
        SceneManager.LoadScene("Menu");
    }
}
