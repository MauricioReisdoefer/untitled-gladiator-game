# Movement

O módulo `Movement` é responsável por controlar o movimento de entidades no jogo, incluindo a determinação da direção, a aplicação de velocidade e a modificação da velocidade. Ele é composto por interfaces e classes que definem como as entidades se movem e como sua velocidade pode ser ajustada.

## Interfaces

### `IDirectionProvider`

Esta interface define o contrato para qualquer componente que forneça a direção atual de movimento de uma entidade.

| Método                  | Descrição                                           |
| :---------------------- | :-------------------------------------------------- |
| `GetCurrentDirection()` | Retorna um `Vector2` representando a direção atual. |

### `ISpeedModifier`

Esta interface define o contrato para qualquer componente que possa modificar a velocidade de uma entidade.

| Método                | Descrição                                                                   |
| :-------------------- | :-------------------------------------------------------------------------- |
| `GetSpeedModifier()`  | Retorna um valor `float` que será usado para multiplicar a velocidade base. |

## Classes

### `MovementComponent`

Esta classe é o componente principal de movimento. Ela requer um `Rigidbody2D` e utiliza um `IDirectionProvider` para obter a direção e um `SpeedProvider` para obter a velocidade, aplicando uma força ao `Rigidbody2D` para mover a entidade.

**Dependências:**

* `IDirectionProvider`: Fornece a direção atual de movimento.
* `SpeedProvider`: Fornece a velocidade atual de movimento, considerando modificadores.
* `Rigidbody2D`: Componente físico para aplicar força e mover a entidade.

**Métodos:**

* `Start()`: Obtém referências para `IDirectionProvider`, `SpeedProvider` e `Rigidbody2D`.
* `Update()`: Aplica uma força ao `Rigidbody2D` na direção fornecida pelo `IDirectionProvider`, multiplicada pela velocidade fornecida pelo `SpeedProvider` e `Time.deltaTime`.

### `KeyboardDirectionProvider`

Esta classe implementa a interface `IDirectionProvider` e fornece a direção de movimento com base na entrada do teclado (eixos "Horizontal" e "Vertical").

**Métodos:**

* `GetCurrentDirection()`: Retorna um `Vector2` normalizado com base na entrada dos eixos "Horizontal" e "Vertical" do teclado.

### `SpeedProvider`

Esta classe gerencia a velocidade de uma entidade, aplicando uma `baseSpeed` e todos os `ISpeedModifier`s anexados ao mesmo `GameObject`.

**Propriedades Serializadas:**

* `baseSpeed`: A velocidade base da entidade.

**Dependências:**

* `ISpeedModifier[]`: Array de modificadores que alteram a velocidade.

**Métodos:**

* `Awake()`: Obtém referências para todos os `ISpeedModifier`s anexados.
* `GetCurrentSpeed()`: Calcula e retorna a velocidade atual, multiplicando a `baseSpeed` por todos os valores retornados pelos `ISpeedModifier`s.

### `RunModifier`

Esta classe implementa a interface `ISpeedModifier` e aplica um modificador de velocidade quando uma tecla específica é pressionada, simulando uma ação de "correr".

**Propriedades Serializadas:**

* `runIntensity`: O fator pelo qual a velocidade será multiplicada quando a tecla for pressionada.
* `key`: A `KeyCode` que ativa este modificador de velocidade.

**Métodos:**

* `GetSpeedModifier()`: Retorna `runIntensity` se a `key` estiver sendo pressionada, caso contrário, retorna `1` (sem modificação).
