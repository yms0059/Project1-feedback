using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;

namespace Ensharp_study_assignment1
{
    class Game
    {
        Exceptions Exc = new Exceptions();
        PlayerInfo PInfo = new PlayerInfo();

        public Game()
        {
            
        }

        public void PlayerMode()
        {
            //3목 게임 판을 2차원 배열로 생성함
            string[,] tttboard = new string[3, 3] { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };

            //9번을 넘어갈 수 없기 때문에 말을 둔 횟수가 9를 넘어가면 게임이 종료되게 설정하고, 말 두는 순서를 구별하기 위해 선언
            int turn = 0;
            //선공, 후공 선택 시 입력받음
            int chooseturn;
            //3목 게임 판에서 말을 둘 곳을 고르는 입력을 받음
            int selection;
            
            //PlayerMode일 때, 플레이하는 두 사람 이름을 입력받음
            PInfo.setPlayerModeName();

            Console.Clear();
            Console.Title = "tic tac toe _ jaehyuk shin";
            Console.WriteLine("●○●○●○●○●○●○●○●○●○●○");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t [ tic tac toe ]");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("     Hello " + PInfo.P1name + " and " + PInfo.P2name + ". Choose Turn");
            Console.WriteLine();
            Console.WriteLine("   1. " + PInfo.P1name + " First Turn   2. " + PInfo.P2name + " First Turn");
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("●○●○●○●○●○●○●○●○●○●○");
            Console.WriteLine();
            Console.Write("\t Input number : ");

            //선공, 후공 선택
            chooseturn = Exc.GetInput(1, 2);

            //3목 게임 판을 출력, 말을 고를 때마다 refresh된다
            Board(tttboard);
            
            do
            {
                //P1이 선공을 하는 경우
                if (chooseturn == 1)
                {
                    //P1이 말을 두는 순서일 때,
                    if (turn % 2 == 0)
                    {
                        Console.Write("\t" + PInfo.P1name + " Turn");
                        selection = Exc.GetInput(1, 9);
                        //중복된 곳을 선택했는지 체크해서 다시 입력받게 함
                        while (Exc.DuplicationCheck(selection, tttboard) == false)
                        {
                            Console.Write("\t Already selected. Input again");
                            selection = Exc.GetInput(1, 9);
                        }
                    }
                    //P2가 말을 두는 순서일 때,
                    else
                    {
                        Console.Write("\t" + PInfo.P2name + " Turn");
                        selection = Exc.GetInput(1, 9);
                        //중복된 곳을 선택했는지 체크해서 다시 입력받게 함
                        while (Exc.DuplicationCheck(selection, tttboard) == false)
                        {
                            Console.Write("\t Already selected. Input again");
                            selection = Exc.GetInput(1, 9);
                        }
                    }
                }
                //P2가 선공을 하는 경우
                else
                {
                    //P2가 말을 두는 순서
                    if (turn % 2 == 0)
                    {
                        Console.Write("\t" + PInfo.P2name + " Turn");
                        selection = Exc.GetInput(1, 9);
                        //중복된 곳을 선택했는지 체크해서 다시 입력받게 함
                        while (Exc.DuplicationCheck(selection, tttboard) == false)
                        {
                            Console.Write("\t Already selected. Input again");
                            selection = Exc.GetInput(1, 9);
                        }
                    }
                    //P1이 말을 두는 순서
                    else
                    {
                        Console.Write("\t" + PInfo.P1name + " Turn");
                        selection = Exc.GetInput(1, 9);
                        //중복된 곳을 선택했는지 체크해서 다시 입력받게 함
                        while (Exc.DuplicationCheck(selection, tttboard) == false)
                        {
                            Console.Write("\t Already selected. Input again");
                            selection = Exc.GetInput(1, 9);
                        }
                    }
                }

                //입력받은 selection으로 선택한 부분 표시
                if (turn % 2 == 0)
                {
                    switch (selection)
                    {
                        case 1:
                            tttboard[0, 0] = "○";
                            Board(tttboard);
                            break;
                        case 2:
                            tttboard[0, 1] = "○";
                            Board(tttboard);
                            break;
                        case 3:
                            tttboard[0, 2] = "○";
                            Board(tttboard);
                            break;
                        case 4:
                            tttboard[1, 0] = "○";
                            Board(tttboard);
                            break;
                        case 5:
                            tttboard[1, 1] = "○";
                            Board(tttboard);
                            break;
                        case 6:
                            tttboard[1, 2] = "○";
                            Board(tttboard);
                            break;
                        case 7:
                            tttboard[2, 0] = "○";
                            Board(tttboard);
                            break;
                        case 8:
                            tttboard[2, 1] = "○";
                            Board(tttboard);
                            break;
                        case 9:
                            tttboard[2, 2] = "○";
                            Board(tttboard);
                            break;
                    }
                    //말을 한 번씩 뒀을 때마다 이긴경우가 있는지 체크함, 3을 리턴하면 이긴경우
                    if (Exc.CheckWinCase(tttboard) == 3)
                    {
                        //만약에 이겼을 경우, turn을 9만큼 올려줘서 게임이 종료되게 설정
                        turn += 9;
                        //P1이 이긴 경우 P1이 3점 올라간다
                        if (chooseturn == 1)
                        {
                            PInfo.setPlayerModeScore(3);
                            PInfo.setPlayerModeScore(0);
                            Console.WriteLine("\t" + PInfo.P1name + " ○○○ WinWinWin");
                            Console.WriteLine("\t Congratulations, " + PInfo.P1name + " got 3 points");
                        }
                        //P2가 이긴 경우 P2가 3점 올라간다
                        else
                        {
                            PInfo.setPlayerModeScore(0);
                            PInfo.setPlayerModeScore(3);
                            Console.WriteLine("\t" + PInfo.P2name + " ○○○ WinWinWin");
                            Console.WriteLine("\t Congratulations, " + PInfo.P2name + " got 3 points");
                        }
                    }
                }

                else
                {
                    switch (selection)
                    {
                        case 1:
                            tttboard[0, 0] = "●";
                            Board(tttboard);
                            break;
                        case 2:
                            tttboard[0, 1] = "●";
                            Board(tttboard);
                            break;
                        case 3:
                            tttboard[0, 2] = "●";
                            Board(tttboard);
                            break;
                        case 4:
                            tttboard[1, 0] = "●";
                            Board(tttboard);
                            break;
                        case 5:
                            tttboard[1, 1] = "●";
                            Board(tttboard);
                            break;
                        case 6:
                            tttboard[1, 2] = "●";
                            Board(tttboard);
                            break;
                        case 7:
                            tttboard[2, 0] = "●";
                            Board(tttboard);
                            break;
                        case 8:
                            tttboard[2, 1] = "●";
                            Board(tttboard);
                            break;
                        case 9:
                            tttboard[2, 2] = "●";
                            Board(tttboard);
                            break;
                    }
                    if (Exc.CheckWinCase(tttboard) == 3)
                    {
                        turn += 9;
                        if (chooseturn == 1)
                        {
                            PInfo.setPlayerModeScore(0);
                            PInfo.setPlayerModeScore(3);
                            Console.WriteLine("\t" + PInfo.P2name + " ●●● WinWinWin");
                            Console.WriteLine("\t Congratulations, " + PInfo.P2name + " got 3 points");
                        }
                        else
                        {
                            PInfo.setPlayerModeScore(3);
                            PInfo.setPlayerModeScore(0);
                            Console.WriteLine("\t" + PInfo.P1name + " ●●● WinWinWin");
                            Console.WriteLine("\t Congratulations, " + PInfo.P1name + " got 3 points");
                        }
                    }
                }
                //말을 9번 다 뒀을 때, 3목 게임 판을 확인해서 이긴 경우가 없으면 비긴경우이다
                if (turn == 8)
                {
                    //비겼을 시, 3이 아닌 1을 반환하게 설정
                    if (Exc.CheckWinCase(tttboard) == 1)
                    {
                        //P1, P2 두 명에게 1점씩 나눠줌
                        PInfo.setPlayerModeScore(1);
                        PInfo.setPlayerModeScore(1);
                        Console.WriteLine("\t DrawDrawDraw");
                        Console.WriteLine("\t Fair Play, You got 1 point each");
                    }
                }
                //한 번 씩 말을 둘 때마다, turn이 1씩 올라간다
                turn++;
            }
            while (turn < 9);
            Console.WriteLine("\t Game Ended");

            Console.WriteLine();
            Console.WriteLine("\t Press ENTER to return to the menu");
            Console.ReadLine();
        }




