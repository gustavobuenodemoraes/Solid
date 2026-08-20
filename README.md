# Princípios SOLID em C# (.NET 8)

Repositório prático para estudo, consulta e demonstração técnica dos princípios **SOLID**, contrastando implementações com alto acoplamento (anti-padrões) contra soluções desacopladas, coesas e preparadas para testes de unidade.

---

## 1. S - Princípio da Responsabilidade Única (Single Responsibility Principle - SRP)

> **Definição:** *Uma classe ou módulo deve ter um, e apenas um, motivo para mudar.*

### 🤖 Ilustração Visual do Conceito
![Ilustração do Princípio da Responsabilidade Única (SRP)](./img/conceito-srp.jpg)

---

## 2. O - Princípio Aberto/Fechado (Open/Closed Principle - OCP)

> **Definição:** *Entidades de software (classes, módulos, funções) devem estar abertas para extensão, mas fechadas para modificação.*

### 🤖 Ilustração Visual do Conceito

![Ilustração do Princípio Aberto/Fechado (OCP)](./img/conceito-ocp.jpg)

### 📊 Comparativo Técnico

| Aspecto | Modo Incorreto (`Ocp.Incorreto`) | Modo Correto (`Ocp.Correto`) |
| :--- | :--- | :--- |
| **Extensibilidade** | Baixa. Adicionar um novo meio de pagamento exige alterar a classe central com novos `if/else`. | Alta. Para suportar um novo meio, cria-se apenas uma nova classe que implementa `IEstrategiaPagamento`. |
| **Risco de Regressão** | Alto. Alterar código existente pode introduzir bugs em meios de pagamento que já estavam estáveis em produção. | Zero no núcleo. O processador existente nunca é modificado; apenas novas classes são injetadas. |
| **Padrão Aplicado** | Código procedural acoplado. | **Strategy Pattern** combinado com injeção de dependência e polimorfismo. |
