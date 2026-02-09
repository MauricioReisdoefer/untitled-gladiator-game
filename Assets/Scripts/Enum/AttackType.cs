using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType
{
    Melee,          // Espadas, lanças, socos
    Ranged,         // Lanças arremessadas, redes, facas
    Charge,         // Investida / corrida com impacto
    Area,           // Golpe em arco, giro, ataque em área
    Throw,          // Arremessar inimigo ou objeto
    Counter,        // Contra-ataque
    Finisher,       // Golpe finalizador
    Trap            // Redes, armadilhas da arena
}
