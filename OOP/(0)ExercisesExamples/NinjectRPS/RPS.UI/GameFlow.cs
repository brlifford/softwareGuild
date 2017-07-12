using Ninject;
using RPS.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.UI
{
    public class GameFlow
    {
        public void Start()
        {
            Choice player1Choice;
            GameManager gm = DIContainer.Kernel.Get<GameManager>();

            TestChoiceGetterConsumer testingNewClass = DIContainer.Kernel.Get<TestChoiceGetterConsumer>();

            TestChoiceGetterConsumer test2 = new TestChoiceGetterConsumer(new AlwaysPaper());

            SillyTest testing = DIContainer.Kernel.Get<SillyTest>(); // Ninject still instantiates

            while(true)
            {
                Console.Clear();
                player1Choice = ConsoleInput.GetChoiceFromUser();
                PlayRoundResponse response = gm.PlayRound(player1Choice);

                ConsoleOutput.DisplayResult(response);

                if (!ConsoleInput.QueryPlayAgain())
                    return;
            }
        }
        
    }
}
