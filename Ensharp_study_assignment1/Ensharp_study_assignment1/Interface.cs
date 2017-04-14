using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;

namespace Ensharp_study_assignment1
{
    class Interface
    {
        Game PickGame = new Game();
        Exceptions Exc = new Exceptions();
        PlayerInfo PInfo = new PlayerInfo();

        public Interface()
        {
            
        }
        public void SelectMode()
        {
            Console.Clear();
            Console.Title = "Tic Tac Toe _ JaeHyuk Shin";
            Console.WriteLine("●○●○●○●○●○●○●○●○●○●○");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t [ Tic Tac Toe ]");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("\t 1. Player vs Player\n");
            Console.WriteLine("\t 2. Player vs Computer\n");
            Console.WriteLine("\t 3. Score Record\n");
            Console.WriteLine("\t 4. Exit program\n");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("●○●○●○●○●○●○●○●○●○●○");
            Console.WriteLine();
            Console.Write("\t Select Mode : ");

            
            //숫자를 입력받아서 어떤 모드로 들어갈지 결정한다
            int select_mode;
            select_mode = Exc.GetInput(1, 4);

            //4번 프로그램 종료를 누르기 전까지 프로그램은 계속 실행된다
            while (true)
            {
                switch (select_mode)
                {
                    //1. 플레이어 대전 모드
                    case 1:
                        PickGame.PlayerMode();
                        break;
                    
                    //2. 컴퓨터 대전 모드
                    case 2:
                        PickGame.ComputerMode();
                        break;
                    //3. 점수판 확인
                    case 3:
                        PickGame.showPlayerModeScore();
                        PickGame.showComputerModeScore();
                        break;
                    //4. 프로그램종료
                    case 4:
                        ConfirmingProcess();
                        break;
                }

                Console.Clear();
                Console.Title = "Tic Tac Toe _ JaeHyuk Shin";
                Console.WriteLine("●○●○●○●○●○●○●○●○●○●○");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("\t [ Tic Tac Toe ]");
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("\t 1. Player vs Player\n");
                Console.WriteLine("\t 2. Player vs Computer\n");
                Console.WriteLine("\t 3. Score Record\n");
                Console.WriteLine("\t 4. Exit program\n");

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("●○●○●○●○●○●○●○●○●○●○");
                Console.WriteLine();
                Console.Write("\t Select Mode : ");
                select_mode = Exc.GetInput(1, 4);
            }
        }
        //4. 프로그램 종료를 누르면 바로 꺼지지 않게 확인 프로세스를 거치게 함
        public void ConfirmingProcess()
        {
            int confirm_select;

            Console.Clear();
            Console.Title = "Tic Tac Toe _ JaeHyuk Shin";
            Console.WriteLine("●○●○●○●○●○●○●○●○●○●○");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t [ Tic Tac Toe ]");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("\t Are you sure ? \n");
            Console.WriteLine("\t 1. Yes \t 2. No\n");
            Console.WriteLine("\n");
            Console.WriteLine("\n");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("●○●○●○●○●○●○●○●○●○●○");
            Console.WriteLine();
            Console.Write("\t Input number : ");

            confirm_select = Exc.GetInput(1, 2);

            //종료 확인하면 프로그램을 완전히 종료시킴
            if (confirm_select == 1)
            {
                Console.Clear();
                Console.Title = "Tic Tac Toe _ JaeHyuk Shin";
                Console.WriteLine("●○●○●○●○●○●○●○●○●○●○");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("\t [ Tic Tac Toe ]");
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("\n");
                Console.WriteLine("\t Program Terminated. Bye\n");
                Console.WriteLine("\n");
                Console.WriteLine("\n");

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("●○●○●○●○●○●○●○●○●○●○");
                Console.WriteLine();
                Environment.Exit(1);
            }
            //종료를 취소하면 다시 메뉴화면을 생성해서 보여줌
            else
            {
                SelectMode();
            }
        }


    }
}
