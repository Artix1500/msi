using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics.Interpolation;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Complex;

namespace KNN
{
    public partial class Form1 : Form
    {
        private const int NOfAttributes = 9;
        private readonly double[][] _data = {
                    new[] {1, 0.4, 0.2, 0.2, 0.2, 0, 0, 0, 0, 0},
                    new[] {1, 0.4, 0, 0, 0, 0.4, 0.4, 0.4, 0, 0},
                    new[]{1, 0.4, 0, 0, 0, 0.4, 0.4, 0, 0, 0},
                    new[]{1, 0, 0, 0, 0.4, 0, 0, 0.4, 0.4, 0},
                    new[]{2, 0.4, 0.4, 0, 0, 0, 0.4, 0, 0, 0},
                    new[]{2, 0.6, 0, 0, 0, 0, 0.6, 0.6, 0, 0},
                    new[]{2, 0.4, 0, 0, 0, 0.2, 0, 0, 0, 0},
                    new[]{2, 0.8, 0.4, 0, 0, 0.4, 0.4, 0, 0.6, 0},
                    new[]{2, 0.6, 0, 0, 0, 0.6, 0.6, 0, 0.6, 0.6},
                    new[]{2, 0.6, 0, 0, 0.6, 0, 0, 0.6, 0, 0},
                    new[]{2, 0.6, 0.4, 0.8, 0, 0.8, 0.8, 0, 0, 0},
                    new[]{2, 0.6, 0, 0, 0, 0.4, 0.4, 0, 0, 0},
                    new[]{2, 0.4, 0, 0, 0, 0.8, 0.8, 0, 0, 0},
                    new[]{2, 0.4, 0.6, 0, 0, 0.4, 0.4, 0, 0.4, 0},
                    new[]{2, 0.6, 0, 0, 0, 0.8, 0.8, 0, 0.4, 0},
                    new[]{2, 0.4, 0, 0, 0, 0.2, 0.2, 0.4, 0, 0},
                    new[]{2, 0.4, 0, 0.2, 0, 0.4, 0.4, 0.2, 0.2, 0},
                    new[]{2, 0.4, 0.4, 0.2, 0.2, 0, 0, 0, 0, 0},
                    new[]{2, 0.6, 0.6, 0, 0, 0, 0, 0, 0, 0},
                    new[]{2, 0.4, 0.4, 0, 0, 0.4, 0.4, 0, 0, 0},
                    new[]{2, 0.4, 0, 0, 0, 0.4, 0.4, 0, 0.4, 0},
                    new[]{2, 0.8, 0.6, 0.2, 0, 0.8, 0.8, 0.6, 0, 0},
                    new[]{2, 0, 0, 0, 0, 0.8, 0.8, 0, 0, 0},
                    new[]{2, 0, 0, 0, 0, 0, 0, 0.4, 0.6, 0.6},
                    new[]{3, 0.6, 0, 0, 0.4, 0, 0, 0.6, 0, 0},
                    new[]{3, 0.8, 0.6, 0, 0.8, 0.8, 0.8, 0.6, 0, 0},
                    new[]{3, 0.6, 0, 0, 0, 0.6, 0.6, 0, 0.6, 0},
                    new[]{3, 0.6, 0.6, 0.2, 0, 0.6, 0.6, 0, 0.2, 0},
                    new[]{3, 0.8, 0, 0, 0, 0, 0, 0, 0.6, 0},
                    new[]{3, 1, 0, 0, 0, 1, 1, 0.2, 1, 0.6},
                    new[]{3, 0.6, 0, 0, 0, 1, 1, 0, 0.8, 0},
                    new[]{3, 0, 0.6, 0, 0, 0.8, 0.8, 0.8, 0, 0},
                    new[]{3, 0.8, 0.6, 0, 0, 0.8, 0.8, 0.4, 0.4, 0},
                    new[]{3, 0.8, 0.6, 0, 0, 0.8, 0.8, 0.4, 0.4, 0},
                    new[]{3, 0.8, 0, 0, 0, 0.4, 0.4, 0, 0.6, 0.4},
                    new[]{3, 0.8, 0, 0, 0, 0.8, 0.8, 0.2, 0, 0},
                    new[]{3, 0.6, 0.6, 0.4, 0, 0.6, 0.6, 0, 0.6, 0},
                    new[]{3, 0.8, 0.8, 0, 0.2, 0.4, 0, 0.6, 0, 0},
                    new[]{4, 0.8, 0, 0, 0, 0, 0.6, 0, 0.8, 0.4},
                    new[]{4, 0.6, 0, 0, 0.4, 0, 0, 0.6, 0, 0},
                    new[]{4, 0.8, 0, 0, 0, 0, 0, 0, 0.8, 0.6},
                    new[]{4, 0.8, 0, 0, 0, 0.8, 0.8, 0, 0.6, 0.6},
                    new[]{4, 0.6, 0.4, 0.4, 0, 0.6, 0.6, 0.4, 0.4, 0},
                    new[]{4, 1, 0, 0, 0, 1, 1, 0, 0.8, 0},
                    new[]{4, 0.6, 0.8, 0, 0, 0.6, 0.6, 0, 0.6, 0.6},
                    new[]{5, 0.8, 0.8, 0, 0.2, 0, 0, 0, 0.8, 0.8},
                    new[]{5, 0.8, 0.8, 0, 0.2, 0, 0, 0, 0.8, 0},
                    new[]{5, 0.8, 0.8, 0, 1, 0, 0, 1, 0, 0},
                    new[]{5, 0.8, 0, 0, 0, 0, 0, 0, 0.6, 0.6},
                    new[]{5, 0.8, 0, 0, 0, 1, 1, 0, 1, 0.8}
                    };

