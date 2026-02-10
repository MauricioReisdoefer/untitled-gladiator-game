# Health

O módulo `Health` é responsável por gerenciar a saúde de entidades no jogo, incluindo a aplicação de dano, cura e a detecção de morte. Ele é composto por interfaces e classes que definem o comportamento de componentes de saúde e pipelines de sofrimento de dano.

## Interfaces

### `IHealthComponent`

Esta interface define o contrato para qualquer componente que gerencie a saúde de uma entidade. Ele especifica os métodos essenciais para interagir com o sistema de saúde.

| Método                      | Descrição                                                       |
| :-------------------------- | :-------------------------------------------------------------- |
| `Heal(float health)`        | Aplica cura à entidade, aumentando sua saúde.                   |
| `Die()`                     | Lida com a lógica de morte da entidade.                         |
| `SufferDamage(float health)`| Aplica dano à entidade, diminuindo sua saúde.                   |
| `GetCurrentHealth()`        | Retorna o valor atual da saúde da entidade.                     |
| `GetMaxHealth()`            | Retorna o valor máximo da saúde que a entidade pode ter.        |

### `ISufferPipeline`

Esta interface define um pipeline para processar o dano sofrido por uma entidade. Ela permite que modificadores sejam aplicados antes que o dano final seja infligido.

| Método                                | Descrição                                                   |
| :------------------------------------ | :---------------------------------------------------------- |
| `SufferDamage(AttackData attackData)` | Processa o dano recebido, aplicando modificadores           |

### `ISufferModifier`

Esta interface (não lida diretamente, mas inferida pelo uso em `BaseSufferPipeline`) é usada para definir modificadores que alteram o dano recebido por uma entidade.

| Método                     | Descrição                                                              |
| :------------------------- | :--------------------------------------------------------------------- |\n| `GetSufferModifier()`      | Retorna um valor float que modifica o dano recebido.                   |

## Classes

### `BaseHealthComponent`

Esta classe implementa a interface `IHealthComponent` e fornece a funcionalidade básica para gerenciar a saúde de uma entidade. Ela mantém a saúde atual e máxima, e lida com a lógica de cura, dano e morte.

**Propriedades Protegidas:**

* `currentHealth`: A saúde atual da entidade.
* `maxHealth`: A saúde máxima que a entidade pode ter.

**Métodos:**

* `Start()`: Inicializa `currentHealth` com `maxHealth`.
* `Heal(float health)`: Aumenta `currentHealth` pelo valor de `health`, garantindo que não exceda `maxHealth`.
* `SufferDamage(float health)`: Diminui `currentHealth` pelo valor de `health`. Se `currentHealth` for menor ou igual a zero, chama o método `Die()`.
* `Die()`: Destrói o `gameObject` ao qual este componente está anexado.
* `GetCurrentHealth()`: Retorna o valor de `currentHealth`.
* `GetMaxHealth()`: Retorna o valor de `maxHealth`.

### `BaseSufferPipeline`

Esta classe implementa a interface `ISufferPipeline` e é responsável por processar o dano sofrido por uma entidade. Ela coleta todos os `ISufferModifier` anexados ao mesmo `GameObject` e os aplica ao dano antes de passá-lo para o `IHealthComponent`.

**Dependências:**

* `IHealthComponent`: Componente de saúde para aplicar o dano final.
* `ISufferModifier[]`: Array de modificadores que alteram o dano recebido.
* `Rigidbody2D`: Usado para aplicar força de *knockback*.

**Métodos:**

* `Awake()`: Obtém referências para `Rigidbody2D`, `ISufferModifier`s e `IHealthComponent`.
* `SufferDamage(AttackData attackData)`: Itera sobre os `ISufferModifier`s para ajustar o `attackData.damage`. Calcula e aplica uma força de *knockback* baseada na direção do ataque e no dano. Finalmente, chama `SufferDamage` no `IHealthComponent` com o dano modificado.
