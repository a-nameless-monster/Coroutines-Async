using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class ChangeColorAsync : MonoBehaviour
{

    [SerializeField] private TMP_Text rgbLabel;
    private Renderer renderer;
    private Task[] tasks = new Task[3];

    void Awake()
    {
        renderer = GetComponent<Renderer>();
        renderer.material.color = UnityEngine.Color.red;
    }

    void Update()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            if (tasks[0] == null)
            {
                tasks[0] = IncreaseValue(0);

            }
            else
            {
                tasks[0] = null;
            }


        }
        if (Keyboard.current.gKey.wasPressedThisFrame)
        {
            if (tasks[1] == null)
            {
                tasks[1] = IncreaseValue(1);

            }
            else
            {
                tasks[1] = null;
            }

        }
        if (Keyboard.current.bKey.wasPressedThisFrame)
        {
            if (tasks[2] == null)
            {
                tasks[2] = IncreaseValue(2);

            }
            else
            {
                tasks[2] = null;
            }

        }

        Color32 c = renderer.material.color;

        rgbLabel.text = $"Async\nRed:{c.r}\nGreen:{c.g}\nBlue:{c.b}";

    }

    public async Task IncreaseValue(int channel)
    {
        await Task.Yield();
        float val = renderer.material.color[channel];
        while (tasks[channel] != null && !destroyCancellationToken.IsCancellationRequested)
        {
            var c = renderer.material.color;
            c[channel] = Mathf.PingPong(val, 1f);
            renderer.material.color = c;
            await Task.Delay(10);
            val += 0.01f;
        }

    }
}
