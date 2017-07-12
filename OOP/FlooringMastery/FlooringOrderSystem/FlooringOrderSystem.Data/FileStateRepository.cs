using FlooringOrderSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderSystem.Data
{
    public class FileStateRepository
    {

        List<Tax> _taxes = new List<Tax>();

        public FileStateRepository()
        {
            using (StreamReader sr = new StreamReader(Settings.TaxFilePath))
            {
                sr.ReadLine();
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Tax state = new Tax();
                    string[] columns = line.Split(',');

                    state.StateAbbreviation = columns[0];
                    state.State = columns[1];
                    state.TaxRate = decimal.Parse(columns[2]);

                    _taxes.Add(state);
                }
            }
        }

        public bool CheckForState(string state)
        {
            bool isInList = false;

            foreach(var tax in _taxes)
            {
                if(state == tax.StateAbbreviation.ToString())
                {
                    isInList = true;
                }
            }

            return isInList;
        }

        public Tax GetTaxRate(string state)
        {
            var taxRate = _taxes.SingleOrDefault(t => t.StateAbbreviation == state);
            
            return  taxRate;
        }
    }
}
