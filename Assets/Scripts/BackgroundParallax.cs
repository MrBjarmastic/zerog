using UnityEngine;
using System.Collections;

public class BackgroundParallax : MonoBehaviour
{
    Renderer rend;

    void Awake()
    {
        rend = gameObject.renderer;
        rend.sortingLayerName = "background";
    }
    // Set within the properties of the object to which the script is attached
    // controls the speed of movement relative to the ship
    public float speed = 0;

    // Call this function when moving the ship
    public void updatePos(Vector2 delta)
    {
        renderer.material.mainTextureOffset += delta * Time.deltaTime * speed * 0.2f;
    }
}
