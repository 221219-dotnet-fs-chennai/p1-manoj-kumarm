using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UILayer
{
    internal interface ILayout
    {
        /// <summary>
        /// Will display the page and choices to the user in the terminal
        /// </summary>
        void Display();

        /// <summary>
        /// Will record the user's choice and route to the respective page based on that choice
        /// </summary>
        /// <returns></returns>
        string UserChoice();
    }
}
