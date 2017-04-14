using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensharp_study_assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Main에서 Interface클래스 불러와서 계속 실행
            Interface NewGame = new Interface();
            NewGame.SelectMode();
        }
    }
}
