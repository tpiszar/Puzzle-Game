using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    public GameObject[] pages;
    public Animator fadeAnim;
    GameObject lastPage;
    string level;

    private void Start()
    {
        fadeAnim.Play("FadeIn");
        Invoke("FadeIn", 1f);
    }

    void FadeIn()
    {
        Animator[] anims = pages[0].GetComponentsInChildren<Animator>();
        foreach (Animator anim in anims)
        {
            anim.Play("FadeIn");
        }
    }

    public void SelectLevel(string name)
    {
        level = name;
        Animator[] anims = pages[1].GetComponentsInChildren<Animator>();
        foreach (Animator anim in anims)
        {
            anim.Play("FadeOut");
        }
        fadeAnim.Play("FadeOut");
        Invoke("LoadScene", 1f);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(level);
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }

    public void SwitchPage(int page)
    {
        lastPage = pages[0];
        Invoke("DeActivate", 1f);
        pages[page].SetActive(true);
        Animator[] anims1 = pages[0].GetComponentsInChildren<Animator>();
        Animator[] anims2 = pages[page].GetComponentsInChildren<Animator>();
        foreach (Animator anim in anims1)
        {
            anim.Play("FadeOut");
        }
        foreach (Animator anim in anims2)
        {
            anim.Play("FadeIn");
        }
    }

    public void Main(int page)
    {
        lastPage = pages[page];
        Invoke("DeActivate", 1f);
        pages[0].SetActive(true);
        Animator[] anims1 = pages[page].GetComponentsInChildren<Animator>();
        Animator[] anims2 = pages[0].GetComponentsInChildren<Animator>();
        foreach (Animator anim in anims1)
        {
            anim.Play("FadeOut");
        }
        foreach (Animator anim in anims2)
        {
            anim.Play("FadeIn");
        }
    }

    void DeActivate()
    {
        lastPage.SetActive(false);
    }
}