        private readonly Vector<double>[] _trainingDataVectors = new Vector<double>[0];

        private int K => (int)KSelectBox.Value;

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

            var vectorBuilder = Vector<double>.Build;
            _trainingDataVectors = _data.Select(v => vectorBuilder.Dense(v)).ToArray();

            KSelectBox.Value = 4;
        }


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

        private int calculateKNN(Vector<double> objectToClassify = null, bool showResultsInUI = true)
        {
            if (objectToClassify == null)
            {
                double redux = (double)reduxtb.Value / 10;
                double react = (double)reacttb.Value / 10;
                double angular = (double)angulartb.Value / 10;
                double css = (double)csstb.Value / 10;
                double html = (double)htmltb.Value / 10;
                double typescript = (double)typescripttb.Value / 10;
                double vue = (double)vuetb.Value / 10;
                double git = (double)gittb.Value / 10;
                double javascript = (double)javascripttb.Value / 10;

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

                objectToClassify = Vector<double>.Build.Dense(new[] { javascript, git, vue, typescript, html, css, angular, react, redux });
            }
            
            var topClasses = _trainingDataVectors
                .OrderBy(classifiedObject => GetDistance(objectToClassify,classifiedObject.SubVector(1,NOfAttributes))) // orders ascending by distance between classified object and new object
                .Take(K) //takes K with closest distance
                .Select(classifiedObject => (int)classifiedObject[0]) //selects the class number
                .ToList();

            var topClass = topClasses
                .GroupBy(c => c) //group by class number
                .OrderByDescending(group => group.Count()) //order by n of occurences of every class
                .Select(group => group.Key) // select back the class number (which is the key for grouping)
                .FirstOrDefault(); //take first one IF TWO CLASSES OCCURED WITH THE SAME FREQUENCY ANY OF THEM CAN WIN

            if (showResultsInUI)
            {
                ResultLabel.Text = $@"Closest classes: {string.Join(" ", topClasses)}"+
                                   $@"Assigned class: {topClass} --> {GetSalaryForClass(topClass)}";

                this.Text = $@"Ile jesteś wart -> Precision: {GetPrecisionOnTrainingSet()}";
            }

            return topClass;
        }

        private double GetDistance(Vector<double> v1, Vector<double> v2)
        {
            var diff = v1 - v2;
            if (EuclideanNormRadioButton.Checked)
            {
                return diff.L2Norm();
            }
            if (ManhattanNormRadioButton.Checked)
            {
                return diff.L1Norm();
            }
            if (infinityNormRadioButton.Checked)
            {
                return diff.InfinityNorm();
            }
            return diff.L2Norm();
        }

        private string GetSalaryForClass(int classNumber)
        {
            var step = 3000;
            var upperBound = classNumber * step;
            return $"{upperBound - step} - {upperBound} zł";
        }

        private double GetPrecisionOnTrainingSet()
        {
            var successfulPredictions = _trainingDataVectors.Count(v =>
            {
                var predictedClass = calculateKNN(v.SubVector(1, NOfAttributes),false);
                var knownClass = (int) v[0];
                return predictedClass == knownClass;
            });

            return (double)successfulPredictions / _trainingDataVectors.Length;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void EuclideanNormRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            calculateKNN();
        }

        private void ManhattanNormRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            calculateKNN();
        }

        private void infinityNormRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            calculateKNN();
        }

        private void KSelectBox_ValueChanged(object sender, EventArgs e)
        {
            calculateKNN();
        }
    }
}
