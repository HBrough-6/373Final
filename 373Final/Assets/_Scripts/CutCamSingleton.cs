using UnityEngine;

public class CutCamSingleton : MonoBehaviour
{
    public static CutCamSingleton Instance;

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
