using UnityEngine;
using System.Collections;

public class FadeCycle : MonoBehaviour
{
    Animator animator;
    public Animator animatorTitle;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
            Change();
    }

    void Cycle()
    {
        animator.SetBool("isCycling", true);
    }

    void Change()
    {
        if (Input.anyKeyDown && animator.GetBool("isCycling"))
        {
            // PressAny Exit
            animator.SetBool("isCycling", false);
            animator.SetTrigger("FadeOut");
            animatorTitle.SetBool("Up", true);

            GameObject.Find("AudioManager").GetComponent<AudioManager>().BgmPlay();
        }
    }
}

