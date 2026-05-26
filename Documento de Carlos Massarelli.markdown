# 🎯 Sistema de Plataforma de Streaming

## 📚 Objetivo do Desafio

Desenvolver um sistema completo utilizando os **4 pilares da Programação Orientada a Objetos (POO)**:

- Encapsulamento
- Herança
- Polimorfismo
- Abstração

O projeto deverá ser desenvolvido em C# utilizando console application.

---

# 🎬 Contexto do Projeto

Uma empresa deseja criar uma plataforma de streaming semelhante à Netflix ou Spotify.

A plataforma possui diferentes tipos de conteúdo:

- Filmes
- Séries
- Podcasts

Todos os conteúdos possuem informações em comum, porém cada tipo possui comportamentos específicos.

O sistema deverá permitir:

- cadastrar conteúdos
- listar conteúdos
- buscar conteúdo por título
- remover conteúdos
- exibir informações completas

---

# 🎯 Objetivo do Sistema

Criar um sistema orientado a objetos que permita gerenciar conteúdos de uma plataforma de streaming.

---

# 📌 Regras Obrigatórias

O projeto DEVE utilizar obrigatoriamente:

- Classes
- Objetos
- Construtores
- Encapsulamento
- Herança
- Polimorfismo
- Abstração
- Sobrescrita de métodos (`override`)
- Listas (`List<T>`)

---

# ✅ Abstração

Criar uma classe abstrata chamada:

```csharp
Conteudo
```

Ela NÃO poderá ser instanciada diretamente.

---

# ✅ Encapsulamento

Todos os atributos devem ser privados.

Exemplo:

```csharp
private string titulo;
```

Os atributos deverão ser acessados através de:

- métodos getters/setters

---

# ✅ Herança

Criar as seguintes classes filhas:

```csharp
Filme
Serie
Podcast
```

Todas devem herdar da classe:

```csharp
Conteudo
```

---

# ✅ Polimorfismo

A classe abstrata deverá possuir o método:

```csharp
public abstract void ExibirInformacoes();
```

Cada classe filha deverá sobrescrever esse método utilizando:

```csharp
override
```

Cada tipo de conteúdo deverá exibir informações diferentes.

---

# 🧱 Estrutura Esperada

# Classe Abstrata: Conteudo

## Atributos

- Id
- Titulo
- Categoria
- AnoLancamento

---

## Métodos

```csharp
public abstract void ExibirInformacoes();
```

---

# 🎥 Classe Filme

## Atributos

- DuracaoMinutos

---

## Exemplo de comportamento

```text
===== FILME =====

Título: Interestelar
Categoria: Ficção Científica
Ano: 2014
Duração: 169 minutos

Filme disponível para assistir.
```

---

# 📺 Classe Serie

## Atributos

- QuantidadeTemporadas
- EpisodiosPorTemporada

---

## Exemplo de comportamento

```text
===== SÉRIE =====

Título: Dark
Categoria: Ficção
Ano: 2017

Temporadas: 3
Episódios por temporada: 10

Série com múltiplas temporadas.
```

---

# 🎙️ Classe Podcast

## Atributos

- NomeApresentador
- QuantidadeEpisodios

---

## Exemplo de comportamento

```text
===== PODCAST =====

Título: Hipsters Ponto Tech
Categoria: Tecnologia
Ano: 2024

Apresentador: Paulo Silveira
Quantidade de episódios: 200

Podcast disponível em áudio.
```

---

# 🖥️ Funcionalidades Obrigatórias

O sistema deverá possuir um menu semelhante a este:

```text
1 - Cadastrar conteúdo
2 - Listar conteúdos
3 - Buscar conteúdo por título
4 - Exibir detalhes de um conteúdo
5 - Remover conteúdo
6 - Sair
```

---

# 📌 Regras de Validação

O sistema deve impedir:

- título vazio
- categoria vazia
- ano inválido
- duração negativa
- quantidade de episódios menor que 1
- IDs duplicados

---

# 💡 Requisitos Técnicos

O projeto deverá utilizar:

- `List<Conteudo>`
- métodos
- construtores
- propriedades
- sobrescrita de métodos
- classe abstrata
- herança
- encapsulamento
- polimorfismo

---

# 🔥 Desafios Extras

## ⭐ Nível 1

Adicionar:

- sistema de avaliação
- nota de 0 a 10
- ranking dos conteúdos mais bem avaliados

### Valor:
+2 pontos

---

## ⭐⭐ Nível 2

Criar a interface:

```csharp
IReproduzivel
```

Com os métodos:

```csharp
Play()
Pause()
```

As classes deverão implementar essa interface.

### Valor:
+3 pontos
