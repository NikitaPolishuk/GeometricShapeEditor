using Asset.Scripts.Controller;
using Asset.Scripts.Factory;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public ShapesController ShapesController;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Init();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Init()
    {
        ShapesController.Init(new PrismFactory(), new ParallelepipedFactory(), new SphereFactory(), new CapsuleFactory());
    }
}
