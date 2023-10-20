using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    int horizontal, vertical;

    // Start is called before the first frame update
    void Start()
    {
        horizontal = Animator.StringToHash("horizontal");
        vertical = Animator.StringToHash("vertical");
    }

    // Update is called once per frame
    public void UpdateAnimatorValues(float horizontalMovement, float verticalMovement, bool isSprinting)

    {
        if (isSprinting)
        {
            horizontalMovement = 2;
        }
        playerManager.Instance.animator.SetFloat(horizontal, horizontalMovement, 0.1f, Time.deltaTime);
        playerManager.Instance.animator.SetFloat(vertical, verticalMovement, 0.1f, Time.deltaTime);
    }
}
