using FighterApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterApp
{
    class Program
    {
        static void Main(string[] args)
        {

            StreetFighter mess = new StreetFighter(120, 2, 1, 7);
          
            ProFighter ryu = new ProFighter(150, 4, 2, 13);
            RockStarFighter blanka = new RockStarFighter(170, 5, 4, 17);
            ryu.DoBoxing(blanka); blanka.DoStreet(mess);
            mess.DoStreet(blanka); blanka.DoStreet(mess);
            blanka.DoBoxing(ryu); blanka.DoStreet(mess);
            blanka.DoMuayThai(ryu); blanka.DoStreet(mess);
            blanka.DoStreet(mess); blanka.DoStreet(mess);
            blanka.DoStreet(mess); blanka.DoStreet(mess);
            mess.DoStreet(blanka);
            Console.ReadLine();
        }
    }
}
