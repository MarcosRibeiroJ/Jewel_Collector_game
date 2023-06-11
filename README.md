# Jewel Collector Game

Projeto final criado para a disciplina **INF0990 - Programação em C#**.
A disciplina foi ministrada pelo **Professor Dr. Ricardo Ribeiro Gudwin** no curso de extensão **"Tecnologias Microsoft"** na **Universidade de Campinas (Unicamp)**.<br>
Nesse projeto, foi desenvolvido um jogo em C# que deve ser executado em Prompt de Comando.

## Objetivo do Jogo

O objetivo do jogo é conduzir um robô por um mapa 2D, coletando joias e desviando de obstáculos. Ganha o jogo quem coletar todas as joias de todas as 30 fases.
 
 ## Comandos básicos
 
 Utilize as teclas:
 
 - W (movimenta o robô uma casa para cima).
 - A (movimenta o robô uma casa para à esquerda).
 - S (movimenta o robô uma casa para baixo).
 - D (movimenta o robô uma casa para à direita).
 - G (coleta joias ou recarrega o robô).

## Símbolos de cada elemento

- **JB** (JewelBlue) Representa as joias do tipo Blue Jewel.
- **JG** (JewelGreen) Representa as joias do tipo Green Jewel.
- **JR** (JewelRed) Representa as joias do tipo Red Jewel.
- **ME** Representa o robô.
- **\##** Representa água e o robô não pode ultrapassá-la.
- **\$$** Representa uma árvore e o robô não pode ultrapassá-la. Quando está na cor verde, pode ser utilizada para recarregar o robô, mas quando está na cor preta, significa que já foi utilizada.
- **!!** Representa o elemento radioativo.

## Como jogar

Percorra o mapa e quando estiver próximo a uma joia ou árvore em uma das quatro direções (acima, abaixo, esquerda, direita), pressione a tecla G para coletar/recarregar.

### Regras a partir do Level 2

A partir do level 2 o robô terá um tanque de combustível, cada movimento reduz esse combustível em 1 ponto. Você perde o jogo se o combustível acabar.
É possível recarregar pressionando a tecla G quando estiver próximo de uma árvore ou quando coletar uma joia do tipo **JewelBlue**.
- A **árvore** recarrega o combustível em **3 pontos**, mas o robô só pode recarregar uma vez em cada árvore.
- A joia **JewelBlue** recarrega o combustível em **5 pontos**.
- Tome cuidado com o elemento **radioativo**, se o robô passar ao lado de um, perderá **10 pontos** de combustível. É possível desativar esse elemento se o robô ocupar sua casa, mas ao fazer isso, perderá **30 pontos** de combustível.
