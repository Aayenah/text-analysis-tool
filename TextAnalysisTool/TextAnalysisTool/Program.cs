using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextAnalysisTool {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());




            //AVLTree<Word> avl = new AVLTree<Word>();
            //string output = "";

            //////Test left rotation/////
            //avl.InsertItem(50);
            //avl.InsertItem(70);
            //avl.InsertItem(80);

            /////Test right rotation/////
            //avl.InsertItem(50);
            //avl.InsertItem(20);
            //avl.InsertItem(10);

            /////Test double (right-left) rotation/////
            //avl.InsertItem(50);
            //avl.InsertItem(70);
            //avl.InsertItem(60);

            /////Test double (left-right) rotation/////
            //avl.InsertItem(50);
            //avl.InsertItem(30);
            //avl.InsertItem(40);

            //avl.PreOrder(ref output);

            

            //Console.WriteLine("PreOrder AVL: " + output);
            
            //Console.ReadKey();
        }
    }
}
