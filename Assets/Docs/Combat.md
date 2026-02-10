# Combat

O módulo `Combat` gerencia as interações de ataque e dano entre entidades no jogo. Ele define interfaces para entrada de ataque, componentes de ataque, aplicação de dano e modificadores de dano, além de implementações básicas para ataques baseados em teclado e tempo.

## Interfaces

### `IAttackInput`

Define a interface para qualquer componente que possa iniciar um ataque.

| Método            | Descrição                               |
| :---------------- | :-------------------------------------- |
| `ExecuteAttack()` | Inicia o processo de ataque.            |

### `IAttackComponent`

Define a interface para componentes que determinam os alvos de um ataque.

| Método                                       | Descrição                                                              |
| :------------------------------------------- |
| `GetAttackHits(Vector2 origin, Vector2 direction, float distance)` | Retorna um array de `Collider2D` que foram atingidos pelo ataque, dado um ponto de origem, direção e distância. |

### `IDamageApplier`

Define a interface para componentes que aplicam dano a uma entidade.

| Método                               | Descrição                                                              |
| :----------------------------------- | :--------------------------------------------------------------------- |
| `ApplyDamage(AttackData attackData)` | Aplica o dano contido em `attackData` a uma entidade.                  |

### `IDamageModifier`

Esta interface (inferida pelo uso em `BaseDamageApplier`) é usada para definir modificadores que alteram o dano a ser aplicado.

| Método                     | Descrição                                                              |
| :------------------------- | :--------------------------------------------------------------------- |
| `GetDamageModifier()`      | Retorna um valor float que modifica o dano a ser aplicado.             |

## Classes

### `BaseDamageApplier`

Esta classe implementa a interface `IDamageApplier`. Ela coleta todos os `IDamageModifier` anexados ao mesmo `GameObject` e os aplica ao dano antes de passá-lo para o `ISufferPipeline` do defensor.

**Dependências:**

* `IDamageModifier[]`: Array de modificadores que alteram o dano.
* `ISufferPipeline`: Pipeline de sofrimento de dano do defensor.

**Métodos:**

* `Awake()`: Obtém referências para os `IDamageModifier`s.
* `ApplyDamage(AttackData attackData)`: Itera sobre os `IDamageModifier`s para ajustar o `attackData.damage`. Em seguida, tenta obter um `ISufferPipeline` do defensor e chama seu método `SufferDamage` com os dados de ataque modificados.

### `BaseKeyboardAttackInput`

Esta classe implementa a interface `IAttackInput` e permite que o jogador inicie ataques usando a entrada do teclado (botão "Fire1"). Ela calcula a direção do ataque com base na posição do mouse e utiliza um `IAttackComponent` para detectar acertos e um `IDamageApplier` para aplicar o dano.

**Dependências:**

* `IAttackComponent`: Componente para detectar alvos de ataque.
* `IDamageApplier`: Componente para aplicar dano.
* `DataComponent`: Componente para acessar dados de combate (e.g., `CombatData`).

**Métodos:**

* `Awake()`: Obtém referências para `IAttackComponent`, `IDamageApplier` e `DataComponent`.
* `ExecuteAttack()`: Calcula a direção do ataque, obtém os acertos usando `IAttackComponent`, cria um `AttackData` com informações do atacante, defensor, dano e *knockback*, e então chama `ApplyDamage` no `IDamageApplier` para cada alvo atingido.
* `Update()`: Verifica a entrada do botão "Fire1" e chama `ExecuteAttack()` se pressionado.

### `BaseTimerAttackInput`

Esta classe implementa a interface `IAttackInput` e inicia ataques automaticamente em intervalos de tempo definidos. Similar ao `BaseKeyboardAttackInput`, ela utiliza um `IAttackComponent` para detectar acertos e um `IDamageApplier` para aplicar o dano.

**Propriedades Serializadas:**

* `attackInterval`: O intervalo de tempo entre os ataques automáticos.
* `attackDirection`: A direção predefinida do ataque.

**Dependências:**

* `IAttackComponent`: Componente para detectar alvos de ataque.
* `IDamageApplier`: Componente para aplicar dano.
* `DataComponent`: Componente para acessar dados de combate (e.g., `CombatData`).

**Métodos:**

* `Awake()`: Obtém referências para `IAttackComponent`, `IDamageApplier` e `DataComponent`.
* `ExecuteAttack()`: Utiliza a `attackDirection` predefinida, obtém os acertos usando `IAttackComponent`, cria um `AttackData` com informações do atacante, defensor, dano e *knockback*, e então chama `ApplyDamage` no `IDamageApplier` para cada alvo atingido.
* `Update()`: Verifica se o tempo para o próximo ataque foi atingido e, se sim, atualiza `nextAttackTime` e chama `ExecuteAttack()`.

### `RayAttackComponent`

Esta classe implementa a interface `IAttackComponent` e utiliza um `Raycast` para detectar acertos em uma linha reta a partir da origem do ataque.

**Métodos:**

* `GetAttackHits(Vector2 origin, Vector2 direction, float distance)`: Realiza um `RaycastAll` a partir da `origin` na `direction` com a `distance` especificada e retorna todos os `Collider2D` atingidos.
