using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KNN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            reduxScore.Text = "Redux 0/10";
            reactScore.Text = "React 0/10";
            angularScore.Text = "Angular 0/10";
            cssScore.Text = "CSSS 0/10";
            htmlScore.Text = "HTML 0/10";
            typescriptScore.Text = "TypeScript 0/10";
            vueScore.Text = "Vue 0/10";
            gitScore.Text = "Git 0/10";
            javascriptScore.Text = "JavaScript 0/10";


            
        }

        double[,] data = {
                    {1, 0.4, 0.2, 0.2, 0.2, 0, 0, 0, 0, 0},
                    {1, 0.4, 0, 0, 0, 0.4, 0.4, 0.4, 0, 0},
                    {1, 0.4, 0, 0, 0, 0.4, 0.4, 0, 0, 0},
                    {1, 0, 0, 0, 0.4, 0, 0, 0.4, 0.4, 0},
                    {2, 0.4, 0.4, 0, 0, 0, 0.4, 0, 0, 0},
                    {2, 0.6, 0, 0, 0, 0, 0.6, 0.6, 0, 0},
                    {2, 0.4, 0, 0, 0, 0.2, 0, 0, 0, 0},
                    {2, 0.8, 0.4, 0, 0, 0.4, 0.4, 0, 0.6, 0},
                    {2, 0.6, 0, 0, 0, 0.6, 0.6, 0, 0.6, 0.6},
                    {2, 0.6, 0, 0, 0.6, 0, 0, 0.6, 0, 0},
                    {2, 0.6, 0.4, 0.8, 0, 0.8, 0.8, 0, 0, 0},
                    {2, 0.6, 0, 0, 0, 0.4, 0.4, 0, 0, 0},
                    {2, 0.4, 0, 0, 0, 0.8, 0.8, 0, 0, 0},
                    {2, 0.4, 0.6, 0, 0, 0.4, 0.4, 0, 0.4, 0},
                    {2, 0.6, 0, 0, 0, 0.8, 0.8, 0, 0.4, 0},
                    {2, 0.4, 0, 0, 0, 0.2, 0.2, 0.4, 0, 0},
                    {2, 0.4, 0, 0.2, 0, 0.4, 0.4, 0.2, 0.2, 0},
                    {2, 0.4, 0.4, 0.2, 0.2, 0, 0, 0, 0, 0},
                    {2, 0.6, 0.6, 0, 0, 0, 0, 0, 0, 0},
                    {2, 0.4, 0.4, 0, 0, 0.4, 0.4, 0, 0, 0},
                    {2, 0.4, 0, 0, 0, 0.4, 0.4, 0, 0.4, 0},
                    {2, 0.8, 0.6, 0.2, 0, 0.8, 0.8, 0.6, 0, 0},
                    {2, 0, 0, 0, 0, 0.8, 0.8, 0, 0, 0},
                    {2, 0, 0, 0, 0, 0, 0, 0.4, 0.6, 0.6},
                    {3, 0.6, 0, 0, 0.4, 0, 0, 0.6, 0, 0},
                    {3, 0.8, 0.6, 0, 0.8, 0.8, 0.8, 0.6, 0, 0},
                    {3, 0.6, 0, 0, 0, 0.6, 0.6, 0, 0.6, 0},
                    {3, 0.6, 0.6, 0.2, 0, 0.6, 0.6, 0, 0.2, 0},
                    {3, 0.8, 0, 0, 0, 0, 0, 0, 0.6, 0},
                    {3, 1, 0, 0, 0, 1, 1, 0.2, 1, 0.6},
                    {3, 0.6, 0, 0, 0, 1, 1, 0, 0.8, 0},
                    {3, 0, 0.6, 0, 0, 0.8, 0.8, 0.8, 0, 0},
                    {3, 0.8, 0.6, 0, 0, 0.8, 0.8, 0.4, 0.4, 0},
                    {3, 0.8, 0.6, 0, 0, 0.8, 0.8, 0.4, 0.4, 0},
                    {3, 0.8, 0, 0, 0, 0.4, 0.4, 0, 0.6, 0.4},
                    {3, 0.8, 0, 0, 0, 0.8, 0.8, 0.2, 0, 0},
                    {3, 0.6, 0.6, 0.4, 0, 0.6, 0.6, 0, 0.6, 0},
                    {3, 0.8, 0.8, 0, 0.2, 0.4, 0, 0.6, 0, 0},
                    {4, 0.8, 0, 0, 0, 0, 0.6, 0, 0.8, 0.4},
                    {4, 0.6, 0, 0, 0.4, 0, 0, 0.6, 0, 0},
                    {4, 0.8, 0, 0, 0, 0, 0, 0, 0.8, 0.6},
                    {4, 0.8, 0, 0, 0, 0.8, 0.8, 0, 0.6, 0.6},
                    {4, 0.6, 0.4, 0.4, 0, 0.6, 0.6, 0.4, 0.4, 0},
                    {4, 1, 0, 0, 0, 1, 1, 0, 0.8, 0},
                    {4, 0.6, 0.8, 0, 0, 0.6, 0.6, 0, 0.6, 0.6},
                    {5, 0.8, 0.8, 0, 0.2, 0, 0, 0, 0.8, 0.8},
                    {5, 0.8, 0.8, 0, 0.2, 0, 0, 0, 0.8, 0},
                    {5, 0.8, 0.8, 0, 1, 0, 0, 1, 0, 0},
                    {5, 0.8, 0, 0, 0, 0, 0, 0, 0.6, 0.6},
                    {5, 0.8, 0, 0, 0, 1, 1, 0, 1, 0.8}
                    };

        private void trackBarMoved(object sender, EventArgs e)
        {


            reduxScore.Text = "Redux " + reduxtb.Value + "/10";
            reactScore.Text = "React " + reacttb.Value + "/10";
            angularScore.Text = "Angular " + angulartb.Value + "/10";
            cssScore.Text = "CSSS " + csstb.Value + "/10";
            htmlScore.Text = "HTML " + htmltb.Value + "/10";
            typescriptScore.Text = "TypeScript " + typescripttb.Value + "/10";
            vueScore.Text = "Vue " + vuetb.Value + "/10";
            gitScore.Text = "Git " + gittb.Value + "/10";
            javascriptScore.Text = "JavaScript " + javascripttb.Value + "/10";

            calculateKNN();


        }

        private void calculateKNN()
        {
            float redux = (float)reduxtb.Value / 10;
            float react = (float)reacttb.Value / 10;
            float angular = (float)angulartb.Value / 10;
            float css = (float)csstb.Value / 10;
            float html = (float)htmltb.Value / 10;
            float typescript = (float)typescripttb.Value / 10;
            float vue = (float)vuetb.Value / 10;
            float git = (float)gittb.Value / 10;
            float javascript = (float)javascripttb.Value / 10;

            ResultLabel.Text =
                        redux + " " +
                        react + " " +
                        angular + " " +
                        css + " " +
                        html + " " +
                        typescript + " " +
                        vue + " " +
                        git + " " +
                        javascript + " ";



            /// OBLICZYC !!!!!!!!! ;)
            /// 
            double[] currValues = { javascript, git, vue, typescript, html, css, angular, react, redux };
            List<(int, double)> dist = new List<(int, double)>();

            for(int i = 0; i < data.GetUpperBound(0); i++)
            {
                int classNr = (int)data[i,0];

                double distNr = 0;

                for(int j = 1; j < data.GetUpperBound(1); j++)
                {
                    distNr += (currValues[j - 1] - data[i,j]) * (currValues[j - 1] - data[i,j]);
                }
                distNr = Math.Sqrt(distNr);
                dist.Add((classNr, distNr));

            }

            dist.Sort((x, y) => x.Item2.CompareTo(y.Item2));


            /// k = 4
            /// 
            int nr1 = dist[0].Item1;
            int nr2 = dist[1].Item1;
            int nr3 = dist[2].Item1;
            int nr4 = dist[3].Item1;
            ResultLabel.Text = "WYNIK " + (nr1).ToString() + " " + (nr2).ToString() + " " + (nr3).ToString() + " " + (nr4).ToString() + " ";



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
