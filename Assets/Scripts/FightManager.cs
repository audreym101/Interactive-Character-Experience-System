using UnityEngine;

public class FightManager : MonoBehaviour
{
    [Header("Fighters")]
    public Animator fighter1;
    public Animator fighter2;
    public Animator fighter3;

    [Header("Managers")]
    public UIManager uiManager;
    public AudioManager audioManager;

    [Header("Health")]
    public float maxHealth = 100f;

    private Animator currentFighter;
    private int currentFighterIndex = 1;
    private float[] health = new float[4];

    void Start()
    {
        health[1] = maxHealth;
        health[2] = maxHealth;
        health[3] = maxHealth;

        uiManager.SetHealth(1, 1f);
        uiManager.SetHealth(2, 1f);
        uiManager.SetHealth(3, 1f);

        SelectFighter(1);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SelectFighter(1);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SelectFighter(2);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SelectFighter(3);

        if (Input.GetKeyDown(KeyCode.Q)) Punch();
        if (Input.GetKeyDown(KeyCode.W)) Kick();
        if (Input.GetKeyDown(KeyCode.E)) Hit();
        if (Input.GetKeyDown(KeyCode.R)) KO();
        if (Input.GetKeyDown(KeyCode.T)) ResetKO();
    }

    public void SelectFighter(int index)
    {
        currentFighterIndex = index;
        currentFighter = index == 1 ? fighter1 : index == 2 ? fighter2 : fighter3;
        uiManager.UpdateActiveFighterText("Fighter " + index);
    }

    public void Punch()
    {
        currentFighter.ResetTrigger("Kick");
        currentFighter.ResetTrigger("Hit");
        currentFighter.SetTrigger("Punch");
        audioManager.PlayPunch();
    }

    public void Kick()
    {
        currentFighter.ResetTrigger("Punch");
        currentFighter.ResetTrigger("Hit");
        currentFighter.SetTrigger("Kick");
        audioManager.PlayKick();
    }

    public void Hit()
    {
        currentFighter.ResetTrigger("Punch");
        currentFighter.ResetTrigger("Kick");
        currentFighter.SetTrigger("Hit");
        audioManager.PlayHit();
        ApplyDamage(currentFighterIndex, 10f);
    }

    public void KO()
    {
        if (currentFighter.GetBool("KO")) return;
        currentFighter.ResetTrigger("Punch");
        currentFighter.ResetTrigger("Kick");
        currentFighter.ResetTrigger("Hit");
        currentFighter.SetBool("KO", true);
        audioManager.PlayKO();
        uiManager.ShowWinner("Fighter " + currentFighterIndex);
    }

    public void ResetKO()
    {
        currentFighter.SetBool("KO", false);
    }

    void ApplyDamage(int index, float damage)
    {
        health[index] -= damage;
        health[index] = Mathf.Clamp(health[index], 0, maxHealth);
        uiManager.SetHealth(index, health[index] / maxHealth);

        if (health[index] <= 0)
            KO();
    }
}
