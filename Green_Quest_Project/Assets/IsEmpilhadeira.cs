using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsEmpilhadeira : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            animator.SetBool("EsUmaEmpilhadeira", true);
        }
    }
}
