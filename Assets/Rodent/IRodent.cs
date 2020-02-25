public interface IRodent
{
    void LevelUp();

    void TakeDamage(float damage);

    void GainExp(float exp);

    int GetCurrentLevel();

    float GetCurrentHealth();

    float GetHealth();

    float GetMovement();

    float GetCurrentExp();

    StatSheet GetStatSheet();

    void ReadStats();

    void DebugStats();
}
