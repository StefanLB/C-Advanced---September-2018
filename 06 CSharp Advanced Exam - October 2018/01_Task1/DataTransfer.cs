using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_DataTransfer
{
    class DataTransfer
    {
        static void Main(string[] args)
        {
            int messages = int.Parse(Console.ReadLine());

            int messagesTotalSize = 0;

            for (int i = 0; i < messages; i++)
            {
                string currentInput = Console.ReadLine();

                if (!currentInput.Contains("s:") || !currentInput.Contains(";r:") || !currentInput.Contains(";m--"))
                {
                    continue;
                }

                string[] tokens = currentInput.Split(new string[] { "s:",";r:",";m--" }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (tokens.Length<3)
                {
                    continue;
                }

                string codedSender = tokens[0];
                string codedReceiver = tokens[1];
                string message = tokens[2];

                string sender = string.Empty;
                string receiver = string.Empty;

                bool messageOK = true;

                for (int l = 1; l < message.Length-1; l++)
                {
                    if (!Char.IsLetter(message[l]) && !Char.IsWhiteSpace(message[l]))
                    {
                        messageOK = false;
                        break;
                    }
                }

                if (!messageOK)
                {
                    continue;
                }

                for (int j = 0; j < codedSender.Length; j++)
                {
                    if (Char.IsLetter(codedSender[j]) || Char.IsWhiteSpace(codedSender[j]))
                    {
                        sender += codedSender[j];
                    }
                    else if (Char.IsDigit(codedSender[j]))
                    {
                        messagesTotalSize += int.Parse(codedSender[j].ToString());
                    }
                }

                for (int k = 0; k < codedReceiver.Length; k++)
                {
                    if (Char.IsLetter(codedReceiver[k]) || Char.IsWhiteSpace(codedReceiver[k]))
                    {
                        receiver += codedReceiver[k];
                    }
                    else if (Char.IsDigit(codedReceiver[k]))
                    {
                        messagesTotalSize += int.Parse(codedReceiver[k].ToString()) ;
                    }
                }

                Console.WriteLine($"{sender} says {message} to {receiver}");
            }

            Console.WriteLine($"Total data transferred: {messagesTotalSize}MB");

        }
    }
}
