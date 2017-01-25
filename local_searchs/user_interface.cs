using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace local_searchs
{
    public partial class user_interface : Form
    {
        public user_interface()
        {
            InitializeComponent();
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutUs = new AboutBox();
            aboutUs.Show();
        }

        private void hill_run_btn_Click(object sender, EventArgs e)
        {
            textBox1.Text = "searching...";
            textBox1.Refresh();
            int[] a = helper.generate_random_array(number_of_queen());
            ILocal_Search<int[]> h = new best_choise<int[]>();
            n_queens_problem nqp = new n_queens_problem();
            int[] result = h.solve(nqp, a);
            textBox1.Text = print_n_queen_result(result);
        }

        private string print_n_queen_result(int[] result)
        {
            int n = result.Length;
            string pr = n + "-Queen problem:\r\n";
            for (int i = 0; i < n; i++)
            {
                pr += "|";
                for (int j = 0; j < n; j++)
                {
                    if (result[i] == j)
                        pr += "Q";
                    else
                        pr += "  .  ";
                }
                pr += "|\r\n";
            }
            n_queens_problem nqp = new n_queens_problem();
            if (!nqp.total_satisfaction(result)) pr += ("Algorithm trapped in local optimum!!");
            return pr;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "searching...";
            textBox1.Refresh();
            int[] a;
            ILocal_Search<int[]> h = new best_choise<int[]>();
            n_queens_problem nqp = new n_queens_problem();
            int[] result;
            do
            {
                a = helper.generate_random_array(number_of_queen());
                result = h.solve(nqp, a);
            } while (!nqp.total_satisfaction(result));

            textBox1.Text = print_n_queen_result(result);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "searching...";
            textBox1.Refresh();
            int[] a = helper.generate_random_array(number_of_queen());
            ILocal_Search<int[]> h = new first_choise<int[]>();
            n_queens_problem nqp = new n_queens_problem();
            int[] result = h.solve(nqp, a);
            textBox1.Text = print_n_queen_result(result);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "searching...";
            textBox1.Refresh();
            int[] a;
            ILocal_Search<int[]> h = new first_choise<int[]>();
            n_queens_problem nqp = new n_queens_problem();
            int[] result;
            do
            {
                a = helper.generate_random_array(number_of_queen());
                result = h.solve(nqp, a);
            } while (!nqp.total_satisfaction(result));

            textBox1.Text = print_n_queen_result(result);
        }

        private int number_of_queen()
        {
            return (int)numericUpDown1.Value;
        }

        private int number_of_beams()
        {
            return (int)numericUpDown3.Value;
        }

        private void user_interface_Load(object sender, EventArgs e)
        {
            numericUpDown11_ValueChanged(sender, e);
            numericUpDown9_ValueChanged(sender, e);
            numericUpDown7_ValueChanged(sender, e);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox2.Text = "searching...";
            textBox2.Refresh();
            int n_beams = number_of_beams();
            int n_queen = number_of_queen();
            int[][] initialize_beams = new int[n_beams][];
            for (int i = 0; i < n_beams; i++)
                initialize_beams[i] = helper.generate_random_array(n_queen);

            local_beam_search<int[]> lbs = new local_beam_search<int[]>();
            n_queens_problem nqp = new n_queens_problem();
            int[] result = lbs.solve(nqp, initialize_beams, n_beams);
            textBox2.Text = print_n_queen_result(result);
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown1.Value = numericUpDown4.Value;
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown1.Value = numericUpDown5.Value;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox3.Text = "searching...";
            textBox3.Refresh();
            double initial_temp = (double)numericUpDown6.Value;
            double cooling_factor = double.Parse(textBox4.Text);
            simulated_annealing<int[]> sa = new simulated_annealing<int[]>(initial_temp, cooling_factor);
            n_queens_problem nqp = new n_queens_problem();
            int[] result = sa.solve(nqp, helper.generate_random_array(number_of_queen()));
            textBox3.Text = print_n_queen_result(result);
        }

        private string print_graph_coloring_result(graph_coloring gc, int[] result)
        {
            string pr = "Graph coloring problem:\r\nAdjacency matrix:\r\n  ";
            int c = gc.number_of_colors();
            int n = result.Length;
            bool[,] matrix = gc.get_matrix();
            for (int i = 0; i < n; i++)
            {
                pr += "  " + i + " ";
            }
            pr += "\r\n";
            for (int i = 0; i < n; i++)
            {
                pr += i + " ";
                for (int j = 0; j < n; j++)
                {
                    pr += "  " + bool_to_check(matrix[i, j]) + " ";
                }
                pr += "\r\n";
            }
            pr += "number of available colors: " + c + "\r\nresult:\r\n";

            for (int i = 0; i < n; i++)
            {
                pr += "[" + i + "]: " + int_to_color(result[i]) + "\t";
            }

            if (!gc.total_satisfaction(result)) pr += ("\r\nAlgorithm trapped in local optimum!!");
            return pr;
        }

        private char bool_to_check(bool b)
        {
            return (b) ? '●' : '-';
        }

        private char int_to_color(int i)
        {
            return (char)(i + 65);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox5.Text = "searching...";
            textBox5.Refresh();
            int color_constraint = number_of_colors();
            int[] a = helper.generate_random_array(number_of_nodes(), color_constraint);
            bool[,] adj_matrix = get_adjacency_matrix();
            ILocal_Search<int[]> h = new best_choise<int[]>();
            graph_coloring gc = new graph_coloring(adj_matrix, color_constraint);
            int[] result = h.solve(gc, a);
            textBox5.Text = print_graph_coloring_result(gc, result);
        }

        private int number_of_colors()
        {
            return (int)numericUpDown2.Value;
        }

        private int number_of_nodes()
        {
            return (int)numericUpDown11.Value;
        }


        private bool[,] get_adjacency_matrix()
        {
            string input = adj_matrix_txt.Text.Replace("\r\n", "");
            int n = number_of_nodes();
            bool[,] output = new bool[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int k = (i * n + j) * 2;
                    output[i, j] = (input.ElementAt(k) == '0') ? false : true;
                }
            }

            return output;

            throw new Exception();
        }

        private void numericUpDown11_ValueChanged(object sender, EventArgs e)
        {
            int n = (int)numericUpDown11.Value;
            bool[,] ba = new bool[n, n];
            adj_matrix_txt.Text = draw_input_graph(ba, n);
        }

        private string draw_input_graph(bool[,] graph, int n)
        {
            string s = "";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    s += (graph[i, j]) ? "1" : "0";
                    s += " ";
                }
                s += "\r\n";
            }
            return s;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int n = number_of_nodes();
            adj_matrix_txt.Text = draw_input_graph(helper.generate_random_graph(n), n);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox5.Text = "searching...";
            textBox5.Refresh();
            int color_constraint = number_of_colors();
            bool[,] adj_matrix = get_adjacency_matrix();
            ILocal_Search<int[]> h = new best_choise<int[]>();
            graph_coloring gc = new graph_coloring(adj_matrix, color_constraint);
            int[] a;
            int[] result;
            int i = 0;
            do
            {
                i++;
                a = helper.generate_random_array(number_of_nodes(), color_constraint);
                result = h.solve(gc, a);
            } while (!gc.total_satisfaction(result) && i < 1000);

            textBox5.Text = print_graph_coloring_result(gc, result);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox5.Text = "searching...";
            textBox5.Refresh();
            int color_constraint = number_of_colors();
            int[] a = helper.generate_random_array(number_of_nodes(), color_constraint);
            bool[,] adj_matrix = get_adjacency_matrix();
            ILocal_Search<int[]> h = new first_choise<int[]>();
            graph_coloring gc = new graph_coloring(adj_matrix, color_constraint);
            int[] result = h.solve(gc, a);
            textBox5.Text = print_graph_coloring_result(gc, result);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox5.Text = "searching...";
            textBox5.Refresh();
            int color_constraint = number_of_colors();
            bool[,] adj_matrix = get_adjacency_matrix();
            ILocal_Search<int[]> h = new first_choise<int[]>();
            graph_coloring gc = new graph_coloring(adj_matrix, color_constraint);
            int[] a;
            int[] result;
            int i = 0;
            do
            {
                i++;
                a = helper.generate_random_array(number_of_nodes(), color_constraint);
                result = h.solve(gc, a);
            } while (!gc.total_satisfaction(result) && i < 1000);

            textBox5.Text = print_graph_coloring_result(gc, result);
        }

        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown11.Value = numericUpDown9.Value;
            int n = (int)numericUpDown9.Value;
            bool[,] ba = new bool[n, n];
            textBox8.Text = draw_input_graph(ba, n);
        }

        private void numericUpDown12_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown2.Value = numericUpDown12.Value;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            adj_matrix_txt.Text = textBox8.Text;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int n = number_of_nodes();
            textBox8.Text = draw_input_graph(helper.generate_random_graph(n), n);
        }

        private void numericUpDown10_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown3.Value = numericUpDown10.Value;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox9.Text = "searching...";
            textBox9.Refresh();
            int color_constraint = number_of_colors();
            int n_beams = number_of_beams();
            bool[,] adj_matrix = get_adjacency_matrix();
            int[][] initialize_beams = new int[n_beams][];
            int n_of_nodes = number_of_nodes();
            for (int i = 0; i < n_beams; i++)
                initialize_beams[i] = helper.generate_random_array(n_of_nodes, color_constraint);
            local_beam_search<int[]> lbs = new local_beam_search<int[]>();
            graph_coloring gc = new graph_coloring(adj_matrix, color_constraint);
            int[] result = lbs.solve(gc, initialize_beams, n_beams);
            textBox9.Text = print_graph_coloring_result(gc, result);
        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown6.Value = numericUpDown8.Value;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            textBox4.Text = textBox6.Text;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            adj_matrix_txt.Text = textBox7.Text;
        }

        private void numericUpDown13_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown2.Value = numericUpDown13.Value;
        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown11.Value = numericUpDown7.Value;
            int n = (int)numericUpDown7.Value;
            bool[,] ba = new bool[n, n];
            textBox7.Text = draw_input_graph(ba, n);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            int n = number_of_nodes();
            textBox7.Text = draw_input_graph(helper.generate_random_graph(n), n);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox10.Text = "searching...";
            textBox10.Refresh();
            int color_constraint = number_of_colors();
            int[] a = helper.generate_random_array(number_of_nodes(), color_constraint);
            bool[,] adj_matrix = get_adjacency_matrix();
            double initial_temp = (double)numericUpDown8.Value;
            double cooling_factor = double.Parse(textBox6.Text);
            simulated_annealing<int[]> sa = new simulated_annealing<int[]>(initial_temp, cooling_factor);
            graph_coloring gc = new graph_coloring(adj_matrix, color_constraint);
            int[] result = sa.solve(gc, a);
            textBox10.Text = print_graph_coloring_result(gc, result);
        }
    }
}