        public void ComputerMode()
        {
            string[,] tttboard = new string[3, 3] { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };

            int turn = 0;
            int chooseturn;
            int selection;
            
            Random computersel = new Random();

            //컴퓨터 대전 모드에서의 플레이어의 이름을 입력받고, 점수를 0으로 초기화해준다
            PInfo.setComputerModeName();

            Console.Clear();
            Console.Title = "tic tac toe _ jaehyuk shin";
            Console.WriteLine("●○●○●○●○●○●○●○●○●○●○");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t [ tic tac toe ]");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("     Hello " + PInfo.ComputerModeName + " Choose Turn");
            Console.WriteLine();
            Console.WriteLine("   1. First Turn   2. Second Turn");
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("●○●○●○●○●○●○●○●○●○●○");
            Console.WriteLine();
            Console.Write("\t Input number : ");

            chooseturn = Exc.GetInput(1, 2);

            Board(tttboard);

            do
            {
                //유저가 선공을 하는 경우
                if (chooseturn == 1)
                {
                    //유저 순서일 때, 말을 둘 곳을 입력받음
                    if (turn % 2 == 0)
                    {
                        Console.Write("\t" + PInfo.ComputerModeName + " Turn");
                        selection = Exc.GetInput(1,9);
                        while (Exc.DuplicationCheck(selection, tttboard) == false)
                        {
                            Console.Write("\t Already selected. Input again");
                            selection = Exc.GetInput(1, 9);
                        }
                    }
                    //컴퓨터가 하는 순서일 때, 말을 원래 뒀던 곳이 아닌 빈 곳을 임의로 골라 말을 둔다
                    else
                    {
                        //컴퓨터가 말을 두는 시간을 조금 둬서 바로바로 입력이 안 되게 설정
                        Thread.Sleep(1000);
                        selection = computersel.Next(1, 10);
                        while (Exc.DuplicationCheck(selection, tttboard) == false)
                        {
                            selection = computersel.Next(1, 10);
                        }
                    }
                }
                //유저가 후공을 하는 경우
                else
                {
                    if (turn % 2 == 0)
                    {
                        Thread.Sleep(1000);
                        selection = computersel.Next(1, 10);
                        while (Exc.DuplicationCheck(selection, tttboard) == false)
                        {
                            selection = computersel.Next(1, 10);
                        }
                    }
                    else
                    {
                        Console.Write("\t" + PInfo.ComputerModeName + " Turn");
                        selection = Exc.GetInput(1,9);
                        while (Exc.DuplicationCheck(selection, tttboard) == false)
                        {
                            Console.Write("\t Already selected. Input again");
                            selection = Exc.GetInput(1, 9);
                        }
                    }
                }

                if (turn % 2 == 0)
                {
                    switch (selection)
                    {
                        case 1:
                            tttboard[0, 0] = "○";
                            Board(tttboard);
                            break;
                        case 2:
                            tttboard[0, 1] = "○";
                            Board(tttboard);
                            break;
                        case 3:
                            tttboard[0, 2] = "○";
                            Board(tttboard);
                            break;
                        case 4:
                            tttboard[1, 0] = "○";
                            Board(tttboard);
                            break;
                        case 5:
                            tttboard[1, 1] = "○";
                            Board(tttboard);
                            break;
                        case 6:
                            tttboard[1, 2] = "○";
                            Board(tttboard);
                            break;
                        case 7:
                            tttboard[2, 0] = "○";
                            Board(tttboard);
                            break;
                        case 8:
                            tttboard[2, 1] = "○";
                            Board(tttboard);
                            break;
                        case 9:
                            tttboard[2, 2] = "○";
                            Board(tttboard);
                            break;
                    }
                    if (Exc.CheckWinCase(tttboard) == 3)
                    {
                        turn += 9;
                        if (chooseturn == 1)
                        {
                            //유저가 이긴 경우 유저의 점수를 3점 올려준다
                            PInfo.updateComputerModeScore(3);
                            Console.WriteLine("\t" + PInfo.ComputerModeName + " ○○○ WinWinWin");
                            Console.WriteLine("\t Congratulations, You got 3 points");
                        }
                        else
                        {
                            //컴퓨터가 이긴 경우 유저의 점수는 올라가지 않는다
                            Console.WriteLine("\t Computer ○○○ WinWinWin");
                            Console.WriteLine("\t You got 0 point");
                        }
                        
                    }

                }

                else
                {
                    switch (selection)
                    {
                        case 1:
                            tttboard[0, 0] = "●";
                            Board(tttboard);
                            break;
                        case 2:
                            tttboard[0, 1] = "●";
                            Board(tttboard);
                            break;
                        case 3:
                            tttboard[0, 2] = "●";
                            Board(tttboard);
                            break;
                        case 4:
                            tttboard[1, 0] = "●";
                            Board(tttboard);
                            break;
                        case 5:
                            tttboard[1, 1] = "●";
                            Board(tttboard);
                            break;
                        case 6:
                            tttboard[1, 2] = "●";
                            Board(tttboard);
                            break;
                        case 7:
                            tttboard[2, 0] = "●";
                            Board(tttboard);
                            break;
                        case 8:
                            tttboard[2, 1] = "●";
                            Board(tttboard);
                            break;
                        case 9:
                            tttboard[2, 2] = "●";
                            Board(tttboard);
                            break;
                    }
                    if (Exc.CheckWinCase(tttboard) == 3)
                    {
                        turn += 9;
                        if (chooseturn == 1)
                        {
                            Console.WriteLine("\t Computer ●●● WinWinWin");
                            Console.WriteLine("\t You got 0 point");
                        }
                        else
                        {
                            PInfo.updateComputerModeScore(3);
                            Console.WriteLine("\t" + PInfo.ComputerModeName + " ●●● WinWinWin");
                            Console.WriteLine("\t Congratulations, You got 3 points");
                        }
                    }
                }
                //컴퓨터모드로 했을 시, 비긴 경우 체크해서 비기면 1점을 유저에게 준다
                if(turn == 8)
                {
                    if(Exc.CheckWinCase(tttboard) == 1)
                    {
                        PInfo.updateComputerModeScore(1);
                        Console.WriteLine("\t DrawDrawDraw");
                        Console.WriteLine("\t Fair Play, You got 1 point");
                    }
                }
                turn++;
            }
            while (turn < 9);
            Console.WriteLine("\t Game Ended");

            Console.WriteLine();
            Console.WriteLine("\t Press ENTER to return to the menu");
            Console.ReadLine();
        }

