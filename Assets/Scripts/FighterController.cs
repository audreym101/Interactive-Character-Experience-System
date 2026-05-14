using UnityEngine;

public class FighterController : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        if (anim == null)
            Debug.LogError("Animator not found on " + gameObject.name);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Q pressed - Punch");
            anim.ResetTrigger("Kick");
            anim.ResetTrigger("Hit");
            anim.SetTrigger("Punch");
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("W pressed - Kick");
            anim.ResetTrigger("Punch");
            anim.ResetTrigger("Hit");
            anim.SetTrigger("Kick");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E pressed - Hit");
            anim.ResetTrigger("Punch");
            anim.ResetTrigger("Kick");
            anim.SetTrigger("Hit");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R pressed - KO");
            anim.ResetTrigger("Punch");
            anim.ResetTrigger("Kick");
            anim.ResetTrigger("Hit");
            anim.SetBool("KO", true);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("T pressed - KO Reset");
            anim.SetBool("KO", false);
        }
    }
}