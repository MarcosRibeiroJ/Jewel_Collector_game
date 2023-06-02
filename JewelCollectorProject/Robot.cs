using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JewelCollectorProject.Jewels;

namespace JewelCollectorProject
{
    /// <summary>
    /// Classe que define um objeto do tipo Robot.
    /// Essa classe herda de Cell e sendo assim, precisa reescrever o método ToString
    /// </summary>
    public class Robot : Cell
    {
        public int X {get;set;}
        public int Y {get;set;}
        public int Bag {get; set;}
        public int TotalScore {get; set;}
        public string? PressedKeyStatus {get; set;}
        /// <summary>
        /// Construtor de um objeto do tipo Robot
        /// </summary>
        /// <param name="xLocation">Recebe um inteiro que irá representar a posição atual do Robot na coordenada X</param>
        /// <param name="yLocation">Recebe um inteiro que irá representar a posição atual do Robot na coordenada Y</param>
        public Robot(int xLocation, int yLocation)
        {
            X = xLocation;
            Y = yLocation;
        }

        /// <summary>
        /// Método que move o Robot uma posição acima.
        /// Esse método recebe como parâmetro um objeto do tipo mapa e de acordo com a posição atual do Robot no mapa, verifica se a próxima posição é do tipo Empty (vazia).
        /// Em caso positivo, utiliza um try catch para tentar mover o Robot.
        /// Ele conseguirá mover sempre que existir ao menos uma célula acima do Robot e fará uma troca de objetos na matriz que representa o mapa.
        /// Após a troca, irá alterar o valor da property PressedKeyStatus passando uma string que representa a tecla usada para mover o Robot acima.
        /// Isso gera um efeito visual que imprime a tecla pressionada pelo usuário no jogo principal.
        /// Caso o Robot não consiga se mover acima, uma Exception do tipo ArgumentOutOfRangeException é gerada e no jogo principal será impresso uma mensagem para o usuário.
        /// </summary>
        /// <param name="map">Objeto do tipo Map que o Robot recebe para analisar sua posição atual e os objetos ao seu redor</param>
        public void moveUp(List<List<Cell>> map)
        {
            try
            {
                if(map[X-1][Y] is Empty)
                {
                    map[X][Y] = map[X-1][Y];
                    map[X-1][Y] = this;
                    X--;
                    PressedKeyStatus = "w";
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                
                PressedKeyStatus = "MOVIMENTO INVÁLIDO";
            }
            
        }

        /// <summary>
        /// Método com a mesma funcionalidade de "moveUp", porém a validação verifica objetos na célula à esquerda de Robot.
        /// Possui o mesmo tratamento "try/catch" mas em caso positivo, altera o valor de PressedKeyStatus para a string que representa a tecla usada para mover o Robot para a esquerda.
        /// </summary>
        /// <param name="map">Objeto do tipo Map que o Robot recebe para analisar sua posição atual e os objetos ao seu redor</param>
        public void moveLeft(List<List<Cell>> map) {
            try
            {
                if(map[X][Y-1] is Empty)
                {
                    map[X][Y] = map[X][Y-1];
                    map[X][Y-1] = this;
                    Y--;
                    PressedKeyStatus = "a";
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                
                PressedKeyStatus = "MOVIMENTO INVÁLIDO";
            }
            
        }

        /// <summary>
        /// Método com a mesma funcionalidade de "moveUp", porém a validação verifica objetos na célula abaixo de Robot.
        /// Possui o mesmo tratamento "try/catch" mas em caso positivo, altera o valor de PressedKeyStatus para a string que representa a tecla usada para mover o Robot para baixo.
        /// </summary>
        /// <param name="map">Objeto do tipo Map que o Robot recebe para analisar sua posição atual e os objetos ao seu redor</param>
        public void moveDown(List<List<Cell>> map)
        {
            try
            {
                if(map[X+1][Y] is Empty)
                {
                    map[X][Y] = map[X+1][Y];
                    map[X+1][Y] = this;
                    X++;
                    PressedKeyStatus = "s";
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                
                PressedKeyStatus = "MOVIMENTO INVÁLIDO";
            }
            
        }

        /// <summary>
        /// Método com a mesma funcionalidade de "moveUp", porém a validação verifica objetos na célula à direita de Robot.
        /// Possui o mesmo tratamento "try/catch" mas em caso positivo, altera o valor de PressedKeyStatus para a string que representa a tecla usada para mover o Robot para a direita.
        /// </summary>
        /// <param name="map">Objeto do tipo Map que o Robot recebe para analisar sua posição atual e os objetos ao seu redor</param>
        public string moveRight(List<List<Cell>> map)
        {
            int totalColumns = map.Count > 0 ? map[0].Count : 0;

            try
            {
                if(map[X][Y+1] is Empty)
                {
                    map[X][Y] = map[X][Y+1];
                    map[X][Y+1] = this;
                    Y++;
                    PressedKeyStatus = "d";
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                
                PressedKeyStatus = "MOVIMENTO INVÁLIDO";
            }
            return "";
        }
        
        /// <summary>
        /// Método principal para coletar as jóias.
        /// Esse método irá chamar outros quatro que realizam a coleta em cada uma das células ao redor do Robot
        /// </summary>
        /// <param name="map">Objeto Map necessário para verificar as jóias nas posições ao redor de Robot</param>
        public void captureJewel(List<List<Cell>> map) {
            isJewelUp(map);
            isJewelDown(map);
            isJewelLeft(map);
            isJewelRight(map);
            PressedKeyStatus = "g";
        }

        /// <summary>
        /// Método que verifica se acima de Robot existe uma célula acima de Robot e se a célula um objeto do tipo IJewel.
        /// Nesse caso, optei por não utilizar um bloco "try/catch" porque o método irá verificar as 4 direções ao redor de Robot.
        /// Nessa lógica mesmo que ele não consiga coletar acima, talvez existam jóias em outras posições.
        /// Uma mensagem de "MOVIMENTO INVÁLIDO" para coletas acima, poderia não ser verdade para alguma das outras posições.
        /// A interface IJewel foi criada para não ter necessidade de vericar entre os 3 tipos de jóias, reduzindo o número de validações.
        /// Caso o objeto acima de Robot seja uma jóia, esse objeto é enviado para o método "score" que fará o devido tratamento
        /// Em seguida será incrementado 1 na Bag de Robot para controlar o total de jóias coletadas.
        /// Por último um novo objeto do tipo Empty será instanciado e e adicionado na posição da jóia.
        /// </summary>
        /// <param name="map">Objeto Map necessário para analisar a posição de Robot e dos objetos ao seu redor.</param>
        private void isJewelUp(List<List<Cell>> map) {
            
            if(X > 0 && map[X-1][Y] is IJewel) {
                score(map[X-1][Y]);
                Bag++;
                Cell cell = new Empty();
                map[X-1][Y] = cell;
            }
        }

        /// <summary>
        /// Mesma funcionalidade de "isJewelUp" mas verifica o conteúdo da célula abaixo de Robot.
        /// </summary>
        /// <param name="map">Objeto Map necessário para analisar a posição de Robot e dos objetos ao seu redor.</param>
        private void isJewelDown(List<List<Cell>> map) {
            
            if(X < map.Count -1 && map[X+1][Y] is IJewel) {
                score(map[X+1][Y]);
                Bag++;
                Cell cell = new Empty();
                map[X+1][Y] = cell;
            }
        }

        /// <summary>
        /// Mesma funcionalidade de "isJewelUp" mas verifica o conteúdo da célula à esquerda de Robot.
        /// </summary>
        /// <param name="map">Objeto Map necessário para analisar a posição de Robot e dos objetos ao seu redor.</param>
        private void isJewelLeft(List<List<Cell>> map) {
            
            if(Y > 0 && map[X][Y-1] is IJewel) {
                score(map[X][Y-1]);
                Bag++;
                Cell cell = new Empty();
                map[X][Y-1] = cell;
            }
        }

        /// <summary>
        /// Mesma funcionalidade de "isJewelUp" mas verifica o conteúdo da célula à direita de Robot.
        /// </summary>
        /// <param name="map">Objeto Map necessário para analisar a posição de Robot e dos objetos ao seu redor.</param>
        private void isJewelRight(List<List<Cell>> map) {
            int totalColumns = map.Count > 0 ? map[0].Count : 0;

            if(Y < totalColumns -1 && map[X][Y+1] is IJewel) {
                score(map[X][Y+1]);
                Bag++;
                Cell cell = new Empty();
                map[X][Y+1] = cell;
            }
        }

        /// <summary>
        /// Método que recebe um objeto do tipo mais genérico Cell.
        /// Em seguida de acordo com o tipo de jóia, incrementa na property TotalScore o valor que cada jóia possui.
        /// Mesmo recebendo como parâmetro um objeto mais genérico Cell, não terei conflitos porque a validação para IJewel já foi realizada anteriormente.
        /// </summary>
        /// <param name="jewel">Objeto do tipo Cell que representa uma jóia.</param>
        public void score(Cell jewel) {
            if(jewel is RedJewel)
            {
                TotalScore += 100;
            } else if(jewel is GreenJewel)
            {
                TotalScore += 50;
            } else if(jewel is BlueJewel)
            {
                TotalScore += 10;
            }           
        }

        /// <summary>
        /// Reescrita do método ToString herdado da classe abstrata Cell
        /// </summary>
        /// <returns>Retorna a impressão visual de um Robot no jogo.</returns>
        public override string ToString()
        {
            return " ME ";
        }
    }
}