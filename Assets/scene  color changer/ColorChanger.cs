using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public List<Texture> texture = new ();
    public Material material;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeColor();
    }

    public void ChangeColor()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            int currentTextureIndex = texture.IndexOf(material.mainTexture);
            currentTextureIndex++;
            if (currentTextureIndex >= texture.Count)
            {
                currentTextureIndex = 0;
            }
            material.mainTexture = texture[currentTextureIndex];
        }
    }
}
