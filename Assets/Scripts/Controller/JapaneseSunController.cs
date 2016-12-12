using UnityEngine;

public class JapaneseSunController : MonoBehaviour
{
    [SerializeField]
    private float duration;

    void Start()
    {
        LeanTween.rotateZ(gameObject, 180f, duration).setLoopClamp();
    }
}