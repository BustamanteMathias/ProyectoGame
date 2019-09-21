using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoGame;

namespace ProyectoGame
{
    public class DBNpc
    {
        private List<NPC> DB_NPC = new List<NPC>();

        private List<NPC_Guitarra>  DB_NPC_Guitarristas      = new List<NPC_Guitarra>();
        private List<NPC_Bajo>      DB_NPC_Bajistas          = new List<NPC_Bajo>();
        private List<NPC_Bateria>   DB_NPC_Bateristas        = new List<NPC_Bateria>();
        private List<NPC_Voz>       DB_NPC_Voz               = new List<NPC_Voz>();

        public DBNpc()
        {
            this.InstanciarGuitarristas (DB_NPC_Guitarristas);
            this.InstanciarBajistas     (DB_NPC_Bajistas);
            this.InstanciarBateristas   (DB_NPC_Bateristas);
            this.InstanciarVoz          (DB_NPC_Voz);

            foreach (NPC item in DB_NPC_Guitarristas)
            {
                this.DB_NPC.Add(item);
            }
            foreach (NPC item in DB_NPC_Bajistas)
            {
                this.DB_NPC.Add(item);
            }
            foreach (NPC item in DB_NPC_Bateristas)
            {
                this.DB_NPC.Add(item);
            }
            foreach (NPC item in DB_NPC_Voz)
            {
                this.DB_NPC.Add(item);
            }
        }

        #region PROPIEDADES SOLO DE LECTURA QUE RETORNA LAS LISTAS DE NPC'S
        public List<NPC> GetNPC_ALL
        {
            get { return this.DB_NPC; }
        }
        public List<NPC_Guitarra> GetNPC_Guitarristas
        {
            get { return this.DB_NPC_Guitarristas; }
        }
        public List<NPC_Bajo> GetNPC_Bajistas
        {
            get { return this.DB_NPC_Bajistas; }
        }
        public List<NPC_Bateria> GetNPC_Bateristas
        {
            get { return this.DB_NPC_Bateristas; }
        }
        public List<NPC_Voz> GetNPC_Voz
        {
            get { return this.DB_NPC_Voz; }
        }

        #endregion

        #region BASE DE DATOS
        private void InstanciarGuitarristas (List<NPC_Guitarra> listaGuitarristas)
        {
            string DESCRIPCION_1000 = "NONE";

            #region BASE DE DATOS DE GUITARRISTAS
            //ID'S 1000 - 1999
            //                                          ID      NOMBRE      DESCRIPCION         VIDA    NIVEL   EXPERIENCIA     AF      AM      DF      DM

            listaGuitarristas.Add(new NPC_Guitarra(     1000,   "Nombre1",  DESCRIPCION_1000,   1000,   1,      0,              10,     10,     10,     10)); 

            #endregion
        }
        private void InstanciarBajistas(List<NPC_Bajo> listaBajistas)
        {
            string DESCRIPCION_1000 = "NONE";

            #region BASE DE DATOS DE BAJISTAS
            //ID'S 2000 - 2999
            //                                          ID      NOMBRE      DESCRIPCION         VIDA    NIVEL   EXPERIENCIA     AF      AM      DF      DM

            listaBajistas.Add(new NPC_Bajo(             2000,   "Nombre1",  DESCRIPCION_1000,   1000,   1,      0,              10,     10,     10,     10));

            #endregion
        }
        private void InstanciarBateristas(List<NPC_Bateria> listaBateristas)
        {
            string DESCRIPCION_1000 = "NONE";

            #region BASE DE DATOS DE BATERISTAS
            //ID'S 3000 - 3999
            //                                          ID      NOMBRE      DESCRIPCION         VIDA    NIVEL   EXPERIENCIA     AF      AM      DF      DM

            listaBateristas.Add(new NPC_Bateria(        3000,   "Nombre1",  DESCRIPCION_1000,   1000,   1,      0,              10,     10,     10,     10));

            #endregion
        }
        private void InstanciarVoz(List<NPC_Voz> listaVoz)
        {
            string DESCRIPCION_1000 = "NONE";

            #region BASE DE DATOS DE VOZ
            //ID'S 4000 - 4999
            //                                          ID      NOMBRE      DESCRIPCION         VIDA    NIVEL   EXPERIENCIA     AF      AM      DF      DM

            listaVoz.Add(new NPC_Voz(                   4000,   "Nombre1",  DESCRIPCION_1000,   1000,   1,      0,              10,     10,     10,     10));

            #endregion
        }
        #endregion

        public void Mostrar()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\tBASE DE DATOS NPC\n\n");

            foreach (NPC item in this.DB_NPC)
            {
                if(item is NPC_Guitarra)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(item.MostrarInfoNPC());
                }
                else if(item is NPC_Bajo)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(item.MostrarInfoNPC());
                }
                else if(item is NPC_Bateria)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(item.MostrarInfoNPC());
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(item.MostrarInfoNPC());
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
