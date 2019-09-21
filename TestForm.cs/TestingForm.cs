using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoGame;

namespace TestForm.cs
{
    public partial class TestingForm : Form
    {
        DBCartas DB_CARTAS = new DBCartas();
        DBNpc DB_NPCS = new DBNpc();

        List<CartaSoporte>  listaCartas_Soporte     = new List<CartaSoporte>();
        List<Carta>         listaCartas_Guitarra    = new List<Carta>();
        List<Carta>         listaCartas_Bateria     = new List<Carta>();
        List<Carta>         listaCartas_Bajo        = new List<Carta>();
        List<Carta>         listaCartas_Voz         = new List<Carta>();

        Player p1 = new Player("PLAYER1", 1000, 100, 100);
        Player p2 = new Player("PLAYER2", 1000, 100, 100);

        NPC_Guitarra    npcGuitarra1_p1 = null;
        NPC_Guitarra    npcGuitarra2_p1 = null;
        NPC_Bajo        npcBajo_p1      = null;
        NPC_Bateria     npcBateria_p1   = null;
        NPC_Voz         npcVoz_p1       = null;

        NPC_Guitarra    npcGuitarra1_p2 = null;
        NPC_Guitarra    npcGuitarra2_p2 = null;
        NPC_Bajo        npcBajo_p2      = null;
        NPC_Bateria     npcBateria_p2   = null;
        NPC_Voz         npcVoz_p2       = null;


        public TestingForm()
        {
            InitializeComponent();
            this.Text = "TESTING BATALLA POR TURNOS";

            listaCartas_Soporte     = DB_CARTAS.GetMazoSoporte;
            listaCartas_Guitarra    = DB_CARTAS.GetMazoGuitarra;
            listaCartas_Bajo        = DB_CARTAS.GetMazoBajo;
            listaCartas_Bateria     = DB_CARTAS.GetMazoBateria;
            listaCartas_Voz         = DB_CARTAS.GetMazoVoz;

            #region CARGA AL COMBOBOX TODAS LAS CARTAS SUPPORT DE LOS DOS PLAYER
            foreach (CartaSoporte item in listaCartas_Soporte)
            {
                this.comboBoxSup1_1.Items.Add(item.Nombre);
            }
            foreach (CartaSoporte item in listaCartas_Soporte)
            {
                this.comboBoxSup2_1.Items.Add(item.Nombre);
            }
            foreach (CartaSoporte item in listaCartas_Soporte)
            {
                this.comboBoxSup3_1.Items.Add(item.Nombre);
            }
            foreach (CartaSoporte item in listaCartas_Soporte)
            {
                this.comboBoxSup4_1.Items.Add(item.Nombre);
            }
            foreach (CartaSoporte item in listaCartas_Soporte)
            {
                this.comboBoxSup5_1.Items.Add(item.Nombre);
            }

            foreach (CartaSoporte item in listaCartas_Soporte)
            {
                this.comboBoxSup1_2.Items.Add(item.Nombre);
            }
            foreach (CartaSoporte item in listaCartas_Soporte)
            {
                this.comboBoxSup2_2.Items.Add(item.Nombre);
            }
            foreach (CartaSoporte item in listaCartas_Soporte)
            {
                this.comboBoxSup3_2.Items.Add(item.Nombre);
            }
            foreach (CartaSoporte item in listaCartas_Soporte)
            {
                this.comboBoxSup4_2.Items.Add(item.Nombre);
            }
            foreach (CartaSoporte item in listaCartas_Soporte)
            {
                this.comboBoxSup5_2.Items.Add(item.Nombre);
            }
            #endregion

            #region CARGA A LOS COMBOS DE LOS NPC SUS RESPECTIVAS CARTAS
            foreach (Carta item in DB_CARTAS.GetMazoCompleto)
            {
                switch (item.Clase)
                {
                    case EClase.Guitarra:
                        this.cmbSlot1_Guitarra1_J1.Items.Add(item.Nombre);
                        this.cmbSlot2_Guitarra1_J1.Items.Add(item.Nombre);
                        this.cmbSlot3_Guitarra1_J1.Items.Add(item.Nombre);

                        this.cmbSlot1_Guitarra2_J1.Items.Add(item.Nombre);
                        this.cmbSlot2_Guitarra2_J1.Items.Add(item.Nombre);
                        this.cmbSlot3_Guitarra2_J1.Items.Add(item.Nombre);

                        this.cmbSlot1_Guitarra1_J2.Items.Add(item.Nombre);
                        this.cmbSlot2_Guitarra1_J2.Items.Add(item.Nombre);
                        this.cmbSlot3_Guitarra1_J2.Items.Add(item.Nombre);

                        this.cmbSlot1_Guitarra2_J2.Items.Add(item.Nombre);
                        this.cmbSlot2_Guitarra2_J2.Items.Add(item.Nombre);
                        this.cmbSlot3_Guitarra2_J2.Items.Add(item.Nombre);
                        break;
                    case EClase.Bajo:
                        this.cmbSlot1_Bajo_J1.Items.Add(item.Nombre);
                        this.cmbSlot2_Bajo_J1.Items.Add(item.Nombre);
                        this.cmbSlot3_Bajo_J1.Items.Add(item.Nombre);

                        this.cmbSlot1_Bajo_J2.Items.Add(item.Nombre);
                        this.cmbSlot2_Bajo_J2.Items.Add(item.Nombre);
                        this.cmbSlot3_Bajo_J2.Items.Add(item.Nombre);
                        break;
                    case EClase.Bateria:
                        this.cmbSlot1_Bateria_J1.Items.Add(item.Nombre);
                        this.cmbSlot2_Bateria_J1.Items.Add(item.Nombre);
                        this.cmbSlot3_Bateria_J1.Items.Add(item.Nombre);

                        this.cmbSlot1_Bateria_J2.Items.Add(item.Nombre);
                        this.cmbSlot2_Bateria_J2.Items.Add(item.Nombre);
                        this.cmbSlot3_Bateria_J2.Items.Add(item.Nombre);
                        break;
                    case EClase.Voz:
                        this.cmbSlot1_Voz_J1.Items.Add(item.Nombre);
                        this.cmbSlot2_Voz_J1.Items.Add(item.Nombre);
                        this.cmbSlot3_Voz_J1.Items.Add(item.Nombre);

                        this.cmbSlot1_Voz_J2.Items.Add(item.Nombre);
                        this.cmbSlot2_Voz_J2.Items.Add(item.Nombre);
                        this.cmbSlot3_Voz_J2.Items.Add(item.Nombre);
                        break;
                    case EClase.Soporte:
                        //LAS PODRIA INSTANCIAR ACA PERO NO LAS AGREGUE DENTRO DEL MAZO STANDAR. ARREGLAR ESO.
                        break;
                    default:
                        break;
                }
            } 
            #endregion


        }

