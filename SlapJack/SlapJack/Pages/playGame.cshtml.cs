using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SlapJack.Pages
{
    public class playGameModel : PageModel
    {
        public void CommandBtn_Click(Object sender, EventArgs e)
        {
            Console.WriteLine("Hello World!!");
        }

        public void OnGet()
        {

        }
    }


    public static class Extensions
    {
        public static void Enqueue(this Queue<Card> cards, Queue<Card> newCards)
        {
            foreach (var card in newCards)
            {
                cards.Enqueue(card);
            }
        }
    }
}