using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{

    public static playerManager Instance {get; private set;}
    [Header("Scripts")]
    public AnimatorManager animatorManager;

    public GameObject player;
    public playerLocomotion PlayerLocomotion;
    public inputManager InputManager;
    [Header("Stats")]
    public float Speed;
    public Rigidbody Rigidbody;

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InputManager = player.GetComponent<inputManager>();
        PlayerLocomotion = player.GetComponent<playerLocomotion>();
        Rigidbody = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        InputManager.HandleAllInput();
    }



    private void FixedUpdate()
    {
        
    }

}
