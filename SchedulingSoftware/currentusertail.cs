using System.ComponentModel;

namespace SchedulingSoftware
{
    public class currentusertail
    {

       
            public currentusertail()
            {

            }

            private int idnumber;
            public void setIDNum(int a)
            {
                idnumber = a;
            }
            public int getIDNum()
            {
                return idnumber;
            }

            private string currentusernm;
            public void SetCurrentUserNM(string b)
            {
                currentusernm = b;
            }
            public string GetCurrentUserNM()
            {
                return currentusernm;
            }



            public BindingList<currentusertail> logg = new BindingList<currentusertail>();

        





    }
}
