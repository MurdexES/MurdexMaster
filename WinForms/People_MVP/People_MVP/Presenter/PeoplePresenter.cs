using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using People_MVP.Model;
using People_MVP.View;

namespace People_MVP.Presenter
{
    internal class PeoplePresenter
    {
        private MainView view;

        public PeoplePresenter(MainView view)
        {
            this.view = view;
        }
    }
}
