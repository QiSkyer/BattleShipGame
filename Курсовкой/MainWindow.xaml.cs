using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Курсовкой
{
    /// <summary>
    /// Павлов Сергей 305 Курсовая работа: Разработка программы "Игра Морской бой"
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        //окно подсказки
        Form1 form1 = new Form1();

        Random rnd = new Random();
        int random, ar = -1;

        double xl; double xv;
        double ol; double ov;
        int xp = 0; int op = 0;

        int xp0 = 0; int op0 = 0;
        double xl0= 0; double xv0 = 0;
        double ol0 = 0; double ov0 = 0;

        int remember;

        List<Image> Xpoints0 = new List<Image>();
        List<Image> Opoints0 = new List<Image>();

        List<Image> Xpoints = new List<Image>();
        List<Image> Opoints = new List<Image>();

        bool[] ifvertical = new bool[10];
        bool returnverticalposition = false;
        bool[] ifMouseClicked = new bool[10];

        int Lasttapedship = 0;
        int ActiveRectangle = 0;
        int ActiveRectangle2 = 1;
        int LastActiveRectangle = 0;

        int a, a1;
        //запоминание положения кораблей на элементах field1
        int[] SP = new int[10];

        Point[] Positions = new Point[10];

        //Координаты кораблей
        double[] ShipsLeft = new double[10];
        double[] ShipsTop = new double[10];

        //Элементы Fi1
        Rectangle[] Field1 = new Rectangle[100];
       
        Image[] Ships = new Image[10];

        bool[] GameRec = new bool[100];
        bool[] AttackedRec = new bool[100];

        //Элементы Fi2
        Rectangle[] Field2 = new Rectangle[100];
        bool[] GameRec2 = new bool[100];


        //               Ключи      
        //_______________________________________

        bool Lock1 = false;
        //Запрет размещения корабля на rectangle
        bool[] LockRec = new bool[100];
        bool[] LockRec2 = new bool[100];
       //_________________________________
        bool Lock2 = true;
        bool ifGameStarted = false;

        bool YourAttack = false;
        bool AIAttack = false;

        bool end1 = false;
        bool end2 = false;

       bool DoubleAttack = false;
        bool ALeft;
        bool ARight;
        bool AUp;
        bool ADown;
        bool VerticalStrategy;
        bool HorizontalStrategy;

        //_____________________________________________

        public MainWindow()
        {

            SP[0] = -1; //Пустое 
            SP[1] = -1;
            SP[2] = -1;
            SP[3] = -1;
            SP[4] = -1;
            SP[5] = -1;
            SP[6] = -1;
            SP[7] = -1;
            SP[8] = -1;
            SP[9] = -1;

            InitializeComponent();

            Ships[0] = Avia;
            Ships[1] = Destroyer1;
            Ships[2] = Destroyer2;
            Ships[3] = Lodka1;
            Ships[4] = Lodka2;
            Ships[5] = Lodka3;
            Ships[6] = Mini1;
            Ships[7] = Mini2;
            Ships[8] = Mini3;
            Ships[9] = Mini4;

            Field1[0] = A1;
            Field1[1] = A2;
            Field1[2] = A3;
            Field1[3] = A4;
            Field1[4] = A5;
            Field1[5] = A6;
            Field1[6] = A7;
            Field1[7] = A8;
            Field1[8] = A9;
            Field1[9] = A10;

            Field1[10] = B1;
            Field1[11] = B2;
            Field1[12] = B3;
            Field1[13] = B4;
            Field1[14] = B5;
            Field1[15] = B6;
            Field1[16] = B7;
            Field1[17] = B8;
            Field1[18] = B9;
            Field1[19] = B10;

            Field1[20] = C1;
            Field1[21] = C2;
            Field1[22] = C3;
            Field1[23] = C4;
            Field1[24] = C5;
            Field1[25] = C6;
            Field1[26] = C7;
            Field1[27] = C8;
            Field1[28] = C9;
            Field1[29] = C10;

            Field1[30] = D1;
            Field1[31] = D2;
            Field1[32] = D3;
            Field1[33] = D4;
            Field1[34] = D5;
            Field1[35] = D6;
            Field1[36] = D7;
            Field1[37] = D8;
            Field1[38] = D9;
            Field1[39] = D10;

            Field1[40] = E1;
            Field1[41] = E2;
            Field1[42] = E3;
            Field1[43] = E4;
            Field1[44] = E5;
            Field1[45] = E6;
            Field1[46] = E7;
            Field1[47] = E8;
            Field1[48] = E9;
            Field1[49] = E10;

            Field1[50] = F1;
            Field1[51] = F2;
            Field1[52] = F3;
            Field1[53] = F4;
            Field1[54] = F5;
            Field1[55] = F6;
            Field1[56] = F7;
            Field1[57] = F8;
            Field1[58] = F9;
            Field1[59] = F10;

            Field1[60] = G1;
            Field1[61] = G2;
            Field1[62] = G3;
            Field1[63] = G4;
            Field1[64] = G5;
            Field1[65] = G6;
            Field1[66] = G7;
            Field1[67] = G8;
            Field1[68] = G9;
            Field1[69] = G10;

            Field1[70] = H1;
            Field1[71] = H2;
            Field1[72] = H3;
            Field1[73] = H4;
            Field1[74] = H5;
            Field1[75] = H6;
            Field1[76] = H7;
            Field1[77] = H8;
            Field1[78] = H9;
            Field1[79] = H10;

            Field1[80] = I1;
            Field1[81] = I2;
            Field1[82] = I3;
            Field1[83] = I4;
            Field1[84] = I5;
            Field1[85] = I6;
            Field1[86] = I7;
            Field1[87] = I8;
            Field1[88] = I9;
            Field1[89] = I10;

            Field1[90] = J1;
            Field1[91] = J2;
            Field1[92] = J3;
            Field1[93] = J4;
            Field1[94] = J5;
            Field1[95] = J6;
            Field1[96] = J7;
            Field1[97] = J8;
            Field1[98] = J9;
            Field1[99] = J10;
            //_________________________

            Field2[0] = _A1;
            Field2[1] = _A2;
            Field2[2] = _A3;
            Field2[3] = _A4;
            Field2[4] = _A5;
            Field2[5] = _A6;
            Field2[6] = _A7;
            Field2[7] = _A8;
            Field2[8] = _A9;
            Field2[9] = _A10;

            Field2[10] = _B1;
            Field2[11] = _B2;
            Field2[12] = _B3;
            Field2[13] = _B4;
            Field2[14] = _B5;
            Field2[15] = _B6;
            Field2[16] = _B7;
            Field2[17] = _B8;
            Field2[18] = _B9;
            Field2[19] = _B10;

            Field2[20] = _C1;
            Field2[21] = _C2;
            Field2[22] = _C3;
            Field2[23] = _C4;
            Field2[24] = _C5;
            Field2[25] = _C6;
            Field2[26] = _C7;
            Field2[27] = _C8;
            Field2[28] = _C9;
            Field2[29] = _C10;

            Field2[30] = _D1;
            Field2[31] = _D2;
            Field2[32] = _D3;
            Field2[33] = _D4;
            Field2[34] = _D5;
            Field2[35] = _D6;
            Field2[36] = _D7;
            Field2[37] = _D8;
            Field2[38] = _D9;
            Field2[39] = _D10;

            Field2[40] = _E1;
            Field2[41] = _E2;
            Field2[42] = _E3;
            Field2[43] = _E4;
            Field2[44] = _E5;
            Field2[45] = _E6;
            Field2[46] = _E7;
            Field2[47] = _E8;
            Field2[48] = _E9;
            Field2[49] = _E10;

            Field2[50] = _F1;
            Field2[51] = _F2;
            Field2[52] = _F3;
            Field2[53] = _F4;
            Field2[54] = _F5;
            Field2[55] = _F6;
            Field2[56] = _F7;
            Field2[57] = _F8;
            Field2[58] = _F9;
            Field2[59] = _F10;

            Field2[60] = _G1;
            Field2[61] = _G2;
            Field2[62] = _G3;
            Field2[63] = _G4;
            Field2[64] = _G5;
            Field2[65] = _G6;
            Field2[66] = _G7;
            Field2[67] = _G8;
            Field2[68] = _G9;
            Field2[69] = _G10;

            Field2[70] = _H1;
            Field2[71] = _H2;
            Field2[72] = _H3;
            Field2[73] = _H4;
            Field2[74] = _H5;
            Field2[75] = _H6;
            Field2[76] = _H7;
            Field2[77] = _H8;
            Field2[78] = _H9;
            Field2[79] = _H10;

            Field2[80] = _I1;
            Field2[81] = _I2;
            Field2[82] = _I3;
            Field2[83] = _I4;
            Field2[84] = _I5;
            Field2[85] = _I6;
            Field2[86] = _I7;
            Field2[87] = _I8;
            Field2[88] = _I9;
            Field2[89] = _I10;

            Field2[90] = _J1;
            Field2[91] = _J2;
            Field2[92] = _J3;
            Field2[93] = _J4;
            Field2[94] = _J5;
            Field2[95] = _J6;
            Field2[96] = _J7;
            Field2[97] = _J8;
            Field2[98] = _J9;
            Field2[99] = _J10;



            Timerset();
            //  AI расположение кораблей


            random = rnd.Next(1, 3);
            if (random == 1)
            {
                //Авианосец по горизонтали
                random = rnd.Next(0, 69);

                while (Lock2 == true)
                    if (LockRec2[random] == true || LockRec2[random + 10] == true || LockRec2[random + 20] == true || LockRec2[random + 30] == true)
                    {
                        Lock2 = true;
                        random = rnd.Next(0, 69);
                    }
                    else
                    {

                        // клетки окружающие авиа по горизонтали
                        //_____________________________________________________________________________________________
                        //сверху
                        if (random == 0 || random == 10 || random == 20 || random == 30 || random == 40 || random == 50 || random == 60 || random == 70 || random == 80 || random == 90)
                        { }
                        else
                        {


                            LockRec2[random - 1] = true;
                       //     Field2[random - 1].Fill = Brushes.LightBlue;

                            LockRec2[random + 9] = true;
                      //      Field2[random + 9].Fill = Brushes.LightBlue;

                            LockRec2[random + 19] = true;
                       //     Field2[random + 19].Fill = Brushes.LightBlue;

                            LockRec2[random + 29] = true;
                      //      Field2[random + 29].Fill = Brushes.LightBlue;

                            //слева сверху
                            if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                            { }
                            else
                            {
                                LockRec2[random - 11] = true;
                     //           Field2[random - 11].Fill = Brushes.LightBlue;
                            }
                            //справа сверху
                            if (random == 60 || random == 61 || random == 62 || random == 63 || random == 64 || random == 65 || random == 66 || random == 67 || random == 68 || random == 69)
                            { }
                            else
                            {

                                LockRec2[random + 39] = true;
                      //          Field2[random + 39].Fill = Brushes.LightBlue;

                            }
                        }
                        //слева
                        if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                        {
                        }
                        else
                        {
                            LockRec2[random - 10] = true;
                     //       Field2[random - 10].Fill = Brushes.LightBlue;
                        }
                        //снизу
                        if (random == 9 || random == 19 || random == 29 || random == 39 || random == 49 || random == 59 || random == 69 || random == 79 || random == 89 || random == 99)
                        { }
                        else
                        {
                            //слева снизу
                            if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                            {
                            }
                            else
                            {
                                LockRec2[random - 9] = true;
                       //         Field2[random - 9].Fill = Brushes.LightBlue;
                            }
                            //справа снизу
                            if (random == 60 || random == 61 || random == 62 || random == 63 || random == 64 || random == 65 || random == 66 || random == 67 || random == 68 || random == 69)
                            { }
                            else
                            {

                                LockRec2[random + 41] = true;
                       //         Field2[random + 41].Fill = Brushes.LightBlue;

                            }

                            LockRec2[random + 1] = true;
                        //    Field2[random + 1].Fill = Brushes.LightBlue;

                            LockRec2[random + 11] = true;
                        //    Field2[random + 11].Fill = Brushes.LightBlue;

                            LockRec2[random + 21] = true;
                       //     Field2[random + 21].Fill = Brushes.LightBlue;

                            LockRec2[random + 31] = true;
                       //     Field2[random + 31].Fill = Brushes.LightBlue;
                        }
                        //справа 
                        if (random == 60 || random == 61 || random == 62 || random == 63 || random == 64 || random == 65 || random == 66 || random == 67 || random == 68 || random == 69)
                        { }
                        else
                        {

                            LockRec2[random + 40] = true;
                       //     Field2[random + 40].Fill = Brushes.LightBlue;
                            Lock2 = false;
                        }



                        //_____________________________________________________________________________________________

                        GameRec2[random] = true;
                    //    Field2[random].Fill = Brushes.Gray;

                        GameRec2[random + 10] = true;
                    //    Field2[random + 10].Fill = Brushes.Gray;

                        GameRec2[random + 20] = true;
                    //    Field2[random + 20].Fill = Brushes.Gray;

                        GameRec2[random + 30] = true;
                   //    Field2[random + 30].Fill = Brushes.Gray;
                        Lock2 = false;
                    }
            }
            else
            {
                //Авианосец по вертикали
                while (Lock2 == true)
                    if (LockRec2[random] == true || LockRec2[random + 1] == true || LockRec2[random + 2] == true || LockRec2[random + 3] == true)
                    {
                        Lock2 = true;


                        ar = rnd.Next(0, 10);
                        switch (ar)
                        {
                            case 0:
                                random = rnd.Next(0, 7);
                                break;

                            case 1:
                                random = rnd.Next(10, 17);

                                break;

                            case 2:
                                random = rnd.Next(20, 27);
                                break;

                            case 3:
                                random = rnd.Next(30, 37);
                                break;

                            case 4:
                                random = rnd.Next(40, 47);
                                break;

                            case 5:
                                random = rnd.Next(50, 57);
                                break;
                            case 6:
                                random = rnd.Next(60, 67);
                                break;
                            case 7:
                                random = rnd.Next(70, 77);
                                break;
                            case 8:
                                random = rnd.Next(80, 87);
                                break;
                            case 9:
                                random = rnd.Next(90, 97);
                                break;
                        }
                    }
                    else
                    {
                        Lock2 = false;



                    }
                // клетки окружающие авиа по вертикали
                //_____________________________________________________________________________________________
                //сверху
                if (random == 0 || random == 10 || random == 20 || random == 30 || random == 40 || random == 50 || random == 60 || random == 70 || random == 80 || random == 90)
                { }
                else
                {
                    LockRec2[random - 1] = true;
                          //     Field2[random - 1].Fill = Brushes.LightBlue;

                    //слева сверху
                    if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                    { }
                    else
                    {
                        LockRec2[random - 11] = true;
                        //         Field2[random - 11].Fill = Brushes.LightBlue;
                    }
                    //справа сверху
                    if (random == 90 || random == 91 || random == 92 || random == 93 || random == 94 || random == 95 || random == 96 || random == 97 || random == 98 || random == 99)
                    { }
                    else
                    {

                        LockRec2[random + 9] = true;
                         //      Field2[random + 9].Fill = Brushes.LightBlue;

                    }
                }
                //слева
                if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                {
                }
                else
                {
                    LockRec2[random - 10] = true;
                      //     Field2[random - 10].Fill = Brushes.LightBlue;

                    LockRec2[random - 9] = true;
                     //     Field2[random - 9].Fill = Brushes.LightBlue;

                    LockRec2[random - 8] = true;
                     //    Field2[random - 8].Fill = Brushes.LightBlue;

                    LockRec2[random - 7] = true;
                      //   Field2[random - 7].Fill = Brushes.LightBlue;
                }
                //снизу
                if (random == 6 || random == 16 || random == 26 || random == 36 || random == 46 || random == 56 || random == 66 || random == 76 || random == 86 || random == 96)
                { }
                else
                {
                    //слева снизу
                    if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                    {
                    }
                    else
                    {
                        LockRec2[random - 6] = true;
                         //        Field2[random - 6].Fill = Brushes.LightBlue;
                    }
                    //справа снизу
                    if (random == 90 || random == 91 || random == 92 || random == 93 || random == 94 || random == 95 || random == 96 || random == 97 || random == 98 || random == 99)
                    { }
                    else
                    {

                        LockRec2[random + 14] = true;
                      //            Field2[random + 14].Fill = Brushes.LightBlue;

                    }

                    LockRec2[random + 4] = true;
                     //     Field2[random + 4].Fill = Brushes.LightBlue;


                }
                //справа 
                if (random == 90 || random == 91 || random == 92 || random == 93 || random == 94 || random == 95 || random == 96 || random == 97 || random == 98 || random == 99)
                { }
                else
                {

                    LockRec2[random + 10] = true;
                     //      Field2[random + 10].Fill = Brushes.LightBlue;


                    LockRec2[random + 11] = true;
                    //      Field2[random + 11].Fill = Brushes.LightBlue;

                    LockRec2[random + 12] = true;
                  //        Field2[random + 12].Fill = Brushes.LightBlue;

                    LockRec2[random + 13] = true;
                   //       Field2[random + 13].Fill = Brushes.LightBlue;
                }



                //_____________________________________________________________________________________________


                GameRec2[random] = true;
            //    Field2[random].Fill = Brushes.Gray;

                GameRec2[random + 1] = true;
           //     Field2[random + 1].Fill = Brushes.Gray;

                GameRec2[random + 2] = true;
            //    Field2[random + 2].Fill = Brushes.Gray;

                GameRec2[random + 3] = true;
             //   Field2[random + 3].Fill = Brushes.Gray;
            }

            Lock2 = true;

            // Destroyer1 по горизонтали
          

                random = rnd.Next(0, 79);

                while (Lock2 == true)
                    if (LockRec2[random] == true || LockRec2[random + 10] == true || LockRec2[random + 20] == true || GameRec2[random] == true || GameRec2[random + 10] == true || GameRec2[random + 20] == true)
                    {
                        Lock2 = true;
                        random = rnd.Next(0, 79);
                    }
                    else
                    {


                        // клетки окружающие Destroyer по горизонтали
                        //_____________________________________________________________________________________________
                        //сверху
                        if (random == 0 || random == 10 || random == 20 || random == 30 || random == 40 || random == 50 || random == 60 || random == 70 || random == 80 || random == 90)
                        { }
                        else
                        {
                            LockRec2[random - 1] = true;
                            //           Field1[LastActiveRectangle - 1].Fill = Brushes.Gray;

                            LockRec2[random + 9] = true;
                            //          Field1[LastActiveRectangle + 9].Fill = Brushes.Gray;

                            LockRec2[random + 19] = true;
                            //          Field1[LastActiveRectangle + 19].Fill = Brushes.Gray;


                            //слева сверху
                            if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                            { }
                            else
                            {
                                LockRec2[random - 11] = true;
                                //              Field1[LastActiveRectangle - 11].Fill = Brushes.Gray;
                            }
                            //справа сверху
                            if (random == 70 || random == 71 || random == 72 || random == 73 || random == 74 || random == 75 || random == 76 || random == 77 || random == 78 || random == 79)
                            { }
                            else
                            {

                                LockRec2[random + 29] = true;
                                //            Field1[LastActiveRectangle + 29].Fill = Brushes.Gray;

                            }
                        }
                        //слева
                        if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                        {
                        }
                        else
                        {
                            LockRec2[random - 10] = true;
                            //          Field1[LastActiveRectangle - 10].Fill = Brushes.Gray;
                        }
                        //снизу
                        if (random == 9 || random == 19 || random == 29 || random == 39 || random == 49 || random == 59 || random == 69 || random == 79 || random == 89 || random == 99)
                        { }
                        else
                        {
                            //слева снизу
                            if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                            {
                            }
                            else
                            {
                                LockRec2[random - 9] = true;
                                //             Field1[LastActiveRectangle - 9].Fill = Brushes.Gray;
                            }
                            //справа снизу
                            if (random == 70 || random == 71 || random == 72 || random == 73 || random == 74 || random == 75 || random == 76 || random == 77 || random == 78 || random == 79)
                            { }
                            else
                            {

                                LockRec2[random + 31] = true;
                                //             Field1[LastActiveRectangle + 31].Fill = Brushes.Gray;

                            }

                            LockRec2[random + 1] = true;
                            //         Field1[LastActiveRectangle + 1].Fill = Brushes.Gray;

                            LockRec2[random + 11] = true;
                            //         Field1[LastActiveRectangle + 11].Fill = Brushes.Gray;

                            LockRec2[random + 21] = true;
                            //          Field1[LastActiveRectangle + 21].Fill = Brushes.Gray;


                        }
                        //справа 
                        if (random == 70 || random == 71 || random == 72 || random == 73 || random == 74 || random == 75 || random == 76 || random == 77 || random == 78 || random == 79)
                        { }
                        else
                        {

                            LockRec2[random + 30] = true;
                            //          Field1[LastActiveRectangle + 30].Fill = Brushes.Gray;

                        }



                    //_____________________________________________________________________________________________

                    GameRec2[random] = true;
              //      Field2[random].Fill = Brushes.Gray;

                    GameRec2[random + 10] = true;
             //       Field2[random + 10].Fill = Brushes.Gray;

                    GameRec2[random + 20] = true;
              //      Field2[random + 20].Fill = Brushes.Gray;

                    Lock2 = false;
                    }

            Lock2 = true;

            // Destroyer2 


            random = rnd.Next(0, 79);

            while (Lock2 == true)
                if (LockRec2[random] == true || LockRec2[random + 10] == true || LockRec2[random + 20] == true || GameRec2[random] == true || GameRec2[random + 10] == true || GameRec2[random + 20] == true)
                {
                    Lock2 = true;
                    random = rnd.Next(0, 79);
                }
                else
                {


                    // клетки окружающие Destroyer2 по горизонтали
                    //_____________________________________________________________________________________________
                    //сверху
                    if (random == 0 || random == 10 || random == 20 || random == 30 || random == 40 || random == 50 || random == 60 || random == 70 || random == 80 || random == 90)
                    { }
                    else
                    {
                        LockRec2[random - 1] = true;
                        //           Field1[LastActiveRectangle - 1].Fill = Brushes.Gray;

                        LockRec2[random + 9] = true;
                        //          Field1[LastActiveRectangle + 9].Fill = Brushes.Gray;

                        LockRec2[random + 19] = true;
                        //          Field1[LastActiveRectangle + 19].Fill = Brushes.Gray;


                        //слева сверху
                        if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                        { }
                        else
                        {
                            LockRec2[random - 11] = true;
                            //              Field1[LastActiveRectangle - 11].Fill = Brushes.Gray;
                        }
                        //справа сверху
                        if (random == 70 || random == 71 || random == 72 || random == 73 || random == 74 || random == 75 || random == 76 || random == 77 || random == 78 || random == 79)
                        { }
                        else
                        {

                            LockRec2[random + 29] = true;
                            //            Field1[LastActiveRectangle + 29].Fill = Brushes.Gray;

                        }
                    }
                    //слева
                    if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                    {
                    }
                    else
                    {
                        LockRec2[random - 10] = true;
                        //          Field1[LastActiveRectangle - 10].Fill = Brushes.Gray;
                    }
                    //снизу
                    if (random == 9 || random == 19 || random == 29 || random == 39 || random == 49 || random == 59 || random == 69 || random == 79 || random == 89 || random == 99)
                    { }
                    else
                    {
                        //слева снизу
                        if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                        {
                        }
                        else
                        {
                            LockRec2[random - 9] = true;
                            //             Field1[LastActiveRectangle - 9].Fill = Brushes.Gray;
                        }
                        //справа снизу
                        if (random == 70 || random == 71 || random == 72 || random == 73 || random == 74 || random == 75 || random == 76 || random == 77 || random == 78 || random == 79)
                        { }
                        else
                        {

                            LockRec2[random + 31] = true;
                            //             Field1[LastActiveRectangle + 31].Fill = Brushes.Gray;

                        }

                        LockRec2[random + 1] = true;
                        //         Field1[LastActiveRectangle + 1].Fill = Brushes.Gray;

                        LockRec2[random + 11] = true;
                        //         Field1[LastActiveRectangle + 11].Fill = Brushes.Gray;

                        LockRec2[random + 21] = true;
                        //          Field1[LastActiveRectangle + 21].Fill = Brushes.Gray;


                    }
                    //справа 
                    if (random == 70 || random == 71 || random == 72 || random == 73 || random == 74 || random == 75 || random == 76 || random == 77 || random == 78 || random == 79)
                    { }
                    else
                    {

                        LockRec2[random + 30] = true;
                        //          Field1[LastActiveRectangle + 30].Fill = Brushes.Gray;

                    }



                    //_____________________________________________________________________________________________

                    GameRec2[random] = true;
              //      Field2[random].Fill = Brushes.Gray;

                    GameRec2[random + 10] = true;
              //      Field2[random + 10].Fill = Brushes.Gray;

                    GameRec2[random + 20] = true;
               //     Field2[random + 20].Fill = Brushes.Gray;

                    Lock2 = false;
                }


            Lock2 = true;


            random = rnd.Next(1, 3);
            if (random == 1)
            {
                //Lodka1 по горизонтали


                random = rnd.Next(0, 89);

                while (Lock2 == true)
                    if (LockRec2[random] == true || LockRec2[random + 10] == true || GameRec2[random] == true || GameRec2[random + 10] == true)
                    {

                        random = rnd.Next(0, 89);
                    }
                    else
                    {

                        // клетки окружающие Lodka по горизонтали
                        //_____________________________________________________________________________________________
                        //сверху
                        if (random == 0 || random == 10 || random == 20 || random == 30 || random == 40 || random == 50 || random == 60 || random == 70 || random == 80 || random == 90)
                        { }
                        else
                        {
                            LockRec2[random - 1] = true;
                            //          Field1[LastActiveRectangle - 1].Fill = Brushes.Gray;

                            LockRec2[random + 9] = true;
                            //           Field1[LastActiveRectangle + 9].Fill = Brushes.Gray;


                            //слева сверху
                            if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                            { }
                            else
                            {
                                LockRec2[random - 11] = true;
                                //              Field1[LastActiveRectangle - 11].Fill = Brushes.Gray;
                            }
                            //справа сверху
                            if (random == 80 || random == 81 || random == 82 || random == 83 || random == 84 || random == 85 || random == 86 || random == 87 || random == 88 || random == 89)
                            { }
                            else
                            {

                                LockRec2[random + 19] = true;
                                //               Field1[LastActiveRectangle + 19].Fill = Brushes.Gray;

                            }
                        }
                        //слева
                        if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                        {
                        }
                        else
                        {
                            LockRec2[random - 10] = true;
                            //         Field1[LastActiveRectangle - 10].Fill = Brushes.Gray;
                        }
                        //снизу
                        if (random == 9 || random == 19 || random == 29 || random == 39 || random == 49 || random == 59 || random == 69 || random == 79 || random == 89 || random == 99)
                        { }
                        else
                        {
                            //слева снизу
                            if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                            {
                            }
                            else
                            {
                                LockRec2[random - 9] = true;
                                //              Field1[LastActiveRectangle - 9].Fill = Brushes.Gray;
                            }
                            //справа снизу
                            if (random == 80 || random == 81 || random == 82 || random == 83 || random == 84 || random == 85 || random == 86 || random == 87 || random == 88 || random == 89)
                            { }
                            else
                            {

                                LockRec2[random + 21] = true;
                                //              Field1[LastActiveRectangle + 21].Fill = Brushes.Gray;

                            }

                            LockRec2[random + 1] = true;
                            //         Field1[LastActiveRectangle + 1].Fill = Brushes.Gray;

                            LockRec2[random + 11] = true;
                            //          Field1[LastActiveRectangle + 11].Fill = Brushes.Gray;

                        }
                        //справа 
                        if (random == 80 || random == 81 || random == 82 || random == 83 || random == 84 || random == 85 || random == 86 || random == 87 || random == 88 || random == 89)
                        { }
                        else
                        {

                            LockRec2[random + 20] = true;
                            //          Field1[LastActiveRectangle + 20].Fill = Brushes.Gray;

                        }

                        //_____________________________________________________________________________________________

                        GameRec2[random] = true;
                 //       Field2[random].Fill = Brushes.Gray;

                        GameRec2[random + 10] = true;
                 //       Field2[random + 10].Fill = Brushes.Gray;

                        Lock2 = false;
                    }
            }
            else
            {
                //Lodka по вертикали
                while (Lock2 == true)
                    if (LockRec2[random] == true || LockRec2[random + 1] == true || GameRec2[random] == true || GameRec2[random + 1] == true)
                    {
                    
                       


                        ar = rnd.Next(0, 10);
                        switch (ar)
                        {
                            case 0:
                                random = rnd.Next(0, 8);
                                break;

                            case 1:
                                random = rnd.Next(10, 18);

                                break;

                            case 2:
                                random = rnd.Next(20, 28);
                                break;

                            case 3:
                                random = rnd.Next(30, 38);
                                break;

                            case 4:
                                random = rnd.Next(40, 48);
                                break;

                            case 5:
                                random = rnd.Next(50, 58);
                                break;
                            case 6:
                                random = rnd.Next(60, 68);
                                break;
                            case 7:
                                random = rnd.Next(70, 78);
                                break;
                            case 8:
                                random = rnd.Next(80, 88);
                                break;
                            case 9:
                                random = rnd.Next(90, 98);
                                break;
                        }
                    }
                    else
                    {
                      

                        // клетки окружающие Lodka по вертикали
                        //_____________________________________________________________________________________________
                        //сверху
                        if (random == 0 || random == 10 || random == 20 || random == 30 || random == 40 || random == 50 || random == 60 || random == 70 || random == 80 || random == 90)
                        { }
                        else
                        {
                            LockRec2[random - 1] = true;
                            //             Field1[LastActiveRectangle - 1].Fill = Brushes.Gray;

                            //слева сверху
                            if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                            { }
                            else
                            {
                                LockRec2[random - 11] = true;
                                //                Field1[LastActiveRectangle - 11].Fill = Brushes.Gray;
                            }
                            //справа сверху
                            if (random == 90 || random == 91 || random == 92 || random == 93 || random == 94 || random == 95 || random == 96 || random == 97 || random == 98 || random == 99)
                            { }
                            else
                            {

                                LockRec2[random + 9] = true;
                                //               Field1[LastActiveRectangle + 9].Fill = Brushes.Gray;

                            }
                        }
                        //слева
                        if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                        {
                        }
                        else
                        {
                            LockRec2[random - 10] = true;
                            //             Field1[LastActiveRectangle - 10].Fill = Brushes.Gray;

                            LockRec2[random - 9] = true;
                            //            Field1[LastActiveRectangle - 9].Fill = Brushes.Gray;


                        }
                        //снизу
                        if (random == 8 || random == 18 || random == 28 || random == 38 || random == 48 || random == 58 || random == 68 || random == 78 || random == 88 || random == 98)
                        { }
                        else
                        {
                            //слева снизу
                            if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                            {
                            }
                            else
                            {
                                LockRec2[random - 8] = true;
                                //                 Field1[LastActiveRectangle - 8].Fill = Brushes.Gray;
                            }
                            //справа снизу
                            if (random == 90 || random == 91 || random == 92 || random == 93 || random == 94 || random == 95 || random == 96 || random == 97 || random == 98 || random == 99)
                            { }
                            else
                            {

                                LockRec2[random + 12] = true;
                                //                 Field1[LastActiveRectangle + 12].Fill = Brushes.Gray;

                            }

                            LockRec2[random + 2] = true;
                            //          Field1[LastActiveRectangle + 2].Fill = Brushes.Gray;


                        }
                        //справа 
                        if (random == 90 || random == 91 || random == 92 || random == 93 || random == 94 || random == 95 || random == 96 || random == 97 || random == 98 || random == 99)
                        { }
                        else
                        {

                            LockRec2[random + 10] = true;
                            //          Field1[LastActiveRectangle + 10].Fill = Brushes.Gray;


                            LockRec2[random + 11] = true;
                            //             Field1[LastActiveRectangle + 11].Fill = Brushes.Gray;


                        }

                        //_____________________________________________________________________________________________

                        GameRec2[random] = true;
                   //     Field2[random].Fill = Brushes.Gray;

                        GameRec2[random + 1] = true;
                 //       Field2[random + 1].Fill = Brushes.Gray;

                        Lock2 = false;
                    }


            }

            Lock2 = true;

            random = rnd.Next(1, 3);
            if (random == 1)
            {
                //Lodka2 по горизонтали


                random = rnd.Next(0, 89);

                while (Lock2 == true)
                    if (LockRec2[random] == true || LockRec2[random + 10] == true || GameRec2[random] == true || GameRec2[random + 10] == true)
                    {

                        random = rnd.Next(0, 89);
                    }
                    else
                    {

                        // клетки окружающие Lodka по горизонтали
                        //_____________________________________________________________________________________________
                        //сверху
                        if (random == 0 || random == 10 || random == 20 || random == 30 || random == 40 || random == 50 || random == 60 || random == 70 || random == 80 || random == 90)
                        { }
                        else
                        {
                            LockRec2[random - 1] = true;
                            //          Field1[LastActiveRectangle - 1].Fill = Brushes.Gray;

                            LockRec2[random + 9] = true;
                            //           Field1[LastActiveRectangle + 9].Fill = Brushes.Gray;


                            //слева сверху
                            if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                            { }
                            else
                            {
                                LockRec2[random - 11] = true;
                                //              Field1[LastActiveRectangle - 11].Fill = Brushes.Gray;
                            }
                            //справа сверху
                            if (random == 80 || random == 81 || random == 82 || random == 83 || random == 84 || random == 85 || random == 86 || random == 87 || random == 88 || random == 89)
                            { }
                            else
                            {

                                LockRec2[random + 19] = true;
                                //               Field1[LastActiveRectangle + 19].Fill = Brushes.Gray;

                            }
                        }
                        //слева
                        if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                        {
                        }
                        else
                        {
                            LockRec2[random - 10] = true;
                            //         Field1[LastActiveRectangle - 10].Fill = Brushes.Gray;
                        }
                        //снизу
                        if (random == 9 || random == 19 || random == 29 || random == 39 || random == 49 || random == 59 || random == 69 || random == 79 || random == 89 || random == 99)
                        { }
                        else
                        {
                            //слева снизу
                            if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                            {
                            }
                            else
                            {
                                LockRec2[random - 9] = true;
                                //              Field1[LastActiveRectangle - 9].Fill = Brushes.Gray;
                            }
                            //справа снизу
                            if (random == 80 || random == 81 || random == 82 || random == 83 || random == 84 || random == 85 || random == 86 || random == 87 || random == 88 || random == 89)
                            { }
                            else
                            {

                                LockRec2[random + 21] = true;
                                //              Field1[LastActiveRectangle + 21].Fill = Brushes.Gray;

                            }

                            LockRec2[random + 1] = true;
                            //         Field1[LastActiveRectangle + 1].Fill = Brushes.Gray;

                            LockRec2[random + 11] = true;
                            //          Field1[LastActiveRectangle + 11].Fill = Brushes.Gray;

                        }
                        //справа 
                        if (random == 80 || random == 81 || random == 82 || random == 83 || random == 84 || random == 85 || random == 86 || random == 87 || random == 88 || random == 89)
                        { }
                        else
                        {

                            LockRec2[random + 20] = true;
                            //          Field1[LastActiveRectangle + 20].Fill = Brushes.Gray;

                        }

                        //_____________________________________________________________________________________________

                        GameRec2[random] = true;
                 //       Field2[random].Fill = Brushes.Gray;

                        GameRec2[random + 10] = true;
                 //       Field2[random + 10].Fill = Brushes.Gray;

                        Lock2 = false;
                    }
            }
            else
            {
                //Lodka по вертикали
                while (Lock2 == true)
                    if (LockRec2[random] == true || LockRec2[random + 1] == true || GameRec2[random] == true || GameRec2[random + 1] == true)
                    {




                        ar = rnd.Next(0, 10);
                        switch (ar)
                        {
                            case 0:
                                random = rnd.Next(0, 8);
                                break;

                            case 1:
                                random = rnd.Next(10, 18);

                                break;

                            case 2:
                                random = rnd.Next(20, 28);
                                break;

                            case 3:
                                random = rnd.Next(30, 38);
                                break;

                            case 4:
                                random = rnd.Next(40, 48);
                                break;

                            case 5:
                                random = rnd.Next(50, 58);
                                break;
                            case 6:
                                random = rnd.Next(60, 68);
                                break;
                            case 7:
                                random = rnd.Next(70, 78);
                                break;
                            case 8:
                                random = rnd.Next(80, 88);
                                break;
                            case 9:
                                random = rnd.Next(90, 98);
                                break;
                        }
                    }
                    else
                    {


                        // клетки окружающие Lodka по вертикали
                        //_____________________________________________________________________________________________
                        //сверху
                        if (random == 0 || random == 10 || random == 20 || random == 30 || random == 40 || random == 50 || random == 60 || random == 70 || random == 80 || random == 90)
                        { }
                        else
                        {
                            LockRec2[random - 1] = true;
                            //             Field1[LastActiveRectangle - 1].Fill = Brushes.Gray;

                            //слева сверху
                            if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                            { }
                            else
                            {
                                LockRec2[random - 11] = true;
                                //                Field1[LastActiveRectangle - 11].Fill = Brushes.Gray;
                            }
                            //справа сверху
                            if (random == 90 || random == 91 || random == 92 || random == 93 || random == 94 || random == 95 || random == 96 || random == 97 || random == 98 || random == 99)
                            { }
                            else
                            {

                                LockRec2[random + 9] = true;
                                //               Field1[LastActiveRectangle + 9].Fill = Brushes.Gray;

                            }
                        }
                        //слева
                        if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                        {
                        }
                        else
                        {
                            LockRec2[random - 10] = true;
                            //             Field1[LastActiveRectangle - 10].Fill = Brushes.Gray;

                            LockRec2[random - 9] = true;
                            //            Field1[LastActiveRectangle - 9].Fill = Brushes.Gray;


                        }
                        //снизу
                        if (random == 8 || random == 18 || random == 28 || random == 38 || random == 48 || random == 58 || random == 68 || random == 78 || random == 88 || random == 98)
                        { }
                        else
                        {
                            //слева снизу
                            if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                            {
                            }
                            else
                            {
                                LockRec2[random - 8] = true;
                                //                 Field1[LastActiveRectangle - 8].Fill = Brushes.Gray;
                            }
                            //справа снизу
                            if (random == 90 || random == 91 || random == 92 || random == 93 || random == 94 || random == 95 || random == 96 || random == 97 || random == 98 || random == 99)
                            { }
                            else
                            {

                                LockRec2[random + 12] = true;
                                //                 Field1[LastActiveRectangle + 12].Fill = Brushes.Gray;

                            }

                            LockRec2[random + 2] = true;
                            //          Field1[LastActiveRectangle + 2].Fill = Brushes.Gray;


                        }
                        //справа 
                        if (random == 90 || random == 91 || random == 92 || random == 93 || random == 94 || random == 95 || random == 96 || random == 97 || random == 98 || random == 99)
                        { }
                        else
                        {

                            LockRec2[random + 10] = true;
                            //          Field1[LastActiveRectangle + 10].Fill = Brushes.Gray;


                            LockRec2[random + 11] = true;
                            //             Field1[LastActiveRectangle + 11].Fill = Brushes.Gray;


                        }

                        //_____________________________________________________________________________________________

                        GameRec2[random] = true;
                   //     Field2[random].Fill = Brushes.Gray;

                        GameRec2[random + 1] = true;
                 //       Field2[random + 1].Fill = Brushes.Gray;

                        Lock2 = false;
                    }


            }

            Lock2 = true;

            random = rnd.Next(1, 3);
            if (random == 1)
            {
                //Lodka3 по горизонтали


                random = rnd.Next(0, 89);

                while (Lock2 == true)
                    if (LockRec2[random] == true || LockRec2[random + 10] == true || GameRec2[random] == true || GameRec2[random + 10] == true)
                    {

                        random = rnd.Next(0, 89);
                    }
                    else
                    {

                        // клетки окружающие Lodka по горизонтали
                        //_____________________________________________________________________________________________
                        //сверху
                        if (random == 0 || random == 10 || random == 20 || random == 30 || random == 40 || random == 50 || random == 60 || random == 70 || random == 80 || random == 90)
                        { }
                        else
                        {
                            LockRec2[random - 1] = true;
                            //          Field1[LastActiveRectangle - 1].Fill = Brushes.Gray;

                            LockRec2[random + 9] = true;
                            //           Field1[LastActiveRectangle + 9].Fill = Brushes.Gray;


                            //слева сверху
                            if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                            { }
                            else
                            {
                                LockRec2[random - 11] = true;
                                //              Field1[LastActiveRectangle - 11].Fill = Brushes.Gray;
                            }
                            //справа сверху
                            if (random == 80 || random == 81 || random == 82 || random == 83 || random == 84 || random == 85 || random == 86 || random == 87 || random == 88 || random == 89)
                            { }
                            else
                            {

                                LockRec2[random + 19] = true;
                                //               Field1[LastActiveRectangle + 19].Fill = Brushes.Gray;

                            }
                        }
                        //слева
                        if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                        {
                        }
                        else
                        {
                            LockRec2[random - 10] = true;
                            //         Field1[LastActiveRectangle - 10].Fill = Brushes.Gray;
                        }
                        //снизу
                        if (random == 9 || random == 19 || random == 29 || random == 39 || random == 49 || random == 59 || random == 69 || random == 79 || random == 89 || random == 99)
                        { }
                        else
                        {
                            //слева снизу
                            if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                            {
                            }
                            else
                            {
                                LockRec2[random - 9] = true;
                                //              Field1[LastActiveRectangle - 9].Fill = Brushes.Gray;
                            }
                            //справа снизу
                            if (random == 80 || random == 81 || random == 82 || random == 83 || random == 84 || random == 85 || random == 86 || random == 87 || random == 88 || random == 89)
                            { }
                            else
                            {

                                LockRec2[random + 21] = true;
                                //              Field1[LastActiveRectangle + 21].Fill = Brushes.Gray;

                            }

                            LockRec2[random + 1] = true;
                            //         Field1[LastActiveRectangle + 1].Fill = Brushes.Gray;

                            LockRec2[random + 11] = true;
                            //          Field1[LastActiveRectangle + 11].Fill = Brushes.Gray;

                        }
                        //справа 
                        if (random == 80 || random == 81 || random == 82 || random == 83 || random == 84 || random == 85 || random == 86 || random == 87 || random == 88 || random == 89)
                        { }
                        else
                        {

                            LockRec2[random + 20] = true;
                            //          Field1[LastActiveRectangle + 20].Fill = Brushes.Gray;

                        }

                        //_____________________________________________________________________________________________

                        GameRec2[random] = true;
                  //      Field2[random].Fill = Brushes.Gray;

                        GameRec2[random + 10] = true;
                  //      Field2[random + 10].Fill = Brushes.Gray;

                        Lock2 = false;
                    }
            }
            else
            {
                //Lodka по вертикали
                while (Lock2 == true)
                    if (LockRec2[random] == true || LockRec2[random + 1] == true || GameRec2[random] == true || GameRec2[random + 1] == true)
                    {




                        ar = rnd.Next(0, 10);
                        switch (ar)
                        {
                            case 0:
                                random = rnd.Next(0, 8);
                                break;

                            case 1:
                                random = rnd.Next(10, 18);

                                break;

                            case 2:
                                random = rnd.Next(20, 28);
                                break;

                            case 3:
                                random = rnd.Next(30, 38);
                                break;

                            case 4:
                                random = rnd.Next(40, 48);
                                break;

                            case 5:
                                random = rnd.Next(50, 58);
                                break;
                            case 6:
                                random = rnd.Next(60, 68);
                                break;
                            case 7:
                                random = rnd.Next(70, 78);
                                break;
                            case 8:
                                random = rnd.Next(80, 88);
                                break;
                            case 9:
                                random = rnd.Next(90, 98);
                                break;
                        }
                    }
                    else
                    {


                        // клетки окружающие Lodka по вертикали
                        //_____________________________________________________________________________________________
                        //сверху
                        if (random == 0 || random == 10 || random == 20 || random == 30 || random == 40 || random == 50 || random == 60 || random == 70 || random == 80 || random == 90)
                        { }
                        else
                        {
                            LockRec2[random - 1] = true;
                            //             Field1[LastActiveRectangle - 1].Fill = Brushes.Gray;

                            //слева сверху
                            if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                            { }
                            else
                            {
                                LockRec2[random - 11] = true;
                                //                Field1[LastActiveRectangle - 11].Fill = Brushes.Gray;
                            }
                            //справа сверху
                            if (random == 90 || random == 91 || random == 92 || random == 93 || random == 94 || random == 95 || random == 96 || random == 97 || random == 98 || random == 99)
                            { }
                            else
                            {

                                LockRec2[random + 9] = true;
                                //               Field1[LastActiveRectangle + 9].Fill = Brushes.Gray;

                            }
                        }
                        //слева
                        if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                        {
                        }
                        else
                        {
                            LockRec2[random - 10] = true;
                            //             Field1[LastActiveRectangle - 10].Fill = Brushes.Gray;

                            LockRec2[random - 9] = true;
                            //            Field1[LastActiveRectangle - 9].Fill = Brushes.Gray;


                        }
                        //снизу
                        if (random == 8 || random == 18 || random == 28 || random == 38 || random == 48 || random == 58 || random == 68 || random == 78 || random == 88 || random == 98)
                        { }
                        else
                        {
                            //слева снизу
                            if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                            {
                            }
                            else
                            {
                                LockRec2[random - 8] = true;
                                //                 Field1[LastActiveRectangle - 8].Fill = Brushes.Gray;
                            }
                            //справа снизу
                            if (random == 90 || random == 91 || random == 92 || random == 93 || random == 94 || random == 95 || random == 96 || random == 97 || random == 98 || random == 99)
                            { }
                            else
                            {

                                LockRec2[random + 12] = true;
                                //                 Field1[LastActiveRectangle + 12].Fill = Brushes.Gray;

                            }

                            LockRec2[random + 2] = true;
                            //          Field1[LastActiveRectangle + 2].Fill = Brushes.Gray;


                        }
                        //справа 
                        if (random == 90 || random == 91 || random == 92 || random == 93 || random == 94 || random == 95 || random == 96 || random == 97 || random == 98 || random == 99)
                        { }
                        else
                        {

                            LockRec2[random + 10] = true;
                            //          Field1[LastActiveRectangle + 10].Fill = Brushes.Gray;


                            LockRec2[random + 11] = true;
                            //             Field1[LastActiveRectangle + 11].Fill = Brushes.Gray;


                        }

                        //_____________________________________________________________________________________________

                        GameRec2[random] = true;
                  //      Field2[random].Fill = Brushes.Gray;

                        GameRec2[random + 1] = true;
                  //      Field2[random + 1].Fill = Brushes.Gray;

                        Lock2 = false;
                    }


            }

            Lock2 = true;


            //Mini1
            random = rnd.Next(0, 99);

            while (Lock2 == true)
                if (LockRec2[random] == true|| GameRec2[random] == true )
                {

                    random = rnd.Next(0, 99);
                }
                else
                {

                    // клетки окружающие Mini по горизонтали
                    //_____________________________________________________________________________________________
                    //сверху
                    if (random == 0 || random == 10 || random == 20 || random == 30 || random == 40 || random == 50 || random == 60 || random == 70 || random == 80 || random == 90)
                    { }
                    else
                    {
                        LockRec2[random - 1] = true;
                        //                Field1[LastActiveRectangle - 1].Fill = Brushes.Gray;


                        //слева сверху
                        if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                        { }
                        else
                        {
                            LockRec2[random - 11] = true;
                            //                   Field1[LastActiveRectangle - 11].Fill = Brushes.Gray;
                        }
                        //справа сверху
                        if (random == 90 || random == 91 || random == 92 || random == 93 || random == 94 || random == 95 || random == 96 || random == 97 || random == 98 || random == 99)
                        { }
                        else
                        {

                            LockRec2[random + 9] = true;
                            //                 Field1[LastActiveRectangle + 9].Fill = Brushes.Gray;

                        }
                    }
                    //слева
                    if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                    {
                    }
                    else
                    {
                        LockRec2[random - 10] = true;
                        //              Field1[LastActiveRectangle - 10].Fill = Brushes.Gray;
                    }
                    //снизу
                    if (random == 9 || random == 19 || random == 29 || random == 39 || random == 49 || random == 59 || random == 69 || random == 79 || random == 89 || random == 99)
                    { }
                    else
                    {
                        //слева снизу
                        if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                        {
                        }
                        else
                        {
                            LockRec2[random - 9] = true;
                            //              Field1[LastActiveRectangle - 9].Fill = Brushes.Gray;
                        }
                        //справа снизу
                        if (random == 90 || random == 91 || random == 92 || random == 93 || random == 94 || random == 95 || random == 96 || random == 97 || random == 98 || random == 99)
                        { }
                        else
                        {

                            LockRec2[random + 11] = true;
                            //               Field1[LastActiveRectangle + 11].Fill = Brushes.Gray;

                        }

                        LockRec2[random + 1] = true;
                        //           Field1[LastActiveRectangle + 1].Fill = Brushes.Gray;



                    }
                    //справа 
                    if (random == 90 || random == 91 || random == 92 || random == 93 || random == 94 || random == 95 || random == 96 || random == 97 || random == 98 || random == 99)
                    { }
                    else
                    {

                        LockRec2[random + 10] = true;
                        //           Field1[LastActiveRectangle + 10].Fill = Brushes.Gray;

                    }

                    //_____________________________________________________________________________________________


                    GameRec2[random] = true;
                //    Field2[random].Fill = Brushes.Gray;
                    Lock2 = false;
                }

            
             Lock2 = true;

            //Mini2


            random = rnd.Next(0, 99);

            while (Lock2 == true)
                if (LockRec2[random] == true || GameRec2[random] == true)
                {

                    random = rnd.Next(0, 99);
                }
                else
                {

                    // клетки окружающие Mini по горизонтали
                    //_____________________________________________________________________________________________
                    //сверху
                    if (random == 0 || random == 10 || random == 20 || random == 30 || random == 40 || random == 50 || random == 60 || random == 70 || random == 80 || random == 90)
                    { }
                    else
                    {
                        LockRec2[random - 1] = true;
                        //                Field1[LastActiveRectangle - 1].Fill = Brushes.Gray;


                        //слева сверху
                        if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                        { }
                        else
                        {
                            LockRec2[random - 11] = true;
                            //                   Field1[LastActiveRectangle - 11].Fill = Brushes.Gray;
                        }
                        //справа сверху
                        if (random == 90 || random == 91 || random == 92 || random == 93 || random == 94 || random == 95 || random == 96 || random == 97 || random == 98 || random == 99)
                        { }
                        else
                        {

                            LockRec2[random + 9] = true;
                            //                 Field1[LastActiveRectangle + 9].Fill = Brushes.Gray;

                        }
                    }
                    //слева
                    if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                    {
                    }
                    else
                    {
                        LockRec2[random - 10] = true;
                        //              Field1[LastActiveRectangle - 10].Fill = Brushes.Gray;
                    }
                    //снизу
                    if (random == 9 || random == 19 || random == 29 || random == 39 || random == 49 || random == 59 || random == 69 || random == 79 || random == 89 || random == 99)
                    { }
                    else
                    {
                        //слева снизу
                        if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                        {
                        }
                        else
                        {
                            LockRec2[random - 9] = true;
                            //              Field1[LastActiveRectangle - 9].Fill = Brushes.Gray;
                        }
                        //справа снизу
                        if (random == 90 || random == 91 || random == 92 || random == 93 || random == 94 || random == 95 || random == 96 || random == 97 || random == 98 || random == 99)
                        { }
                        else
                        {

                            LockRec2[random + 11] = true;
                            //               Field1[LastActiveRectangle + 11].Fill = Brushes.Gray;

                        }

                        LockRec2[random + 1] = true;
                        //           Field1[LastActiveRectangle + 1].Fill = Brushes.Gray;



                    }
                    //справа 
                    if (random == 90 || random == 91 || random == 92 || random == 93 || random == 94 || random == 95 || random == 96 || random == 97 || random == 98 || random == 99)
                    { }
                    else
                    {

                        LockRec2[random + 10] = true;
                        //           Field1[LastActiveRectangle + 10].Fill = Brushes.Gray;

                    }

                    //_____________________________________________________________________________________________


                    GameRec2[random] = true;
                //    Field2[random].Fill = Brushes.Gray;
                    Lock2 = false;
                }


            Lock2 = true;

            //Mini3


            random = rnd.Next(0, 99);

            while (Lock2 == true)
                if (LockRec2[random] == true || GameRec2[random] == true)
                {

                    random = rnd.Next(0, 99);
                }
                else
                {

                    // клетки окружающие Mini по горизонтали
                    //_____________________________________________________________________________________________
                    //сверху
                    if (random == 0 || random == 10 || random == 20 || random == 30 || random == 40 || random == 50 || random == 60 || random == 70 || random == 80 || random == 90)
                    { }
                    else
                    {
                        LockRec2[random - 1] = true;
                        //                Field1[LastActiveRectangle - 1].Fill = Brushes.Gray;


                        //слева сверху
                        if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                        { }
                        else
                        {
                            LockRec2[random - 11] = true;
                            //                   Field1[LastActiveRectangle - 11].Fill = Brushes.Gray;
                        }
                        //справа сверху
                        if (random == 90 || random == 91 || random == 92 || random == 93 || random == 94 || random == 95 || random == 96 || random == 97 || random == 98 || random == 99)
                        { }
                        else
                        {

                            LockRec2[random + 9] = true;
                            //                 Field1[LastActiveRectangle + 9].Fill = Brushes.Gray;

                        }
                    }
                    //слева
                    if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                    {
                    }
                    else
                    {
                        LockRec2[random - 10] = true;
                        //              Field1[LastActiveRectangle - 10].Fill = Brushes.Gray;
                    }
                    //снизу
                    if (random == 9 || random == 19 || random == 29 || random == 39 || random == 49 || random == 59 || random == 69 || random == 79 || random == 89 || random == 99)
                    { }
                    else
                    {
                        //слева снизу
                        if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                        {
                        }
                        else
                        {
                            LockRec2[random - 9] = true;
                            //              Field1[LastActiveRectangle - 9].Fill = Brushes.Gray;
                        }
                        //справа снизу
                        if (random == 90 || random == 91 || random == 92 || random == 93 || random == 94 || random == 95 || random == 96 || random == 97 || random == 98 || random == 99)
                        { }
                        else
                        {

                            LockRec2[random + 11] = true;
                            //               Field1[LastActiveRectangle + 11].Fill = Brushes.Gray;

                        }

                        LockRec2[random + 1] = true;
                        //           Field1[LastActiveRectangle + 1].Fill = Brushes.Gray;



                    }
                    //справа 
                    if (random == 90 || random == 91 || random == 92 || random == 93 || random == 94 || random == 95 || random == 96 || random == 97 || random == 98 || random == 99)
                    { }
                    else
                    {

                        LockRec2[random + 10] = true;
                        //           Field1[LastActiveRectangle + 10].Fill = Brushes.Gray;

                    }

                    //_____________________________________________________________________________________________


                    GameRec2[random] = true;
               //     Field2[random].Fill = Brushes.Gray;
                    Lock2 = false;
                }


            Lock2 = true;

            //Mini4
            random = rnd.Next(0, 99);

            while (Lock2 == true)
                if (LockRec2[random] == true || GameRec2[random] == true)
                {

                    random = rnd.Next(0, 99);
                }
                else
                {

                    // клетки окружающие Mini по горизонтали
                    //_____________________________________________________________________________________________
                    //сверху
                    if (random == 0 || random == 10 || random == 20 || random == 30 || random == 40 || random == 50 || random == 60 || random == 70 || random == 80 || random == 90)
                    { }
                    else
                    {
                        LockRec2[random - 1] = true;
                        //                Field1[LastActiveRectangle - 1].Fill = Brushes.Gray;


                        //слева сверху
                        if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                        { }
                        else
                        {
                            LockRec2[random - 11] = true;
                            //                   Field1[LastActiveRectangle - 11].Fill = Brushes.Gray;
                        }
                        //справа сверху
                        if (random == 90 || random == 91 || random == 92 || random == 93 || random == 94 || random == 95 || random == 96 || random == 97 || random == 98 || random == 99)
                        { }
                        else
                        {

                            LockRec2[random + 9] = true;
                            //                 Field1[LastActiveRectangle + 9].Fill = Brushes.Gray;

                        }
                    }
                    //слева
                    if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                    {
                    }
                    else
                    {
                        LockRec2[random - 10] = true;
                        //              Field1[LastActiveRectangle - 10].Fill = Brushes.Gray;
                    }
                    //снизу
                    if (random == 9 || random == 19 || random == 29 || random == 39 || random == 49 || random == 59 || random == 69 || random == 79 || random == 89 || random == 99)
                    { }
                    else
                    {
                        //слева снизу
                        if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                        {
                        }
                        else
                        {
                            LockRec2[random - 9] = true;
                            //              Field1[LastActiveRectangle - 9].Fill = Brushes.Gray;
                        }
                        //справа снизу
                        if (random == 90 || random == 91 || random == 92 || random == 93 || random == 94 || random == 95 || random == 96 || random == 97 || random == 98 || random == 99)
                        { }
                        else
                        {

                            LockRec2[random + 11] = true;
                            //               Field1[LastActiveRectangle + 11].Fill = Brushes.Gray;

                        }

                        LockRec2[random + 1] = true;
                        //           Field1[LastActiveRectangle + 1].Fill = Brushes.Gray;



                    }
                    //справа 
                    if (random == 90 || random == 91 || random == 92 || random == 93 || random == 94 || random == 95 || random == 96 || random == 97 || random == 98 || random == 99)
                    { }
                    else
                    {

                        LockRec2[random + 10] = true;
                        //           Field1[LastActiveRectangle + 10].Fill = Brushes.Gray;

                    }

                    //_____________________________________________________________________________________________


                    GameRec2[random] = true;
              //      Field2[random].Fill = Brushes.Gray;
                    Lock2 = false;
                }


        }



        /// <summary>
        /// Таймера для запуска события
        /// </summary>

        private void Timerset()
        {
            DispatcherTimer timerMove = new DispatcherTimer();
            timerMove.Tick += new EventHandler(timerTickMove);
            timerMove.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timerMove.Start();

            DispatcherTimer timerGame = new DispatcherTimer();
            timerMove.Tick += new EventHandler(timerTickGame);
            timerMove.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timerMove.Start();
            
        }

        //Таймер для автоматической коректировки расположения кораблей в ячейках
        private void timerTickMove(object sender, EventArgs e)
        {
            
            if (ifMouseClicked[0] == false)
                if (LockRec[LastActiveRectangle] != true )
            {
                if (Lasttapedship == 0)
                {
                    if ((ShipsLeft[Lasttapedship] + 10 >= Canvas.GetLeft(Field1[LastActiveRectangle]) && ShipsLeft[Lasttapedship] <= Canvas.GetLeft(Field1[LastActiveRectangle]) + Field1[LastActiveRectangle].Width) && ((ShipsTop[Lasttapedship] + 10 >= Canvas.GetTop(Field1[LastActiveRectangle])) && ShipsTop[Lasttapedship] + 8 <= Canvas.GetTop(Field1[LastActiveRectangle]) + Field1[LastActiveRectangle].Height))
                    {
                        //для авианосца по горизонтали
                        if (ifvertical[Lasttapedship] == false)
                        {
                            if (LastActiveRectangle == 70 || LastActiveRectangle == 80 || LastActiveRectangle == 90 ||
                                LastActiveRectangle == 71 || LastActiveRectangle == 81 || LastActiveRectangle == 91 ||
                                LastActiveRectangle == 72 || LastActiveRectangle == 82 || LastActiveRectangle == 92 ||
                                LastActiveRectangle == 73 || LastActiveRectangle == 83 || LastActiveRectangle == 93 ||
                                LastActiveRectangle == 74 || LastActiveRectangle == 84 || LastActiveRectangle == 94 ||
                                LastActiveRectangle == 75 || LastActiveRectangle == 85 || LastActiveRectangle == 95 ||
                                LastActiveRectangle == 76 || LastActiveRectangle == 86 || LastActiveRectangle == 96 ||
                                LastActiveRectangle == 77 || LastActiveRectangle == 87 || LastActiveRectangle == 97 ||
                                LastActiveRectangle == 78 || LastActiveRectangle == 88 || LastActiveRectangle == 98 ||
                                LastActiveRectangle == 79 || LastActiveRectangle == 89 || LastActiveRectangle == 99)
                            {
                            }
                            else
                            {
                                Canvas.SetLeft(Ships[Lasttapedship], Canvas.GetLeft(Field1[LastActiveRectangle]));
                                Canvas.SetTop(Ships[Lasttapedship], Canvas.GetTop(Field1[LastActiveRectangle]) - 7);
                                Field1[LastActiveRectangle].Fill = Brushes.DarkBlue;
                                Field1[LastActiveRectangle + 10].Fill = Brushes.DarkBlue;
                                Field1[LastActiveRectangle + 20].Fill = Brushes.DarkBlue;
                                Field1[LastActiveRectangle + 30].Fill = Brushes.DarkBlue;


                                
                                GameRec[LastActiveRectangle] = true;

                              
                                GameRec[LastActiveRectangle + 10] = true;

                              
                                GameRec[LastActiveRectangle + 20] = true;

                              
                                GameRec[LastActiveRectangle + 30] = true;

                                // клетки окружающие авиа по горизонтали
                                //_____________________________________________________________________________________________
                                //сверху
                                
                                if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 10 || SP[Lasttapedship] == 20 || SP[Lasttapedship] == 30 || SP[Lasttapedship] == 40 || SP[Lasttapedship] == 50 || SP[Lasttapedship] == 60 || SP[Lasttapedship] == 70 || SP[Lasttapedship] == 80 || SP[Lasttapedship] == 90)
                                { }
                                else
                                {
                                    LockRec[LastActiveRectangle - 1] = true;
                                //    Field1[LastActiveRectangle - 1].Fill = Brushes.Gray;

                                    LockRec[LastActiveRectangle + 9] = true;
                                //    Field1[LastActiveRectangle + 9].Fill = Brushes.Gray;

                                    LockRec[LastActiveRectangle + 19] = true;
                                //    Field1[LastActiveRectangle + 19].Fill = Brushes.Gray;

                                    LockRec[LastActiveRectangle + 29] = true;
                                //    Field1[LastActiveRectangle + 29].Fill = Brushes.Gray;
                                    
                                    //слева сверху
                                    if (LastActiveRectangle == 0 || LastActiveRectangle == 1 || LastActiveRectangle == 2 || LastActiveRectangle == 3 || LastActiveRectangle == 4 || LastActiveRectangle == 5 || LastActiveRectangle == 6 || LastActiveRectangle == 7 || LastActiveRectangle == 8 || LastActiveRectangle == 9)
                                    { }
                                    else
                                    {
                                        LockRec[LastActiveRectangle - 11] = true;
                               //         Field1[LastActiveRectangle - 11].Fill = Brushes.Gray;
                                    }
                                    //справа сверху
                                    if (LastActiveRectangle == 60 || LastActiveRectangle == 61 || LastActiveRectangle == 62 || LastActiveRectangle == 63 || LastActiveRectangle == 64 || LastActiveRectangle == 65 || LastActiveRectangle == 66 || LastActiveRectangle == 67 || LastActiveRectangle == 68 || LastActiveRectangle == 69)
                                    { }
                                    else
                                    {

                                        LockRec[LastActiveRectangle + 39] = true;
                                //        Field1[LastActiveRectangle + 39].Fill = Brushes.Gray;

                                    }
                                }
                                //слева
                                if (LastActiveRectangle == 0 || LastActiveRectangle == 1 || LastActiveRectangle == 2 || LastActiveRectangle == 3 || LastActiveRectangle == 4 || LastActiveRectangle == 5 || LastActiveRectangle == 6 || LastActiveRectangle == 7 || LastActiveRectangle == 8 || LastActiveRectangle == 9)
                                {
                                }
                                else
                                {
                                    LockRec[LastActiveRectangle - 10] = true;
                              //      Field1[LastActiveRectangle - 10].Fill = Brushes.Gray;
                                }
                                //снизу
                                if (LastActiveRectangle == 9 || LastActiveRectangle == 19 || LastActiveRectangle == 29 || LastActiveRectangle == 39 || LastActiveRectangle == 49 || LastActiveRectangle == 59 || LastActiveRectangle == 69 || LastActiveRectangle == 79 || LastActiveRectangle == 89 || LastActiveRectangle == 99)
                                { }
                                else
                                {
                                    //слева снизу
                                    if (LastActiveRectangle == 0 || LastActiveRectangle == 1 || LastActiveRectangle == 2 || LastActiveRectangle == 3 || LastActiveRectangle == 4 || LastActiveRectangle == 5 || LastActiveRectangle == 6 || LastActiveRectangle == 7 || LastActiveRectangle == 8 || LastActiveRectangle == 9)
                                    {
                                    }
                                    else
                                    {
                                        LockRec[LastActiveRectangle - 9] = true;
                                //        Field1[LastActiveRectangle - 9].Fill = Brushes.Gray;
                                    }
                                    //справа снизу
                                    if (LastActiveRectangle == 60 || LastActiveRectangle == 61 || LastActiveRectangle == 62 || LastActiveRectangle == 63 || LastActiveRectangle == 64 || LastActiveRectangle == 65 || LastActiveRectangle == 66 || LastActiveRectangle == 67 || LastActiveRectangle == 68 || LastActiveRectangle == 69)
                                    { }
                                    else
                                    {

                                        LockRec[LastActiveRectangle + 41] = true;
                                //        Field1[LastActiveRectangle + 41].Fill = Brushes.Gray;

                                    }

                                    LockRec[LastActiveRectangle + 1] = true;
                               //     Field1[LastActiveRectangle + 1].Fill = Brushes.Gray;

                                    LockRec[LastActiveRectangle + 11] = true;
                              //      Field1[LastActiveRectangle + 11].Fill = Brushes.Gray;

                                    LockRec[LastActiveRectangle + 21] = true;
                               //     Field1[LastActiveRectangle + 21].Fill = Brushes.Gray;

                                    LockRec[LastActiveRectangle + 31] = true;
                              //      Field1[LastActiveRectangle + 31].Fill = Brushes.Gray;
                                }
                                //справа 
                                if ( LastActiveRectangle == 60 || LastActiveRectangle == 61 || LastActiveRectangle == 62 || LastActiveRectangle == 63 || LastActiveRectangle == 64 || LastActiveRectangle == 65 || LastActiveRectangle == 66 || LastActiveRectangle == 67 || LastActiveRectangle == 68 || LastActiveRectangle == 69)
                                { }
                                else
                                {
                                    
                                        LockRec[LastActiveRectangle + 40] = true;
                             //           Field1[LastActiveRectangle + 40].Fill = Brushes.Gray;
                                    
                                }



                               //_____________________________________________________________________________________________
                            }
                        }

                        //для авианосца по вертикали
                        if (ifvertical[Lasttapedship] == true)
                        {
                            if (LastActiveRectangle == 7  || LastActiveRectangle == 8  || LastActiveRectangle == 9  ||
                                LastActiveRectangle == 17 || LastActiveRectangle == 18 || LastActiveRectangle == 19 ||
                                LastActiveRectangle == 27 || LastActiveRectangle == 28 || LastActiveRectangle == 29 ||
                                LastActiveRectangle == 37 || LastActiveRectangle == 38 || LastActiveRectangle == 39 ||
                                LastActiveRectangle == 47 || LastActiveRectangle == 48 || LastActiveRectangle == 49 ||
                                LastActiveRectangle == 57 || LastActiveRectangle == 58 || LastActiveRectangle == 59 ||
                                LastActiveRectangle == 67 || LastActiveRectangle == 68 || LastActiveRectangle == 69 ||
                                LastActiveRectangle == 77 || LastActiveRectangle == 78 || LastActiveRectangle == 79 ||
                                LastActiveRectangle == 87 || LastActiveRectangle == 88 || LastActiveRectangle == 89 ||
                                LastActiveRectangle == 97 || LastActiveRectangle == 98 || LastActiveRectangle == 99)
                            {
                            }
                            else
                            {
                                Canvas.SetLeft(Ships[Lasttapedship], Canvas.GetLeft(Field1[LastActiveRectangle]) + 3);
                                Canvas.SetTop(Ships[Lasttapedship], Canvas.GetTop(Field1[LastActiveRectangle]) - 7);

                                Field1[LastActiveRectangle].Fill = Brushes.DarkBlue;
                                Field1[LastActiveRectangle + 1].Fill = Brushes.DarkBlue;
                                Field1[LastActiveRectangle + 2].Fill = Brushes.DarkBlue;
                                Field1[LastActiveRectangle + 3].Fill = Brushes.DarkBlue;

                             
                                GameRec[LastActiveRectangle] = true;

                               
                                GameRec[LastActiveRectangle + 1] = true;

                              
                                GameRec[LastActiveRectangle + 2] = true;

                                
                                GameRec[LastActiveRectangle + 3] = true;

                            }
                            // клетки окружающие авиа по вертикали
                            //_____________________________________________________________________________________________
                            //сверху
                            if (LastActiveRectangle == 0 || LastActiveRectangle == 10 || LastActiveRectangle == 20 || LastActiveRectangle == 30 || LastActiveRectangle == 40 || LastActiveRectangle == 50 || LastActiveRectangle == 60 || LastActiveRectangle == 70 || LastActiveRectangle == 80 || LastActiveRectangle == 90)
                            { }
                            else
                            {
                                LockRec[LastActiveRectangle - 1] = true;
                     //           Field1[LastActiveRectangle - 1].Fill = Brushes.Gray;

                                //слева сверху
                                if (LastActiveRectangle == 0 || LastActiveRectangle == 1 || LastActiveRectangle == 2 || LastActiveRectangle == 3 || LastActiveRectangle == 4 || LastActiveRectangle == 5 || LastActiveRectangle == 6 || LastActiveRectangle == 7 || LastActiveRectangle == 8 || LastActiveRectangle == 9)
                                { }
                                else
                                {
                                    LockRec[LastActiveRectangle - 11] = true;
                           //         Field1[LastActiveRectangle - 11].Fill = Brushes.Gray;
                                }
                                //справа сверху
                                if (LastActiveRectangle == 90 || LastActiveRectangle == 91 || LastActiveRectangle == 92 || LastActiveRectangle == 93 || LastActiveRectangle == 94 || LastActiveRectangle == 95 || LastActiveRectangle == 96 || LastActiveRectangle == 97 || LastActiveRectangle == 98 || LastActiveRectangle == 99)
                                { }
                                else
                                {

                                    LockRec[LastActiveRectangle + 9] = true;
                            //        Field1[LastActiveRectangle + 9].Fill = Brushes.Gray;

                                }
                            }
                            //слева
                            if (LastActiveRectangle == 0 || LastActiveRectangle == 1 || LastActiveRectangle == 2 || LastActiveRectangle == 3 || LastActiveRectangle == 4 || LastActiveRectangle == 5 || LastActiveRectangle == 6 || LastActiveRectangle == 7 || LastActiveRectangle == 8 || LastActiveRectangle == 9)
                            {
                            }
                            else
                            {
                                LockRec[LastActiveRectangle - 10] = true;
                         //       Field1[LastActiveRectangle - 10].Fill = Brushes.Gray;

                                LockRec[LastActiveRectangle - 9] = true;
                          //      Field1[LastActiveRectangle - 9].Fill = Brushes.Gray;

                                LockRec[LastActiveRectangle - 8] = true;
                           //     Field1[LastActiveRectangle - 8].Fill = Brushes.Gray;

                                LockRec[LastActiveRectangle - 7] = true;
                           //     Field1[LastActiveRectangle - 7].Fill = Brushes.Gray;
                            }
                            //снизу
                            if (LastActiveRectangle == 6 || LastActiveRectangle == 16 || LastActiveRectangle == 26 || LastActiveRectangle == 36 || LastActiveRectangle == 46 || LastActiveRectangle == 56 || LastActiveRectangle == 66 || LastActiveRectangle == 76 || LastActiveRectangle == 86 || LastActiveRectangle == 96)
                            { }
                            else
                            {
                                //слева снизу
                                if (LastActiveRectangle == 0 || LastActiveRectangle == 1 || LastActiveRectangle == 2 || LastActiveRectangle == 3 || LastActiveRectangle == 4 || LastActiveRectangle == 5 || LastActiveRectangle == 6 || LastActiveRectangle == 7 || LastActiveRectangle == 8 || LastActiveRectangle == 9)
                                {
                                }
                                else
                                {
                                    LockRec[LastActiveRectangle - 6] = true;
                          //          Field1[LastActiveRectangle - 6].Fill = Brushes.Gray;
                                }
                                //справа снизу
                                if (LastActiveRectangle == 90 || LastActiveRectangle == 91 || LastActiveRectangle == 92 || LastActiveRectangle == 93 || LastActiveRectangle == 94 || LastActiveRectangle == 95 || LastActiveRectangle == 96 || LastActiveRectangle == 97 || LastActiveRectangle == 98 || LastActiveRectangle == 99)
                                { }
                                else
                                {

                                    LockRec[LastActiveRectangle + 14] = true;
                          //          Field1[LastActiveRectangle + 14].Fill = Brushes.Gray;

                                }

                                LockRec[LastActiveRectangle + 4] = true;
                          //      Field1[LastActiveRectangle + 4].Fill = Brushes.Gray;

                              
                            }
                            //справа 
                            if (LastActiveRectangle == 90 || LastActiveRectangle == 91 || LastActiveRectangle == 92 || LastActiveRectangle == 93 || LastActiveRectangle == 94 || LastActiveRectangle == 95 || LastActiveRectangle == 96 || LastActiveRectangle == 97 || LastActiveRectangle == 98 || LastActiveRectangle == 99)
                            { }
                            else
                            {

                                LockRec[LastActiveRectangle + 10] = true;
                         //       Field1[LastActiveRectangle + 10].Fill = Brushes.Gray;


                                LockRec[LastActiveRectangle + 11] = true;
                          //      Field1[LastActiveRectangle + 11].Fill = Brushes.Gray;

                                LockRec[LastActiveRectangle + 12] = true;
                          //      Field1[LastActiveRectangle + 12].Fill = Brushes.Gray;

                                LockRec[LastActiveRectangle + 13] = true;
                          //      Field1[LastActiveRectangle + 13].Fill = Brushes.Gray;
                            }



                            //_____________________________________________________________________________________________
                        }
                    }
                }
               

            }
            // Для Destroyer
            if (ifMouseClicked[1] == false && ifMouseClicked[2] == false)
            {
               
                    if (Lasttapedship >= 1 && Lasttapedship <= 2)
                    if (LockRec[LastActiveRectangle] != true )
                    {
                    if ((ShipsLeft[Lasttapedship] + 10 >= Canvas.GetLeft(Field1[LastActiveRectangle]) && ShipsLeft[Lasttapedship] <= Canvas.GetLeft(Field1[LastActiveRectangle]) + Field1[LastActiveRectangle].Width) && ((ShipsTop[Lasttapedship] + 10 >= Canvas.GetTop(Field1[LastActiveRectangle])) && ShipsTop[Lasttapedship] + 8 <= Canvas.GetTop(Field1[LastActiveRectangle]) + Field1[LastActiveRectangle].Height))
                    {
                        //для Destroyer по горизонтали
                        if (ifvertical[Lasttapedship] == false)
                        {
                            if ( LastActiveRectangle == 80 || LastActiveRectangle == 90 ||
                                 LastActiveRectangle == 81 || LastActiveRectangle == 91 ||
                                 LastActiveRectangle == 82 || LastActiveRectangle == 92 ||
                                 LastActiveRectangle == 83 || LastActiveRectangle == 93 ||
                                 LastActiveRectangle == 84 || LastActiveRectangle == 94 ||
                                 LastActiveRectangle == 85 || LastActiveRectangle == 95 ||
                                 LastActiveRectangle == 86 || LastActiveRectangle == 96 ||
                                 LastActiveRectangle == 87 || LastActiveRectangle == 97 ||
                                 LastActiveRectangle == 88 || LastActiveRectangle == 98 ||
                                 LastActiveRectangle == 89 || LastActiveRectangle == 99 )
                            {
                            }
                            else
                            {
                                Canvas.SetLeft(Ships[Lasttapedship], Canvas.GetLeft(Field1[LastActiveRectangle]));
                                Canvas.SetTop(Ships[Lasttapedship], Canvas.GetTop(Field1[LastActiveRectangle]) - 5);
                                Field1[LastActiveRectangle].Fill = Brushes.DarkBlue;
                                Field1[LastActiveRectangle + 10].Fill = Brushes.DarkBlue;
                                Field1[LastActiveRectangle + 20].Fill = Brushes.DarkBlue;

                             
                                GameRec[LastActiveRectangle] = true;

                             
                                GameRec[LastActiveRectangle + 10] = true;

                           
                                GameRec[LastActiveRectangle + 20] = true;
                            }

                            // клетки окружающие Destroyer по горизонтали
                            //_____________________________________________________________________________________________
                            //сверху
                            if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 10 || SP[Lasttapedship] == 20 || SP[Lasttapedship] == 30 || SP[Lasttapedship] == 40 || SP[Lasttapedship] == 50 || SP[Lasttapedship] == 60 || SP[Lasttapedship] == 70 || SP[Lasttapedship] == 80 || SP[Lasttapedship] == 90)
                            { }
                            else
                            {
                                LockRec[LastActiveRectangle - 1] = true;
                     //           Field1[LastActiveRectangle - 1].Fill = Brushes.Gray;

                                LockRec[LastActiveRectangle + 9] = true;
                      //          Field1[LastActiveRectangle + 9].Fill = Brushes.Gray;

                                LockRec[LastActiveRectangle + 19] = true;
                      //          Field1[LastActiveRectangle + 19].Fill = Brushes.Gray;


                                //слева сверху
                                if (LastActiveRectangle == 0 || LastActiveRectangle == 1 || LastActiveRectangle == 2 || LastActiveRectangle == 3 || LastActiveRectangle == 4 || LastActiveRectangle == 5 || LastActiveRectangle == 6 || LastActiveRectangle == 7 || LastActiveRectangle == 8 || LastActiveRectangle == 9)
                                { }
                                else
                                {
                                    LockRec[LastActiveRectangle - 11] = true;
                      //              Field1[LastActiveRectangle - 11].Fill = Brushes.Gray;
                                }
                                //справа сверху
                                if (LastActiveRectangle == 70 || LastActiveRectangle == 71 || LastActiveRectangle == 72 || LastActiveRectangle == 73 || LastActiveRectangle == 74 || LastActiveRectangle == 75 || LastActiveRectangle == 76 || LastActiveRectangle == 77 || LastActiveRectangle == 78 || LastActiveRectangle == 79)
                                { }
                                else
                                {

                                    LockRec[LastActiveRectangle + 29] = true;
                        //            Field1[LastActiveRectangle + 29].Fill = Brushes.Gray;

                                }
                            }
                            //слева
                            if (LastActiveRectangle == 0 || LastActiveRectangle == 1 || LastActiveRectangle == 2 || LastActiveRectangle == 3 || LastActiveRectangle == 4 || LastActiveRectangle == 5 || LastActiveRectangle == 6 || LastActiveRectangle == 7 || LastActiveRectangle == 8 || LastActiveRectangle == 9)
                            {
                            }
                            else
                            {
                                LockRec[LastActiveRectangle - 10] = true;
                      //          Field1[LastActiveRectangle - 10].Fill = Brushes.Gray;
                            }
                            //снизу
                            if (LastActiveRectangle == 9 || LastActiveRectangle == 19 || LastActiveRectangle == 29 || LastActiveRectangle == 39 || LastActiveRectangle == 49 || LastActiveRectangle == 59 || LastActiveRectangle == 69 || LastActiveRectangle == 79 || LastActiveRectangle == 89 || LastActiveRectangle == 99)
                            { }
                            else
                            {
                                //слева снизу
                                if (LastActiveRectangle == 0 || LastActiveRectangle == 1 || LastActiveRectangle == 2 || LastActiveRectangle == 3 || LastActiveRectangle == 4 || LastActiveRectangle == 5 || LastActiveRectangle == 6 || LastActiveRectangle == 7 || LastActiveRectangle == 8 || LastActiveRectangle == 9)
                                {
                                }
                                else
                                {
                                    LockRec[LastActiveRectangle - 9] = true;
                       //             Field1[LastActiveRectangle - 9].Fill = Brushes.Gray;
                                }
                                //справа снизу
                                if (LastActiveRectangle == 70 || LastActiveRectangle == 71 || LastActiveRectangle == 72 || LastActiveRectangle == 73 || LastActiveRectangle == 74 || LastActiveRectangle == 75 || LastActiveRectangle == 76 || LastActiveRectangle == 77 || LastActiveRectangle == 78 || LastActiveRectangle == 79)
                                { }
                                else
                                {

                                    LockRec[LastActiveRectangle + 31] = true;
                       //             Field1[LastActiveRectangle + 31].Fill = Brushes.Gray;

                                }

                                LockRec[LastActiveRectangle + 1] = true;
                       //         Field1[LastActiveRectangle + 1].Fill = Brushes.Gray;

                                LockRec[LastActiveRectangle + 11] = true;
                       //         Field1[LastActiveRectangle + 11].Fill = Brushes.Gray;

                                LockRec[LastActiveRectangle + 21] = true;
                      //          Field1[LastActiveRectangle + 21].Fill = Brushes.Gray;

                               
                            }
                            //справа 
                            if (LastActiveRectangle == 70 || LastActiveRectangle == 71 || LastActiveRectangle == 72 || LastActiveRectangle == 73 || LastActiveRectangle == 74 || LastActiveRectangle == 75 || LastActiveRectangle == 76 || LastActiveRectangle == 77 || LastActiveRectangle == 78 || LastActiveRectangle == 79)
                            { }
                            else
                            {

                                LockRec[LastActiveRectangle + 30] = true;
                      //          Field1[LastActiveRectangle + 30].Fill = Brushes.Gray;

                            }



                            //_____________________________________________________________________________________________
                        }

                        //для Destroyer по вертикали
                        if (ifvertical[Lasttapedship] == true)
                        {
                            if ( LastActiveRectangle == 8 || LastActiveRectangle == 9  ||
                                LastActiveRectangle == 18 || LastActiveRectangle == 19 ||
                                LastActiveRectangle == 28 || LastActiveRectangle == 29 ||
                                LastActiveRectangle == 38 || LastActiveRectangle == 39 ||
                                LastActiveRectangle == 48 || LastActiveRectangle == 49 ||
                                LastActiveRectangle == 58 || LastActiveRectangle == 59 ||
                                LastActiveRectangle == 68 || LastActiveRectangle == 69 ||
                                LastActiveRectangle == 78 || LastActiveRectangle == 79 ||
                                LastActiveRectangle == 88 || LastActiveRectangle == 89 ||
                                LastActiveRectangle == 98 || LastActiveRectangle == 99)
                            {
                            }
                            else
                            {
                                Canvas.SetLeft(Ships[Lasttapedship], Canvas.GetLeft(Field1[LastActiveRectangle]) - 7);
                                Canvas.SetTop(Ships[Lasttapedship], Canvas.GetTop(Field1[LastActiveRectangle]) - 7);
                                Field1[LastActiveRectangle].Fill = Brushes.DarkBlue;
                                Field1[LastActiveRectangle + 1].Fill = Brushes.DarkBlue;
                                Field1[LastActiveRectangle + 2].Fill = Brushes.DarkBlue;

                           
                                GameRec[LastActiveRectangle] = true;

                            
                                GameRec[LastActiveRectangle + 1] = true;

                           
                                GameRec[LastActiveRectangle + 2] = true;

                            }

                            // клетки окружающие Destroyer по вертикали
                            //_____________________________________________________________________________________________
                            //сверху
                            if (LastActiveRectangle == 0 || LastActiveRectangle == 10 || LastActiveRectangle == 20 || LastActiveRectangle == 30 || LastActiveRectangle == 40 || LastActiveRectangle == 50 || LastActiveRectangle == 60 || LastActiveRectangle == 70 || LastActiveRectangle == 80 || LastActiveRectangle == 90)
                            { }
                            else
                            {
                                LockRec[LastActiveRectangle - 1] = true;
                     //           Field1[LastActiveRectangle - 1].Fill = Brushes.Gray;

                                //слева сверху
                                if (LastActiveRectangle == 0 || LastActiveRectangle == 1 || LastActiveRectangle == 2 || LastActiveRectangle == 3 || LastActiveRectangle == 4 || LastActiveRectangle == 5 || LastActiveRectangle == 6 || LastActiveRectangle == 7 || LastActiveRectangle == 8 || LastActiveRectangle == 9)
                                { }
                                else
                                {
                                    LockRec[LastActiveRectangle - 11] = true;
                       //             Field1[LastActiveRectangle - 11].Fill = Brushes.Gray;
                                }
                                //справа сверху
                                if (LastActiveRectangle == 90 || LastActiveRectangle == 91 || LastActiveRectangle == 92 || LastActiveRectangle == 93 || LastActiveRectangle == 94 || LastActiveRectangle == 95 || LastActiveRectangle == 96 || LastActiveRectangle == 97 || LastActiveRectangle == 98 || LastActiveRectangle == 99)
                                { }
                                else
                                {

                                    LockRec[LastActiveRectangle + 9] = true;
                      //              Field1[LastActiveRectangle + 9].Fill = Brushes.Gray;

                                }
                            }
                            //слева
                            if (LastActiveRectangle == 0 || LastActiveRectangle == 1 || LastActiveRectangle == 2 || LastActiveRectangle == 3 || LastActiveRectangle == 4 || LastActiveRectangle == 5 || LastActiveRectangle == 6 || LastActiveRectangle == 7 || LastActiveRectangle == 8 || LastActiveRectangle == 9)
                            {
                            }
                            else
                            {
                                LockRec[LastActiveRectangle - 10] = true;
                       //         Field1[LastActiveRectangle - 10].Fill = Brushes.Gray;

                                LockRec[LastActiveRectangle - 9] = true;
                      //          Field1[LastActiveRectangle - 9].Fill = Brushes.Gray;

                                LockRec[LastActiveRectangle - 8] = true;
                      //          Field1[LastActiveRectangle - 8].Fill = Brushes.Gray;

                            }
                            //снизу
                            if (LastActiveRectangle == 7 || LastActiveRectangle == 17 || LastActiveRectangle == 27 || LastActiveRectangle == 37 || LastActiveRectangle == 47 || LastActiveRectangle == 57 || LastActiveRectangle == 67 || LastActiveRectangle == 77 || LastActiveRectangle == 87 || LastActiveRectangle == 97)
                            { }
                            else
                            {
                                //слева снизу
                                if (LastActiveRectangle == 0 || LastActiveRectangle == 1 || LastActiveRectangle == 2 || LastActiveRectangle == 3 || LastActiveRectangle == 4 || LastActiveRectangle == 5 || LastActiveRectangle == 6 || LastActiveRectangle == 7 || LastActiveRectangle == 8 || LastActiveRectangle == 9)
                                {
                                }
                                else
                                {
                                    LockRec[LastActiveRectangle - 7] = true;
                       //             Field1[LastActiveRectangle - 7].Fill = Brushes.Gray;
                                }
                                //справа снизу
                                if (LastActiveRectangle == 90 || LastActiveRectangle == 91 || LastActiveRectangle == 92 || LastActiveRectangle == 93 || LastActiveRectangle == 94 || LastActiveRectangle == 95 || LastActiveRectangle == 96 || LastActiveRectangle == 97 || LastActiveRectangle == 98 || LastActiveRectangle == 99)
                                { }
                                else
                                {

                                    LockRec[LastActiveRectangle + 13] = true;
                      //              Field1[LastActiveRectangle + 13].Fill = Brushes.Gray;

                                }

                                LockRec[LastActiveRectangle + 3] = true;
                      //          Field1[LastActiveRectangle + 3].Fill = Brushes.Gray;


                            }
                            //справа 
                            if (LastActiveRectangle == 90 || LastActiveRectangle == 91 || LastActiveRectangle == 92 || LastActiveRectangle == 93 || LastActiveRectangle == 94 || LastActiveRectangle == 95 || LastActiveRectangle == 96 || LastActiveRectangle == 97 || LastActiveRectangle == 98 || LastActiveRectangle == 99)
                            { }
                            else
                            {

                                LockRec[LastActiveRectangle + 10] = true;
                     //           Field1[LastActiveRectangle + 10].Fill = Brushes.Gray;


                                LockRec[LastActiveRectangle + 11] = true;
                      //          Field1[LastActiveRectangle + 11].Fill = Brushes.Gray;

                                LockRec[LastActiveRectangle + 12] = true;
                     //           Field1[LastActiveRectangle + 12].Fill = Brushes.Gray;

                               
                            }

                            //_____________________________________________________________________________________________
                        }
                    }
                }
            }

            // Для Lodka
            if (ifMouseClicked[3] == false && ifMouseClicked[4] == false && ifMouseClicked[5] == false)
            {
                if (Lasttapedship >= 3 && Lasttapedship <= 5)
                {
                    if (LockRec[LastActiveRectangle] != true)
                        if ((ShipsLeft[Lasttapedship] + 10 >= Canvas.GetLeft(Field1[LastActiveRectangle]) && ShipsLeft[Lasttapedship] <= Canvas.GetLeft(Field1[LastActiveRectangle]) + Field1[LastActiveRectangle].Width) && ((ShipsTop[Lasttapedship] + 10 >= Canvas.GetTop(Field1[LastActiveRectangle])) && ShipsTop[Lasttapedship] + 8 <= Canvas.GetTop(Field1[LastActiveRectangle]) + Field1[LastActiveRectangle].Height))
                    {
                        //для Lodka по горизонтали
                        if (ifvertical[Lasttapedship] == false)
                        {
                            if ( LastActiveRectangle == 90 ||
                                 LastActiveRectangle == 91 ||
                                 LastActiveRectangle == 92 ||
                                 LastActiveRectangle == 93 ||
                                 LastActiveRectangle == 94 ||
                                 LastActiveRectangle == 95 ||
                                 LastActiveRectangle == 96 ||
                                 LastActiveRectangle == 97 ||
                                 LastActiveRectangle == 98 ||
                                 LastActiveRectangle == 99 )
                            {
                            }
                            else
                            {
                                Canvas.SetLeft(Ships[Lasttapedship], Canvas.GetLeft(Field1[LastActiveRectangle]) -5);
                                Canvas.SetTop(Ships[Lasttapedship], Canvas.GetTop(Field1[LastActiveRectangle]) - 3);
                                Field1[LastActiveRectangle].Fill = Brushes.DarkBlue;
                                Field1[LastActiveRectangle + 10].Fill = Brushes.DarkBlue;

                               
                                GameRec[LastActiveRectangle] = true;
                                
                                GameRec[LastActiveRectangle + 10] = true;

                                // клетки окружающие Lodka по горизонтали
                                //_____________________________________________________________________________________________
                                //сверху
                                if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 10 || SP[Lasttapedship] == 20 || SP[Lasttapedship] == 30 || SP[Lasttapedship] == 40 || SP[Lasttapedship] == 50 || SP[Lasttapedship] == 60 || SP[Lasttapedship] == 70 || SP[Lasttapedship] == 80 || SP[Lasttapedship] == 90)
                                { }
                                else
                                {
                                    LockRec[LastActiveRectangle - 1] = true;
                          //          Field1[LastActiveRectangle - 1].Fill = Brushes.Gray;

                                    LockRec[LastActiveRectangle + 9] = true;
                         //           Field1[LastActiveRectangle + 9].Fill = Brushes.Gray;


                                    //слева сверху
                                    if (LastActiveRectangle == 0 || LastActiveRectangle == 1 || LastActiveRectangle == 2 || LastActiveRectangle == 3 || LastActiveRectangle == 4 || LastActiveRectangle == 5 || LastActiveRectangle == 6 || LastActiveRectangle == 7 || LastActiveRectangle == 8 || LastActiveRectangle == 9)
                                    { }
                                    else
                                    {
                                        LockRec[LastActiveRectangle - 11] = true;
                          //              Field1[LastActiveRectangle - 11].Fill = Brushes.Gray;
                                    }
                                    //справа сверху
                                    if (LastActiveRectangle == 80 || LastActiveRectangle == 81 || LastActiveRectangle == 82 || LastActiveRectangle == 83 || LastActiveRectangle == 84 || LastActiveRectangle == 85 || LastActiveRectangle == 86 || LastActiveRectangle == 87 || LastActiveRectangle == 88 || LastActiveRectangle == 89)
                                    { }
                                    else
                                    {

                                        LockRec[LastActiveRectangle + 19] = true;
                         //               Field1[LastActiveRectangle + 19].Fill = Brushes.Gray;

                                    }
                                }
                                //слева
                                if (LastActiveRectangle == 0 || LastActiveRectangle == 1 || LastActiveRectangle == 2 || LastActiveRectangle == 3 || LastActiveRectangle == 4 || LastActiveRectangle == 5 || LastActiveRectangle == 6 || LastActiveRectangle == 7 || LastActiveRectangle == 8 || LastActiveRectangle == 9)
                                {
                                }
                                else
                                {
                                    LockRec[LastActiveRectangle - 10] = true;
                           //         Field1[LastActiveRectangle - 10].Fill = Brushes.Gray;
                                }
                                //снизу
                                if (LastActiveRectangle == 9 || LastActiveRectangle == 19 || LastActiveRectangle == 29 || LastActiveRectangle == 39 || LastActiveRectangle == 49 || LastActiveRectangle == 59 || LastActiveRectangle == 69 || LastActiveRectangle == 79 || LastActiveRectangle == 89 || LastActiveRectangle == 99)
                                { }
                                else
                                {
                                    //слева снизу
                                    if (LastActiveRectangle == 0 || LastActiveRectangle == 1 || LastActiveRectangle == 2 || LastActiveRectangle == 3 || LastActiveRectangle == 4 || LastActiveRectangle == 5 || LastActiveRectangle == 6 || LastActiveRectangle == 7 || LastActiveRectangle == 8 || LastActiveRectangle == 9)
                                    {
                                    }
                                    else
                                    {
                                        LockRec[LastActiveRectangle - 9] = true;
                          //              Field1[LastActiveRectangle - 9].Fill = Brushes.Gray;
                                    }
                                    //справа снизу
                                    if (LastActiveRectangle == 80 || LastActiveRectangle == 81 || LastActiveRectangle == 82 || LastActiveRectangle == 83 || LastActiveRectangle == 84 || LastActiveRectangle == 85 || LastActiveRectangle == 86 || LastActiveRectangle == 87 || LastActiveRectangle == 88 || LastActiveRectangle == 89)
                                    { }
                                    else
                                    {

                                        LockRec[LastActiveRectangle + 21] = true;
                          //              Field1[LastActiveRectangle + 21].Fill = Brushes.Gray;

                                    }

                                    LockRec[LastActiveRectangle + 1] = true;
                           //         Field1[LastActiveRectangle + 1].Fill = Brushes.Gray;

                                    LockRec[LastActiveRectangle + 11] = true;
                          //          Field1[LastActiveRectangle + 11].Fill = Brushes.Gray;

                                }
                                //справа 
                                if (LastActiveRectangle == 80 || LastActiveRectangle == 81 || LastActiveRectangle == 82 || LastActiveRectangle == 83 || LastActiveRectangle == 84 || LastActiveRectangle == 85 || LastActiveRectangle == 86 || LastActiveRectangle == 87 || LastActiveRectangle == 88 || LastActiveRectangle == 89)
                                { }
                                else
                                {

                                    LockRec[LastActiveRectangle + 20] = true;
                          //          Field1[LastActiveRectangle + 20].Fill = Brushes.Gray;

                                }

                                //_____________________________________________________________________________________________
                            }
                        }

                        //для Lodka по вертикали
                        if (ifvertical[Lasttapedship] == true)
                        {
                            if ( LastActiveRectangle == 9  ||
                                 LastActiveRectangle == 19 ||
                                 LastActiveRectangle == 29 ||
                                 LastActiveRectangle == 39 ||
                                 LastActiveRectangle == 49 ||
                                 LastActiveRectangle == 59 ||
                                 LastActiveRectangle == 69 ||
                                 LastActiveRectangle == 79 ||
                                 LastActiveRectangle == 89 ||
                                 LastActiveRectangle == 99 )
                            {
                            }
                            else
                            {
                                Canvas.SetLeft(Ships[Lasttapedship], Canvas.GetLeft(Field1[LastActiveRectangle]) - 3);
                                Canvas.SetTop(Ships[Lasttapedship], Canvas.GetTop(Field1[LastActiveRectangle]) - 7);
                                Field1[LastActiveRectangle].Fill = Brushes.DarkBlue;
                                Field1[LastActiveRectangle + 1].Fill = Brushes.DarkBlue;

                               
                                GameRec[LastActiveRectangle] = true;

                                
                                GameRec[LastActiveRectangle + 1] = true;
                            }

                            // клетки окружающие Lodka по вертикали
                            //_____________________________________________________________________________________________
                            //сверху
                            if (LastActiveRectangle == 0 || LastActiveRectangle == 10 || LastActiveRectangle == 20 || LastActiveRectangle == 30 || LastActiveRectangle == 40 || LastActiveRectangle == 50 || LastActiveRectangle == 60 || LastActiveRectangle == 70 || LastActiveRectangle == 80 || LastActiveRectangle == 90)
                            { }
                            else
                            {
                                LockRec[LastActiveRectangle - 1] = true;
                   //             Field1[LastActiveRectangle - 1].Fill = Brushes.Gray;

                                //слева сверху
                                if (LastActiveRectangle == 0 || LastActiveRectangle == 1 || LastActiveRectangle == 2 || LastActiveRectangle == 3 || LastActiveRectangle == 4 || LastActiveRectangle == 5 || LastActiveRectangle == 6 || LastActiveRectangle == 7 || LastActiveRectangle == 8 || LastActiveRectangle == 9)
                                { }
                                else
                                {
                                    LockRec[LastActiveRectangle - 11] = true;
                    //                Field1[LastActiveRectangle - 11].Fill = Brushes.Gray;
                                }
                                //справа сверху
                                if (LastActiveRectangle == 90 || LastActiveRectangle == 91 || LastActiveRectangle == 92 || LastActiveRectangle == 93 || LastActiveRectangle == 94 || LastActiveRectangle == 95 || LastActiveRectangle == 96 || LastActiveRectangle == 97 || LastActiveRectangle == 98 || LastActiveRectangle == 99)
                                { }
                                else
                                {

                                    LockRec[LastActiveRectangle + 9] = true;
                     //               Field1[LastActiveRectangle + 9].Fill = Brushes.Gray;

                                }
                            }
                            //слева
                            if (LastActiveRectangle == 0 || LastActiveRectangle == 1 || LastActiveRectangle == 2 || LastActiveRectangle == 3 || LastActiveRectangle == 4 || LastActiveRectangle == 5 || LastActiveRectangle == 6 || LastActiveRectangle == 7 || LastActiveRectangle == 8 || LastActiveRectangle == 9)
                            {
                            }
                            else
                            {
                                LockRec[LastActiveRectangle - 10] = true;
                   //             Field1[LastActiveRectangle - 10].Fill = Brushes.Gray;

                                LockRec[LastActiveRectangle - 9] = true;
                    //            Field1[LastActiveRectangle - 9].Fill = Brushes.Gray;


                            }
                            //снизу
                            if (LastActiveRectangle == 8 || LastActiveRectangle == 18 || LastActiveRectangle == 28 || LastActiveRectangle == 38 || LastActiveRectangle == 48 || LastActiveRectangle == 58 || LastActiveRectangle == 68 || LastActiveRectangle == 78 || LastActiveRectangle == 88 || LastActiveRectangle == 98)
                            { }
                            else
                            {
                                //слева снизу
                                if (LastActiveRectangle == 0 || LastActiveRectangle == 1 || LastActiveRectangle == 2 || LastActiveRectangle == 3 || LastActiveRectangle == 4 || LastActiveRectangle == 5 || LastActiveRectangle == 6 || LastActiveRectangle == 7 || LastActiveRectangle == 8 || LastActiveRectangle == 9)
                                {
                                }
                                else
                                {
                                    LockRec[LastActiveRectangle - 8] = true;
                   //                 Field1[LastActiveRectangle - 8].Fill = Brushes.Gray;
                                }
                                //справа снизу
                                if (LastActiveRectangle == 90 || LastActiveRectangle == 91 || LastActiveRectangle == 92 || LastActiveRectangle == 93 || LastActiveRectangle == 94 || LastActiveRectangle == 95 || LastActiveRectangle == 96 || LastActiveRectangle == 97 || LastActiveRectangle == 98 || LastActiveRectangle == 99)
                                { }
                                else
                                {

                                    LockRec[LastActiveRectangle + 12] = true;
                   //                 Field1[LastActiveRectangle + 12].Fill = Brushes.Gray;

                                }

                                LockRec[LastActiveRectangle + 2] = true;
                      //          Field1[LastActiveRectangle + 2].Fill = Brushes.Gray;


                            }
                            //справа 
                            if (LastActiveRectangle == 90 || LastActiveRectangle == 91 || LastActiveRectangle == 92 || LastActiveRectangle == 93 || LastActiveRectangle == 94 || LastActiveRectangle == 95 || LastActiveRectangle == 96 || LastActiveRectangle == 97 || LastActiveRectangle == 98 || LastActiveRectangle == 99)
                            { }
                            else
                            {

                                LockRec[LastActiveRectangle + 10] = true;
                      //          Field1[LastActiveRectangle + 10].Fill = Brushes.Gray;


                                LockRec[LastActiveRectangle + 11] = true;
                   //             Field1[LastActiveRectangle + 11].Fill = Brushes.Gray;


                            }

                            //_____________________________________________________________________________________________

                        }
                        }
                }
            }

            // Для Mini
            if (ifMouseClicked[6] == false && ifMouseClicked[7] == false && ifMouseClicked[8] == false && ifMouseClicked[9] == false)
            {
                if (Lasttapedship >= 6 && Lasttapedship <= 9)
                    if (LockRec[LastActiveRectangle] != true)
                    {
                    if ((ShipsLeft[Lasttapedship] + 10 >= Canvas.GetLeft(Field1[LastActiveRectangle]) && ShipsLeft[Lasttapedship] <= Canvas.GetLeft(Field1[LastActiveRectangle]) + Field1[LastActiveRectangle].Width) && ((ShipsTop[Lasttapedship] + 10 >= Canvas.GetTop(Field1[LastActiveRectangle])) && ShipsTop[Lasttapedship] + 8 <= Canvas.GetTop(Field1[LastActiveRectangle]) + Field1[LastActiveRectangle].Height))
                    {
                        //для Mini по горизонтали
                        if (ifvertical[Lasttapedship] == false)
                        {
                            
                            
                                Canvas.SetLeft(Ships[Lasttapedship], Canvas.GetLeft(Field1[LastActiveRectangle]) - 3);
                                Canvas.SetTop(Ships[Lasttapedship], Canvas.GetTop(Field1[LastActiveRectangle]) - 3);
                                Field1[LastActiveRectangle].Fill = Brushes.DarkBlue;
                                GameRec[LastActiveRectangle] = true;

                                // клетки окружающие Mini по горизонтали
                                //_____________________________________________________________________________________________
                                //сверху
                                if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 10 || SP[Lasttapedship] == 20 || SP[Lasttapedship] == 30 || SP[Lasttapedship] == 40 || SP[Lasttapedship] == 50 || SP[Lasttapedship] == 60 || SP[Lasttapedship] == 70 || SP[Lasttapedship] == 80 || SP[Lasttapedship] == 90)
                                { }
                                else
                                {
                                    LockRec[LastActiveRectangle - 1] = true;
                    //                Field1[LastActiveRectangle - 1].Fill = Brushes.Gray;


                                    //слева сверху
                                    if (LastActiveRectangle == 0 || LastActiveRectangle == 1 || LastActiveRectangle == 2 || LastActiveRectangle == 3 || LastActiveRectangle == 4 || LastActiveRectangle == 5 || LastActiveRectangle == 6 || LastActiveRectangle == 7 || LastActiveRectangle == 8 || LastActiveRectangle == 9)
                                    { }
                                    else
                                    {
                                        LockRec[LastActiveRectangle - 11] = true;
                     //                   Field1[LastActiveRectangle - 11].Fill = Brushes.Gray;
                                    }
                                    //справа сверху
                                    if (LastActiveRectangle == 90 || LastActiveRectangle == 91 || LastActiveRectangle == 92 || LastActiveRectangle == 93 || LastActiveRectangle == 94 || LastActiveRectangle == 95 || LastActiveRectangle == 96 || LastActiveRectangle == 97 || LastActiveRectangle == 98 || LastActiveRectangle == 99)
                                    { }
                                    else
                                    {

                                        LockRec[LastActiveRectangle + 9] = true;
                       //                 Field1[LastActiveRectangle + 9].Fill = Brushes.Gray;

                                    }
                                }
                                //слева
                                if (LastActiveRectangle == 0 || LastActiveRectangle == 1 || LastActiveRectangle == 2 || LastActiveRectangle == 3 || LastActiveRectangle == 4 || LastActiveRectangle == 5 || LastActiveRectangle == 6 || LastActiveRectangle == 7 || LastActiveRectangle == 8 || LastActiveRectangle == 9)
                                {
                                }
                                else
                                {
                                    LockRec[LastActiveRectangle - 10] = true;
                      //              Field1[LastActiveRectangle - 10].Fill = Brushes.Gray;
                                }
                                //снизу
                                if (LastActiveRectangle == 9 || LastActiveRectangle == 19 || LastActiveRectangle == 29 || LastActiveRectangle == 39 || LastActiveRectangle == 49 || LastActiveRectangle == 59 || LastActiveRectangle == 69 || LastActiveRectangle == 79 || LastActiveRectangle == 89 || LastActiveRectangle == 99)
                                { }
                                else
                                {
                                    //слева снизу
                                    if (LastActiveRectangle == 0 || LastActiveRectangle == 1 || LastActiveRectangle == 2 || LastActiveRectangle == 3 || LastActiveRectangle == 4 || LastActiveRectangle == 5 || LastActiveRectangle == 6 || LastActiveRectangle == 7 || LastActiveRectangle == 8 || LastActiveRectangle == 9)
                                    {
                                    }
                                    else
                                    {
                                        LockRec[LastActiveRectangle - 9] = true;
                          //              Field1[LastActiveRectangle - 9].Fill = Brushes.Gray;
                                    }
                                    //справа снизу
                                    if (LastActiveRectangle == 90 || LastActiveRectangle == 91 || LastActiveRectangle == 92 || LastActiveRectangle == 93 || LastActiveRectangle == 94 || LastActiveRectangle == 95 || LastActiveRectangle == 96 || LastActiveRectangle == 97 || LastActiveRectangle == 98 || LastActiveRectangle == 99)
                                    { }
                                    else
                                    {

                                        LockRec[LastActiveRectangle + 11] = true;
                         //               Field1[LastActiveRectangle + 11].Fill = Brushes.Gray;

                                    }

                                    LockRec[LastActiveRectangle + 1] = true;
                         //           Field1[LastActiveRectangle + 1].Fill = Brushes.Gray;

                                    

                                }
                                //справа 
                                if (LastActiveRectangle == 90 || LastActiveRectangle == 91 || LastActiveRectangle == 92 || LastActiveRectangle == 93 || LastActiveRectangle == 94 || LastActiveRectangle == 95 || LastActiveRectangle == 96 || LastActiveRectangle == 97 || LastActiveRectangle == 98 || LastActiveRectangle == 99)
                                { }
                                else
                                {

                                    LockRec[LastActiveRectangle + 10] = true;
                         //           Field1[LastActiveRectangle + 10].Fill = Brushes.Gray;

                                }

                                //_____________________________________________________________________________________________
                            }

                            //для Mini по вертикали
                            if (ifvertical[Lasttapedship] == true)
                        {
                           
                                Canvas.SetLeft(Ships[Lasttapedship], Canvas.GetLeft(Field1[LastActiveRectangle]) - 3);
                                Canvas.SetTop(Ships[Lasttapedship], Canvas.GetTop(Field1[LastActiveRectangle]) - 5);
                                Field1[LastActiveRectangle].Fill = Brushes.DarkBlue;

                            GameRec[LastActiveRectangle] = true;

                                // клетки окружающие mini по вертикали
                                //_____________________________________________________________________________________________
                                //сверху
                                if (LastActiveRectangle == 0 || LastActiveRectangle == 10 || LastActiveRectangle == 20 || LastActiveRectangle == 30 || LastActiveRectangle == 40 || LastActiveRectangle == 50 || LastActiveRectangle == 60 || LastActiveRectangle == 70 || LastActiveRectangle == 80 || LastActiveRectangle == 90)
                                { }
                                else
                                {
                                    LockRec[LastActiveRectangle - 1] = true;
                        //            Field1[LastActiveRectangle - 1].Fill = Brushes.Gray;

                                    //слева сверху
                                    if (LastActiveRectangle == 0 || LastActiveRectangle == 1 || LastActiveRectangle == 2 || LastActiveRectangle == 3 || LastActiveRectangle == 4 || LastActiveRectangle == 5 || LastActiveRectangle == 6 || LastActiveRectangle == 7 || LastActiveRectangle == 8 || LastActiveRectangle == 9)
                                    { }
                                    else
                                    {
                                        LockRec[LastActiveRectangle - 11] = true;
                        //                Field1[LastActiveRectangle - 11].Fill = Brushes.Gray;
                                    }
                                    //справа сверху
                                    if (LastActiveRectangle == 90 || LastActiveRectangle == 91 || LastActiveRectangle == 92 || LastActiveRectangle == 93 || LastActiveRectangle == 94 || LastActiveRectangle == 95 || LastActiveRectangle == 96 || LastActiveRectangle == 97 || LastActiveRectangle == 98 || LastActiveRectangle == 99)
                                    { }
                                    else
                                    {

                                        LockRec[LastActiveRectangle + 9] = true;
                      //                  Field1[LastActiveRectangle + 9].Fill = Brushes.Gray;

                                    }
                                }
                                //слева
                                if (LastActiveRectangle == 0 || LastActiveRectangle == 1 || LastActiveRectangle == 2 || LastActiveRectangle == 3 || LastActiveRectangle == 4 || LastActiveRectangle == 5 || LastActiveRectangle == 6 || LastActiveRectangle == 7 || LastActiveRectangle == 8 || LastActiveRectangle == 9)
                                {
                                }
                                else
                                {
                                    LockRec[LastActiveRectangle - 10] = true;
                       //             Field1[LastActiveRectangle - 10].Fill = Brushes.Gray;


                                }
                                //снизу
                                if (LastActiveRectangle == 9 || LastActiveRectangle == 19 || LastActiveRectangle == 29 || LastActiveRectangle == 39 || LastActiveRectangle == 49 || LastActiveRectangle == 59 || LastActiveRectangle == 69 || LastActiveRectangle == 79 || LastActiveRectangle == 89 || LastActiveRectangle == 99)
                                { }
                                else
                                {
                                    //слева снизу
                                    if (LastActiveRectangle == 0 || LastActiveRectangle == 1 || LastActiveRectangle == 2 || LastActiveRectangle == 3 || LastActiveRectangle == 4 || LastActiveRectangle == 5 || LastActiveRectangle == 6 || LastActiveRectangle == 7 || LastActiveRectangle == 8 || LastActiveRectangle == 9)
                                    {
                                    }
                                    else
                                    {
                                        LockRec[LastActiveRectangle - 9] = true;
                         //               Field1[LastActiveRectangle - 9].Fill = Brushes.Gray;
                                    }
                                    //справа снизу
                                    if (LastActiveRectangle == 90 || LastActiveRectangle == 91 || LastActiveRectangle == 92 || LastActiveRectangle == 93 || LastActiveRectangle == 94 || LastActiveRectangle == 95 || LastActiveRectangle == 96 || LastActiveRectangle == 97 || LastActiveRectangle == 98 || LastActiveRectangle == 99)
                                    { }
                                    else
                                    {

                                        LockRec[LastActiveRectangle + 11] = true;
                      //                  Field1[LastActiveRectangle + 11].Fill = Brushes.Gray;

                                    }

                                    LockRec[LastActiveRectangle + 1] = true;
                        //            Field1[LastActiveRectangle + 1].Fill = Brushes.Gray;


                                }
                                //справа 
                                if (LastActiveRectangle == 90 || LastActiveRectangle == 91 || LastActiveRectangle == 92 || LastActiveRectangle == 93 || LastActiveRectangle == 94 || LastActiveRectangle == 95 || LastActiveRectangle == 96 || LastActiveRectangle == 97 || LastActiveRectangle == 98 || LastActiveRectangle == 99)
                                { }
                                else
                                {

                                    LockRec[LastActiveRectangle + 10] = true;
                          //          Field1[LastActiveRectangle + 10].Fill = Brushes.Gray;

                                }

                                //_____________________________________________________________________________________________
                            }

                        }
                }
            }

            for (int i=0; i< 10; i++)
            {
                Ships[i].IsHitTestVisible = true;
            }
            //счетчик количества клеток на которых стоят корабли
            a = 0;
            for (int i = 0; i < 100; i++)
            {
                if (GameRec[i] == true)
                {
                    a++;
                }
            }
            Number1.Content = a;

            //счетчик количества клеток на которых стоят корабли
            a1 = 0;
            for (int i = 0; i < 100; i++)
            {
                if (GameRec2[i] == true)
                {
                    a1++;
                }
            }
            Number2.Content = a1;

            if (Convert.ToUInt32(Number1.Content) == 20 && ifGameStarted == false)
            {
                StartButton.Visibility = Visibility.Visible;
            }
            else
            {
                StartButton.Visibility = Visibility.Hidden;
            }
        }

        


        ///<summary> 
        ///                                 Вертикальное | горизонтальное положение кораблей
        ///</summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SP[Lasttapedship] != -1)
                {
                    //Вертикальное
                    if (returnverticalposition == false)
                    {

                        if (Lasttapedship == 0)
                        {
                                if (SP[Lasttapedship] == 7 || SP[Lasttapedship] == 8 || SP[Lasttapedship] == 9 ||
                                SP[Lasttapedship] == 17 || SP[Lasttapedship] == 18 || SP[Lasttapedship] == 19 ||
                                SP[Lasttapedship] == 27 || SP[Lasttapedship] == 28 || SP[Lasttapedship] == 29 ||
                                SP[Lasttapedship] == 37 || SP[Lasttapedship] == 38 || SP[Lasttapedship] == 39 ||
                                SP[Lasttapedship] == 47 || SP[Lasttapedship] == 48 || SP[Lasttapedship] == 49 ||
                                SP[Lasttapedship] == 57 || SP[Lasttapedship] == 58 || SP[Lasttapedship] == 59 ||
                                SP[Lasttapedship] == 67 || SP[Lasttapedship] == 68 || SP[Lasttapedship] == 69 ||
                                SP[Lasttapedship] == 77 || SP[Lasttapedship] == 78 || SP[Lasttapedship] == 79 ||
                                SP[Lasttapedship] == 87 || SP[Lasttapedship] == 88 || SP[Lasttapedship] == 89 ||
                                SP[Lasttapedship] == 97 || SP[Lasttapedship] == 98 || SP[Lasttapedship] == 99)
                            { }
                            else 
                            {

                                Ships[Lasttapedship].Height = 140;
                                Ships[Lasttapedship].Width = 33;
                                Ships[Lasttapedship].Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Авианосец_00002.png"));
                                ifvertical[Lasttapedship] = true;

                                //Очистка поля для авиа по вертикали
                                {

                                    Canvas.SetLeft(Ships[Lasttapedship], Canvas.GetLeft(Field1[SP[Lasttapedship]]));
                                    Canvas.SetTop(Ships[Lasttapedship], Canvas.GetTop(Field1[SP[Lasttapedship]]) - 7);

                                    { Field1[SP[Lasttapedship] + 10].Fill = Brushes.Azure; }
                                    { Field1[SP[Lasttapedship] + 20].Fill = Brushes.Azure; }
                                    { Field1[SP[Lasttapedship] + 30].Fill = Brushes.Azure; }

                                   
                                    GameRec[SP[Lasttapedship] + 10] = false;

                                  
                                    GameRec[SP[Lasttapedship] + 20] = false;

                                 
                                    GameRec[SP[Lasttapedship] + 30] = false;

                                    Field1[SP[Lasttapedship]].Fill = Brushes.DarkBlue;
                                    Field1[SP[Lasttapedship] + 1].Fill = Brushes.DarkBlue;
                                    Field1[SP[Lasttapedship] + 2].Fill = Brushes.DarkBlue;
                                    Field1[SP[Lasttapedship] + 3].Fill = Brushes.DarkBlue;

                                  
                                    GameRec[SP[Lasttapedship] + 1] = true;

                                 
                                    GameRec[SP[Lasttapedship] + 2] = true;

                                   
                                    GameRec[SP[Lasttapedship] + 3] = true;

                                }
                            }

                           

                            //очистка клеток по горизонтали
                            //_____________________________________________________________________________________________
                            //сверху
                            if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 10 || SP[Lasttapedship] == 20 || SP[Lasttapedship] == 30 || SP[Lasttapedship] == 40 || SP[Lasttapedship] == 50 || SP[Lasttapedship] == 60 || SP[Lasttapedship] == 70 || SP[Lasttapedship] == 80 || SP[Lasttapedship] == 90)
                            { }
                            else
                            {
                                LockRec[SP[Lasttapedship] - 1] = false;
                     //           Field1[SP[Lasttapedship] - 1].Fill = Brushes.Azure;

                                LockRec[SP[Lasttapedship] + 9] = false;
                     //           Field1[SP[Lasttapedship] + 9].Fill = Brushes.Azure;

                                LockRec[SP[Lasttapedship] + 19] = false;
                     //           Field1[SP[Lasttapedship] + 19].Fill = Brushes.Azure;

                                LockRec[SP[Lasttapedship] + 29] = false;
                     //           Field1[SP[Lasttapedship] + 29].Fill = Brushes.Azure;

                                //слева сверху
                                if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 1 || SP[Lasttapedship] == 2 || SP[Lasttapedship] == 3 || SP[Lasttapedship] == 4 || SP[Lasttapedship] == 5 || SP[Lasttapedship] == 6 || SP[Lasttapedship] == 7 || SP[Lasttapedship] == 8 || SP[Lasttapedship] == 9)
                                { }
                                else
                                {
                                    LockRec[SP[Lasttapedship] - 11] = false;
                      //              Field1[SP[Lasttapedship] - 11].Fill = Brushes.Azure;
                                }
                                //справа сверху
                                if (SP[Lasttapedship] == 60 || SP[Lasttapedship] == 61 || SP[Lasttapedship] == 62 || SP[Lasttapedship] == 63 || SP[Lasttapedship] == 64 || SP[Lasttapedship] == 65 || SP[Lasttapedship] == 66 || SP[Lasttapedship] == 67 || SP[Lasttapedship] == 68 || SP[Lasttapedship] == 69)
                                { }
                                else
                                {

                                    LockRec[SP[Lasttapedship] + 39] = false;
                    //                Field1[SP[Lasttapedship] + 39].Fill = Brushes.Azure;

                                }
                            }
                            //слева
                            if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 1 || SP[Lasttapedship] == 2 || SP[Lasttapedship] == 3 || SP[Lasttapedship] == 4 || SP[Lasttapedship] == 5 || SP[Lasttapedship] == 6 || SP[Lasttapedship] == 7 || SP[Lasttapedship] == 8 || SP[Lasttapedship] == 9)
                            {
                            }
                            else
                            {
                                LockRec[SP[Lasttapedship] - 10] = false;
                      //          Field1[SP[Lasttapedship] - 10].Fill = Brushes.Azure;
                            }
                            //снизу
                            if (SP[Lasttapedship] == 9 || SP[Lasttapedship] == 19 || SP[Lasttapedship] == 29 || SP[Lasttapedship] == 39 || SP[Lasttapedship] == 49 || SP[Lasttapedship] == 59 || SP[Lasttapedship] == 69 || SP[Lasttapedship] == 79 || SP[Lasttapedship] == 89 || SP[Lasttapedship] == 99)
                            { }
                            else
                            {
                                //слева снизу
                                if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 1 || SP[Lasttapedship] == 2 || SP[Lasttapedship] == 3 || SP[Lasttapedship] == 4 || SP[Lasttapedship] == 5 || SP[Lasttapedship] == 6 || SP[Lasttapedship] == 7 || SP[Lasttapedship] == 8 || SP[Lasttapedship] == 9)
                                {
                                }
                                else
                                {
                                    LockRec[SP[Lasttapedship] - 9] = false;
                      //              Field1[SP[Lasttapedship] - 9].Fill = Brushes.Azure;
                                }
                                //справа снизу
                                if (SP[Lasttapedship] == 60 || SP[Lasttapedship] == 61 || SP[Lasttapedship] == 62 || SP[Lasttapedship] == 63 || SP[Lasttapedship] == 64 || SP[Lasttapedship] == 65 || SP[Lasttapedship] == 66 || SP[Lasttapedship] == 67 || SP[Lasttapedship] == 68 || SP[Lasttapedship] == 69)
                                { }
                                else
                                {

                                    LockRec[SP[Lasttapedship] + 41] = false;
                    //                Field1[SP[Lasttapedship] + 41].Fill = Brushes.Azure;

                                }

                                LockRec[SP[Lasttapedship] + 1] = false;
                     //           Field1[SP[Lasttapedship] + 1].Fill = Brushes.Azure;

                                LockRec[SP[Lasttapedship] + 11] = false;
                      //          Field1[SP[Lasttapedship] + 11].Fill = Brushes.Azure;

                                LockRec[SP[Lasttapedship] + 21] = false;
                      //          Field1[SP[Lasttapedship] + 21].Fill = Brushes.Azure;

                                LockRec[SP[Lasttapedship] + 31] = false;
                     //           Field1[SP[Lasttapedship] + 31].Fill = Brushes.Azure;
                            }
                            //справа 
                            if (SP[Lasttapedship] == 60 || SP[Lasttapedship] == 61 || SP[Lasttapedship] == 62 || SP[Lasttapedship] == 63 || SP[Lasttapedship] == 64 || SP[Lasttapedship] == 65 || SP[Lasttapedship] == 66 || SP[Lasttapedship] == 67 || SP[Lasttapedship] == 68 || SP[Lasttapedship] == 69)
                            { }
                            else
                            {

                                LockRec[SP[Lasttapedship] + 40] = false;
                     //           Field1[SP[Lasttapedship] + 40].Fill = Brushes.Azure;

                            }

                            //_____________________________________________________________________________________________

                        }

                        if (Lasttapedship >= 1 && Lasttapedship <= 2)
                        {
                            if ( SP[Lasttapedship] == 8  || SP[Lasttapedship] == 9  ||
                                 SP[Lasttapedship] == 18 || SP[Lasttapedship] == 19 ||
                                 SP[Lasttapedship] == 28 || SP[Lasttapedship] == 29 ||
                                 SP[Lasttapedship] == 38 || SP[Lasttapedship] == 39 ||
                                 SP[Lasttapedship] == 48 || SP[Lasttapedship] == 49 ||
                                 SP[Lasttapedship] == 58 || SP[Lasttapedship] == 59 ||
                                 SP[Lasttapedship] == 68 || SP[Lasttapedship] == 69 ||
                                 SP[Lasttapedship] == 78 || SP[Lasttapedship] == 79 ||
                                 SP[Lasttapedship] == 88 || SP[Lasttapedship] == 89 ||
                                 SP[Lasttapedship] == 98 || SP[Lasttapedship] == 99)
                            {
                            }
                            else
                            {

                                Ships[Lasttapedship].Height = 100;
                                Ships[Lasttapedship].Width = 43;
                                Ships[Lasttapedship].Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Эсминец_00002.png"));
                                ifvertical[Lasttapedship] = true;

                                //Очистка поля для Destroyer по вертикали
                                {
                                    Canvas.SetLeft(Ships[Lasttapedship], Canvas.GetLeft(Field1[SP[Lasttapedship]]));
                                    Canvas.SetTop(Ships[Lasttapedship], Canvas.GetTop(Field1[SP[Lasttapedship]]) - 5);

                                    { Field1[SP[Lasttapedship] + 10].Fill = Brushes.Azure; }
                                    { Field1[SP[Lasttapedship] + 20].Fill = Brushes.Azure; }
                                   
                                    GameRec[SP[Lasttapedship] + 10] = false;

                                    GameRec[SP[Lasttapedship] + 20] = false;

                                    Field1[SP[Lasttapedship]].Fill = Brushes.DarkBlue;
                                    Field1[SP[Lasttapedship] + 1].Fill = Brushes.DarkBlue;
                                    Field1[SP[Lasttapedship] + 2].Fill = Brushes.DarkBlue;    
                                   
                                    GameRec[SP[Lasttapedship] + 1] = true;

                                    GameRec[SP[Lasttapedship] + 2] = true;

                                    // очистка клеткок окружающих Destroyer по горизонтали
                                    //_____________________________________________________________________________________________
                                    //сверху
                                    if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 10 || SP[Lasttapedship] == 20 || SP[Lasttapedship] == 30 || SP[Lasttapedship] == 40 || SP[Lasttapedship] == 50 || SP[Lasttapedship] == 60 || SP[Lasttapedship] == 70 || SP[Lasttapedship] == 80 || SP[Lasttapedship] == 90)
                                    { }
                                    else
                                    {
                                        LockRec[SP[Lasttapedship] - 1] = false;
                        //                Field1[SP[Lasttapedship] - 1].Fill = Brushes.Azure;

                                        LockRec[SP[Lasttapedship] + 9] = false;
                        //                Field1[SP[Lasttapedship] + 9].Fill = Brushes.Azure;
                    
                                        LockRec[SP[Lasttapedship] + 19] = false;
                         //               Field1[SP[Lasttapedship] + 19].Fill = Brushes.Azure;


                                        //слева сверху
                                        if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 1 || SP[Lasttapedship] == 2 || SP[Lasttapedship] == 3 || SP[Lasttapedship] == 4 || SP[Lasttapedship] == 5 || SP[Lasttapedship] == 6 || SP[Lasttapedship] == 7 || SP[Lasttapedship] == 8 || SP[Lasttapedship] == 9)
                                        { }
                                        else
                                        {
                                            LockRec[SP[Lasttapedship] - 11] = false;
                         //                   Field1[SP[Lasttapedship] - 11].Fill = Brushes.Azure;
                                        }
                                        //справа сверху
                                        if (SP[Lasttapedship] == 70 || SP[Lasttapedship] == 71 || SP[Lasttapedship] == 72 || SP[Lasttapedship] == 73 || SP[Lasttapedship] == 74 || SP[Lasttapedship] == 75 || SP[Lasttapedship] == 76 || SP[Lasttapedship] == 77 || SP[Lasttapedship] == 78 || SP[Lasttapedship] == 79)
                                        { }
                                        else
                                        {

                                            LockRec[SP[Lasttapedship] + 29] = false;
                         //                   Field1[SP[Lasttapedship] + 29].Fill = Brushes.Azure;

                                        }
                                    }
                                    //слева
                                    if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 1 || SP[Lasttapedship] == 2 || SP[Lasttapedship] == 3 || SP[Lasttapedship] == 4 || SP[Lasttapedship] == 5 || SP[Lasttapedship] == 6 || SP[Lasttapedship] == 7 || SP[Lasttapedship] == 8 || SP[Lasttapedship] == 9)
                                    {
                                    }
                                    else
                                    {
                                        LockRec[SP[Lasttapedship] - 10] = false;
                        //                Field1[SP[Lasttapedship] - 10].Fill = Brushes.Azure;
                                    }
                                    //снизу
                                    if (SP[Lasttapedship] == 9 || SP[Lasttapedship] == 19 || SP[Lasttapedship] == 29 || SP[Lasttapedship] == 39 || SP[Lasttapedship] == 49 || SP[Lasttapedship] == 59 || SP[Lasttapedship] == 69 || SP[Lasttapedship] == 79 || SP[Lasttapedship] == 89 || SP[Lasttapedship] == 99)
                                    { }
                                    else
                                    {
                                        //слева снизу
                                        if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 1 || SP[Lasttapedship] == 2 || SP[Lasttapedship] == 3 || SP[Lasttapedship] == 4 || SP[Lasttapedship] == 5 || SP[Lasttapedship] == 6 || SP[Lasttapedship] == 7 || SP[Lasttapedship] == 8 || SP[Lasttapedship] == 9)
                                        {
                                        }
                                        else
                                        {
                                            LockRec[SP[Lasttapedship] - 9] = false;
                         //                   Field1[SP[Lasttapedship] - 9].Fill = Brushes.Azure;
                                        }
                                        //справа снизу
                                        if (SP[Lasttapedship] == 70 || SP[Lasttapedship] == 71 || SP[Lasttapedship] == 72 || SP[Lasttapedship] == 73 || SP[Lasttapedship] == 74 || SP[Lasttapedship] == 75 || SP[Lasttapedship] == 76 || SP[Lasttapedship] == 77 || SP[Lasttapedship] == 78 || SP[Lasttapedship] == 79)
                                        { }
                                        else
                                        {

                                            LockRec[SP[Lasttapedship] + 31] = false;
                          //                  Field1[SP[Lasttapedship] + 31].Fill = Brushes.Azure;

                                        }

                                        LockRec[SP[Lasttapedship] + 1] = false;
                           //             Field1[SP[Lasttapedship] + 1].Fill = Brushes.Azure;

                                        LockRec[SP[Lasttapedship] + 11] = false;
                         //               Field1[SP[Lasttapedship] + 11].Fill = Brushes.Azure;

                                        LockRec[SP[Lasttapedship] + 21] = false;
                          //              Field1[SP[Lasttapedship] + 21].Fill = Brushes.Azure;


                                    }
                                    //справа 
                                    if (SP[Lasttapedship] == 70 || SP[Lasttapedship] == 71 || SP[Lasttapedship] == 72 || SP[Lasttapedship] == 73 || SP[Lasttapedship] == 74 || SP[Lasttapedship] == 75 || SP[Lasttapedship] == 76 || SP[Lasttapedship] == 77 || SP[Lasttapedship] == 78 || SP[Lasttapedship] == 79)
                                    { }
                                    else
                                    {

                                        LockRec[SP[Lasttapedship] + 30] = false;
                            //            Field1[SP[Lasttapedship] + 30].Fill = Brushes.Azure;

                                    }



                                    //_____________________________________________________________________________________________
                                }
                            }
                        }

                        if (Lasttapedship >= 3 && Lasttapedship <= 5)
                        {
                            if (SP[Lasttapedship] == 9  ||
                                 SP[Lasttapedship] == 19 ||
                                 SP[Lasttapedship] == 29 ||
                                 SP[Lasttapedship] == 39 ||
                                 SP[Lasttapedship] == 49 ||
                                 SP[Lasttapedship] == 59 ||
                                 SP[Lasttapedship] == 69 ||
                                 SP[Lasttapedship] == 79 ||
                                 SP[Lasttapedship] == 89 ||
                                 SP[Lasttapedship] == 99 )
                            {
                            }
                            else
                            {

                                Ships[Lasttapedship].Height = 75;
                                Ships[Lasttapedship].Width = 30;
                                Ships[Lasttapedship].Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Корабль_00002.png"));
                                ifvertical[Lasttapedship] = true;

                                //Очистка поля для Lodka по вертикали
                                {
                                    Canvas.SetLeft(Ships[Lasttapedship], Canvas.GetLeft(Field1[SP[Lasttapedship]]) - 5);
                                    Canvas.SetTop(Ships[Lasttapedship], Canvas.GetTop(Field1[SP[Lasttapedship]]) - 3);

                                    { Field1[SP[Lasttapedship] + 10].Fill = Brushes.Azure; }

                                    
                                    GameRec[SP[Lasttapedship] + 10] = false;

                                    Field1[SP[Lasttapedship]].Fill = Brushes.DarkBlue;
                                    Field1[SP[Lasttapedship] + 1].Fill = Brushes.DarkBlue;

                                   
                                    GameRec[SP[Lasttapedship] + 1] = true;

                                }

                                // очистка клетки окружающие Lodka по горизонтали
                                //_____________________________________________________________________________________________
                                //сверху
                                if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 10 || SP[Lasttapedship] == 20 || SP[Lasttapedship] == 30 || SP[Lasttapedship] == 40 || SP[Lasttapedship] == 50 || SP[Lasttapedship] == 60 || SP[Lasttapedship] == 70 || SP[Lasttapedship] == 80 || SP[Lasttapedship] == 90)
                                { }
                                else
                                {
                                    LockRec[SP[Lasttapedship] - 1] = false;
                     //               Field1[SP[Lasttapedship] - 1].Fill = Brushes.Azure;

                                    LockRec[SP[Lasttapedship] + 9] = false;
                      //              Field1[SP[Lasttapedship] + 9].Fill = Brushes.Azure;


                                    //слева сверху
                                    if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 1 || SP[Lasttapedship] == 2 || SP[Lasttapedship] == 3 || SP[Lasttapedship] == 4 || SP[Lasttapedship] == 5 || SP[Lasttapedship] == 6 || SP[Lasttapedship] == 7 || SP[Lasttapedship] == 8 || SP[Lasttapedship] == 9)
                                    { }
                                    else
                                    {
                                        LockRec[SP[Lasttapedship] - 11] = false;
                      //                  Field1[SP[Lasttapedship] - 11].Fill = Brushes.Azure;
                                    }
                                    //справа сверху
                                    if (SP[Lasttapedship] == 80 || SP[Lasttapedship] == 81 || SP[Lasttapedship] == 82 || SP[Lasttapedship] == 83 || SP[Lasttapedship] == 84 || SP[Lasttapedship] == 85 || SP[Lasttapedship] == 86 || SP[Lasttapedship] == 87 || SP[Lasttapedship] == 88 || SP[Lasttapedship] == 89)
                                    { }
                                    else
                                    {

                                        LockRec[SP[Lasttapedship] + 19] = false;
                     //                   Field1[SP[Lasttapedship] + 19].Fill = Brushes.Azure;

                                    }
                                }
                                //слева
                                if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 1 || SP[Lasttapedship] == 2 || SP[Lasttapedship] == 3 || SP[Lasttapedship] == 4 || SP[Lasttapedship] == 5 || SP[Lasttapedship] == 6 || SP[Lasttapedship] == 7 || SP[Lasttapedship] == 8 || SP[Lasttapedship] == 9)
                                {
                                }
                                else
                                {
                                    LockRec[SP[Lasttapedship] - 10] = false;
                    //                Field1[SP[Lasttapedship] - 10].Fill = Brushes.Azure;
                                }
                                //снизу
                                if (SP[Lasttapedship] == 9 || SP[Lasttapedship] == 19 || SP[Lasttapedship] == 29 || SP[Lasttapedship] == 39 || SP[Lasttapedship] == 49 || SP[Lasttapedship] == 59 || SP[Lasttapedship] == 69 || SP[Lasttapedship] == 79 || SP[Lasttapedship] == 89 || SP[Lasttapedship] == 99)
                                { }
                                else
                                {
                                    //слева снизу
                                    if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 1 || SP[Lasttapedship] == 2 || SP[Lasttapedship] == 3 || SP[Lasttapedship] == 4 || SP[Lasttapedship] == 5 || SP[Lasttapedship] == 6 || SP[Lasttapedship] == 7 || SP[Lasttapedship] == 8 || SP[Lasttapedship] == 9)
                                    {
                                    }
                                    else
                                    {
                                        LockRec[SP[Lasttapedship] - 9] = false;
                      //                  Field1[SP[Lasttapedship] - 9].Fill = Brushes.Azure;
                                    }
                                    //справа снизу
                                    if (SP[Lasttapedship] == 80 || SP[Lasttapedship] == 81 || SP[Lasttapedship] == 82 || SP[Lasttapedship] == 83 || SP[Lasttapedship] == 84 || SP[Lasttapedship] == 85 || SP[Lasttapedship] == 86 || SP[Lasttapedship] == 87 || SP[Lasttapedship] == 88 || SP[Lasttapedship] == 89)
                                    { }
                                    else
                                    {

                                        LockRec[SP[Lasttapedship] + 21] = false;
                     //                   Field1[SP[Lasttapedship] + 21].Fill = Brushes.Azure;

                                    }

                                    LockRec[SP[Lasttapedship] + 1] = false;
                    //                Field1[SP[Lasttapedship] + 1].Fill = Brushes.Azure;

                                    LockRec[SP[Lasttapedship] + 11] = false;
                    //                Field1[SP[Lasttapedship] + 11].Fill = Brushes.Azure;

                                }
                                //справа 
                                if (SP[Lasttapedship] == 80 || SP[Lasttapedship] == 81 || SP[Lasttapedship] == 82 || SP[Lasttapedship] == 83 || SP[Lasttapedship] == 84 || SP[Lasttapedship] == 85 || SP[Lasttapedship] == 86 || SP[Lasttapedship] == 87 || SP[Lasttapedship] == 88 || SP[Lasttapedship] == 89)
                                { }
                                else
                                {

                                    LockRec[SP[Lasttapedship] + 20] = false;
                    //                Field1[SP[Lasttapedship] + 20].Fill = Brushes.Azure;

                                }

                                //_____________________________________________________________________________________________
                            }

                        }
                        if (Lasttapedship >= 6 && Lasttapedship <= 9)
                        {
                            

                                Ships[Lasttapedship].Height = 39;
                                Ships[Lasttapedship].Width = 31;
                                Ships[Lasttapedship].Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Это_00001_00002.png"));
                                ifvertical[Lasttapedship] = true;

                                //Очистка поля для Mini по вертикали
                                {
                                    Canvas.SetLeft(Ships[Lasttapedship], Canvas.GetLeft(Field1[SP[Lasttapedship]]) - 3);
                                    Canvas.SetTop(Ships[Lasttapedship], Canvas.GetTop(Field1[SP[Lasttapedship]]) - 5);

                                    Field1[SP[Lasttapedship]].Fill = Brushes.DarkBlue;
                                GameRec[SP[Lasttapedship]] = true;
                                }

                            
                        }

                        returnverticalposition = true;

                    }
                    else
                    //Горизонтальное
                    {
                        if (returnverticalposition == true)
                        {
                            if (Lasttapedship == 0)
                            {
                                if (ifvertical[Lasttapedship] == true)
                                {
                                    if (SP[Lasttapedship] == 70 || SP[Lasttapedship] == 80 || SP[Lasttapedship] == 90 ||
                                        SP[Lasttapedship] == 71 || SP[Lasttapedship] == 81 || SP[Lasttapedship] == 91 ||
                                        SP[Lasttapedship] == 72 || SP[Lasttapedship] == 82 || SP[Lasttapedship] == 92 ||
                                        SP[Lasttapedship] == 73 || SP[Lasttapedship] == 83 || SP[Lasttapedship] == 93 ||
                                        SP[Lasttapedship] == 74 || SP[Lasttapedship] == 84 || SP[Lasttapedship] == 94 ||
                                        SP[Lasttapedship] == 75 || SP[Lasttapedship] == 85 || SP[Lasttapedship] == 95 ||
                                        SP[Lasttapedship] == 76 || SP[Lasttapedship] == 86 || SP[Lasttapedship] == 96 ||
                                        SP[Lasttapedship] == 77 || SP[Lasttapedship] == 87 || SP[Lasttapedship] == 97 ||
                                        SP[Lasttapedship] == 78 || SP[Lasttapedship] == 88 || SP[Lasttapedship] == 98 ||
                                        SP[Lasttapedship] == 79 || SP[Lasttapedship] == 89 || SP[Lasttapedship] == 99)
                                    { }
                                    else
                                    {
                                        Ships[Lasttapedship].Height = 33;
                                        Ships[Lasttapedship].Width = 149;
                                        Ships[Lasttapedship].Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Авианосец_00001.png"));
                                        ifvertical[Lasttapedship] = false;

                                        //Очистка для авиа

                                        Canvas.SetLeft(Ships[Lasttapedship], Canvas.GetLeft(Field1[SP[Lasttapedship]]));
                                        Canvas.SetTop(Ships[Lasttapedship], Canvas.GetTop(Field1[SP[Lasttapedship]]) - 7);

                                        Field1[SP[Lasttapedship]].Fill = Brushes.DarkBlue;
                                        Field1[SP[Lasttapedship] + 10].Fill = Brushes.DarkBlue;
                                        Field1[SP[Lasttapedship] + 20].Fill = Brushes.DarkBlue;
                                        Field1[SP[Lasttapedship] + 30].Fill = Brushes.DarkBlue;

                                       
                                        GameRec[SP[Lasttapedship]] = true;

                                       
                                        GameRec[SP[Lasttapedship] + 10] = true;

                                     
                                        GameRec[SP[Lasttapedship] + 20] = true;

                                      
                                        GameRec[SP[Lasttapedship] + 30] = true;

                                        Field1[SP[Lasttapedship] + 1].Fill = Brushes.Azure;
                                        Field1[SP[Lasttapedship] + 2].Fill = Brushes.Azure;
                                        Field1[SP[Lasttapedship] + 3].Fill = Brushes.Azure;

                                       
                                        GameRec[SP[Lasttapedship] + 1] = false;
                                        
                                       
                                        GameRec[SP[Lasttapedship] + 2] = false;
                                       


                                        GameRec[SP[Lasttapedship] + 3] = false;
                                        


                                    }

                                }

                                // очистка клеток окружающих авиа по вертикали
                                //_____________________________________________________________________________________________
                                //сверху
                                if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 10 || SP[Lasttapedship] == 20 || SP[Lasttapedship] == 30 || SP[Lasttapedship] == 40 || SP[Lasttapedship] == 50 || SP[Lasttapedship] == 60 || SP[Lasttapedship] == 70 || SP[Lasttapedship] == 80 || SP[Lasttapedship] == 90)
                                { }
                                else
                                {
                                    LockRec[SP[Lasttapedship] - 1] = false;
                 //                   Field1[SP[Lasttapedship] - 1].Fill = Brushes.Azure;

                                    //слева сверху
                                    if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 1 || SP[Lasttapedship] == 2 || SP[Lasttapedship] == 3 || SP[Lasttapedship] == 4 || SP[Lasttapedship] == 5 || SP[Lasttapedship] == 6 || SP[Lasttapedship] == 7 || SP[Lasttapedship] == 8 || SP[Lasttapedship] == 9)
                                    { }
                                    else
                                    {
                                        LockRec[SP[Lasttapedship] - 11] = false;
                   //                     Field1[SP[Lasttapedship] - 11].Fill = Brushes.Azure;
                                    }
                                    //справа сверху
                                    if (SP[Lasttapedship] == 90 || SP[Lasttapedship] == 91 || SP[Lasttapedship] == 92 || SP[Lasttapedship] == 93 || SP[Lasttapedship] == 94 || SP[Lasttapedship] == 95 || SP[Lasttapedship] == 96 || SP[Lasttapedship] == 97 || SP[Lasttapedship] == 98 || SP[Lasttapedship] == 99)
                                    { }
                                    else
                                    {

                                        LockRec[SP[Lasttapedship] + 9] = false;
                     //                   Field1[SP[Lasttapedship] + 9].Fill = Brushes.Azure;

                                    }
                                }
                                //слева
                                if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 1 || SP[Lasttapedship] == 2 || SP[Lasttapedship] == 3 || SP[Lasttapedship] == 4 || SP[Lasttapedship] == 5 || SP[Lasttapedship] == 6 || SP[Lasttapedship] == 7 || SP[Lasttapedship] == 8 || SP[Lasttapedship] == 9)
                                {
                                }
                                else
                                {
                                    LockRec[SP[Lasttapedship] - 10] = false;
                      //           Field1[SP[Lasttapedship] - 10].Fill = Brushes.Azure;

                                    LockRec[SP[Lasttapedship] - 9] = false;
                      //              Field1[SP[Lasttapedship] - 9].Fill = Brushes.Azure;

                                    LockRec[SP[Lasttapedship] - 8] = false;
                      //              Field1[SP[Lasttapedship] - 8].Fill = Brushes.Azure;

                                    LockRec[SP[Lasttapedship] - 7] = false;
                     //               Field1[SP[Lasttapedship] - 7].Fill = Brushes.Azure;
                                }
                                //снизу
                                if (SP[Lasttapedship] == 6 || SP[Lasttapedship] == 16 || SP[Lasttapedship] == 26 || SP[Lasttapedship] == 36 || SP[Lasttapedship] == 46 || SP[Lasttapedship] == 56 || SP[Lasttapedship] == 66 || SP[Lasttapedship] == 76 || SP[Lasttapedship] == 86 || SP[Lasttapedship] == 96)
                                { }
                                else
                                {
                                    //слева снизу
                                    if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 1 || SP[Lasttapedship] == 2 || SP[Lasttapedship] == 3 || SP[Lasttapedship] == 4 || SP[Lasttapedship] == 5 || SP[Lasttapedship] == 6 || SP[Lasttapedship] == 7 || SP[Lasttapedship] == 8 || SP[Lasttapedship] == 9)
                                    {
                                    }
                                    else
                                    {
                                        LockRec[SP[Lasttapedship] - 6] = false;
                       //                 Field1[SP[Lasttapedship] - 6].Fill = Brushes.Azure;
                                    }
                                    //справа снизу
                                    if (SP[Lasttapedship] == 90 || SP[Lasttapedship] == 91 || SP[Lasttapedship] == 92 || SP[Lasttapedship] == 93 || SP[Lasttapedship] == 94 || SP[Lasttapedship] == 95 || SP[Lasttapedship] == 96 || SP[Lasttapedship] == 97 || SP[Lasttapedship] == 98 || SP[Lasttapedship] == 99)
                                    { }
                                    else
                                    {

                                        LockRec[SP[Lasttapedship] + 14] = false;
                        //                Field1[SP[Lasttapedship] + 14].Fill = Brushes.Azure;

                                    }

                                    LockRec[SP[Lasttapedship] + 4] = false;
                      //              Field1[SP[Lasttapedship] + 4].Fill = Brushes.Azure;


                                }
                                //справа 
                                if (SP[Lasttapedship] == 90 || SP[Lasttapedship] == 91 || SP[Lasttapedship] == 92 || SP[Lasttapedship] == 93 || SP[Lasttapedship] == 94 || SP[Lasttapedship] == 95 || SP[Lasttapedship] == 96 || SP[Lasttapedship] == 97 || SP[Lasttapedship] == 98 || SP[Lasttapedship] == 99)
                                { }
                                else
                                {

                                    LockRec[SP[Lasttapedship] + 10] = false;
                          //          Field1[SP[Lasttapedship] + 10].Fill = Brushes.Azure;


                                    LockRec[SP[Lasttapedship] + 11] = false;
                    //                Field1[SP[Lasttapedship] + 11].Fill = Brushes.Azure;

                                    LockRec[SP[Lasttapedship] + 12] = false;
                  //                  Field1[SP[Lasttapedship] + 12].Fill = Brushes.Azure;

                                    LockRec[SP[Lasttapedship] + 13] = false;
                   //                 Field1[SP[Lasttapedship] + 13].Fill = Brushes.Azure;
                                }



                                //_____________________________________________________________________________________________
                            }
                            if (Lasttapedship >= 1 && Lasttapedship <= 2)
                            {
                                if (ifvertical[Lasttapedship] == true)
                                {
                                    if ( SP[Lasttapedship] == 80 || SP[Lasttapedship] == 90 ||
                                         SP[Lasttapedship] == 81 || SP[Lasttapedship] == 91 ||
                                         SP[Lasttapedship] == 82 || SP[Lasttapedship] == 92 ||
                                         SP[Lasttapedship] == 83 || SP[Lasttapedship] == 93 ||
                                         SP[Lasttapedship] == 84 || SP[Lasttapedship] == 94 ||
                                         SP[Lasttapedship] == 85 || SP[Lasttapedship] == 95 ||
                                         SP[Lasttapedship] == 86 || SP[Lasttapedship] == 96 ||
                                         SP[Lasttapedship] == 87 || SP[Lasttapedship] == 97 ||
                                         SP[Lasttapedship] == 88 || SP[Lasttapedship] == 98 ||
                                         SP[Lasttapedship] == 89 || SP[Lasttapedship] == 99)
                                    { }
                                    else
                                    {
                                        Ships[Lasttapedship].Height = 39;
                                        Ships[Lasttapedship].Width = 110;
                                        Ships[Lasttapedship].Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Эсминец_00001_00001.png"));
                                        ifvertical[Lasttapedship] = false;

                                        Canvas.SetLeft(Ships[Lasttapedship], Canvas.GetLeft(Field1[SP[Lasttapedship]]) - 7);
                                        Canvas.SetTop(Ships[Lasttapedship], Canvas.GetTop(Field1[SP[Lasttapedship]]) - 7);

                                        //Очистка для Destroyer

                                        Field1[SP[Lasttapedship]].Fill = Brushes.DarkBlue;
                                        Field1[SP[Lasttapedship] + 10].Fill = Brushes.DarkBlue;
                                        Field1[SP[Lasttapedship] + 20].Fill = Brushes.DarkBlue;

                                   
                                        GameRec[SP[Lasttapedship]] = true;

                                      
                                        GameRec[SP[Lasttapedship] + 10] = true;

                                       
                                        GameRec[SP[Lasttapedship] + 20] = true;

                                        Field1[SP[Lasttapedship] + 1].Fill = Brushes.Azure;
                                        Field1[SP[Lasttapedship] + 2].Fill = Brushes.Azure;

                                       
                                        GameRec[SP[Lasttapedship] + 1] = false;

                                       
                                        GameRec[SP[Lasttapedship] + 2] = false;
                                    }

                                    // очистка клетки окружающие Destroyer по вертикали
                                    //_____________________________________________________________________________________________
                                    //сверху
                                    if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 10 || SP[Lasttapedship] == 20 || SP[Lasttapedship] == 30 || SP[Lasttapedship] == 40 || SP[Lasttapedship] == 50 || SP[Lasttapedship] == 60 || SP[Lasttapedship] == 70 || SP[Lasttapedship] == 80 || SP[Lasttapedship] == 90)
                                    { }
                                    else
                                    {
                                        LockRec[SP[Lasttapedship] - 1] = true;
                      //                  Field1[SP[Lasttapedship] - 1].Fill = Brushes.Azure;

                                        //слева сверху
                                        if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 1 || SP[Lasttapedship] == 2 || SP[Lasttapedship] == 3 || SP[Lasttapedship] == 4 || SP[Lasttapedship] == 5 || SP[Lasttapedship] == 6 || SP[Lasttapedship] == 7 || SP[Lasttapedship] == 8 || SP[Lasttapedship] == 9)
                                        { }
                                        else
                                        {
                                            LockRec[SP[Lasttapedship] - 11] = true;
                     //                       Field1[SP[Lasttapedship] - 11].Fill = Brushes.Azure;
                                        }
                                        //справа сверху
                                        if (SP[Lasttapedship] == 90 || SP[Lasttapedship] == 91 || SP[Lasttapedship] == 92 || SP[Lasttapedship] == 93 || SP[Lasttapedship] == 94 || SP[Lasttapedship] == 95 || SP[Lasttapedship] == 96 || SP[Lasttapedship] == 97 || SP[Lasttapedship] == 98 || SP[Lasttapedship] == 99)
                                        { }
                                        else
                                        {

                                            LockRec[SP[Lasttapedship] + 9] = true;
                      //                      Field1[SP[Lasttapedship] + 9].Fill = Brushes.Azure;

                                        }
                                    }
                                    //слева
                                    if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 1 || SP[Lasttapedship] == 2 || SP[Lasttapedship] == 3 || SP[Lasttapedship] == 4 || SP[Lasttapedship] == 5 || SP[Lasttapedship] == 6 || SP[Lasttapedship] == 7 || SP[Lasttapedship] == 8 || SP[Lasttapedship] == 9)
                                    {
                                    }
                                    else
                                    {
                                        LockRec[SP[Lasttapedship] - 10] = true;
                        //                Field1[SP[Lasttapedship] - 10].Fill = Brushes.Azure;

                                        LockRec[SP[Lasttapedship] - 9] = true;
                       //                 Field1[SP[Lasttapedship] - 9].Fill = Brushes.Azure;

                                        LockRec[SP[Lasttapedship] - 8] = true;
                        //                Field1[SP[Lasttapedship] - 8].Fill = Brushes.Azure;

                                    }
                                    //снизу
                                    if (SP[Lasttapedship] == 7 || SP[Lasttapedship] == 17 || SP[Lasttapedship] == 27 || SP[Lasttapedship] == 37 || SP[Lasttapedship] == 47 || SP[Lasttapedship] == 57 || SP[Lasttapedship] == 67 || SP[Lasttapedship] == 77 || SP[Lasttapedship] == 87 || SP[Lasttapedship] == 97)
                                    { }
                                    else
                                    {
                                        //слева снизу
                                        if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 1 || SP[Lasttapedship] == 2 || SP[Lasttapedship] == 3 || SP[Lasttapedship] == 4 || SP[Lasttapedship] == 5 || SP[Lasttapedship] == 6 || SP[Lasttapedship] == 7 || SP[Lasttapedship] == 8 || SP[Lasttapedship] == 9)
                                        {
                                        }
                                        else
                                        {
                                            LockRec[SP[Lasttapedship] - 7] = true;
                    //                        Field1[SP[Lasttapedship] - 7].Fill = Brushes.Azure;
                                        }
                                        //справа снизу
                                        if (SP[Lasttapedship] == 90 || SP[Lasttapedship] == 91 || SP[Lasttapedship] == 92 || SP[Lasttapedship] == 93 || SP[Lasttapedship] == 94 || SP[Lasttapedship] == 95 || SP[Lasttapedship] == 96 || SP[Lasttapedship] == 97 || SP[Lasttapedship] == 98 || SP[Lasttapedship] == 99)
                                        { }
                                        else
                                        {

                                            LockRec[SP[Lasttapedship] + 13] = true;
                         //                   Field1[SP[Lasttapedship] + 13].Fill = Brushes.Azure;

                                        }

                                        LockRec[SP[Lasttapedship] + 3] = true;
                         //               Field1[SP[Lasttapedship] + 3].Fill = Brushes.Azure;


                                    }
                                    //справа 
                                    if (SP[Lasttapedship] == 90 || SP[Lasttapedship] == 91 || SP[Lasttapedship] == 92 || SP[Lasttapedship] == 93 || SP[Lasttapedship] == 94 || SP[Lasttapedship] == 95 || SP[Lasttapedship] == 96 || SP[Lasttapedship] == 97 || SP[Lasttapedship] == 98 || SP[Lasttapedship] == 99)
                                    { }
                                    else
                                    {

                                        LockRec[SP[Lasttapedship] + 10] = true;
                        //                Field1[SP[Lasttapedship] + 10].Fill = Brushes.Azure;


                                        LockRec[SP[Lasttapedship] + 11] = true;
                        //                Field1[SP[Lasttapedship] + 11].Fill = Brushes.Azure;

                                        LockRec[SP[Lasttapedship] + 12] = true;
                       //                 Field1[SP[Lasttapedship] + 12].Fill = Brushes.Azure;


                                    }



                                    //_____________________________________________________________________________________________
                                }


                            }
                            if (Lasttapedship >= 3 && Lasttapedship <= 5)
                            {
                                if (ifvertical[Lasttapedship] == true)
                                {
                                    if (SP[Lasttapedship] == 90 ||
                                          SP[Lasttapedship] == 91 ||
                                          SP[Lasttapedship] == 92 ||
                                          SP[Lasttapedship] == 93 ||
                                          SP[Lasttapedship] == 94 ||
                                          SP[Lasttapedship] == 95 ||
                                          SP[Lasttapedship] == 96 ||
                                          SP[Lasttapedship] == 97 ||
                                          SP[Lasttapedship] == 98 ||
                                          SP[Lasttapedship] == 99 )
                                    { }
                                    else
                                    {
                                        Ships[Lasttapedship].Height = 30;
                                        Ships[Lasttapedship].Width = 80;
                                        Ships[Lasttapedship].Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Корабль_00001.png"));
                                        ifvertical[Lasttapedship] = false;

                                        Canvas.SetLeft(Ships[Lasttapedship], Canvas.GetLeft(Field1[SP[Lasttapedship]]) - 3);
                                        Canvas.SetTop(Ships[Lasttapedship], Canvas.GetTop(Field1[SP[Lasttapedship]]) - 7);

                                        //Очистка для Lodka

                                        Field1[SP[Lasttapedship]].Fill = Brushes.DarkBlue;
                                        Field1[SP[Lasttapedship] + 10].Fill = Brushes.DarkBlue;

                                        GameRec[SP[Lasttapedship]] = true;

                                        GameRec[SP[Lasttapedship] + 10] = true;

                                        Field1[SP[Lasttapedship] + 1].Fill = Brushes.Azure;
                                        GameRec[SP[Lasttapedship] + 1] = false;

                                    }

                                    // очистка клетки окружающие Lodka по вертикали
                                    //_____________________________________________________________________________________________
                                    //сверху
                                    if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 10 || SP[Lasttapedship] == 20 || SP[Lasttapedship] == 30 || SP[Lasttapedship] == 40 || SP[Lasttapedship] == 50 || SP[Lasttapedship] == 60 || SP[Lasttapedship] == 70 || SP[Lasttapedship] == 80 || SP[Lasttapedship] == 90)
                                    { }
                                    else
                                    {
                                        LockRec[SP[Lasttapedship] - 1] = false;
                //                        Field1[SP[Lasttapedship] - 1].Fill = Brushes.Azure;

                                        //слева сверху
                                        if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 1 || SP[Lasttapedship] == 2 || SP[Lasttapedship] == 3 || SP[Lasttapedship] == 4 || SP[Lasttapedship] == 5 || SP[Lasttapedship] == 6 || SP[Lasttapedship] == 7 || SP[Lasttapedship] == 8 || SP[Lasttapedship] == 9)
                                        { }
                                        else
                                        {
                                            LockRec[SP[Lasttapedship] - 11] = false;
               //                             Field1[SP[Lasttapedship] - 11].Fill = Brushes.Azure;
                                        }
                                        //справа сверху
                                        if (SP[Lasttapedship] == 90 || SP[Lasttapedship] == 91 || SP[Lasttapedship] == 92 || SP[Lasttapedship] == 93 || SP[Lasttapedship] == 94 || SP[Lasttapedship] == 95 || SP[Lasttapedship] == 96 || SP[Lasttapedship] == 97 || SP[Lasttapedship] == 98 || SP[Lasttapedship] == 99)
                                        { }
                                        else
                                        {

                                            LockRec[SP[Lasttapedship] + 9] = false;
                //                            Field1[SP[Lasttapedship] + 9].Fill = Brushes.Azure;

                                        }
                                    }
                                    //слева
                                    if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 1 || SP[Lasttapedship] == 2 || SP[Lasttapedship] == 3 || SP[Lasttapedship] == 4 || SP[Lasttapedship] == 5 || SP[Lasttapedship] == 6 || SP[Lasttapedship] == 7 || SP[Lasttapedship] == 8 || SP[Lasttapedship] == 9)
                                    {
                                    }
                                    else
                                    {
                                        LockRec[SP[Lasttapedship] - 10] = false;
                 //                       Field1[SP[Lasttapedship] - 10].Fill = Brushes.Azure;

                                        LockRec[SP[Lasttapedship] - 9] = false;
                 //                       Field1[SP[Lasttapedship] - 9].Fill = Brushes.Azure;


                                    }
                                    //снизу
                                    if (SP[Lasttapedship] == 8 || SP[Lasttapedship] == 18 || SP[Lasttapedship] == 28 || SP[Lasttapedship] == 38 || SP[Lasttapedship] == 48 || SP[Lasttapedship] == 58 || SP[Lasttapedship] == 68 || SP[Lasttapedship] == 78 || SP[Lasttapedship] == 88 || SP[Lasttapedship] == 98)
                                    { }
                                    else
                                    {
                                        //слева снизу
                                        if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 1 || SP[Lasttapedship] == 2 || SP[Lasttapedship] == 3 || SP[Lasttapedship] == 4 || SP[Lasttapedship] == 5 || SP[Lasttapedship] == 6 || SP[Lasttapedship] == 7 || SP[Lasttapedship] == 8 || SP[Lasttapedship] == 9)
                                        {
                                        }
                                        else
                                        {
                                            LockRec[SP[Lasttapedship] - 8] = false;
                   //                         Field1[SP[Lasttapedship] - 8].Fill = Brushes.Azure;
                                        }
                                        //справа снизу
                                        if (SP[Lasttapedship] == 90 || SP[Lasttapedship] == 91 || SP[Lasttapedship] == 92 || SP[Lasttapedship] == 93 || SP[Lasttapedship] == 94 || SP[Lasttapedship] == 95 || SP[Lasttapedship] == 96 || SP[Lasttapedship] == 97 || SP[Lasttapedship] == 98 || SP[Lasttapedship] == 99)
                                        { }
                                        else
                                        {

                                            LockRec[SP[Lasttapedship] + 12] = false;
                    //                        Field1[SP[Lasttapedship] + 12].Fill = Brushes.Azure;

                                        }

                                        LockRec[SP[Lasttapedship] + 2] = false;
                    //                    Field1[SP[Lasttapedship] + 2].Fill = Brushes.Azure;


                                    }
                                    //справа 
                                    if (SP[Lasttapedship] == 90 || SP[Lasttapedship] == 91 || SP[Lasttapedship] == 92 || SP[Lasttapedship] == 93 || SP[Lasttapedship] == 94 || SP[Lasttapedship] == 95 || SP[Lasttapedship] == 96 || SP[Lasttapedship] == 97 || SP[Lasttapedship] == 98 || SP[Lasttapedship] == 99)
                                    { }
                                    else
                                    {

                                        LockRec[SP[Lasttapedship] + 10] = false;
                    //                    Field1[SP[Lasttapedship] + 10].Fill = Brushes.Azure;


                                        LockRec[SP[Lasttapedship] + 11] = false;
                     //                   Field1[SP[Lasttapedship] + 11].Fill = Brushes.Azure;


                                    }

                                    //_____________________________________________________________________________________________

                                }

                            }

                            if (Lasttapedship >= 6 && Lasttapedship <= 9)
                            {
                                if (ifvertical[Lasttapedship] == true)
                                {
                                    
                                        Ships[Lasttapedship].Height = 31;
                                        Ships[Lasttapedship].Width = 41;
                                        Ships[Lasttapedship].Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Это_00001_00001.png"));
                                        ifvertical[Lasttapedship] = false;

                                        Canvas.SetLeft(Ships[Lasttapedship], Canvas.GetLeft(Field1[SP[Lasttapedship]]) - 3);
                                        Canvas.SetTop(Ships[Lasttapedship], Canvas.GetTop(Field1[SP[Lasttapedship]]) - 3);

                                        //Очистка для Mini

                                        Field1[SP[Lasttapedship]].Fill = Brushes.DarkBlue;
                                       
                                     

                                }

                               
                            }

                            returnverticalposition = false;
                        }
                    }
                }
            }
            catch { MessageBox.Show("Корабль упирается в стену"); }
        }



        //Расстановка кораблей по полю
        //-------------------------------------------------------------------------------
        private void AviaMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ifGameStarted == false)
            {
                Lasttapedship = 0;
                ifMouseClicked[Lasttapedship] = true;
                Canvas.SetZIndex(Ships[Lasttapedship], 1);

                if (SP[Lasttapedship] != -1)
                    if (LockRec[LastActiveRectangle] != true)
                    {
                        //Очистка поля при повторном перемещении авиа
                        if (ifvertical[Lasttapedship] == false)
                        {
                            if (SP[Lasttapedship] == 70 || SP[Lasttapedship] == 80 || SP[Lasttapedship] == 90 ||
                                SP[Lasttapedship] == 71 || SP[Lasttapedship] == 81 || SP[Lasttapedship] == 91 ||
                                SP[Lasttapedship] == 72 || SP[Lasttapedship] == 82 || SP[Lasttapedship] == 92 ||
                                SP[Lasttapedship] == 73 || SP[Lasttapedship] == 83 || SP[Lasttapedship] == 93 ||
                                SP[Lasttapedship] == 74 || SP[Lasttapedship] == 84 || SP[Lasttapedship] == 94 ||
                                SP[Lasttapedship] == 75 || SP[Lasttapedship] == 85 || SP[Lasttapedship] == 95 ||
                                SP[Lasttapedship] == 76 || SP[Lasttapedship] == 86 || SP[Lasttapedship] == 96 ||
                                SP[Lasttapedship] == 77 || SP[Lasttapedship] == 87 || SP[Lasttapedship] == 97 ||
                                SP[Lasttapedship] == 78 || SP[Lasttapedship] == 88 || SP[Lasttapedship] == 98 ||
                                SP[Lasttapedship] == 79 || SP[Lasttapedship] == 89 || SP[Lasttapedship] == 99)
                            {
                            }
                            else
                            {
                                Field1[SP[Lasttapedship]].Fill = Brushes.Azure;
                                Field1[SP[Lasttapedship] + 10].Fill = Brushes.Azure;
                                Field1[SP[Lasttapedship] + 20].Fill = Brushes.Azure;
                                Field1[SP[Lasttapedship] + 30].Fill = Brushes.Azure;

                                LockRec[SP[Lasttapedship]] = false;
                                GameRec[SP[Lasttapedship]] = false;

                                LockRec[SP[Lasttapedship] + 10] = false;
                                GameRec[SP[Lasttapedship] + 10] = false;

                                LockRec[SP[Lasttapedship] + 20] = false;
                                GameRec[SP[Lasttapedship] + 20] = false;

                                LockRec[SP[Lasttapedship] + 30] = false;
                                GameRec[SP[Lasttapedship] + 30] = false;
                            }
                            //очистка клеток по горизонтали
                            //_____________________________________________________________________________________________
                            //сверху
                            if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 10 || SP[Lasttapedship] == 20 || SP[Lasttapedship] == 30 || SP[Lasttapedship] == 40 || SP[Lasttapedship] == 50 || SP[Lasttapedship] == 60 || SP[Lasttapedship] == 70 || SP[Lasttapedship] == 80 || SP[Lasttapedship] == 90)
                            { }
                            else
                            {
                                try
                                {
                                    //               LockRec[SP[Lasttapedship] - 1] = false;
                                    Field1[SP[Lasttapedship] - 1].Fill = Brushes.Azure;

                                    LockRec[SP[Lasttapedship] + 9] = false;
                                    //                 Field1[SP[Lasttapedship] + 9].Fill = Brushes.Azure;

                                    LockRec[SP[Lasttapedship] + 19] = false;
                                    //                  Field1[SP[Lasttapedship] + 19].Fill = Brushes.Azure;

                                    LockRec[SP[Lasttapedship] + 29] = false;
                                    //                  Field1[SP[Lasttapedship] + 29].Fill = Brushes.Azure;
                                }
                                catch { }
                                //слева сверху
                                if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 1 || SP[Lasttapedship] == 2 || SP[Lasttapedship] == 3 || SP[Lasttapedship] == 4 || SP[Lasttapedship] == 5 || SP[Lasttapedship] == 6 || SP[Lasttapedship] == 7 || SP[Lasttapedship] == 8 || SP[Lasttapedship] == 9)
                                { }
                                else
                                {
                                    LockRec[SP[Lasttapedship] - 11] = false;
                                    //               Field1[SP[Lasttapedship] - 11].Fill = Brushes.Azure;
                                }
                                //справа сверху
                                if (SP[Lasttapedship] == 60 || SP[Lasttapedship] == 61 || SP[Lasttapedship] == 62 || SP[Lasttapedship] == 63 || SP[Lasttapedship] == 64 || SP[Lasttapedship] == 65 || SP[Lasttapedship] == 66 || SP[Lasttapedship] == 67 || SP[Lasttapedship] == 68 || SP[Lasttapedship] == 69)
                                { }
                                else
                                {

                                    LockRec[SP[Lasttapedship] + 39] = false;
                                    //                Field1[SP[Lasttapedship] + 39].Fill = Brushes.Azure;

                                }
                            }
                            //слева
                            if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 1 || SP[Lasttapedship] == 2 || SP[Lasttapedship] == 3 || SP[Lasttapedship] == 4 || SP[Lasttapedship] == 5 || SP[Lasttapedship] == 6 || SP[Lasttapedship] == 7 || SP[Lasttapedship] == 8 || SP[Lasttapedship] == 9)
                            {
                            }
                            else
                            {
                                LockRec[SP[Lasttapedship] - 10] = false;
                                //           Field1[SP[Lasttapedship] - 10].Fill = Brushes.Azure;
                            }
                            //снизу
                            if (SP[Lasttapedship] == 9 || SP[Lasttapedship] == 19 || SP[Lasttapedship] == 29 || SP[Lasttapedship] == 39 || SP[Lasttapedship] == 49 || SP[Lasttapedship] == 59 || SP[Lasttapedship] == 69 || SP[Lasttapedship] == 79 || SP[Lasttapedship] == 89 || SP[Lasttapedship] == 99)
                            { }
                            else
                            {
                                //слева снизу
                                if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 1 || SP[Lasttapedship] == 2 || SP[Lasttapedship] == 3 || SP[Lasttapedship] == 4 || SP[Lasttapedship] == 5 || SP[Lasttapedship] == 6 || SP[Lasttapedship] == 7 || SP[Lasttapedship] == 8 || SP[Lasttapedship] == 9)
                                {
                                }
                                else
                                {
                                    LockRec[SP[Lasttapedship] - 9] = false;
                                    //                 Field1[SP[Lasttapedship] - 9].Fill = Brushes.Azure;
                                }
                                //справа снизу
                                if (SP[Lasttapedship] == 60 || SP[Lasttapedship] == 61 || SP[Lasttapedship] == 62 || SP[Lasttapedship] == 63 || SP[Lasttapedship] == 64 || SP[Lasttapedship] == 65 || SP[Lasttapedship] == 66 || SP[Lasttapedship] == 67 || SP[Lasttapedship] == 68 || SP[Lasttapedship] == 69)
                                { }
                                else
                                {

                                    LockRec[SP[Lasttapedship] + 41] = false;
                                    //               Field1[SP[Lasttapedship] + 41].Fill = Brushes.Azure;

                                }

                                LockRec[SP[Lasttapedship] + 1] = false;
                                //           Field1[SP[Lasttapedship] + 1].Fill = Brushes.Azure;

                                LockRec[SP[Lasttapedship] + 11] = false;
                                //            Field1[SP[Lasttapedship] + 11].Fill = Brushes.Azure;

                                LockRec[SP[Lasttapedship] + 21] = false;
                                //            Field1[SP[Lasttapedship] + 21].Fill = Brushes.Azure;

                                LockRec[SP[Lasttapedship] + 31] = false;
                                //             Field1[SP[Lasttapedship] + 31].Fill = Brushes.Azure;
                            }
                            //справа 
                            if (SP[Lasttapedship] == 60 || SP[Lasttapedship] == 61 || SP[Lasttapedship] == 62 || SP[Lasttapedship] == 63 || SP[Lasttapedship] == 64 || SP[Lasttapedship] == 65 || SP[Lasttapedship] == 66 || SP[Lasttapedship] == 67 || SP[Lasttapedship] == 68 || SP[Lasttapedship] == 69)
                            { }
                            else
                            {

                                LockRec[SP[Lasttapedship] + 40] = false;
                                //              Field1[SP[Lasttapedship] + 40].Fill = Brushes.Azure;

                            }

                            //_____________________________________________________________________________________________

                        }

                        if (ifvertical[Lasttapedship] == true)
                        {
                            if (SP[Lasttapedship] == 7 || SP[Lasttapedship] == 8 || SP[Lasttapedship] == 9 ||
                                SP[Lasttapedship] == 17 || SP[Lasttapedship] == 18 || SP[Lasttapedship] == 19 ||
                                SP[Lasttapedship] == 27 || SP[Lasttapedship] == 28 || SP[Lasttapedship] == 29 ||
                                SP[Lasttapedship] == 37 || SP[Lasttapedship] == 38 || SP[Lasttapedship] == 39 ||
                                SP[Lasttapedship] == 47 || SP[Lasttapedship] == 48 || SP[Lasttapedship] == 49 ||
                                SP[Lasttapedship] == 57 || SP[Lasttapedship] == 58 || SP[Lasttapedship] == 59 ||
                                SP[Lasttapedship] == 67 || SP[Lasttapedship] == 68 || SP[Lasttapedship] == 69 ||
                                SP[Lasttapedship] == 77 || SP[Lasttapedship] == 78 || SP[Lasttapedship] == 79 ||
                                SP[Lasttapedship] == 87 || SP[Lasttapedship] == 88 || SP[Lasttapedship] == 89 ||
                                SP[Lasttapedship] == 97 || SP[Lasttapedship] == 98 || SP[Lasttapedship] == 99)
                            {
                            }
                            else
                            {

                                Field1[SP[Lasttapedship]].Fill = Brushes.Azure;
                                Field1[SP[Lasttapedship] + 1].Fill = Brushes.Azure;
                                Field1[SP[Lasttapedship] + 2].Fill = Brushes.Azure;
                                Field1[SP[Lasttapedship] + 3].Fill = Brushes.Azure;

                                LockRec[SP[Lasttapedship]] = false;
                                GameRec[SP[Lasttapedship]] = false;

                                LockRec[SP[Lasttapedship] + 1] = false;
                                GameRec[SP[Lasttapedship] + 1] = false;

                                LockRec[SP[Lasttapedship] + 2] = false;
                                GameRec[SP[Lasttapedship] + 2] = false;

                                LockRec[SP[Lasttapedship] + 3] = false;
                                GameRec[SP[Lasttapedship] + 3] = false;
                            }
                            // очистка клеток окружающих авиа по вертикали
                            //_____________________________________________________________________________________________
                            //сверху
                            if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 10 || SP[Lasttapedship] == 20 || SP[Lasttapedship] == 30 || SP[Lasttapedship] == 40 || SP[Lasttapedship] == 50 || SP[Lasttapedship] == 60 || SP[Lasttapedship] == 70 || SP[Lasttapedship] == 80 || SP[Lasttapedship] == 90)
                            { }
                            else
                            {
                                LockRec[SP[Lasttapedship] - 1] = false;
                                //           Field1[SP[Lasttapedship] - 1].Fill = Brushes.Azure;

                                //слева сверху
                                if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 1 || SP[Lasttapedship] == 2 || SP[Lasttapedship] == 3 || SP[Lasttapedship] == 4 || SP[Lasttapedship] == 5 || SP[Lasttapedship] == 6 || SP[Lasttapedship] == 7 || SP[Lasttapedship] == 8 || SP[Lasttapedship] == 9)
                                { }
                                else
                                {
                                    LockRec[SP[Lasttapedship] - 11] = false;
                                    //                  Field1[SP[Lasttapedship] - 11].Fill = Brushes.Azure;
                                }
                                //справа сверху
                                if (SP[Lasttapedship] == 90 || SP[Lasttapedship] == 91 || SP[Lasttapedship] == 92 || SP[Lasttapedship] == 93 || SP[Lasttapedship] == 94 || SP[Lasttapedship] == 95 || SP[Lasttapedship] == 96 || SP[Lasttapedship] == 97 || SP[Lasttapedship] == 98 || SP[Lasttapedship] == 99)
                                { }
                                else
                                {

                                    LockRec[SP[Lasttapedship] + 9] = false;
                                    //                  Field1[SP[Lasttapedship] + 9].Fill = Brushes.Azure;

                                }
                            }
                            //слева
                            if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 1 || SP[Lasttapedship] == 2 || SP[Lasttapedship] == 3 || SP[Lasttapedship] == 4 || SP[Lasttapedship] == 5 || SP[Lasttapedship] == 6 || SP[Lasttapedship] == 7 || SP[Lasttapedship] == 8 || SP[Lasttapedship] == 9)
                            {
                            }
                            else
                            {
                                LockRec[SP[Lasttapedship] - 10] = false;
                                //             Field1[SP[Lasttapedship] - 10].Fill = Brushes.Azure;

                                LockRec[SP[Lasttapedship] - 9] = false;
                                //              Field1[SP[Lasttapedship] - 9].Fill = Brushes.Azure;

                                LockRec[SP[Lasttapedship] - 8] = false;
                                //               Field1[SP[Lasttapedship] - 8].Fill = Brushes.Azure;

                                LockRec[SP[Lasttapedship] - 7] = false;
                                //               Field1[SP[Lasttapedship] - 7].Fill = Brushes.Azure;
                            }
                            //снизу
                            if (SP[Lasttapedship] == 6 || SP[Lasttapedship] == 16 || SP[Lasttapedship] == 26 || SP[Lasttapedship] == 36 || SP[Lasttapedship] == 46 || SP[Lasttapedship] == 56 || SP[Lasttapedship] == 66 || SP[Lasttapedship] == 76 || SP[Lasttapedship] == 86 || SP[Lasttapedship] == 96)
                            { }
                            else
                            {
                                //слева снизу
                                if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 1 || SP[Lasttapedship] == 2 || SP[Lasttapedship] == 3 || SP[Lasttapedship] == 4 || SP[Lasttapedship] == 5 || SP[Lasttapedship] == 6 || SP[Lasttapedship] == 7 || SP[Lasttapedship] == 8 || SP[Lasttapedship] == 9)
                                {
                                }
                                else
                                {
                                    LockRec[SP[Lasttapedship] - 6] = false;
                                    //                  Field1[SP[Lasttapedship] - 6].Fill = Brushes.Azure;
                                }
                                //справа снизу
                                if (SP[Lasttapedship] == 90 || SP[Lasttapedship] == 91 || SP[Lasttapedship] == 92 || SP[Lasttapedship] == 93 || SP[Lasttapedship] == 94 || SP[Lasttapedship] == 95 || SP[Lasttapedship] == 96 || SP[Lasttapedship] == 97 || SP[Lasttapedship] == 98 || SP[Lasttapedship] == 99)
                                { }
                                else
                                {

                                    LockRec[SP[Lasttapedship] + 14] = false;
                                    //                Field1[SP[Lasttapedship] + 14].Fill = Brushes.Azure;

                                }

                                LockRec[SP[Lasttapedship] + 4] = false;
                                //           Field1[SP[Lasttapedship] + 4].Fill = Brushes.Azure;


                            }
                            //справа 
                            if (SP[Lasttapedship] == 90 || SP[Lasttapedship] == 91 || SP[Lasttapedship] == 92 || SP[Lasttapedship] == 93 || SP[Lasttapedship] == 94 || SP[Lasttapedship] == 95 || SP[Lasttapedship] == 96 || SP[Lasttapedship] == 97 || SP[Lasttapedship] == 98 || SP[Lasttapedship] == 99)
                            { }
                            else
                            {

                                LockRec[SP[Lasttapedship] + 10] = false;
                                //             Field1[SP[Lasttapedship] + 10].Fill = Brushes.Azure;


                                LockRec[SP[Lasttapedship] + 11] = false;
                                //               Field1[SP[Lasttapedship] + 11].Fill = Brushes.Azure;

                                LockRec[SP[Lasttapedship] + 12] = false;
                                //              Field1[SP[Lasttapedship] + 12].Fill = Brushes.Azure;

                                LockRec[SP[Lasttapedship] + 13] = false;
                                //              Field1[SP[Lasttapedship] + 13].Fill = Brushes.Azure;
                            }



                            //_____________________________________________________________________________________________

                        }
                    }
            }
        }

        private void DestroyerMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ifGameStarted == false)
            {
                Lasttapedship = Convert.ToInt32(((Image)sender).Tag);
                ifMouseClicked[Lasttapedship] = true;
                Canvas.SetZIndex(Ships[Lasttapedship], 1);

                if (SP[Lasttapedship] != -1)
                    if (LockRec[SP[Lasttapedship]] != true)
                    {
                        //Очистка поля при повторном перемещении Destroyer
                        if (ifvertical[Lasttapedship] == false)
                        {
                            if (SP[Lasttapedship] == 80 || SP[Lasttapedship] == 90 ||
                                 SP[Lasttapedship] == 81 || SP[Lasttapedship] == 91 ||
                                 SP[Lasttapedship] == 82 || SP[Lasttapedship] == 92 ||
                                 SP[Lasttapedship] == 83 || SP[Lasttapedship] == 93 ||
                                 SP[Lasttapedship] == 84 || SP[Lasttapedship] == 94 ||
                                 SP[Lasttapedship] == 85 || SP[Lasttapedship] == 95 ||
                                 SP[Lasttapedship] == 86 || SP[Lasttapedship] == 96 ||
                                 SP[Lasttapedship] == 87 || SP[Lasttapedship] == 97 ||
                                 SP[Lasttapedship] == 88 || SP[Lasttapedship] == 98 ||
                                 SP[Lasttapedship] == 89 || SP[Lasttapedship] == 99)
                            {
                            }
                            else
                            {
                                Field1[SP[Lasttapedship]].Fill = Brushes.Azure;
                                Field1[SP[Lasttapedship] + 10].Fill = Brushes.Azure;
                                Field1[SP[Lasttapedship] + 20].Fill = Brushes.Azure;

                                LockRec[SP[Lasttapedship]] = false;
                                GameRec[SP[Lasttapedship]] = false;

                                LockRec[SP[Lasttapedship] + 10] = false;
                                GameRec[SP[Lasttapedship] + 10] = false;

                                LockRec[SP[Lasttapedship] + 20] = false;
                                GameRec[SP[Lasttapedship] + 20] = false;


                                // очистка клеткок окружающих Destroyer по горизонтали
                                //_____________________________________________________________________________________________
                                //сверху
                                if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 10 || SP[Lasttapedship] == 20 || SP[Lasttapedship] == 30 || SP[Lasttapedship] == 40 || SP[Lasttapedship] == 50 || SP[Lasttapedship] == 60 || SP[Lasttapedship] == 70 || SP[Lasttapedship] == 80 || SP[Lasttapedship] == 90)
                                { }
                                else
                                {
                                    LockRec[SP[Lasttapedship] - 1] = false;
                                    //                          Field1[SP[Lasttapedship] - 1].Fill = Brushes.Azure;

                                    LockRec[SP[Lasttapedship] + 9] = false;
                                    //                             Field1[SP[Lasttapedship] + 9].Fill = Brushes.Azure;

                                    LockRec[SP[Lasttapedship] + 19] = false;
                                    //                            Field1[SP[Lasttapedship] + 19].Fill = Brushes.Azure;


                                    //слева сверху
                                    if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 1 || SP[Lasttapedship] == 2 || SP[Lasttapedship] == 3 || SP[Lasttapedship] == 4 || SP[Lasttapedship] == 5 || SP[Lasttapedship] == 6 || SP[Lasttapedship] == 7 || SP[Lasttapedship] == 8 || SP[Lasttapedship] == 9)
                                    { }
                                    else
                                    {
                                        LockRec[SP[Lasttapedship] - 11] = false;
                                        //                                 Field1[SP[Lasttapedship] - 11].Fill = Brushes.Azure;
                                    }
                                    //справа сверху
                                    if (SP[Lasttapedship] == 70 || SP[Lasttapedship] == 71 || SP[Lasttapedship] == 72 || SP[Lasttapedship] == 73 || SP[Lasttapedship] == 74 || SP[Lasttapedship] == 75 || SP[Lasttapedship] == 76 || SP[Lasttapedship] == 77 || SP[Lasttapedship] == 78 || SP[Lasttapedship] == 79)
                                    { }
                                    else
                                    {

                                        LockRec[SP[Lasttapedship] + 29] = false;
                                        //                                  Field1[SP[Lasttapedship] + 29].Fill = Brushes.Azure;

                                    }
                                }
                                //слева
                                if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 1 || SP[Lasttapedship] == 2 || SP[Lasttapedship] == 3 || SP[Lasttapedship] == 4 || SP[Lasttapedship] == 5 || SP[Lasttapedship] == 6 || SP[Lasttapedship] == 7 || SP[Lasttapedship] == 8 || SP[Lasttapedship] == 9)
                                {
                                }
                                else
                                {
                                    LockRec[SP[Lasttapedship] - 10] = false;
                                    //                             Field1[SP[Lasttapedship] - 10].Fill = Brushes.Azure;
                                }
                                //снизу
                                if (SP[Lasttapedship] == 9 || SP[Lasttapedship] == 19 || SP[Lasttapedship] == 29 || SP[Lasttapedship] == 39 || SP[Lasttapedship] == 49 || SP[Lasttapedship] == 59 || SP[Lasttapedship] == 69 || SP[Lasttapedship] == 79 || SP[Lasttapedship] == 89 || SP[Lasttapedship] == 99)
                                { }
                                else
                                {
                                    //слева снизу
                                    if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 1 || SP[Lasttapedship] == 2 || SP[Lasttapedship] == 3 || SP[Lasttapedship] == 4 || SP[Lasttapedship] == 5 || SP[Lasttapedship] == 6 || SP[Lasttapedship] == 7 || SP[Lasttapedship] == 8 || SP[Lasttapedship] == 9)
                                    {
                                    }
                                    else
                                    {
                                        LockRec[SP[Lasttapedship] - 9] = false;
                                        //                                  Field1[SP[Lasttapedship] - 9].Fill = Brushes.Azure;
                                    }
                                    //справа снизу
                                    if (SP[Lasttapedship] == 70 || SP[Lasttapedship] == 71 || SP[Lasttapedship] == 72 || SP[Lasttapedship] == 73 || SP[Lasttapedship] == 74 || SP[Lasttapedship] == 75 || SP[Lasttapedship] == 76 || SP[Lasttapedship] == 77 || SP[Lasttapedship] == 78 || SP[Lasttapedship] == 79)
                                    { }
                                    else
                                    {

                                        LockRec[SP[Lasttapedship] + 31] = false;
                                        //                                  Field1[SP[Lasttapedship] + 31].Fill = Brushes.Azure;

                                    }

                                    LockRec[SP[Lasttapedship] + 1] = false;
                                    //                            Field1[SP[Lasttapedship] + 1].Fill = Brushes.Azure;

                                    LockRec[SP[Lasttapedship] + 11] = false;
                                    //                             Field1[SP[Lasttapedship] + 11].Fill = Brushes.Azure;

                                    LockRec[SP[Lasttapedship] + 21] = false;
                                    //                            Field1[SP[Lasttapedship] + 21].Fill = Brushes.Azure;


                                }
                                //справа 
                                if (SP[Lasttapedship] == 70 || SP[Lasttapedship] == 71 || SP[Lasttapedship] == 72 || SP[Lasttapedship] == 73 || SP[Lasttapedship] == 74 || SP[Lasttapedship] == 75 || SP[Lasttapedship] == 76 || SP[Lasttapedship] == 77 || SP[Lasttapedship] == 78 || SP[Lasttapedship] == 79)
                                { }
                                else
                                {

                                    LockRec[SP[Lasttapedship] + 30] = false;
                                    //                           Field1[SP[Lasttapedship] + 30].Fill = Brushes.Azure;

                                }



                                //_____________________________________________________________________________________________

                            }
                        }

                        if (ifvertical[Lasttapedship] == true)
                        {
                            if (SP[Lasttapedship] == 8 || SP[Lasttapedship] == 9 ||
                                 SP[Lasttapedship] == 18 || SP[Lasttapedship] == 19 ||
                                 SP[Lasttapedship] == 28 || SP[Lasttapedship] == 29 ||
                                 SP[Lasttapedship] == 38 || SP[Lasttapedship] == 39 ||
                                 SP[Lasttapedship] == 48 || SP[Lasttapedship] == 49 ||
                                 SP[Lasttapedship] == 58 || SP[Lasttapedship] == 59 ||
                                 SP[Lasttapedship] == 68 || SP[Lasttapedship] == 69 ||
                                 SP[Lasttapedship] == 78 || SP[Lasttapedship] == 79 ||
                                 SP[Lasttapedship] == 88 || SP[Lasttapedship] == 89 ||
                                 SP[Lasttapedship] == 98 || SP[Lasttapedship] == 99)
                            {
                            }
                            else
                            {

                                Field1[SP[Lasttapedship]].Fill = Brushes.Azure;
                                Field1[SP[Lasttapedship] + 1].Fill = Brushes.Azure;
                                Field1[SP[Lasttapedship] + 2].Fill = Brushes.Azure;

                                LockRec[SP[Lasttapedship]] = false;
                                GameRec[SP[Lasttapedship]] = false;

                                LockRec[SP[Lasttapedship] + 1] = false;
                                GameRec[SP[Lasttapedship] + 1] = false;

                                LockRec[SP[Lasttapedship] + 2] = false;
                                GameRec[SP[Lasttapedship] + 2] = false;
                            }

                            // очистка клетки окружающие Destroyer по вертикали
                            //_____________________________________________________________________________________________
                            //сверху
                            if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 10 || SP[Lasttapedship] == 20 || SP[Lasttapedship] == 30 || SP[Lasttapedship] == 40 || SP[Lasttapedship] == 50 || SP[Lasttapedship] == 60 || SP[Lasttapedship] == 70 || SP[Lasttapedship] == 80 || SP[Lasttapedship] == 90)
                            { }
                            else
                            {
                                LockRec[SP[Lasttapedship] - 1] = false;
                                //               Field1[SP[Lasttapedship] - 1].Fill = Brushes.Azure;

                                //слева сверху
                                if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 1 || SP[Lasttapedship] == 2 || SP[Lasttapedship] == 3 || SP[Lasttapedship] == 4 || SP[Lasttapedship] == 5 || SP[Lasttapedship] == 6 || SP[Lasttapedship] == 7 || SP[Lasttapedship] == 8 || SP[Lasttapedship] == 9)
                                { }
                                else
                                {
                                    LockRec[SP[Lasttapedship] - 11] = false;
                                    //                   Field1[SP[Lasttapedship] - 11].Fill = Brushes.Azure;
                                }
                                //справа сверху
                                if (SP[Lasttapedship] == 90 || SP[Lasttapedship] == 91 || SP[Lasttapedship] == 92 || SP[Lasttapedship] == 93 || SP[Lasttapedship] == 94 || SP[Lasttapedship] == 95 || SP[Lasttapedship] == 96 || SP[Lasttapedship] == 97 || SP[Lasttapedship] == 98 || SP[Lasttapedship] == 99)
                                { }
                                else
                                {

                                    LockRec[SP[Lasttapedship] + 9] = false;
                                    //                 Field1[SP[Lasttapedship] + 9].Fill = Brushes.Azure;

                                }
                            }
                            //слева
                            if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 1 || SP[Lasttapedship] == 2 || SP[Lasttapedship] == 3 || SP[Lasttapedship] == 4 || SP[Lasttapedship] == 5 || SP[Lasttapedship] == 6 || SP[Lasttapedship] == 7 || SP[Lasttapedship] == 8 || SP[Lasttapedship] == 9)
                            {
                            }
                            else
                            {
                                LockRec[SP[Lasttapedship] - 10] = false;
                                //              Field1[SP[Lasttapedship] - 10].Fill = Brushes.Azure;

                                LockRec[SP[Lasttapedship] - 9] = false;
                                //                Field1[SP[Lasttapedship] - 9].Fill = Brushes.Azure;

                                LockRec[SP[Lasttapedship] - 8] = false;
                                //               Field1[SP[Lasttapedship] - 8].Fill = Brushes.Azure;

                            }
                            //снизу
                            if (SP[Lasttapedship] == 7 || SP[Lasttapedship] == 17 || SP[Lasttapedship] == 27 || SP[Lasttapedship] == 37 || SP[Lasttapedship] == 47 || SP[Lasttapedship] == 57 || SP[Lasttapedship] == 67 || SP[Lasttapedship] == 77 || SP[Lasttapedship] == 87 || SP[Lasttapedship] == 97)
                            { }
                            else
                            {
                                //слева снизу
                                if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 1 || SP[Lasttapedship] == 2 || SP[Lasttapedship] == 3 || SP[Lasttapedship] == 4 || SP[Lasttapedship] == 5 || SP[Lasttapedship] == 6 || SP[Lasttapedship] == 7 || SP[Lasttapedship] == 8 || SP[Lasttapedship] == 9)
                                {
                                }
                                else
                                {
                                    LockRec[SP[Lasttapedship] - 7] = false;
                                    //                      Field1[SP[Lasttapedship] - 7].Fill = Brushes.Azure;
                                }
                                //справа снизу
                                if (SP[Lasttapedship] == 90 || SP[Lasttapedship] == 91 || SP[Lasttapedship] == 92 || SP[Lasttapedship] == 93 || SP[Lasttapedship] == 94 || SP[Lasttapedship] == 95 || SP[Lasttapedship] == 96 || SP[Lasttapedship] == 97 || SP[Lasttapedship] == 98 || SP[Lasttapedship] == 99)
                                { }
                                else
                                {

                                    LockRec[SP[Lasttapedship] + 13] = false;
                                    //                   Field1[SP[Lasttapedship] + 13].Fill = Brushes.Azure;

                                }

                                LockRec[SP[Lasttapedship] + 3] = false;
                                //              Field1[SP[Lasttapedship] + 3].Fill = Brushes.Azure;


                            }
                            //справа 
                            if (SP[Lasttapedship] == 90 || SP[Lasttapedship] == 91 || SP[Lasttapedship] == 92 || SP[Lasttapedship] == 93 || SP[Lasttapedship] == 94 || SP[Lasttapedship] == 95 || SP[Lasttapedship] == 96 || SP[Lasttapedship] == 97 || SP[Lasttapedship] == 98 || SP[Lasttapedship] == 99)
                            { }
                            else
                            {

                                LockRec[SP[Lasttapedship] + 10] = false;
                                //              Field1[SP[Lasttapedship] + 10].Fill = Brushes.Azure;

                                LockRec[SP[Lasttapedship] + 11] = false;
                                //             Field1[SP[Lasttapedship] + 11].Fill = Brushes.Azure;

                                LockRec[SP[Lasttapedship] + 12] = false;
                                //               Field1[SP[Lasttapedship] + 12].Fill = Brushes.Azure;


                            }



                            //_____________________________________________________________________________________________

                        }
                    }
            }
        }


        private void LodkaMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ifGameStarted == false)
            {
                Lasttapedship = Convert.ToInt32(((Image)sender).Tag);
                ifMouseClicked[Lasttapedship] = true;
                Canvas.SetZIndex(Ships[Lasttapedship], 1);

                if (SP[Lasttapedship] != -1)
                    if (LockRec[LastActiveRectangle] != true)
                    {

                        //Очистка поля при повторном перемещении Destroyer
                        if (ifvertical[Lasttapedship] == false)
                        {
                            if (SP[Lasttapedship] == 90 ||
                                 SP[Lasttapedship] == 91 ||
                                 SP[Lasttapedship] == 92 ||
                                 SP[Lasttapedship] == 93 ||
                                 SP[Lasttapedship] == 94 ||
                                 SP[Lasttapedship] == 95 ||
                                 SP[Lasttapedship] == 96 ||
                                 SP[Lasttapedship] == 97 ||
                                 SP[Lasttapedship] == 98 ||
                                 SP[Lasttapedship] == 99)
                            {
                            }
                            else
                            {
                                Field1[SP[Lasttapedship]].Fill = Brushes.Azure;
                                Field1[SP[Lasttapedship] + 10].Fill = Brushes.Azure;

                                LockRec[SP[Lasttapedship]] = false;
                                GameRec[SP[Lasttapedship]] = false;

                                LockRec[SP[Lasttapedship] + 10] = false;
                                GameRec[SP[Lasttapedship] + 10] = false;
                                // очистка клетки окружающие Lodka по горизонтали
                                //_____________________________________________________________________________________________
                                //сверху
                                if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 10 || SP[Lasttapedship] == 20 || SP[Lasttapedship] == 30 || SP[Lasttapedship] == 40 || SP[Lasttapedship] == 50 || SP[Lasttapedship] == 60 || SP[Lasttapedship] == 70 || SP[Lasttapedship] == 80 || SP[Lasttapedship] == 90)
                                { }
                                else
                                {
                                    LockRec[SP[Lasttapedship] - 1] = false;
                                    //               Field1[SP[Lasttapedship] - 1].Fill = Brushes.Azure;

                                    LockRec[SP[Lasttapedship] + 9] = false;
                                    //                 Field1[SP[Lasttapedship] + 9].Fill = Brushes.Azure;


                                    //слева сверху
                                    if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 1 || SP[Lasttapedship] == 2 || SP[Lasttapedship] == 3 || SP[Lasttapedship] == 4 || SP[Lasttapedship] == 5 || SP[Lasttapedship] == 6 || SP[Lasttapedship] == 7 || SP[Lasttapedship] == 8 || SP[Lasttapedship] == 9)
                                    { }
                                    else
                                    {
                                        LockRec[SP[Lasttapedship] - 11] = false;
                                        //                  Field1[SP[Lasttapedship] - 11].Fill = Brushes.Azure;
                                    }
                                    //справа сверху
                                    if (SP[Lasttapedship] == 80 || SP[Lasttapedship] == 81 || SP[Lasttapedship] == 82 || SP[Lasttapedship] == 83 || SP[Lasttapedship] == 84 || SP[Lasttapedship] == 85 || SP[Lasttapedship] == 86 || SP[Lasttapedship] == 87 || SP[Lasttapedship] == 88 || SP[Lasttapedship] == 89)
                                    { }
                                    else
                                    {

                                        LockRec[SP[Lasttapedship] + 19] = false;
                                        //                Field1[SP[Lasttapedship] + 19].Fill = Brushes.Azure;

                                    }
                                }
                                //слева
                                if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 1 || SP[Lasttapedship] == 2 || SP[Lasttapedship] == 3 || SP[Lasttapedship] == 4 || SP[Lasttapedship] == 5 || SP[Lasttapedship] == 6 || SP[Lasttapedship] == 7 || SP[Lasttapedship] == 8 || SP[Lasttapedship] == 9)
                                {
                                }
                                else
                                {
                                    LockRec[SP[Lasttapedship] - 10] = false;
                                    //               Field1[SP[Lasttapedship] - 10].Fill = Brushes.Azure;
                                }
                                //снизу
                                if (SP[Lasttapedship] == 9 || SP[Lasttapedship] == 19 || SP[Lasttapedship] == 29 || SP[Lasttapedship] == 39 || SP[Lasttapedship] == 49 || SP[Lasttapedship] == 59 || SP[Lasttapedship] == 69 || SP[Lasttapedship] == 79 || SP[Lasttapedship] == 89 || SP[Lasttapedship] == 99)
                                { }
                                else
                                {
                                    //слева снизу
                                    if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 1 || SP[Lasttapedship] == 2 || SP[Lasttapedship] == 3 || SP[Lasttapedship] == 4 || SP[Lasttapedship] == 5 || SP[Lasttapedship] == 6 || SP[Lasttapedship] == 7 || SP[Lasttapedship] == 8 || SP[Lasttapedship] == 9)
                                    {
                                    }
                                    else
                                    {
                                        LockRec[SP[Lasttapedship] - 9] = false;
                                        //                 Field1[SP[Lasttapedship] - 9].Fill = Brushes.Azure;
                                    }
                                    //справа снизу
                                    if (SP[Lasttapedship] == 80 || SP[Lasttapedship] == 81 || SP[Lasttapedship] == 82 || SP[Lasttapedship] == 83 || SP[Lasttapedship] == 84 || SP[Lasttapedship] == 85 || SP[Lasttapedship] == 86 || SP[Lasttapedship] == 87 || SP[Lasttapedship] == 88 || SP[Lasttapedship] == 89)
                                    { }
                                    else
                                    {

                                        LockRec[SP[Lasttapedship] + 21] = false;
                                        //                    Field1[SP[Lasttapedship] + 21].Fill = Brushes.Azure;

                                    }

                                    LockRec[SP[Lasttapedship] + 1] = false;
                                    //            Field1[SP[Lasttapedship] + 1].Fill = Brushes.Azure;

                                    LockRec[SP[Lasttapedship] + 11] = false;
                                    //            Field1[SP[Lasttapedship] + 11].Fill = Brushes.Azure;

                                }
                                //справа 
                                if (SP[Lasttapedship] == 80 || SP[Lasttapedship] == 81 || SP[Lasttapedship] == 82 || SP[Lasttapedship] == 83 || SP[Lasttapedship] == 84 || SP[Lasttapedship] == 85 || SP[Lasttapedship] == 86 || SP[Lasttapedship] == 87 || SP[Lasttapedship] == 88 || SP[Lasttapedship] == 89)
                                { }
                                else
                                {

                                    LockRec[SP[Lasttapedship] + 20] = false;
                                    //             Field1[SP[Lasttapedship] + 20].Fill = Brushes.Azure;

                                }

                                //_____________________________________________________________________________________________
                            }
                        }

                        if (ifvertical[Lasttapedship] == true)
                        {
                            if (SP[Lasttapedship] == 9 ||
                                 SP[Lasttapedship] == 19 ||
                                 SP[Lasttapedship] == 29 ||
                                 SP[Lasttapedship] == 39 ||
                                 SP[Lasttapedship] == 49 ||
                                 SP[Lasttapedship] == 59 ||
                                 SP[Lasttapedship] == 69 ||
                                 SP[Lasttapedship] == 79 ||
                                 SP[Lasttapedship] == 89 ||
                                 SP[Lasttapedship] == 99)
                            {
                            }
                            else
                            {

                                Field1[SP[Lasttapedship]].Fill = Brushes.Azure;
                                Field1[SP[Lasttapedship] + 1].Fill = Brushes.Azure;

                                LockRec[SP[Lasttapedship]] = false;
                                GameRec[SP[Lasttapedship]] = false;

                                LockRec[SP[Lasttapedship] + 1] = false;
                                GameRec[SP[Lasttapedship] + 1] = false;

                                // очистка клетки окружающие Lodka по вертикали
                                //_____________________________________________________________________________________________
                                //сверху
                                if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 10 || SP[Lasttapedship] == 20 || SP[Lasttapedship] == 30 || SP[Lasttapedship] == 40 || SP[Lasttapedship] == 50 || SP[Lasttapedship] == 60 || SP[Lasttapedship] == 70 || SP[Lasttapedship] == 80 || SP[Lasttapedship] == 90)
                                { }
                                else
                                {
                                    LockRec[SP[Lasttapedship] - 1] = false;
                                    //                    Field1[SP[Lasttapedship] - 1].Fill = Brushes.Azure;

                                    //слева сверху
                                    if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 1 || SP[Lasttapedship] == 2 || SP[Lasttapedship] == 3 || SP[Lasttapedship] == 4 || SP[Lasttapedship] == 5 || SP[Lasttapedship] == 6 || SP[Lasttapedship] == 7 || SP[Lasttapedship] == 8 || SP[Lasttapedship] == 9)
                                    { }
                                    else
                                    {
                                        LockRec[SP[Lasttapedship] - 11] = false;
                                        //                       Field1[SP[Lasttapedship] - 11].Fill = Brushes.Azure;
                                    }
                                    //справа сверху
                                    if (SP[Lasttapedship] == 90 || SP[Lasttapedship] == 91 || SP[Lasttapedship] == 92 || SP[Lasttapedship] == 93 || SP[Lasttapedship] == 94 || SP[Lasttapedship] == 95 || SP[Lasttapedship] == 96 || SP[Lasttapedship] == 97 || SP[Lasttapedship] == 98 || SP[Lasttapedship] == 99)
                                    { }
                                    else
                                    {

                                        LockRec[SP[Lasttapedship] + 9] = false;
                                        //                        Field1[SP[Lasttapedship] + 9].Fill = Brushes.Azure;

                                    }
                                }
                                //слева
                                if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 1 || SP[Lasttapedship] == 2 || SP[Lasttapedship] == 3 || SP[Lasttapedship] == 4 || SP[Lasttapedship] == 5 || SP[Lasttapedship] == 6 || SP[Lasttapedship] == 7 || SP[Lasttapedship] == 8 || SP[Lasttapedship] == 9)
                                {
                                }
                                else
                                {
                                    LockRec[SP[Lasttapedship] - 10] = false;
                                    //             Field1[SP[Lasttapedship] - 10].Fill = Brushes.Azure;

                                    LockRec[SP[Lasttapedship] - 9] = false;
                                    //              Field1[SP[Lasttapedship] - 9].Fill = Brushes.Azure;


                                }
                                //снизу
                                if (SP[Lasttapedship] == 8 || SP[Lasttapedship] == 18 || SP[Lasttapedship] == 28 || SP[Lasttapedship] == 38 || SP[Lasttapedship] == 48 || SP[Lasttapedship] == 58 || SP[Lasttapedship] == 68 || SP[Lasttapedship] == 78 || SP[Lasttapedship] == 88 || SP[Lasttapedship] == 98)
                                { }
                                else
                                {
                                    //слева снизу
                                    if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 1 || SP[Lasttapedship] == 2 || SP[Lasttapedship] == 3 || SP[Lasttapedship] == 4 || SP[Lasttapedship] == 5 || SP[Lasttapedship] == 6 || SP[Lasttapedship] == 7 || SP[Lasttapedship] == 8 || SP[Lasttapedship] == 9)
                                    {
                                    }
                                    else
                                    {
                                        LockRec[SP[Lasttapedship] - 8] = false;
                                        //                    Field1[SP[Lasttapedship] - 8].Fill = Brushes.Azure;
                                    }
                                    //справа снизу
                                    if (SP[Lasttapedship] == 90 || SP[Lasttapedship] == 91 || SP[Lasttapedship] == 92 || SP[Lasttapedship] == 93 || SP[Lasttapedship] == 94 || SP[Lasttapedship] == 95 || SP[Lasttapedship] == 96 || SP[Lasttapedship] == 97 || SP[Lasttapedship] == 98 || SP[Lasttapedship] == 99)
                                    { }
                                    else
                                    {

                                        LockRec[SP[Lasttapedship] + 12] = false;
                                        //                   Field1[SP[Lasttapedship] + 12].Fill = Brushes.Azure;

                                    }

                                    LockRec[SP[Lasttapedship] + 2] = false;
                                    //               Field1[SP[Lasttapedship] + 2].Fill = Brushes.Azure;


                                }
                                //справа 
                                if (SP[Lasttapedship] == 90 || SP[Lasttapedship] == 91 || SP[Lasttapedship] == 92 || SP[Lasttapedship] == 93 || SP[Lasttapedship] == 94 || SP[Lasttapedship] == 95 || SP[Lasttapedship] == 96 || SP[Lasttapedship] == 97 || SP[Lasttapedship] == 98 || SP[Lasttapedship] == 99)
                                { }
                                else
                                {

                                    LockRec[SP[Lasttapedship] + 10] = false;
                                    //              Field1[SP[Lasttapedship] + 10].Fill = Brushes.Azure;


                                    LockRec[SP[Lasttapedship] + 11] = false;
                                    //               Field1[SP[Lasttapedship] + 11].Fill = Brushes.Azure;


                                }

                                //_____________________________________________________________________________________________
                            }

                        }
                    }
            }
        }


        private void MiniMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ifGameStarted == false)
            {
                Lasttapedship = Convert.ToInt32(((Image)sender).Tag);
                ifMouseClicked[Lasttapedship] = true;
                Canvas.SetZIndex(Ships[Lasttapedship], 1);

                if (SP[Lasttapedship] != -1)
                    if (LockRec[SP[Lasttapedship]] != true)
                    {
                        //Очистка поля при повторном перемещении Destroyer


                        Field1[SP[Lasttapedship]].Fill = Brushes.Azure;
                        GameRec[SP[Lasttapedship]] = false;
                        // клетки окружающие Mini по горизонтали
                        //_____________________________________________________________________________________________
                        //сверху
                        if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 10 || SP[Lasttapedship] == 20 || SP[Lasttapedship] == 30 || SP[Lasttapedship] == 40 || SP[Lasttapedship] == 50 || SP[Lasttapedship] == 60 || SP[Lasttapedship] == 70 || SP[Lasttapedship] == 80 || SP[Lasttapedship] == 90)
                        { }
                        else
                        {
                            LockRec[SP[Lasttapedship] - 1] = false;
                            //        Field1[SP[Lasttapedship] - 1].Fill = Brushes.Azure;


                            //слева сверху
                            if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 1 || SP[Lasttapedship] == 2 || SP[Lasttapedship] == 3 || SP[Lasttapedship] == 4 || SP[Lasttapedship] == 5 || SP[Lasttapedship] == 6 || SP[Lasttapedship] == 7 || SP[Lasttapedship] == 8 || SP[Lasttapedship] == 9)
                            { }
                            else
                            {
                                LockRec[SP[Lasttapedship] - 11] = false;
                                //               Field1[SP[Lasttapedship] - 11].Fill = Brushes.Azure;
                            }
                            //справа сверху
                            if (SP[Lasttapedship] == 90 || SP[Lasttapedship] == 91 || SP[Lasttapedship] == 92 || SP[Lasttapedship] == 93 || SP[Lasttapedship] == 94 || SP[Lasttapedship] == 95 || SP[Lasttapedship] == 96 || SP[Lasttapedship] == 97 || SP[Lasttapedship] == 98 || SP[Lasttapedship] == 99)
                            { }
                            else
                            {

                                LockRec[SP[Lasttapedship] + 9] = false;
                                //                Field1[SP[Lasttapedship] + 9].Fill = Brushes.Azure;

                            }
                        }
                        //слева
                        if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 1 || SP[Lasttapedship] == 2 || SP[Lasttapedship] == 3 || SP[Lasttapedship] == 4 || SP[Lasttapedship] == 5 || SP[Lasttapedship] == 6 || SP[Lasttapedship] == 7 || SP[Lasttapedship] == 8 || SP[Lasttapedship] == 9)
                        {
                        }
                        else
                        {
                            LockRec[SP[Lasttapedship] - 10] = false;
                            //            Field1[SP[Lasttapedship] - 10].Fill = Brushes.Azure;
                        }
                        //снизу
                        if (SP[Lasttapedship] == 9 || SP[Lasttapedship] == 19 || SP[Lasttapedship] == 29 || SP[Lasttapedship] == 39 || SP[Lasttapedship] == 49 || SP[Lasttapedship] == 59 || SP[Lasttapedship] == 69 || SP[Lasttapedship] == 79 || SP[Lasttapedship] == 89 || SP[Lasttapedship] == 99)
                        { }
                        else
                        {
                            //слева снизу
                            if (SP[Lasttapedship] == 0 || SP[Lasttapedship] == 1 || SP[Lasttapedship] == 2 || SP[Lasttapedship] == 3 || SP[Lasttapedship] == 4 || SP[Lasttapedship] == 5 || SP[Lasttapedship] == 6 || SP[Lasttapedship] == 7 || SP[Lasttapedship] == 8 || SP[Lasttapedship] == 9)
                            {
                            }
                            else
                            {
                                LockRec[SP[Lasttapedship] - 9] = false;
                                //             Field1[SP[Lasttapedship] - 9].Fill = Brushes.Azure;
                            }
                            //справа снизу
                            if (SP[Lasttapedship] == 90 || SP[Lasttapedship] == 91 || SP[Lasttapedship] == 92 || SP[Lasttapedship] == 93 || SP[Lasttapedship] == 94 || SP[Lasttapedship] == 95 || SP[Lasttapedship] == 96 || SP[Lasttapedship] == 97 || SP[Lasttapedship] == 98 || SP[Lasttapedship] == 99)
                            { }
                            else
                            {

                                LockRec[SP[Lasttapedship] + 11] = false;
                                //              Field1[SP[Lasttapedship] + 11].Fill = Brushes.Azure;

                            }

                            LockRec[SP[Lasttapedship] + 1] = false;
                            //         Field1[SP[Lasttapedship] + 1].Fill = Brushes.Azure;



                        }
                        //справа 
                        if (SP[Lasttapedship] == 90 || SP[Lasttapedship] == 91 || SP[Lasttapedship] == 92 || SP[Lasttapedship] == 93 || SP[Lasttapedship] == 94 || SP[Lasttapedship] == 95 || SP[Lasttapedship] == 96 || SP[Lasttapedship] == 97 || SP[Lasttapedship] == 98 || SP[Lasttapedship] == 99)
                        { }
                        else
                        {

                            LockRec[SP[Lasttapedship] + 10] = false;
                            //         Field1[SP[Lasttapedship] + 10].Fill = Brushes.Azure;

                        }

                        //_____________________________________________________________________________________________



                    }
            }
        }


        //Перемещение корабля с мышкой
        private void AMM(object sender, MouseEventArgs e)
        {

            if (ifMouseClicked[0] == true)
            {
               
                Positions[Lasttapedship] = e.GetPosition(this);
                if (ifvertical[Lasttapedship] == false)
                {
                    Canvas.SetLeft(Avia, Positions[0].X -= 155);
                    Canvas.SetTop(Avia, Positions[0].Y -= 220);
                }
                else
                {
                    Canvas.SetLeft(Avia, Positions[0].X -= 150);
                    Canvas.SetTop(Avia, Positions[0].Y -= 215);
                }
                ShipsLeft[0] = Positions[0].X;
                ShipsTop[0] = Positions[0].Y;
               
            }
        }
        //______________________________________________________________________________________________________________________________________________
        private void MouseLeftButtonUP(object sender, MouseButtonEventArgs e)
        {
            ifMouseClicked[Lasttapedship] = false;
            //Проверка на расположение корабля в field1
            if (e.GetPosition(this).X <= 500 && e.GetPosition(this).X >= 160 && e.GetPosition(this).Y >= 220 && e.GetPosition(this).Y <= 530)
            Ships[Lasttapedship].IsHitTestVisible = Convert.ToBoolean("False");
            Lock1 = true;
            Canvas.SetZIndex(Ships[Lasttapedship], 5);
        }
        //_______________________________________________________________________________________________________________________________________________

        //Перемещение корабля с мышкой
        private void DMM(object sender, MouseEventArgs e)
        {

            if (ifMouseClicked[1] == true || ifMouseClicked[2] == true)
            {
                 Positions[Lasttapedship] = e.GetPosition(this);
                if (ifvertical[Lasttapedship] == false)
                {
                    Canvas.SetLeft(Ships[Lasttapedship], Positions[Lasttapedship].X -= 160);
                    Canvas.SetTop(Ships[Lasttapedship], Positions[Lasttapedship].Y -= 220);
                }
                else
                {
                    Canvas.SetLeft(Ships[Lasttapedship], Positions[Lasttapedship].X -= 160);
                    Canvas.SetTop(Ships[Lasttapedship], Positions[Lasttapedship].Y -= 210);
                }
                ShipsLeft[Lasttapedship] = Positions[Lasttapedship].X;
                ShipsTop[Lasttapedship] = Positions[Lasttapedship].Y;
            }
        }

        //Перемещение корабля с мышкой
        private void LMM(object sender, MouseEventArgs e)
        {
 
            if (ifMouseClicked[3] == true || ifMouseClicked[4] == true || ifMouseClicked[5] == true)
            {
                Positions[Lasttapedship] = e.GetPosition(this);
                if (ifvertical[Lasttapedship] == false)
                {
                    Canvas.SetLeft(Ships[Lasttapedship], Positions[Lasttapedship].X -= 160);
                    Canvas.SetTop(Ships[Lasttapedship], Positions[Lasttapedship].Y -= 210);
                }
                else
                {
                    Canvas.SetLeft(Ships[Lasttapedship], Positions[Lasttapedship].X -= 155);
                    Canvas.SetTop(Ships[Lasttapedship], Positions[Lasttapedship].Y -= 220);
                }
                ShipsLeft[Lasttapedship] = Positions[Lasttapedship].X;
                ShipsTop[Lasttapedship] = Positions[Lasttapedship].Y;
            }
        }

        //Перемещение корабля с мышкой
        private void MMM(object sender, MouseEventArgs e)
        {

            if (ifMouseClicked[6] == true || ifMouseClicked[7] == true || ifMouseClicked[8] == true || ifMouseClicked[9] == true)
            {
                Positions[Lasttapedship] = e.GetPosition(this);
                if (ifvertical[Lasttapedship] == false)
                {
                    Canvas.SetLeft(Ships[Lasttapedship], Positions[Lasttapedship].X -= 155);
                    Canvas.SetTop(Ships[Lasttapedship], Positions[Lasttapedship].Y -= 215);
                }
                else
                {
                    Canvas.SetLeft(Ships[Lasttapedship], Positions[Lasttapedship].X -= 160);
                    Canvas.SetTop(Ships[Lasttapedship], Positions[Lasttapedship].Y -= 210);
                }
                ShipsLeft[Lasttapedship] = Positions[Lasttapedship].X;
                ShipsTop[Lasttapedship] = Positions[Lasttapedship].Y;
            }
        }

        private void RectangleMouseEnter(object sender, MouseEventArgs e)
        {

            ActiveRectangle = Convert.ToInt32(((Rectangle)sender).Tag);
            if (Lock1 == true)
            {
                LastActiveRectangle = ActiveRectangle;
                Lock1 = false;
            }
            //Возвращает возможность кликнуть на корабль
            Ships[Lasttapedship].IsHitTestVisible = Convert.ToBoolean("true");
            SP[Lasttapedship] = LastActiveRectangle;
        }

        //Кнопка подсказки
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            form1.Show();
        }

        //--------------------------------------------------------------------------------

        /// <summary>
        ///          _________________________________________________Процесс игры_____________________________________________________________
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        
        private void timerTickGame(object sender, EventArgs e)
        {
            if (ifGameStarted)
            {
                if (AIAttack == true)
                {
                    if (DoubleAttack == true)
                    {
                        if (AUp == false && AIAttack == true)
                        {
                            //вверх
                           
                            if (random == 0 || random == 10 || random == 20 || random == 30 || random  == 40 || random == 50 || random == 60 || random == 70 || random == 80 || random == 90)
                            {
                                AUp = true;
                            }
                            else
                                remember = random - 1;
                            if (AttackedRec[remember] == true)
                            {
                                AUp = true;
                            }
                            else
                            {
                                if (GameRec[remember] == false)
                                {


                                    Image newImage = new Image();
                                    Opoints0.Add(newImage);

                                    Opoints0[op0].Width = 30;
                                    Opoints0[op0].Height = 28;
                                    ol0 = Canvas.GetLeft(Field1[remember]);
                                    ov0 = Canvas.GetTop(Field1[remember]);
                                    Canvas.SetLeft(Opoints0[op0], ol0);
                                    Canvas.SetTop(Opoints0[op0], ov0);

                                    Fi1.Children.Add(newImage);
                                    Opoints0[op0].Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/O.png"));
                                    op0++;

                                    AttackedRec[remember] = true;
                                    AIAttack = false;
                                    YourAttack = true;
                                    AUp = true;
                                }
                                else
                                {
                                    while (GameRec[remember] == true && AttackedRec[remember] == false)
                                    {
                                        GameRec[remember] = false;
                                        Image newImage = new Image();
                                        Xpoints0.Add(newImage);

                                        Xpoints0[xp0].Width = 30;
                                        Xpoints0[xp0].Height = 28;
                                        xl0 = Canvas.GetLeft(Field1[remember]);
                                        xv0 = Canvas.GetTop(Field1[remember]);
                                        Canvas.SetLeft(Xpoints0[xp0], xl0);
                                        Canvas.SetTop(Xpoints0[xp0], xv0);

                                        Fi1.Children.Add(newImage);
                                        Xpoints0[xp0].Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/X.png"));
                                        xp0++;
                                        GameRec[remember] = false;

                                        AttackedRec[remember] = true;
                                        if (remember == 0 || remember == 10 || remember == 20 || remember == 30 || remember == 40 || remember == 50 || remember == 60 || remember == 70 || remember == 80 || remember == 90)
                                        { }
                                        else
                                        {
                                          
                                            remember -= 1;
                                    
                                        }
                                        
                                    }

                                    Image newImage1 = new Image();
                                    Opoints0.Add(newImage1);

                                    Opoints0[op0].Width = 30;
                                    Opoints0[op0].Height = 28;
                                    ol0 = Canvas.GetLeft(Field1[remember]);
                                    ov0 = Canvas.GetTop(Field1[remember]);
                                    Canvas.SetLeft(Opoints0[op0], ol0);
                                    Canvas.SetTop(Opoints0[op0], ov0);

                                    Fi1.Children.Add(newImage1);
                                    Opoints0[op0].Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/O.png"));
                                    op0++;

                                    AttackedRec[remember] = true;
                                    YourAttack = true;
                                    AIAttack = false;
                                    VerticalStrategy = true;
                                    ALeft = true;
                                    GameRec[remember] = false;
                                }
                            }
                        }

                        if (ALeft == false && AIAttack == true)
                        {
                            //Влево    
                            if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9)
                            {
                                ALeft = true;
                            }
                            else
                                remember = random - 10;
                            if (AttackedRec[remember] == true)
                            {
                                ALeft = true;
                            }
                            else
                            {
                                if (GameRec[remember] == false)
                                {


                                    Image newImage = new Image();
                                    Opoints0.Add(newImage);

                                    Opoints0[op0].Width = 30;
                                    Opoints0[op0].Height = 28;
                                    ol0 = Canvas.GetLeft(Field1[remember]);
                                    ov0 = Canvas.GetTop(Field1[remember]);
                                    Canvas.SetLeft(Opoints0[op0], ol0);
                                    Canvas.SetTop(Opoints0[op0], ov0);

                                    Fi1.Children.Add(newImage);
                                    Opoints0[op0].Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/O.png"));
                                    op0++;

                                    AttackedRec[remember] = true;
                                    AIAttack = false;
                                    YourAttack = true;
                                    ALeft = true;
                                }
                                else
                                {
                                    while (GameRec[remember] == true && AttackedRec[remember] == false)
                                    {
                                        GameRec[remember] = false;
                                        Image newImage = new Image();
                                        Xpoints0.Add(newImage);

                                        Xpoints0[xp0].Width = 30;
                                        Xpoints0[xp0].Height = 28;
                                        xl0 = Canvas.GetLeft(Field1[remember]);
                                        xv0 = Canvas.GetTop(Field1[remember]);
                                        Canvas.SetLeft(Xpoints0[xp0], xl0);
                                        Canvas.SetTop(Xpoints0[xp0], xv0);

                                        Fi1.Children.Add(newImage);
                                        Xpoints0[xp0].Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/X.png"));
                                        xp0++;
                                        GameRec[remember] = false;

                                        AttackedRec[remember] = true;
                                        if (remember == 0 || remember == 1 || remember == 2 || remember == 3 || remember == 4 || remember == 5 || remember == 6 || remember == 7 || remember == 8 || remember == 9)
                                        { }
                                        else
                                        {
                                           
                                            remember -= 10;
                                         
                                        }
                                       
                                    }

                                    Image newImage1 = new Image();
                                    Opoints0.Add(newImage1);

                                    Opoints0[op0].Width = 30;
                                    Opoints0[op0].Height = 28;
                                    ol0 = Canvas.GetLeft(Field1[remember]);
                                    ov0 = Canvas.GetTop(Field1[remember]);
                                    Canvas.SetLeft(Opoints0[op0], ol0);
                                    Canvas.SetTop(Opoints0[op0], ov0);

                                    Fi1.Children.Add(newImage1);
                                    Opoints0[op0].Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/O.png"));
                                    op0++;

                                    AttackedRec[remember] = true;
                                    YourAttack = true;
                                    AIAttack = false;
                                    HorizontalStrategy = true;
                                    ALeft = true;
                                    GameRec[remember] = false;

                                }
                            }

                        }


                        if (ADown == false && AIAttack == true)
                        {
                            //Вниз
                            if (random == 9 || random == 19 || random == 29 || random == 39 || random == 49 || random == 59 || random == 69 || random == 79 || random == 89 || random == 99)
                            {
                                ADown = true;
                                VerticalStrategy = false;
                            }
                            else
                                remember = random + 1;
                            if (AttackedRec[remember] == true)
                            {
                                ADown = true;
                                VerticalStrategy = false;
                            }
                            else
                            {
                                if (GameRec[remember] == false)
                                {


                                    Image newImage = new Image();
                                    Opoints0.Add(newImage);

                                    Opoints0[op0].Width = 30;
                                    Opoints0[op0].Height = 28;
                                    ol0 = Canvas.GetLeft(Field1[remember]);
                                    ov0 = Canvas.GetTop(Field1[remember]);
                                    Canvas.SetLeft(Opoints0[op0], ol0);
                                    Canvas.SetTop(Opoints0[op0], ov0);

                                    Fi1.Children.Add(newImage);
                                    Opoints0[op0].Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/O.png"));
                                    op0++;

                                    AttackedRec[remember] = true;
                                    AIAttack = false;
                                    YourAttack = true;
                                    ADown = true;
                                    VerticalStrategy = false;
                                }
                                else
                                {
                                    while (GameRec[remember] == true && AttackedRec[remember] == false)
                                    {
                                        GameRec[remember] = false;
                                        Image newImage = new Image();
                                        Xpoints0.Add(newImage);

                                        Xpoints0[xp0].Width = 30;
                                        Xpoints0[xp0].Height = 28;
                                        xl0 = Canvas.GetLeft(Field1[remember]);
                                        xv0 = Canvas.GetTop(Field1[remember]);
                                        Canvas.SetLeft(Xpoints0[xp0], xl0);
                                        Canvas.SetTop(Xpoints0[xp0], xv0);

                                        Fi1.Children.Add(newImage);
                                        Xpoints0[xp0].Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/X.png"));
                                        xp0++;
                                        GameRec[remember] = false;

                                        AttackedRec[remember] = true;
                                        if (remember == 9 || remember == 19 || remember == 29 || remember == 39 || remember == 49 || remember == 59 || remember == 69 || remember == 79 || remember == 89 || remember == 99)
                                        { }
                                        else
                                        {
                                            
                                            remember += 1;
                                            
                                        }
                                      
                                    }

                                    Image newImage1 = new Image();
                                    Opoints0.Add(newImage1);

                                    Opoints0[op0].Width = 30;
                                    Opoints0[op0].Height = 28;
                                    ol0 = Canvas.GetLeft(Field1[remember]);
                                    ov0 = Canvas.GetTop(Field1[remember]);
                                    Canvas.SetLeft(Opoints0[op0], ol0);
                                    Canvas.SetTop(Opoints0[op0], ov0);

                                    Fi1.Children.Add(newImage1);
                                    Opoints0[op0].Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/O.png"));
                                    op0++;

                                    AttackedRec[remember] = true;
                                    YourAttack = true;
                                    AIAttack = false;
                                    ADown = true;
                                    if (VerticalStrategy == true)
                                    {
                                        ARight = true;
                                        VerticalStrategy = false;
                                    }
                                    GameRec[remember] = false;
                                }
                            }
                        }

                            if (ARight == false && AIAttack == true && VerticalStrategy == false)
                            {

                                //Вправо
                                if (random == 90 || random == 91 || random == 92 || random == 93 || random == 94 || random == 95 || random == 96 || random == 97 || random == 98 || random == 99)
                                {
                                    ARight = true;
                                    HorizontalStrategy = false;
                                    ARight = true;
                                    
                                    DoubleAttack = false;
                                }
                                else
                                    remember = random + 10;
                                if (AttackedRec[remember] == true)
                                {
                                    ADown = true;
                                    HorizontalStrategy = false;

                                    ARight = true;
                                }
                                else
                                {
                                    if (GameRec[remember] == false)
                                    {


                                        Image newImage = new Image();
                                        Opoints0.Add(newImage);

                                        Opoints0[op0].Width = 30;
                                        Opoints0[op0].Height = 28;
                                        ol0 = Canvas.GetLeft(Field1[remember]);
                                        ov0 = Canvas.GetTop(Field1[remember]);
                                        Canvas.SetLeft(Opoints0[op0], ol0);
                                        Canvas.SetTop(Opoints0[op0], ov0);

                                        Fi1.Children.Add(newImage);
                                        Opoints0[op0].Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/O.png"));
                                        op0++;

                                        AttackedRec[remember] = true;
                                        AIAttack = false;
                                        YourAttack = true;
                                        ARight = true;
                                        HorizontalStrategy = false;
                                        GameRec[random] = false;

                                }
                                    else
                                    {
                                        while (GameRec[remember] == true && AttackedRec[remember] == false)
                                        {
                                        GameRec[remember] = false;
                                        Image newImage = new Image();
                                            Xpoints0.Add(newImage);

                                            Xpoints0[xp0].Width = 30;
                                            Xpoints0[xp0].Height = 28;
                                            xl0 = Canvas.GetLeft(Field1[remember]);
                                            xv0 = Canvas.GetTop(Field1[remember]);
                                            Canvas.SetLeft(Xpoints0[xp0], xl0);
                                            Canvas.SetTop(Xpoints0[xp0], xv0);

                                            Fi1.Children.Add(newImage);
                                            Xpoints0[xp0].Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/X.png"));
                                            xp0++;
                                            GameRec[remember] = false;

                                            AttackedRec[remember] = true;
                                            if (remember == 90 || remember == 91 || remember == 92 || remember == 93 || remember == 94 || remember == 95 || remember == 96 || remember == 97 || remember == 98 || remember == 99)
                                            { }
                                            else
                                            {
                                           
                                            remember += 10;
                                           
                                            }
                                      
                                        }

                                       
                                        Image newImage1 = new Image();
                                        Opoints0.Add(newImage1);

                                        Opoints0[op0].Width = 30;
                                        Opoints0[op0].Height = 28;
                                        ol0 = Canvas.GetLeft(Field1[remember]);
                                        ov0 = Canvas.GetTop(Field1[remember]);
                                        Canvas.SetLeft(Opoints0[op0], ol0);
                                        Canvas.SetTop(Opoints0[op0], ov0);

                                        Fi1.Children.Add(newImage1);
                                        Opoints0[op0].Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/O.png"));
                                        op0++;
                                        
                                        AttackedRec[remember] = true;
                                        ARight = true;
                                        HorizontalStrategy = false;
                                        GameRec[remember] = false;
                               

                                }
                                }
                            }
                        
                       

                        if (AUp == true && ALeft == true && ADown == true && ARight == true)
                        {
                            //______________________________________________
                            AUp = false;
                            ALeft = false;
                            ADown = false;
                            ARight = false;

                            YourAttack = true;
                            AIAttack = false;
                            DoubleAttack = false;
                            //_______________________________________________
                        }
                    }
                    else
                    {
                       


                            while (AttackedRec[random] == true)
                            {
                                random = rnd.Next(0, 100);
                            }


                            if (GameRec[random] == false )
                            {
                                {
                                    Image newImage = new Image();
                                    Opoints0.Add(newImage);

                                    Opoints0[op0].Width = 30;
                                    Opoints0[op0].Height = 28;
                                    ol0 = Canvas.GetLeft(Field1[random]);
                                    ov0 = Canvas.GetTop(Field1[random]);
                                    Canvas.SetLeft(Opoints0[op0], ol0);
                                    Canvas.SetTop(Opoints0[op0], ov0);

                                    Fi1.Children.Add(newImage);
                                    Opoints0[op0].Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/O.png"));
                                    op0++;

                                    AttackedRec[random] = true;
                                    AIAttack = false;
                                    YourAttack = true;
                                    GameRec[random] = false;

                            }
                            }
                            else
                            {

                                Image newImage = new Image();
                                Xpoints0.Add(newImage);

                                Xpoints0[xp0].Width = 30;
                                Xpoints0[xp0].Height = 28;
                                xl0 = Canvas.GetLeft(Field1[random]);
                                xv0 = Canvas.GetTop(Field1[random]);
                                Canvas.SetLeft(Xpoints0[xp0], xl0);
                                Canvas.SetTop(Xpoints0[xp0], xv0);

                                Fi1.Children.Add(newImage);
                                Xpoints0[xp0].Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/X.png"));
                                xp0++;
                                GameRec[random] = false;
                                 GameRec[random] = false;
                                AttackedRec[random] = true;

                                DoubleAttack = true;

                            }
                        
                    }
                }

                
                if (end1 != true && end2 != true)
                {
                    if (Convert.ToInt32(Number1.Content) == 0)
                    {

                        Lose.Visibility = Visibility.Visible;
                        for (int i = 0; i < 100; i++)
                        {
                            Field2[i].IsHitTestVisible = false;
                        }
                        end1 = true;

                    }

                    if (Convert.ToInt32(Number2.Content) == 0)
                    {
                        Win.Visibility = Visibility.Visible;
                        for (int i = 0; i < 100; i++)
                        {
                            Field2[i].IsHitTestVisible = false;

                        }
                        end2 = true;
                    }
                }


            }
        }

      

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            
            Border1.Visibility = Visibility.Hidden;
            Border2.Visibility = Visibility.Hidden;
            Border3.Visibility = Visibility.Hidden;
            Border4.Visibility = Visibility.Hidden;
            Border5.Visibility = Visibility.Hidden;

            СarrierNUM.Visibility = Visibility.Hidden;
            DestroyerNUM.Visibility = Visibility.Hidden;
            LodkiNUM.Visibility = Visibility.Hidden;
            MiniNUM.Visibility = Visibility.Hidden;

            LabelMid.Visibility = Visibility.Hidden;
            ButtonMid1.Visibility = Visibility.Hidden;
            ButtonMid2.Visibility = Visibility.Hidden;

            StartButton.Visibility = Visibility.Hidden;

            ifGameStarted = true;
            YourAttack = true;

            Canvas.SetZIndex(Ships[0], 0);
            Canvas.SetZIndex(Ships[1], 0);
            Canvas.SetZIndex(Ships[2], 0);
            Canvas.SetZIndex(Ships[3], 0);
            Canvas.SetZIndex(Ships[4], 0);
            Canvas.SetZIndex(Ships[5], 0);
            Canvas.SetZIndex(Ships[6], 0);
            Canvas.SetZIndex(Ships[7], 0);
            Canvas.SetZIndex(Ships[8], 0);
            Canvas.SetZIndex(Ships[9], 0);

        }


        //Нажатие на клетку Field2 
        
        private void RectangleF2Clicked(object sender, MouseButtonEventArgs e)
        {
            ActiveRectangle2 = Convert.ToInt32(((Rectangle)sender).Tag);

            if (GameRec2[ActiveRectangle2] == false)
            {
                Image newImage = new Image();
                Opoints.Add(newImage);

                Opoints[op].Width = 30;
                Opoints[op].Height = 28;
                ol = Canvas.GetLeft(Field2[ActiveRectangle2]);
                ov = Canvas.GetTop(Field2[ActiveRectangle2]);
                Canvas.SetLeft(Opoints[op], ol);
                Canvas.SetTop(Opoints[op], ov);

                this.Fi2.Children.Add(newImage);
                Opoints[op].Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/O.png"));
                op++;
                YourAttack = false;
                AIAttack = true;

            }

            if (ifGameStarted == true)
            {
                if (YourAttack == true)
                {
                    if (GameRec2[ActiveRectangle2] == true)
                    {
                        Image newImage = new Image();
                        Xpoints.Add(newImage);
                      
                        Xpoints[xp].Width = 30;
                        Xpoints[xp].Height = 28;
                        xl = Canvas.GetLeft(Field2[ActiveRectangle2]);
                        xv = Canvas.GetTop(Field2[ActiveRectangle2]);
                        Canvas.SetLeft(Xpoints[xp], xl);
                        Canvas.SetTop(Xpoints[xp], xv);
                        
                        this.Fi2.Children.Add(newImage);
                        Xpoints[xp].Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/X.png"));
                        xp++;
                        GameRec2[ActiveRectangle2] = false;
                    }
                }
            }

        }
    }
}
