using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public float speed;
    public Renderer BGRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BGRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}