        //P1 vs P2 모드일 때, 실행했던 게임마다의 점수를 보여준다
        public void showPlayerModeScore()
        {
            Console.Clear();
            Console.Title = "Tic Tac Toe _ JaeHyuk Shin";
            Console.WriteLine("●○●○●○●○●○●○●○●○●○●○");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t [ Tic Tac Toe ]");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine(" Player vs Player Mode Score Board");
            Console.WriteLine();

            PInfo.showPlayerModeInfo();

            Console.WriteLine();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine();
        }

        //컴퓨터 대전 모드일 때의 점수를 출력해준다
        public void showComputerModeScore()
        {
            Console.WriteLine(" Player vs Computer Mode Score Board");
            Console.WriteLine();

            PInfo.showComputerModeInfo();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("●○●○●○●○●○●○●○●○●○●○");
            Console.WriteLine("\nPress ENTER to return to the menu\n");

            Console.ReadLine();
            
        }

        //3목 게임 판을 출력
        public void Board(string[,] board)
        {
            Console.Clear();
            Console.Title = "Tic Tac Toe _ JaeHyuk Shin";
            Console.WriteLine("●○●○●○●○●○●○●○●○●○●○");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t [ Tic Tac Toe ]");
            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("     ");
                    Console.Write(board[i, j]);
                    Console.Write("     ");
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("●○●○●○●○●○●○●○●○●○●○");
            Console.WriteLine();
        }

    }
}
