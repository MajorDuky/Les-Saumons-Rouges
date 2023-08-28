using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextEvent : MonoBehaviour
{
    [SerializeField] Animator textAnimator;
    public void TextFadeOut()
    {
        textAnimator.SetBool("coucou", true);
    }
}
