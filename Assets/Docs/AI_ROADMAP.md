# Arquitetura de IA de Combate (2D) – Estrutura Base

## Objetivo

Criar uma IA comportamental, adaptativa e modular, baseada em composição, separando claramente:

- Percepção
- Modelo Mental
- Memória
- Sistema de Avaliação
- Executor
- Adaptação

---

### 1. Perception Layer

Responsável por coletar informações do mundo.

## Retorna: `PerceptionData`

Contém, por exemplo:

- Distância até o alvo
- Direção
- Velocidade do alvo
- Estado atual do alvo (atacando, vulnerável, etc.)
- Cooldowns visíveis
- Contexto do ambiente

**Importante:**  
Percepção não decide nada. Apenas coleta dados.

---

### 2. Mental Model (Perfil do Inimigo)

Define a personalidade base do inimigo.

Exemplos de atributos:

- Agressividade base
- Tolerância a risco
- Inteligência (peso da memória)
- Tendência a bait
- Preferência de distância
- Impulsividade

Isso é o “DNA” do inimigo.

Não deve mudar drasticamente durante o combate.

---

### 3. Memory System

Armazena informações dinâmicas sobre o combate atual.

## Tipos de memória

### Curto prazo

- Últimas ações do jogador
- Último ataque que falhou
- Último parry recebido

### Médio prazo

- Frequência de parry do jogador
- Taxa de sucesso dos ataques
- Tendência atual (agressivo/passivo)

### Longo prazo (opcional)

- Estilo predominante do jogador
- Histórico entre partidas

Memória é modificada constantemente pela adaptação.

---

### 4. Evaluation Engine (Utility System)

Coração da decisão.

Recebe:

- PerceptionData
- Memory
- MentalModel

Para cada ação possível (Atacar, Recuar, Esperar, Baitar, Defender etc.) calcula:

Utility =  
BaseWeight(MentalModel)  
× ContextFactor(Perception)  
× MemoryModifier  
× RiskFactor  

A ação com maior utilidade é escolhida.

Não é FSM rígida. É avaliação dinâmica.

---

### 5. Action Executor

Responsável por executar a ação escolhida.

Ele:

- Controla movimento
- Dispara ataque
- Respeita cooldowns
- Respeita recovery
- Controla timing

Executor não decide nada.  
Ele apenas executa o que foi escolhido.

---

### 6. Adaptation Engine

Responsável por aprendizado durante o combate.

Recebe o resultado das ações (hit, parry, punido, erro etc.).

Atualiza:

- Memory (diretamente)
- Influência do MentalModel (indiretamente)

Nunca decide ação diretamente.
Apenas ajusta pesos e tendências.

---

### Loop Completo da IA

Perception  
→ Evaluation  
→ Action Selection  
→ Execution  
→ Combat Result  
→ Adaptation  
→ Memory Update  
→ Reavaliação  

Loop contínuo.

---

### Princípios Arquiteturais

- Cada camada tem responsabilidade única.
- Nenhuma camada conhece implementação interna da outra.
- IA nunca aplica dano diretamente.
- Executor nunca decide comportamento.
- Adaptação nunca executa ações.

---

### Resultado Final

Com essa arquitetura, a IA:

- Se adapta ao estilo do jogador
- Aprende padrões durante a luta
- Mantém personalidade própria
- Gera comportamento emergente
- Permanece modular e escalável

Base sólida para:

- Inimigos comuns
- Mini-bosses
- Bosses adaptativos
- IA evolutiva entre partidas
