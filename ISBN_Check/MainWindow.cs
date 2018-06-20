using System;
using Gtk;

public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }
    //ISBN Check Function Isbncheck()
    public static int Isbncheck(string chk)
    {
        //Console.WriteLine(chk);
        if (chk.Length == 10)
        {
            string temp = chk.Substring(0, 9);
            int checknum = 0;
            for (int i = 0; i < 9; i++)
            {
                checknum = checknum + Convert.ToInt32(Convert.ToString(chk[i])) * (10 - i);
            }
            int checkdigit = checknum % 11;
            checkdigit = 11 - checkdigit;
            if (Convert.ToInt32(Convert.ToString(chk[9])) == checkdigit)
            {
                return 1;
            }
            return 0;
        }
        else if (chk.Length == 13)
        {
            int num = 0;
            for (int flag = 0; flag < 12; flag++)
            {
                if (flag % 2 == 1)
                    num += (Convert.ToInt32(Convert.ToString(chk[flag])) * 3);
                else
                    num += (Convert.ToInt32(Convert.ToString(chk[flag])));
            }
            num = num % 10;
            num = 10 - num;
            //Console.WriteLine(num);
            //Console.WriteLine(Convert.ToInt32(chk[12]));
            //Console.WriteLine(Convert.ToInt16(Convert.ToString(chk[12])));
            if (num != Convert.ToInt32(Convert.ToString(chk[12])))
                return 0;
            return 1;
        }
        return 2;
    }
    //Main Window ISBN Button Click Method
    protected void OnIsbnButtonClicked(object sender, EventArgs e)
    {
        if (IsbnEntry.Text.Length != 0)
        {
            int test = Isbncheck(IsbnEntry.Text);
            if (test == 1)
                Isbn_Text_Block.Text="Valid";
            else if (test == 0)
                Isbn_Text_Block.Text="Invalid";
            else
                Isbn_Text_Block.Text = "Wrong Length.";
        }
        else
        {
            Isbn_Text_Block.Text = "Enter ISBN!";
        }
    }
}
