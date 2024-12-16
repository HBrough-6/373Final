using UnityEngine;

public class BlendCamSingleton : MonoBehaviour
{
    public static BlendCamSingleton Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        
    }

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

}
