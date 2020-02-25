public interface IRodent
{
    void LevelUp();

    void TakeDamage(float damage);

    void GainExp(int exp);

    int GetCurrentLevel();

    float GetCurrentHealth();

    float GetHealth();

    float GetMovement();

    float GetCurrentExp();

    StatSheet GetStatSheet();

    void ReadStats();

    void DebugStats();
}