        private void TestingForm_Load(object sender, EventArgs e)
        {
            #region ESTABLECE EN LAS CARTAS SUPPORT EL ITEM "NONE"
            this.comboBoxSup1_1.SelectedItem = this.comboBoxSup1_1.Items[0];
            this.comboBoxSup2_1.SelectedItem = this.comboBoxSup1_1.Items[0];
            this.comboBoxSup3_1.SelectedItem = this.comboBoxSup1_1.Items[0];
            this.comboBoxSup4_1.SelectedItem = this.comboBoxSup1_1.Items[0];
            this.comboBoxSup5_1.SelectedItem = this.comboBoxSup1_1.Items[0];
            this.comboBoxSup1_2.SelectedItem = this.comboBoxSup1_1.Items[0];
            this.comboBoxSup2_2.SelectedItem = this.comboBoxSup1_1.Items[0];
            this.comboBoxSup3_2.SelectedItem = this.comboBoxSup1_1.Items[0];
            this.comboBoxSup4_2.SelectedItem = this.comboBoxSup1_1.Items[0];
            this.comboBoxSup5_2.SelectedItem = this.comboBoxSup1_1.Items[0];
            #endregion

            #region ESTABLECE LAS CARTAS AL INDICE 0 DEL MAZO QUE LE CORRESPONDE. EJ: AL NPC GUITARRA LE ASIGNA LA CARTA DEL INDICE 0 DEL MAZO DE GUITARRAS
            this.cmbSlot1_Guitarra1_J1.SelectedItem = this.cmbSlot1_Guitarra1_J1.Items[0];
            this.cmbSlot2_Guitarra1_J1.SelectedItem = this.cmbSlot1_Guitarra1_J1.Items[0];
            this.cmbSlot3_Guitarra1_J1.SelectedItem = this.cmbSlot1_Guitarra1_J1.Items[0];
            this.cmbSlot1_Guitarra2_J1.SelectedItem = this.cmbSlot1_Guitarra1_J1.Items[0];
            this.cmbSlot2_Guitarra2_J1.SelectedItem = this.cmbSlot1_Guitarra1_J1.Items[0];
            this.cmbSlot3_Guitarra2_J1.SelectedItem = this.cmbSlot1_Guitarra1_J1.Items[0];

            this.cmbSlot1_Guitarra1_J2.SelectedItem = this.cmbSlot1_Guitarra1_J1.Items[0];
            this.cmbSlot2_Guitarra1_J2.SelectedItem = this.cmbSlot1_Guitarra1_J1.Items[0];
            this.cmbSlot3_Guitarra1_J2.SelectedItem = this.cmbSlot1_Guitarra1_J1.Items[0];
            this.cmbSlot1_Guitarra2_J2.SelectedItem = this.cmbSlot1_Guitarra1_J1.Items[0];
            this.cmbSlot2_Guitarra2_J2.SelectedItem = this.cmbSlot1_Guitarra1_J1.Items[0];
            this.cmbSlot3_Guitarra2_J2.SelectedItem = this.cmbSlot1_Guitarra1_J1.Items[0];

            this.cmbSlot1_Bajo_J1.SelectedItem = this.cmbSlot1_Bajo_J1.Items[0];
            this.cmbSlot2_Bajo_J1.SelectedItem = this.cmbSlot1_Bajo_J1.Items[0];
            this.cmbSlot3_Bajo_J1.SelectedItem = this.cmbSlot1_Bajo_J1.Items[0];
            this.cmbSlot1_Bajo_J2.SelectedItem = this.cmbSlot1_Bajo_J1.Items[0];
            this.cmbSlot2_Bajo_J2.SelectedItem = this.cmbSlot1_Bajo_J1.Items[0];
            this.cmbSlot3_Bajo_J2.SelectedItem = this.cmbSlot1_Bajo_J1.Items[0];

            this.cmbSlot1_Bateria_J1.SelectedItem = this.cmbSlot1_Bateria_J1.Items[0];
            this.cmbSlot2_Bateria_J1.SelectedItem = this.cmbSlot1_Bateria_J1.Items[0];
            this.cmbSlot3_Bateria_J1.SelectedItem = this.cmbSlot1_Bateria_J1.Items[0];
            this.cmbSlot1_Bateria_J2.SelectedItem = this.cmbSlot1_Bateria_J1.Items[0];
            this.cmbSlot2_Bateria_J2.SelectedItem = this.cmbSlot1_Bateria_J1.Items[0];
            this.cmbSlot3_Bateria_J2.SelectedItem = this.cmbSlot1_Bateria_J1.Items[0];

            this.cmbSlot1_Voz_J1.SelectedItem = this.cmbSlot1_Voz_J1.Items[0];
            this.cmbSlot2_Voz_J1.SelectedItem = this.cmbSlot1_Voz_J1.Items[0];
            this.cmbSlot3_Voz_J1.SelectedItem = this.cmbSlot1_Voz_J1.Items[0];
            this.cmbSlot1_Voz_J2.SelectedItem = this.cmbSlot1_Voz_J1.Items[0];
            this.cmbSlot2_Voz_J2.SelectedItem = this.cmbSlot1_Voz_J1.Items[0];
            this.cmbSlot3_Voz_J2.SelectedItem = this.cmbSlot1_Voz_J1.Items[0];
            #endregion

            #region ESTABLECE LOS CHECK EN TRUE PARA EL USO DE LOS NPC
            this.checkGuitarra1_J1.Checked = true;
            this.checkGuitarra2_J1.Checked = true;
            this.checkGuitarra1_J2.Checked = true;
            this.checkGuitarra2_J2.Checked = true;
            this.checkBajo_J1.Checked = true;
            this.checkBajo_J2.Checked = true;
            this.checkBateria_J1.Checked = true;
            this.checkBateria_J2.Checked = true;
            this.checkVoz_J1.Checked = true;
            this.checkVoz_J2.Checked = true; 
            #endregion



        }
        private void SET_Click(object sender, EventArgs e)
        {
            //SI SE INGRESA NONE CUENTA COMO CARTA POR ESO NO SE PUEDEN AGREGAR MAS, FUE PARA NO MANDARLE NULL Y PONERME A VALIDAR ESO
            #region CARGA ESTADISTICAS DE CARTA SOPORTE A PLAYER 1
            this.p1 += this.listaCartas_Soporte[this.comboBoxSup1_1.SelectedIndex];
            this.p1 += this.listaCartas_Soporte[this.comboBoxSup2_1.SelectedIndex];
            this.p1 += this.listaCartas_Soporte[this.comboBoxSup3_1.SelectedIndex];
            this.p1 += this.listaCartas_Soporte[this.comboBoxSup4_1.SelectedIndex];
            this.p1 += this.listaCartas_Soporte[this.comboBoxSup5_1.SelectedIndex];

            this.puntosDeVida1.Text = this.p1.Vida.ToString();
            this.defensaFisica1.Text = this.p1.DefensaFisica.ToString();
            this.defensaMagica1.Text = this.p1.DefensaMagica.ToString();
            #endregion

            #region CARGA ESTADISTICAS DE CARTA SOPORTE A PLAYER 2
            this.p2 += this.listaCartas_Soporte[this.comboBoxSup1_2.SelectedIndex];
            this.p2 += this.listaCartas_Soporte[this.comboBoxSup2_2.SelectedIndex];
            this.p2 += this.listaCartas_Soporte[this.comboBoxSup3_2.SelectedIndex];
            this.p2 += this.listaCartas_Soporte[this.comboBoxSup4_2.SelectedIndex];
            this.p2 += this.listaCartas_Soporte[this.comboBoxSup5_2.SelectedIndex];

            this.puntosDeVida2.Text = this.p2.Vida.ToString();
            this.defensaFisica2.Text = this.p2.DefensaFisica.ToString();
            this.defensaMagica2.Text = this.p2.DefensaMagica.ToString();
            #endregion

            #region PLAYER 1 - NPC GUITARRA 1
            if (this.checkGuitarra1_J1.Checked)
            {
                this.npcGuitarra1_p1 = new NPC_Guitarra(1, "NPC_GUITARRA1_1", "", 1000, 1, 1, 100, 100, 100, 100);

                this.npcGuitarra1_p1 += listaCartas_Guitarra[this.cmbSlot1_Guitarra1_J1.SelectedIndex];
                this.npcGuitarra1_p1 += listaCartas_Guitarra[this.cmbSlot2_Guitarra1_J1.SelectedIndex];
                this.npcGuitarra1_p1 += listaCartas_Guitarra[this.cmbSlot3_Guitarra1_J1.SelectedIndex];
                this.p1.GetNPC_Guitarra1 = this.npcGuitarra1_p1;

                this.af_guitarra1_J1.Text = "AF:  " + this.npcGuitarra1_p1.AtaqueFisico.ToString();
                this.am_guitarra1_J1.Text = "AM: "   + this.npcGuitarra1_p1.AtaqueMagico.ToString();
                this.df_guitarra1_J1.Text = "DF:  "  + this.npcGuitarra1_p1.DefensaFisica.ToString();
                this.dm_guitarra1_J1.Text = "DM: "   + this.npcGuitarra1_p1.DefensaMagica.ToString();
                this.vida_guitarra1_J1.Text = this.npcGuitarra1_p1.Vida.ToString();
            }
            else
            {
                this.p1.GetNPC_Guitarra1 = null;
                this.groupBoxGuitarra1_1.Visible = false;
            }
            #endregion

            #region PLAYER 1 - NPC GUITARRA 2
            if (this.checkGuitarra2_J1.Checked)
            {
                this.npcGuitarra2_p1 = new NPC_Guitarra(12, "NPC_GUITARRA2_1", "", 1000, 1, 1, 100, 100, 100, 100);
                                
                this.npcGuitarra2_p1 += listaCartas_Guitarra[this.cmbSlot1_Guitarra2_J1.SelectedIndex];
                this.npcGuitarra2_p1 += listaCartas_Guitarra[this.cmbSlot2_Guitarra2_J1.SelectedIndex];
                this.npcGuitarra2_p1 += listaCartas_Guitarra[this.cmbSlot3_Guitarra2_J1.SelectedIndex];
                this.p1.GetNPC_Guitarra2 = this.npcGuitarra2_p1;

                this.af_guitarra2_J1.Text = "AF:  " + this.npcGuitarra2_p1.AtaqueFisico.ToString();
                this.am_guitarra2_J1.Text = "AM: "   + this.npcGuitarra2_p1.AtaqueMagico.ToString();
                this.df_guitarra2_J1.Text = "DF:  "  + this.npcGuitarra2_p1.DefensaFisica.ToString();
                this.dm_guitarra2_J1.Text = "DM: "   + this.npcGuitarra2_p1.DefensaMagica.ToString();
                this.vida_guitarra2_J1.Text = this.npcGuitarra2_p1.Vida.ToString();
            }
            else
            {
                this.groupBoxGuitarra2_1.Visible = false;
            }
            #endregion

            #region PLAYER 1 - NPC BAJO
            if (this.checkBajo_J1.Checked)
            {
                this.npcBajo_p1 = new NPC_Bajo(1, "NPC_BAJO_1", "", 1000, 1, 1, 100, 100, 100, 100);
                        
                this.npcBajo_p1 += listaCartas_Bajo[this.cmbSlot1_Bajo_J1.SelectedIndex];
                this.npcBajo_p1 += listaCartas_Bajo[this.cmbSlot2_Bajo_J1.SelectedIndex];
                this.npcBajo_p1 += listaCartas_Bajo[this.cmbSlot3_Bajo_J1.SelectedIndex];
                this.p1 += this.npcGuitarra1_p1;

                this.af_bajo_J1.Text = "AF:  " + this.npcBajo_p1.AtaqueFisico.ToString();
                this.am_bajo_J1.Text = "AM: "   + this.npcBajo_p1.AtaqueMagico.ToString();
                this.df_bajo_J1.Text = "DF:  "  + this.npcBajo_p1.DefensaFisica.ToString();
                this.dm_bajo_J1.Text = "DM: "   + this.npcBajo_p1.DefensaMagica.ToString();
                this.vida_bajo_J1.Text = this.npcBajo_p1.Vida.ToString();
            }
            else
            {
                this.groupBoxBajo_1.Visible = false;
            }
            #endregion

            #region PLAYER 1 - NPC BATERIA
            if (this.checkBateria_J1.Checked)
            {
                this.npcBateria_p1 = new NPC_Bateria(1, "NPC_BATERIA_1", "", 1000, 1, 1, 100, 100, 100, 100);
                        
                this.npcBateria_p1 += listaCartas_Bateria[this.cmbSlot1_Bateria_J1.SelectedIndex];
                this.npcBateria_p1 += listaCartas_Bateria[this.cmbSlot2_Bateria_J1.SelectedIndex];
                this.npcBateria_p1 += listaCartas_Bateria[this.cmbSlot3_Bateria_J1.SelectedIndex];
                this.p1 += this.npcBateria_p1;

                this.af_bateria_J1.Text = "AF:  " + this.npcBateria_p1.AtaqueFisico.ToString();
                this.am_bateria_J1.Text = "AM: "   + this.npcBateria_p1.AtaqueMagico.ToString();
                this.df_bateria_J1.Text = "DF:  "  + this.npcBateria_p1.DefensaFisica.ToString();
                this.dm_bateria_J1.Text = "DM: "   + this.npcBateria_p1.DefensaMagica.ToString();
                this.vida_bateria_J1.Text = this.npcBateria_p1.Vida.ToString();
            }
            else
            {
                this.groupBoxBateria_1.Visible = false;
            }
            #endregion

            #region PLAYER 1 - NPC VOZ
            if (this.checkVoz_J1.Checked)
            {
                this.npcVoz_p1 = new NPC_Voz(1, "NPC_VOZ_1", "", 1000, 1, 1, 1000, 100, 100, 100);

                this.npcVoz_p1 += listaCartas_Voz[this.cmbSlot1_Voz_J1.SelectedIndex];
                this.npcVoz_p1 += listaCartas_Voz[this.cmbSlot2_Voz_J1.SelectedIndex];
                this.npcVoz_p1 += listaCartas_Voz[this.cmbSlot3_Voz_J1.SelectedIndex];
                this.p1 += this.npcVoz_p1;

                this.af_voz_J1.Text = "AF:  " + this.npcVoz_p1.AtaqueFisico.ToString();
                this.am_voz_J1.Text = "AM: " + this.npcVoz_p1.AtaqueMagico.ToString();
                this.df_voz_J1.Text = "DF:  " + this.npcVoz_p1.DefensaFisica.ToString();
                this.dm_voz_J1.Text = "DM: " + this.npcVoz_p1.DefensaMagica.ToString();
                this.vida_voz_J1.Text = this.npcVoz_p1.Vida.ToString();
            }
            else
            {
                this.groupBoxVoz_1.Visible = false;
            }
            #endregion

            #region PLAYER 2 - NPC GUITARRA 1
            if (this.checkGuitarra1_J2.Checked)
            {
                this.npcGuitarra1_p2 = new NPC_Guitarra(1, "NPC_GUITARRA1_2", "", 1000, 1, 1, 100, 100, 100, 100);

                this.npcGuitarra1_p2 += listaCartas_Guitarra[this.cmbSlot1_Guitarra1_J2.SelectedIndex];
                this.npcGuitarra1_p2 += listaCartas_Guitarra[this.cmbSlot2_Guitarra1_J2.SelectedIndex];
                this.npcGuitarra1_p2 += listaCartas_Guitarra[this.cmbSlot3_Guitarra1_J2.SelectedIndex];
                this.p2 += this.npcGuitarra1_p2;

                this.af_guitarra1_J2.Text = "AF:  " + this.npcGuitarra1_p2.AtaqueFisico.ToString();
                this.am_guitarra1_J2.Text = "AM: "   + this.npcGuitarra1_p2.AtaqueMagico.ToString();
                this.df_guitarra1_J2.Text = "DF:  "  + this.npcGuitarra1_p2.DefensaFisica.ToString();
                this.dm_guitarra1_J2.Text = "DM: "   + this.npcGuitarra1_p2.DefensaMagica.ToString();
                this.vida_guitarra1_J2.Text = this.npcGuitarra1_p2.Vida.ToString();
            }
            else
            {
                this.groupBoxGuitarra1_2.Visible = false;
            }
            #endregion

            #region PLAYER 2 - NPC GUITARRA 2
            if (this.checkGuitarra2_J2.Checked)
            {
                this.npcGuitarra2_p2 = new NPC_Guitarra(1, "NPC_GUITARRA2_2", "", 1000, 1, 1, 100, 100, 100, 100);

                this.npcGuitarra2_p2 += listaCartas_Guitarra[this.cmbSlot1_Guitarra2_J2.SelectedIndex];
                this.npcGuitarra2_p2 += listaCartas_Guitarra[this.cmbSlot2_Guitarra2_J2.SelectedIndex];
                this.npcGuitarra2_p2 += listaCartas_Guitarra[this.cmbSlot3_Guitarra2_J2.SelectedIndex];
                this.p2 += this.npcGuitarra2_p2;

                this.af_guitarra2_J2.Text = "AF:  " + this.npcGuitarra2_p2.AtaqueFisico.ToString();
                this.am_guitarra2_J2.Text = "AM: "   + this.npcGuitarra2_p2.AtaqueMagico.ToString();
                this.df_guitarra2_J2.Text = "DF:  "  + this.npcGuitarra2_p2.DefensaFisica.ToString();
                this.dm_guitarra2_J2.Text = "DM: "   + this.npcGuitarra2_p2.DefensaMagica.ToString();
                this.vida_guitarra2_J2.Text = this.npcGuitarra2_p2.Vida.ToString();
            }
            else
            {
                this.groupBoxGuitarra2_2.Visible = false;
            }
            #endregion

            #region PLAYER 2 - NPC BAJO
            if (this.checkBajo_J2.Checked)
            {
                this.npcBajo_p2 = new NPC_Bajo(1, "NPC_BAJO_2", "", 1000, 1, 1, 100, 100, 100, 100);

                this.npcBajo_p2 += listaCartas_Bajo[this.cmbSlot1_Bajo_J2.SelectedIndex];
                this.npcBajo_p2 += listaCartas_Bajo[this.cmbSlot2_Bajo_J2.SelectedIndex];
                this.npcBajo_p2 += listaCartas_Bajo[this.cmbSlot3_Bajo_J2.SelectedIndex];
                this.p2 += this.npcBajo_p2;

                this.af_bajo_J2.Text = "AF:  "  + this.npcBajo_p2.AtaqueFisico.ToString();
                this.am_bajo_J2.Text = "AM: "   + this.npcBajo_p2.AtaqueMagico.ToString();
                this.df_bajo_J2.Text = "DF:  "  + this.npcBajo_p2.DefensaFisica.ToString();
                this.dm_bajo_J2.Text = "DM: "   + this.npcBajo_p2.DefensaMagica.ToString();
                this.vida_bajo_J2.Text = this.npcBajo_p2.Vida.ToString();
            }
            else
            {
                this.groupBoxBajo_2.Visible = false;
            }
            #endregion

            #region PLAYER 2 - NPC BATERIA
            if (this.checkBateria_J2.Checked)
            {
                this.npcBateria_p2 = new NPC_Bateria(1, "NPC_BATERIA_2", "", 1000, 1, 1, 100, 100, 100, 100);

                this.npcBateria_p2 += listaCartas_Bateria[this.cmbSlot1_Bateria_J2.SelectedIndex];
                this.npcBateria_p2 += listaCartas_Bateria[this.cmbSlot2_Bateria_J2.SelectedIndex];
                this.npcBateria_p2 += listaCartas_Bateria[this.cmbSlot3_Bateria_J2.SelectedIndex];
                this.p2 += this.npcBateria_p2;

                this.af_bateria_J2.Text = "AF:  "   + this.npcBateria_p2.AtaqueFisico.ToString();
                this.am_bateria_J2.Text = "AM: "    + this.npcBateria_p2.AtaqueMagico.ToString();
                this.df_bateria_J2.Text = "DF:  "   + this.npcBateria_p2.DefensaFisica.ToString();
                this.dm_bateria_J2.Text = "DM: "    + this.npcBateria_p2.DefensaMagica.ToString();
                this.vida_bateria_J2.Text = this.npcBateria_p2.Vida.ToString();
            }
            else
            {
                this.groupBoxBateria_2.Visible = false;
            }
            #endregion

            #region PLAYER 2 - NPC VOZ
            if (this.checkVoz_J2.Checked)
            {
                this.npcVoz_p2 = new NPC_Voz(1, "NPC_VOZ_2", "", 1000, 1, 1, 1000, 100, 100, 100);

                this.npcVoz_p2 += listaCartas_Voz[this.cmbSlot1_Voz_J2.SelectedIndex];
                this.npcVoz_p2 += listaCartas_Voz[this.cmbSlot2_Voz_J2.SelectedIndex];
                this.npcVoz_p2 += listaCartas_Voz[this.cmbSlot3_Voz_J2.SelectedIndex];
                this.p2 += this.npcVoz_p2;

                this.af_voz_J2.Text = "AF:  "   + this.npcVoz_p2.AtaqueFisico.ToString();
                this.am_voz_J2.Text = "AM: "    + this.npcVoz_p2.AtaqueMagico.ToString();
                this.df_voz_J2.Text = "DF:  "   + this.npcVoz_p2.DefensaFisica.ToString();
                this.dm_voz_J2.Text = "DM: "    + this.npcVoz_p2.DefensaMagica.ToString();
                this.vida_voz_J2.Text = this.npcVoz_p2.Vida.ToString();
            }
            else
            {
                this.groupBoxVoz_2.Visible = false;
            }
            #endregion

        }

