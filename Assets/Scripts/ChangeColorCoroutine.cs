using System.Collections;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeColorCoroutine : MonoBehaviour
{
    [SerializeField] private TMP_Text rgbLabel;
    private Renderer renderer;
    private Coroutine rainbow;

    void Awake()
    {
        renderer = GetComponent<Renderer>();
        renderer.material.color = UnityEngine.Color.HSVToRGB(0, 1, 1);


    }

    void Update()
    {
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            if (rainbow == null)
            {
                rainbow = StartCoroutine(RaiseColors());
            }
            else
            {
                StopCoroutine(rainbow);
                rainbow = null;
            }
        }
        Color32 c = renderer.material.color;

        rgbLabel.text = $"Async\nRed:{c.r}\nGreen:{c.g}\nBlue:{c.b}";
    }

    IEnumerator RaiseColors()
    {
        UnityEngine.Color.RGBToHSV(renderer.material.color, out float hue, out float sat, out float val);
        while (true)
        {
            while (hue < 1f)
            {
                hue += 0.0025f;
                renderer.material.color = UnityEngine.Color.HSVToRGB(hue, 1, 1);
                yield return new WaitForSeconds(0.01f);
            }
            hue = 0f;
        }
    }

}

