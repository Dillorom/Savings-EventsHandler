using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsSolution
{
    public delegate void BalanceEventHandler(decimal theValue);

    class Savings
    {
        private decimal m_bankBalance;
        public event BalanceEventHandler balanceChanged;


        public decimal Balance
        {
            set
            {
                m_bankBalance = value;
                balanceChanged(value);
            }
            get
            {
                return m_bankBalance;
            }
        }
    }


    class BalanceLogger
    {
        public void balanceLog(decimal amount)
        {
            Console.WriteLine($"The balance amount is {amount}");
        }
    }

    class BalanceWatcher
    {
        public void balanceWatch(decimal amount)
        {
            if (amount > 1000m)
            {
                Console.WriteLine($"You reached your savings goal! You have {amount}");
            }
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            Savings savings = new Savings();
            BalanceLogger bl = new BalanceLogger();
            BalanceWatcher bw = new BalanceWatcher();

            savings.balanceChanged += bl.balanceLog;
            savings.balanceChanged += bw.balanceWatch;

            string input;
            do {
                Console.WriteLine("How much to deposit?");

                input = Console.ReadLine();
                if (!input.Equals("exit")) {
                    decimal newVal = decimal.Parse(input);

                    savings.Balance += newVal;
                }
            } while (!input.Equals("exit"));
        }
    }
}
