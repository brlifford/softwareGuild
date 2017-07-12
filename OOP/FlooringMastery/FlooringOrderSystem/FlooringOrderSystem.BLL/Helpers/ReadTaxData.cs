using FlooringOrderSystem.Data;
using FlooringOrderSystem.Models;

namespace FlooringOrderSystem.BLL.Helpers
{
    public class ReadTaxData
    {
        FileStateRepository stateRepo = new FileStateRepository();

        public bool InRepo(string state)
        {
            //stateRepo.CheckForState(state);

            if (stateRepo.CheckForState(state))
            {
                return true;
            }
            else
                return false;
        }

        public Tax StateTax(string state)
        {
            Tax setTax = new Tax();
            setTax = stateRepo.GetTaxRate(state);
            return setTax;
        }
    }
}
