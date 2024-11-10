# Jogo-da-Velha-csharp
Este é um mini projeto que fiz em c#, um jogo da velha básico, onde é necessário 2 pessoas para jogar.

### Estrutura do Jogo da Velha (Array 3x3)
- O jogo da velha é representado por um array 3x3. Cada posição do array é associada a um botão no jogo, e a checagem de vitória é realizada verificando as linhas, colunas e diagonais desse array.
- Abaixo está a representação do array 3x3, onde cada número representa a posição da célula:
  
![array 3x3](https://github.com/user-attachments/assets/9113cb70-940b-4f8f-976c-5623c7038489)

### Checagem de Vitória
A lógica de vitória é verificada com base nas posições do array, e também utilizei a propriedade `tabIndex` para facilitar a navegação entre os botões.

A vitória é determinada verificando se algum jogador preencheu uma linha, coluna ou diagonal com suas jogadas. O código checa as seguintes condições:
- **Horizontal**: As linhas do array, verificando as posições [0, 1, 2], [3, 4, 5] e [6, 7, 8].
- **Vertical**: As colunas, verificando as posições [0, 3, 6], [1, 4, 7] e [2, 5, 8].
- **Diagonal**: As diagonais, verificando as posições [0, 4, 8] e [2, 4, 6].
Com isso, conseguimos determinar se há uma vitória para algum jogador.
- Acesse o código fonte, caso queira dar uma olhada na lógica utilizada para fazer as checagens.


 ## Instalação
Siga as etapas abaixo para clonar e executar o projeto:

1. Clone o repositório:
   ```bash
   git clone https://github.com/d4nilo-sousa/Jogo-da-Velha-csharp.git

2. Abra o projeto no Visual Studio
   
3. Compile e execute o projeto pressionando F5 ou clicando em Iniciar.

## Exemplo de Uso
Após iniciar a aplicação, você verá a interface do jogo:
- O jogador X sempre inicia a partida.
- Na interface, você encontrará:
- Label de vez: indica de quem é a vez de jogar.
- Botões do tabuleiro: ao clicar em um botão, ele será preenchido com 'X' ou 'O', conforme o turno.
- Botão de reset: limpa o conteúdo dos botões e reinicia o jogo.
- Painel de pontuação: exibe a quantidade de pontos do jogador X, do jogador O e o número de empates.

