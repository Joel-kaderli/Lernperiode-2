using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Winforms_Spiel
{
    public partial class Form1 : Form
    {
        bool oben, unten, rechts, links;
       
        Panel ApfelPanel = new Panel();

        Random zufall = new Random();
        List<Panel> Schlange = new List<Panel>();

        List<TableLayoutPanelCellPosition> Zellen = new List<TableLayoutPanelCellPosition>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Geschwindigkeit_Click(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:

                    if (!rechts)
                    


                        unten = oben = rechts = false;
                        links = true;
                        break;
                    
              case Keys.Right:

                    if (!links)

                    unten = oben = links = false;
                    rechts = true;
                    break;

              case Keys.Up:

                    if (!unten)

                    unten = rechts = links = false;
                    oben = true;
                    break;

              case Keys.Down:

                    if (!oben)

                    oben = links = rechts = false;
                    unten = true;
                    break;

                deflaut:
                    break;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void StartButten_Click(object sender, EventArgs e)
        {
            ApfelPanel.BackColor = SystemColors.Highlight;
            ApfelPanel.Size=new Size(13,13);

          Feld.Controls.Add(ApfelPanel,zufall.Next(0,Feld.ColumnCount),zufall.Next(0,Feld.RowCount));

          

            if (radioButton1.Checked)
            {
                timer1.Interval = 700;

            }
            else if (radioButton2.Checked) 
            {
                timer1.Interval = 300;

            }
            else if (radioButton3.Checked)
            {
                timer1.Interval = 100;

            }

            groupBox1.Enabled = false;
            StartButten.Enabled = false;

            timer1.Enabled = true;

            Schlange.Add(Kopfpanel);
            Zellen.Add(Feld.GetCellPosition(Kopfpanel));

            unten = true;
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Zellen[0] = Feld.GetCellPosition(Kopfpanel);

            if (unten) 
            {
                Feld.SetCellPosition(Kopfpanel, new TableLayoutPanelCellPosition(Feld.GetColumn(Kopfpanel),Feld.GetRow(Kopfpanel)+1));
            }
            if (oben)
            {
                Feld.SetCellPosition(Kopfpanel, new TableLayoutPanelCellPosition(Feld.GetColumn(Kopfpanel), Feld.GetRow(Kopfpanel) - 1));
            }
            if (rechts)
            {
                Feld.SetCellPosition(Kopfpanel, new TableLayoutPanelCellPosition(Feld.GetColumn(Kopfpanel) +1, Feld.GetRow(Kopfpanel)));
            }
            if (links)
            {
                Feld.SetCellPosition(Kopfpanel, new TableLayoutPanelCellPosition(Feld.GetColumn(Kopfpanel) -1, Feld.GetRow(Kopfpanel)));

            }
            for (int i = 1; i < Schlange.Count; i++) 
            {
                Zellen[i] = Feld.GetCellPosition(Schlange[i]);
                Feld.SetCellPosition(Schlange[i], Zellen[i-1]);
            }

            if (Feld.GetCellPosition(Kopfpanel).Equals(Feld.GetCellPosition(ApfelPanel)))
            {
                Panel PlusPanal = new Panel();
                PlusPanal.BackColor = SystemColors.ControlText;
                PlusPanal.Size= new Size(13,13);

                Schlange.Add(PlusPanal);
                Zellen.Add(new TableLayoutPanelCellPosition(Zellen[Zellen.Count-1].Column, Zellen[Zellen.Count - 1].Row));

                Feld.Controls.Add(PlusPanal, Zellen[Zellen.Count - 1].Column, Zellen[Zellen.Count - 1].Row);

                Feld.SetCellPosition(ApfelPanel, new TableLayoutPanelCellPosition(zufall.Next(0, Feld.ColumnCount), zufall.Next(0, Feld.RowCount)));
            }
        }
    }
}
