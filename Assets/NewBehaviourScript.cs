using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine UIElements;

public class NewBehaviourScript : MonoBehaviour
{

    private Renderer rend;
    public Color[] colors;
    public Vector3 position;
    public float speed;
    public Transform pointA, pointB;
    float radius;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        transform.position = Vector3.forward;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(pointA.position, pointB.position , speed * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
        float dist = Vector3.Distance(transform.position, pointA.position);

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    void OnEnable()
    {
        //rend.material.color = colors[Random.Range(0, colors.Length)];
    }

    void OnDisable()
    {

    }
    void OnMouseUp()
    {

    }

    void OnMouseDown()
    {
        //rend.material.color = colors[Random.Range(0, colors.Length)];
    }


}
