using UnityEngine;
using System.Collections;

public class BackgroundHandler : MonoBehaviour
{

    public BackgroundParallax[] parallaxColl;

    public static BackgroundHandler instance;

    // Use this for initialization
    void Awake()
    {
        // Instantiate this as a singleton class
        instance = this;
    }

    // Update all background handlers
    public static void updateAll(Vector2 delta)
    {
        //  Update background layers
        foreach (var bg in instance.parallaxColl)
        {
            bg.updatePos(delta);
        }
    }
}
