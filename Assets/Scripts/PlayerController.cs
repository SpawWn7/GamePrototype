using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isCasted;
    private Animator playerAnim;
    
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.Space) && !isCasted ) 
        {
            isCasted = true;
            //playerAnim.SetTrigger();
        }

    }
}
