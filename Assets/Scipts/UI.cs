using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public bool volume = false;
    public Animator animator;
    public Animator fadeAnim;
    public GameObject volumePage;
    string sceneName;

    private void Start()
    {
        fadeAnim.Play("FadeIn");
    }

    public void SelectLevel(string name)
    {
        sceneName = name;
        fadeAnim.Play("FadeOut");
        Invoke("LoadScene", 1f);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ToggleVolume()
    {
        if (volume)
        {
            animator.Play("VolFadeOut");
            Invoke("DisableVolume", 1f);
            volume = false;
        }
        else
        {
            volumePage.SetActive(true);
            animator.Play("VolFadeIn");
            volume = true;
        }
    }

    void DisableVolume()
    {
        volumePage.SetActive(false);
    }
}
