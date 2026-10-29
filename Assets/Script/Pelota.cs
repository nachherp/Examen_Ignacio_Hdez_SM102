using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Pelota : MonoBehaviour
{
    public float velocidad = 2f;

    Rigidbody2D rb;
    Vector2 direccion = Vector2.right;
    string resultado = "";

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (resultado != "") return;

        Keyboard teclado = Keyboard.current;
        if (teclado == null) return;

        if (teclado.wKey.isPressed || teclado.upArrowKey.isPressed)
            direccion = Vector2.up;

        if (teclado.sKey.isPressed || teclado.downArrowKey.isPressed)
            direccion = Vector2.down;

        if (teclado.aKey.isPressed || teclado.leftArrowKey.isPressed)
            direccion = Vector2.left;

        if (teclado.dKey.isPressed || teclado.rightArrowKey.isPressed)
            direccion = Vector2.right;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = direccion * velocidad;

        if (resultado != "")
            rb.linearVelocity = Vector2.zero;
    }

    void OnCollisionEnter2D(Collision2D choque)
    {
        if (resultado != "") return;

        resultado = "perdiste";
        Invoke("reiniciar", 2f);
    }

    void OnTriggerEnter2D(Collider2D otro)
    {
        if (resultado != "") return;

        if (otro.name == "meta")
        {
            resultado = "ganas6e";
            Invoke("Reiniciar", 2f);
        }
    }

    void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnGUI()
    {
        GUI.Label(new Rect(20, 20, 200, 40), resultado);
    }
}