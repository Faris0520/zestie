using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth = 25f;
    [SerializeField] private float maxHealth = 100f;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("Sound Settings")]
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip hurtSound;
    private AudioSource audioSource;
    [Header("Health Effect UI")]
    [SerializeField] private GameObject healthUpUI;
    [SerializeField] private GameObject healthDownUI;


    private void Awake()
    {
        startingHealth = Mathf.Clamp(startingHealth, 0, maxHealth);
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>(); // pastikan komponen ini ada

        Debug.Log($"[Health] startingHealth: {startingHealth}, maxHealth: {maxHealth}, currentHealth: {currentHealth}");
    }

    public void TakeDamage(float _damage)
    {
        float oldHealth = currentHealth;
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, maxHealth);
        Debug.Log($"Health decreased: {oldHealth} -> {currentHealth}");

        if (healthDownUI != null)
            healthDownUI.SetActive(true);

        if (hurtSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(hurtSound);
        }

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("dead");
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;

                if (deathSound != null && audioSource != null)
                {
                    audioSource.PlayOneShot(deathSound);
                }

                StartCoroutine(ShowDeathPopupWithDelay(1.5f));
            }
        }
    }


    public void AddHealth(float _value)
    {
        float oldHealth = currentHealth;
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, maxHealth);
        Debug.Log($"Health increased: {oldHealth} -> {currentHealth}");

        if (healthUpUI != null)
            healthUpUI.SetActive(true);
    }

    private IEnumerator ShowDeathPopupWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        FinishTriggerUI finishUI = FindObjectOfType<FinishTriggerUI>();
        if (finishUI != null)
        {
            finishUI.ShowMustRestartPopup();
        }
    }

}
