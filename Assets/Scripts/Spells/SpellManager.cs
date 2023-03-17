using UnityEngine;

public class SpellManager : MonoBehaviour
{
    private SpellController currentSpell;

    public SpellController CurrentSpell { get { return currentSpell; } set { currentSpell = value; } }

    public static SpellManager Instance { get; private set; }

    public void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (currentSpell == null) return;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CurrentSpell.Cast();
            CurrentSpell = null;
        }
    }
}
