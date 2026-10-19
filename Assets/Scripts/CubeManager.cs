using UnityEngine;
using UnityEngine.InputSystem;

public class CubeManager : MonoBehaviour
{
    [SerializeField] private Cube[] _cubes;
    
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Begin();
        }
    }
    //public void Begin()
    //{
    //    for(var i = 0; i < _cubes.Length; i++)
    //    {
    //        StartCoroutine(_cubes[i].RotateForSeconds(1 + 1 * i));
    //    }

    //}

    public void Begin()
    {
        for (var i = 0; i < _cubes.Length; i++)
        {
            _cubes[i].RotateForSeconds(1 + 1 * i);
        }
    }
}
