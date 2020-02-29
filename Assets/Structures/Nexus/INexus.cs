using System.Collections.Generic;

public interface INexus
{
    void SpawnMinion(MinionType minionType);

    float GetNexusHealth();

    Team GetNexusTeam();

    void TakeDamage(float damage);
}