        private void siguienteTurno_Click(object sender, EventArgs e)
        {
            string s = "";
            Combate.Player_vs_Player(this.p1, this.p2, out s);

            if (!this.p2.ExisteNPC_Guitarra1)
            {
                this.groupBoxGuitarra1_2.Visible = false;
            }

            if (!this.p2.ExisteNPC_Guitarra2)
            {
                this.groupBoxGuitarra2_2.Visible = false;
            }

            if (!this.p2.ExisteNPC_Bajo)
            {
                this.groupBoxBajo_2.Visible = false;
            }

            if (!this.p2.ExisteNPC_Bateria)
            {
                this.groupBoxBateria_2.Visible = false;
            }

            if (!this.p2.ExisteNPC_Voz)
            {
                this.groupBoxVoz_2.Visible = false;
            }

            this.RefrescarForm();

            this.listBox.Items.Add(s);
        }

        public void RefrescarForm()
        {
            #region REFRESCAR PS - DF - DM DE PLAYER1 Y PLAYER2
            this.puntosDeVida1.Text = "PV: " + p1.Vida.ToString();
            this.puntosDeVida2.Text = "PV: " + p2.Vida.ToString();

            this.defensaFisica1.Text = "DF: " + p1.DefensaFisica.ToString();
            this.defensaFisica2.Text = "DF: " + p2.DefensaFisica.ToString();

            this.defensaMagica1.Text = "DM: " + p1.DefensaMagica.ToString();
            this.defensaMagica2.Text = "DM: " + p2.DefensaMagica.ToString();
            #endregion

            #region PLAYER1 - GUITARRA 1
            if (this.p1.ExisteNPC_Guitarra1 == true)
            {
                this.af_guitarra1_J1.Text = "AF:  " + this.npcGuitarra1_p1.AtaqueFisico.ToString();
                this.am_guitarra1_J1.Text = "AM: " + this.npcGuitarra1_p1.AtaqueMagico.ToString();
                this.df_guitarra1_J1.Text = "DF:  " + this.npcGuitarra1_p1.DefensaFisica.ToString();
                this.dm_guitarra1_J1.Text = "DM: " + this.npcGuitarra1_p1.DefensaMagica.ToString();
                this.vida_guitarra1_J1.Text = this.npcGuitarra1_p1.Vida.ToString();
            }
            #endregion

            #region PLAYER1 - GUITARRA 2 
            if (p1.ExisteNPC_Guitarra2)
            {
                this.af_guitarra2_J1.Text = "AF:  " + this.npcGuitarra2_p1.AtaqueFisico.ToString();
                this.am_guitarra2_J1.Text = "AM: " + this.npcGuitarra2_p1.AtaqueMagico.ToString();
                this.df_guitarra2_J1.Text = "DF:  " + this.npcGuitarra2_p1.DefensaFisica.ToString();
                this.dm_guitarra2_J1.Text = "DM: " + this.npcGuitarra2_p1.DefensaMagica.ToString();
                this.vida_guitarra2_J1.Text = this.npcGuitarra2_p1.Vida.ToString();
            }
            #endregion

            #region PLAYER1 - BAJO
            if (this.p1.ExisteNPC_Bajo)
            {
                this.af_bajo_J1.Text = "AF:  " + this.npcBajo_p1.AtaqueFisico.ToString();
                this.am_bajo_J1.Text = "AM: " + this.npcBajo_p1.AtaqueMagico.ToString();
                this.df_bajo_J1.Text = "DF:  " + this.npcBajo_p1.DefensaFisica.ToString();
                this.dm_bajo_J1.Text = "DM: " + this.npcBajo_p1.DefensaMagica.ToString();
                this.vida_bajo_J1.Text = this.npcBajo_p1.Vida.ToString();
            }
            #endregion

            #region PLAYER 1 - BATERIA
            if (this.p1.ExisteNPC_Bateria)
            {
                this.af_bateria_J1.Text = "AF:  " + this.npcBateria_p1.AtaqueFisico.ToString();
                this.am_bateria_J1.Text = "AM: " + this.npcBateria_p1.AtaqueMagico.ToString();
                this.df_bateria_J1.Text = "DF:  " + this.npcBateria_p1.DefensaFisica.ToString();
                this.dm_bateria_J1.Text = "DM: " + this.npcBateria_p1.DefensaMagica.ToString();
                this.vida_bateria_J1.Text = this.npcBateria_p1.Vida.ToString();
            }
            #endregion

            #region PLAYER 1 - VOZ
            if (this.p1.ExisteNPC_Voz)
            {
                this.af_voz_J1.Text = "AF:  " + this.npcVoz_p1.AtaqueFisico.ToString();
                this.am_voz_J1.Text = "AM: " + this.npcVoz_p1.AtaqueMagico.ToString();
                this.df_voz_J1.Text = "DF:  " + this.npcVoz_p1.DefensaFisica.ToString();
                this.dm_voz_J1.Text = "DM: " + this.npcVoz_p1.DefensaMagica.ToString();
                this.vida_voz_J1.Text = this.npcVoz_p1.Vida.ToString();
            }
            #endregion

            #region PLAYER 2 - GUITARRA 1
            if (this.p2.ExisteNPC_Guitarra1)
            {
                this.af_guitarra1_J2.Text = "AF:  " + this.npcGuitarra1_p2.AtaqueFisico.ToString();
                this.am_guitarra1_J2.Text = "AM: " + this.npcGuitarra1_p2.AtaqueMagico.ToString();
                this.df_guitarra1_J2.Text = "DF:  " + this.npcGuitarra1_p2.DefensaFisica.ToString();
                this.dm_guitarra1_J2.Text = "DM: " + this.npcGuitarra1_p2.DefensaMagica.ToString();
                this.vida_guitarra1_J2.Text = this.npcGuitarra1_p2.Vida.ToString();
            }
            #endregion

            #region PLAYER 2 - GUITARRA 2
            if (this.p2.ExisteNPC_Guitarra2)
            {
                this.af_guitarra2_J2.Text = "AF:  " + this.npcGuitarra2_p2.AtaqueFisico.ToString();
                this.am_guitarra2_J2.Text = "AM: " + this.npcGuitarra2_p2.AtaqueMagico.ToString();
                this.df_guitarra2_J2.Text = "DF:  " + this.npcGuitarra2_p2.DefensaFisica.ToString();
                this.dm_guitarra2_J2.Text = "DM: " + this.npcGuitarra2_p2.DefensaMagica.ToString();
                this.vida_guitarra2_J2.Text = this.npcGuitarra2_p2.Vida.ToString();
            }
            #endregion

            #region PLAYER 2 - BAJO
            if (this.p2.ExisteNPC_Bajo)
            {
                this.af_bajo_J2.Text = "AF:  " + this.npcBajo_p2.AtaqueFisico.ToString();
                this.am_bajo_J2.Text = "AM: " + this.npcBajo_p2.AtaqueMagico.ToString();
                this.df_bajo_J2.Text = "DF:  " + this.npcBajo_p2.DefensaFisica.ToString();
                this.dm_bajo_J2.Text = "DM: " + this.npcBajo_p2.DefensaMagica.ToString();
                this.vida_bajo_J2.Text = this.npcBajo_p2.Vida.ToString();
            }
            #endregion

            #region PLAYER 2 - BATERIA
            if (p2.ExisteNPC_Bateria)
            {
                this.af_bateria_J2.Text = "AF:  " + this.npcBateria_p2.AtaqueFisico.ToString();
                this.am_bateria_J2.Text = "AM: " + this.npcBateria_p2.AtaqueMagico.ToString();
                this.df_bateria_J2.Text = "DF:  " + this.npcBateria_p2.DefensaFisica.ToString();
                this.dm_bateria_J2.Text = "DM: " + this.npcBateria_p2.DefensaMagica.ToString();
                this.vida_bateria_J2.Text = this.npcBateria_p2.Vida.ToString();
            }
            #endregion

            #region PLAYER 2 - VOZ
            if (this.p2.ExisteNPC_Voz)
            {
                this.af_voz_J2.Text = "AF:  " + this.npcVoz_p2.AtaqueFisico.ToString();
                this.am_voz_J2.Text = "AM: " + this.npcVoz_p2.AtaqueMagico.ToString();
                this.df_voz_J2.Text = "DF:  " + this.npcVoz_p2.DefensaFisica.ToString();
                this.dm_voz_J2.Text = "DM: " + this.npcVoz_p2.DefensaMagica.ToString();
                this.vida_voz_J2.Text = this.npcVoz_p2.Vida.ToString();
            }
            #endregion
        }
    }
}
