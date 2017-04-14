using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;

namespace Ensharp_study_assignment1
{
    class PlayerInfo
    {
        Exceptions Exc = new Exceptions();

        //플레이어 대전 모드에서의 두 플레이어의 이름을 저장할 변수
        public string P1name;
        public string P2name;

        //컴퓨터 대전 모드에서의 유저 플레이어의 이름을 저장할 변수
        public string ComputerModeName;

        ArrayList PlayerModeName = new ArrayList();     //플레이어의 이름을 저장할 ArrayList 이름따로 점수 따로 저장해서 인덱스별로 매칭해서 점수를 출력을 한다
        ArrayList PlayerModeScore = new ArrayList();    //플레이어의 점수를 저장할 ArrayList

        //컴퓨터 대전 모드에서의 유저 플레이어의 이름과 점수를 Dictionary<Key, Value>형태로 저장해서, List<Dictionary>안에 넣어서 점수를 관리함
        public Dictionary<string, int> dictionary = new Dictionary<string, int>();

        public PlayerInfo()
        {
            
        }

        //플레이어 대전 모드에서 게임 시작 전에 플레이어들의 이름을 입력받음
        public void setPlayerModeName()
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
            Console.WriteLine("\t Player1 name\n");
            Console.WriteLine("\n");
            Console.WriteLine("\n");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("●○●○●○●○●○●○●○●○●○●○");
            Console.WriteLine();
            Console.Write("\t Input name : ");
            P1name = Exc.NameInputCheck();
            PlayerModeName.Add(P1name);

            Console.Clear();
            Console.Title = "Tic Tac Toe _ JaeHyuk Shin";
            Console.WriteLine("●○●○●○●○●○●○●○●○●○●○");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t [ Tic Tac Toe ]");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("\n");
            Console.WriteLine("\t Player2 name\n");
            Console.WriteLine("\n");
            Console.WriteLine("\n");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("●○●○●○●○●○●○●○●○●○●○");
            Console.WriteLine();
            Console.Write("\t Input name : ");
            P2name = Exc.NameInputCheck();
            PlayerModeName.Add(P2name);
        }
        //플레이어 대전 모드에서의 점수를 받아서 점수전용 ArrayList에 넣는다
        public void setPlayerModeScore(int score)
        {
            PlayerModeScore.Add(score);
        }
        //플레이어 대전 모드에서 저장한 점수를 출력한다
        public void showPlayerModeInfo()
        {
            for (int i = 0; i < PlayerModeName.Count; i+=2)
            {
                Console.WriteLine("\t{0} : {1} vs {2} : {3}", PlayerModeName[i], PlayerModeScore[i], PlayerModeScore[i+1], PlayerModeName[i+1]);
            }
        }

        //컴퓨터 대전 모드에서 게임 시작 전에 유저 플레이어의 이름을 입력받는다
        public void setComputerModeName()//////////////////////////////////////////////////////////////////////
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
            Console.WriteLine("\t Your name\n");
            Console.WriteLine("\n");
            Console.WriteLine("\n");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("●○●○●○●○●○●○●○●○●○●○");
            Console.WriteLine();
            Console.Write("\t Input name : ");
            ComputerModeName = Exc.NameInputCheck();
            dictionary[ComputerModeName] = 0;
        }
        //처음에 이름을 입력받으면 그에 해당하는 점수값을 0으로 초기화해준다
        public void setComputerModeScore(int score)
        {
            dictionary[ComputerModeName] = score;
        }
        //게임에서 얻은 점수를 해당하는 유저의 점수에 더해준다
        public void updateComputerModeScore(int score)
        {
            dictionary[ComputerModeName] = dictionary[ComputerModeName] + score;
        }
        //컴퓨터 모드 대전에서 저장된 유저플레이어의 점수를 출력한다
        public void showComputerModeInfo()
        {
            //컴퓨터 모드 대전에서 유저와 점수를 Dictionary형태로 저장했고,
            //KeyValuePair형태로 저장된 이름:점수를 리스트로 변형해서 출력함
            List<KeyValuePair<string, int>> list = dictionary.ToList();

            foreach (KeyValuePair<string, int> i in list)
            {
                Console.WriteLine("\t{0} : {1} Point(s)", i.Key, i.Value);
            }
        }


    }
}
