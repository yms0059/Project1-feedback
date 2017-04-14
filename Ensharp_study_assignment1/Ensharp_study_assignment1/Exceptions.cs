using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensharp_study_assignment1
{
    //예외처리 class
    class Exceptions
    {
        //문자열을 받아서 숫자인지 아닌지 판단하는 메소드
        public bool IsNumeric(string numberstring)
        {
            foreach (char i in numberstring)
            {
                if (Char.IsNumber(i) == false)
                {
                    return false;
                }
            }
            return true;
        }

        //정수 start부터 end까지의 입력이 아니면 다시 입력을 받음
        public int GetInput(int start, int end)
        {
            string inputnumber;

            while (true)
            {
                inputnumber = Console.ReadLine();

                while (inputnumber == "" || inputnumber[0] == ' ' || IsNumeric(inputnumber) == false)
                {
                    Console.Write("\t Input again : ");
                    inputnumber = Console.ReadLine();
                }

                if (Convert.ToInt32(inputnumber) >= start && Convert.ToInt32(inputnumber) <= end)
                {
                    return Convert.ToInt32(inputnumber);
                }

                Console.Write("\t Input again : ");
            }
        }

        //문자열 입력받을 때, 아무 것도 입력 안 한 거랑 공백만 있는 문자열은 다시 입력받게 함
        public string NameInputCheck()
        {
            string name;

            name = Console.ReadLine();

            while (name == "" || name[0] == ' ')
            {
                Console.Write("\t Input again : ");
                name = Console.ReadLine();
            }
            return name;
        }

        //3목 게임에서 골랐던 자리를 또 입력을 하게 되면 다시 입력받게 함
        public bool DuplicationCheck(int sel, string[,] board)
        {
            switch (sel)
            {
                case 1:
                    if (board[0, 0] == "○" || board[0, 0] == "●")
                        return false;
                    return true;

                case 2:
                    if (board[0, 1] == "○" || board[0, 1] == "●")
                        return false;
                    return true;

                case 3:
                    if (board[0, 2] == "○" || board[0, 2] == "●")
                        return false;
                    return true;

                case 4:
                    if (board[1, 0] == "○" || board[1, 0] == "●")
                        return false;
                    return true;

                case 5:
                    if (board[1, 1] == "○" || board[1, 1] == "●")
                        return false;
                    return true;

                case 6:
                    if (board[1, 2] == "○" || board[1, 2] == "●")
                        return false;
                    return true;

                case 7:
                    if (board[2, 0] == "○" || board[2, 0] == "●")
                        return false;
                    return true;

                case 8:
                    if (board[2, 1] == "○" || board[2, 1] == "●")
                        return false;
                    return true;

                case 9:
                    if (board[2, 2] == "○" || board[2, 2] == "●")
                        return false;
                    return true;
            }
            return true;
        }

        //게임에서 이기고 비기고 지는 것을 판단함
        public int CheckWinCase(string[,] board)
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0].Equals(board[i, 1], StringComparison.Ordinal) && board[i, 0].Equals(board[i, 2], StringComparison.Ordinal))
                {
                    return 3;
                }
                else if (board[0, i].Equals(board[1, i], StringComparison.Ordinal) && board[0, i].Equals(board[2, i], StringComparison.Ordinal))
                {
                    return 3;
                }
                else if (board[0, 0].Equals(board[1, 1], StringComparison.Ordinal) && board[0, 0].Equals(board[2, 2], StringComparison.Ordinal))
                {
                    return 3;
                }
                else if (board[0, 2].Equals(board[1, 1], StringComparison.Ordinal) && board[0, 2].Equals(board[2, 0], StringComparison.Ordinal))
                {
                    return 3;
                }
            }
            return 1;
        }



    }
}
