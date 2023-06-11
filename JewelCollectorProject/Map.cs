using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JewelCollectorProject.Cells;
using JewelCollectorProject.Cells.Jewels;
using JewelCollectorProject.Cells.Obstacles;
using JewelCollectorProject.Cells.RobotParts;

namespace JewelCollectorProject.Maps
{
    /// <summary>
    /// Classe que representa o mapa (tabuleiro) do jogo.
    /// Seus atributos são:
    /// MapMatrix: Uma matriz de objetos do tipo Cell.
    /// maxTree, maxRedJewel, maxGreenJewel, maxBlueJewel, maxWater, maxAtomic: Inteiros que representam o máximo de cada elemento do jogo.
    /// Robot: Robô inicializado na posição 0X0 da matriz.
    /// </summary>
    public class Map
    {
        public List<List<Cell>> MapMatrix {get;} = new List<List<Cell>>();
        private int maxTree, maxRedJewel, maxGreenJewel, maxBlueJewel, maxWater, maxAtomic;
        public Robot Robot {get;} = new Robot(0,0);
        
        /// <summary>
        /// Método que imprime o elemento da matriz e em seguida retorna as cores do Console para o padrão original. 
        /// </summary>
        public void printMap()
        {
            Console.Clear();
            foreach (List<Cell> row in MapMatrix)
            {
                foreach (Cell cell in row)
                {
                    Console.Write(cell);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Método que cria uma matriz de Cell de acordo com a dimensão informada.
        /// Realiza uma validação conforme a regra:
        /// - Se a dimensão for igual a 10, insere os elementos em posições fixas na matriz.
        /// - Se a dimensão for diferente de 10, insere aleatoriamente os elementos realizando um cálculo proporcional para o máximo de cada elemento.
        /// </summary>
        /// <param name="dimension"></param>
        public void createMap(int dimension)
        {
            for(int i = 0; i < dimension; i++)
            {
                List<Cell> row = new List<Cell>();
                for (int j = 0; j < dimension; j++)
                {
                    row.Add(new Empty());
                }
                MapMatrix.Add(row);
            }
            if(dimension == 10)
            {
                insertFixedCells();
            } else
            {
                generateTotalElements(dimension);
                insertRandomCells(dimension);
            }
        }

        private void insertFixedCells()
        {
            insert(Robot, 0, 0);

            insert(new RedJewel(), 1, 9);
            insert(new RedJewel(), 8, 8);
            insert(new GreenJewel(), 9, 1);
            insert(new GreenJewel(), 7, 6);
            insert(new BlueJewel(), 3, 4);
            insert(new BlueJewel(), 2, 1);

            insert(new Water(), 5, 0);
            insert(new Water(), 5, 1);
            insert(new Water(), 5, 2);
            insert(new Water(), 5, 3);
            insert(new Water(), 5, 4);
            insert(new Water(), 5, 5);
            insert(new Water(), 5, 6);
            insert(new Tree(), 5, 9);
            insert(new Tree(), 3, 9);
            insert(new Tree(), 8, 3);
            insert(new Tree(), 2, 5);
            insert(new Tree(), 1, 4);
        }

        private void insertRandomCells(int dimension)
        {
            insert(Robot, 0, 0);

            for (int i = 0; i <= maxAtomic && dimension > 10; i++)
            {
                Random random = new Random();
                int x = random.Next(1, dimension);
                int y = random.Next(1, dimension);

                if(MapMatrix[x][y] is Empty)
                {
                    insert(new Atomic(), x, y);
                }
            }
            for (int i = 0; i <= maxWater; i++)
            {
                Random random = new Random();
                int x = random.Next(1, dimension);
                int y = random.Next(1, dimension);

                if(MapMatrix[x][y] is Empty)
                {
                    insert(new Water(), x, y);
                }
            }
            for (int i = 0; i <= maxTree; i++)
            {
                Random random = new Random();
                int x = random.Next(1, dimension);
                int y = random.Next(1, dimension);

                if(MapMatrix[x][y] is Empty)
                {
                    insert(new Tree(), x, y);
                }
            }
            for (int i = 0; i <= maxBlueJewel; i++)
            {
                Random random = new Random();
                int x = random.Next(1, dimension);
                int y = random.Next(1, dimension);

                if(MapMatrix[x][y] is Empty)
                {
                    insert(new BlueJewel(), x, y);
                }
            }
            for (int i = 0; i <= maxGreenJewel; i++)
            {
                Random random = new Random();
                int x = random.Next(1, dimension);
                int y = random.Next(1, dimension);

                if(MapMatrix[x][y] is Empty)
                {
                    insert(new GreenJewel(), x, y);
                }
            }
            for (int i = 0; i <= maxRedJewel; i++)
            {
                Random random = new Random();
                int x = random.Next(1, dimension);
                int y = random.Next(1, dimension);
                if(MapMatrix[x][y] is Empty)
                {
                    insert(new RedJewel(), x, y);
                }
            }
        }
        private void insert(Cell cell, int xLocation, int yLocation)
        {
            MapMatrix[xLocation][yLocation] = cell;
        }
        private void generateTotalElements(int dimension)
        {
            maxTree = (int)Math.Round(((dimension * dimension) - 1) * 0.1);
            maxRedJewel = (int)Math.Round(((dimension * dimension) - 1) * 0.1);
            maxGreenJewel = (int)Math.Round(((dimension * dimension) - 1) * 0.1);
            maxBlueJewel = (int)Math.Round(((dimension * dimension) - 1) * 0.1);
            maxWater = (int)Math.Round(((dimension * dimension) - 1) * 0.1);
            maxAtomic = (int)Math.Round(((dimension * dimension) - 1) * 0.01);
        }
    }
}