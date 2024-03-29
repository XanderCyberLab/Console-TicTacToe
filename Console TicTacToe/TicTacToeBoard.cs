﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_TicTacToe
{
    class TicTacToeBoard
    {
        protected int _row;
        protected int _col;
        protected char[,] position;
        protected List<Player> _players;


        //==========================================================================================
        public TicTacToeBoard(List<Player> players)
        {
            _row = 3;
            _col = 3;
            _players = players;

            initialiseGrid();



        }// end of constructor
        //==========================================================================================

        //==========================================================================================
        protected void initialiseGrid()
        {
            position = new char[_row, _col];
            for (int x = 0; x < _row; x++)
            {
                for (int y = 0; y < _col; y++)
                {
                    position[x, y] = ' ';
                }
            }

        }//end of initialiseGrid
        //==========================================================================================

        //==========================================================================================
        protected virtual void printGrid()
        {
            Console.WriteLine("     Columns");     
            Console.Write("   ");
            for (int i = 1; i <= _col; ++i)
            {
                Console.Write("-"+i+"- ");
            }
            Console.WriteLine("");
            Console.Write("  ");
            for (int i = 0; i <= _col * 4; ++i)
            {                
                Console.Write("-");    
            }
            Console.WriteLine("");            
            for (int x = 0; x < _row; x++)
            {
                //Console.Write("    ");

                Console.Write(x+1);
                for (int y = 0; y < _col; y++)
                    //Console.Write("    ");
                {                   
                    Console.Write(" | ");
                    Console.Write(position[x, y]);
                }
                Console.Write(" | ");
                Console.WriteLine("");
            }
            //Console.Write("    ");
            Console.Write("  ");
            for (int i = 0; i <= _col * 4; ++i)
            {
                Console.Write("-");               
            }
            Console.WriteLine("");
        }// end of printGrid
        //==========================================================================================


        //==========================================================================================
        protected bool PlayerMove(Player currentPlayer, int rowPosition, int colPosition)
        {
            if (rowPosition >= _row || rowPosition < 0 || colPosition >= _col || colPosition < 0)
            {
                return false;
            }

            // note the same indent
            if (position[rowPosition, colPosition] == ' ')
            {
                position[rowPosition, colPosition] = currentPlayer.GetPlayerSign();
                return true;
            }
            else
            {
                return false;
            }
        }// end of playerMove
        //==========================================================================================

        //==========================================================================================
        protected virtual bool checkPlayerWon(Player currentPlayer)
        {
            //Horizontal 
            for (int i = 0; i < _row; ++i)
            {
                if ((position[i, 0] == currentPlayer.GetPlayerSign()) &&
                    (position[i, 1] == currentPlayer.GetPlayerSign()) &&
                    (position[i, 2] == currentPlayer.GetPlayerSign()))
                {

                    return true;
                }
            }


            //Vertical
            for (int i = 0; i < _col; ++i)
            {
                if ((position[0, i] == currentPlayer.GetPlayerSign()) &&
                    (position[1, i] == currentPlayer.GetPlayerSign()) &&
                    (position[2, i] == currentPlayer.GetPlayerSign()))
                {
                    return true;
                }
            }

            //Diagonal
            if ((position[0, 0] == currentPlayer.GetPlayerSign()) &&
                (position[1, 1] == currentPlayer.GetPlayerSign()) &&
                (position[2, 2] == currentPlayer.GetPlayerSign()))
            {
                return true;
            }


            if (((position[0, 2] == currentPlayer.GetPlayerSign()) &&
                (position[1, 1] == currentPlayer.GetPlayerSign()) &&
                (position[2, 0] == currentPlayer.GetPlayerSign())))
            {
                return true;
            }


            return false;
        }// end of playerWon
        //==========================================================================================


        //==========================================================================================
        public void PlayGame()
        {

            // just incase we wanted to play agian with this object
            initialiseGrid();

            while (true)
            {
                //if (playerOneTurnToMove == true)
                foreach (Player currentPlayer in _players)
                {
                    Console.Clear();
                    this.printGrid();

                    this.playerTurn(currentPlayer);
                    
                    if (this.checkPlayerWon(currentPlayer))
                    {

                        this.PlayerWon(currentPlayer);

                        return; // exits the function so ofcourse it exist all loops
                    }
                    
                }
            }


        }// end of PlayGame
        //==========================================================================================


        //==========================================================================================
        protected virtual void playerTurn(Player currentPlayer)
        {
            bool validMove = false;
            while (validMove == false)
            {
                Console.Clear();
                this.printGrid();
                Console.WriteLine("");
                Console.WriteLine("{0} please select a Row", currentPlayer.GetPlayerName());
                int rowPosition = Int32.Parse(Console.ReadLine()) - 1;
                Console.WriteLine("{0} please select a Column", currentPlayer.GetPlayerName());
                int colPosition = Int32.Parse(Console.ReadLine()) - 1;
                validMove = this.PlayerMove(currentPlayer, rowPosition, colPosition);

                
            }


        }// end of playerTurn
        //==========================================================================================


        //==========================================================================================
        private void PlayerWon(Player currentPlayer)
        {
            Console.Clear();
            this.printGrid();

            currentPlayer.IncreasedPlayerTotalWins();

            Console.WriteLine("Congratulations {0}", currentPlayer.GetPlayerName());
            Console.WriteLine("Scoreboard");
            //Console.WriteLine("{0} {1} | {2} {3}", playerOne.GetPlayerName(),
            //playerOne.GetPlayerTotalWins(),
            //                                        playerTwo.GetPlayerName(),
            //                                        playerTwo.GetPlayerTotalWins());
            Console.ReadLine();

        }// end of PlayerWon
        //==========================================================================================

    }//CLASS
}//NAMESPACE

        