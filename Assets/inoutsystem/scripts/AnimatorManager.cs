using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    int horizontal, vertical;

    // Start is called before the first frame update
    void Start()
    {
        horizontal = Animator.StringToHash("Horizontal");
        vertical = Animator.StringToHash("vertical");
    }

    // Update is called once per frame
    public void UpdateAnimatorValues(float horizontalMovement, float verticalMovement)
    {
        playerManager.Instance.animatorManager.SetFloat(horizontal, horizontalMovement,0.1f, Time.deltaTime);
    }
}
